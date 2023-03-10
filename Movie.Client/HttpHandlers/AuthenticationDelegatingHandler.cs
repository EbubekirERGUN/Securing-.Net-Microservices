using IdentityModel.Client;
using Microsoft.AspNetCore.Authentication;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;

namespace Movie.Client.HttpHandlers;

public class AuthenticationDelegatingHandler : DelegatingHandler
{
    // private readonly IHttpClientFactory _httpClientFactory;
    // private readonly ClientCredentialsTokenRequest _tokenRequest;
    //
    // public AuthenticationDelegatingHandler(IHttpClientFactory httpClientFactory, ClientCredentialsTokenRequest tokenRequest)
    // {
    //     _httpClientFactory = httpClientFactory;
    //     _tokenRequest = tokenRequest;
    // }

    private readonly IHttpContextAccessor _httpContextAccessor;

    public AuthenticationDelegatingHandler(IHttpContextAccessor httpContextAccessor)
    {
        _httpContextAccessor = httpContextAccessor;
    }

    protected  override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
    {
        // var httpClient = _httpClientFactory.CreateClient("IDPClient");
        //
        // var tokenResponse = await httpClient.RequestClientCredentialsTokenAsync(_tokenRequest);
        // if (tokenResponse.IsError)
        // {
        //     throw new HttpRequestException("Access Token Error");
        // }
        //
        // if (tokenResponse.AccessToken != null) request.SetBearerToken(tokenResponse.AccessToken);

        var accesToken = await _httpContextAccessor.HttpContext.GetTokenAsync(OpenIdConnectParameterNames.AccessToken);

        if (!string.IsNullOrWhiteSpace(accesToken))
        {
            request.SetBearerToken(accesToken);
        }

        return await base.SendAsync(request, cancellationToken);
    }
}