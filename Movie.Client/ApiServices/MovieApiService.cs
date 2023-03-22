using System;
using System.Text;
using IdentityModel.Client;
using Microsoft.AspNetCore.Authentication;
using Microsoft.CodeAnalysis.Elfie.Serialization;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using Movie.Client.Models;
using Newtonsoft.Json;

namespace Movie.Client.ApiServices
{
    public class MovieApiService : IMovieApiService
    {
        private readonly IHttpClientFactory _httpClientFactory;

        private readonly IHttpContextAccessor _httpContextAccessor;
        public MovieApiService(IHttpClientFactory httpClientFactory, IHttpContextAccessor httpContextAccessor)
        {
            _httpClientFactory = httpClientFactory;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<Movies> CreateMovie(Movies movies)
        {

            var httpClient = _httpClientFactory.CreateClient("MovieAPIClient");

            var request = new HttpRequestMessage(HttpMethod.Post, "/movie/CreateMovie")
            {
                Content = new StringContent(JsonConvert.SerializeObject(movies), Encoding.UTF8, "application/json")
            };

            var response = await httpClient.SendAsync(request, HttpCompletionOption.ResponseHeadersRead)
                .ConfigureAwait(false);

            var content = await response.Content.ReadAsStringAsync();
            var movie = JsonConvert.DeserializeObject<Movies>(content);
            return movie;
        }

        public Task DeleteMovie(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<Movies> GetMovie(int id)
        {
            var httpClient = _httpClientFactory.CreateClient("MovieAPIClient");


            var request = new HttpRequestMessage(HttpMethod.Get, $"/movie/{id}");

            var response = await httpClient.SendAsync(request, HttpCompletionOption.ResponseHeadersRead)
                .ConfigureAwait(false);
            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadAsStringAsync();
            var movie = JsonConvert.DeserializeObject<Movies>(content);
            return movie;
        }

        public async Task<IEnumerable<Movies>> GetMovies()
        {
            var httpClient = _httpClientFactory.CreateClient("MovieAPIClient");


            var request = new HttpRequestMessage(HttpMethod.Get, $"/movie/All");

            var response = await httpClient.SendAsync(request, HttpCompletionOption.ResponseHeadersRead)
                .ConfigureAwait(false);

            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadAsStringAsync();
            var moviesList = JsonConvert.DeserializeObject<List<Movies>>(content);
            return moviesList;
        }

        public async Task<UserInfoViewModel> GetUserInfo()
        {

            var httpClient = _httpClientFactory.CreateClient("IDPClient");

            var metaDataResponse = await httpClient.GetDiscoveryDocumentAsync();

            if (metaDataResponse.IsError)
            {
                throw new HttpRequestException("Something went wrong while requesting the acces token");
            }

            var accesToken = await _httpContextAccessor.HttpContext.GetTokenAsync(OpenIdConnectParameterNames.AccessToken);


            var userInfoResponse = await httpClient.GetUserInfoAsync(
                new UserInfoRequest
                {
                    Address = metaDataResponse.UserInfoEndpoint,
                    Token = accesToken
                });

            if (userInfoResponse.IsError)
            {
                throw new HttpRequestException("Something went wrong while requesting the acces token");
            }

            var userInfoDictionary = new Dictionary<string, string>();

            foreach (var claim in userInfoResponse.Claims)
            {
                userInfoDictionary.Add(claim.Type, claim.Value);
            }

            return new UserInfoViewModel(userInfoDictionary);
        }

        public Task<Movies> UpdateMovie(Movies movies)
        {
            throw new NotImplementedException();
        }
    }
}

