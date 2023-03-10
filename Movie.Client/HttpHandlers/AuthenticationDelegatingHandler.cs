using IdentityModel.Client;

namespace Movie.Client.HttpHandlers;

public class AuthenticationDelegatingHandler : DelegatingHandler
{
    private readonly IHttpClientFactory _httpClientFactory;
    private readonly ClientCredentialsTokenRequest _tokenRequest;

    public AuthenticationDelegatingHandler(IHttpClientFactory httpClientFactory, ClientCredentialsTokenRequest tokenRequest)
    {
        _httpClientFactory = httpClientFactory;
        _tokenRequest = tokenRequest;
    }

    protected  override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
    {
        var httpClient = _httpClientFactory.CreateClient("IDPClient");

        var tokenResponse = await httpClient.RequestClientCredentialsTokenAsync(_tokenRequest);
        if (tokenResponse.IsError)
        {
            throw new HttpRequestException("Access Token Error");
        }
        
        if (tokenResponse.AccessToken != null) request.SetBearerToken(tokenResponse.AccessToken);

        
        
        return await base.SendAsync(request, cancellationToken);
    }
}