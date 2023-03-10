using System;
using System.Text;
using IdentityModel.Client;
using Microsoft.CodeAnalysis.Elfie.Serialization;
using Movie.Client.Models;
using Newtonsoft.Json;

namespace Movie.Client.ApiServices
{
	public class MovieApiService : IMovieApiService
    {
        private readonly HttpClient _httpClient;
        public MovieApiService(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient("MovieAPIClient");
        }

        public async Task<Movies?> CreateMovie(Movies movies)
        {

            var request = new HttpRequestMessage(HttpMethod.Post, "api/movie/");

            request.Content = new StringContent(JsonConvert.SerializeObject(movies), Encoding.UTF8, "application/json");

            var response = await _httpClient.SendAsync(request, HttpCompletionOption.ResponseHeadersRead)
                .ConfigureAwait(false);

            var content = await response.Content.ReadAsStringAsync();
            var movie = JsonConvert.DeserializeObject<Movies>(content);
            return movie;
        }

        public Task DeleteMovie(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<Movies?> GetMovie(int id)
        {
            

            var request = new HttpRequestMessage(HttpMethod.Get, $"api/movie/{id}");

            var response = await _httpClient.SendAsync(request, HttpCompletionOption.ResponseHeadersRead)
                .ConfigureAwait(false);
            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadAsStringAsync();
            var movie = JsonConvert.DeserializeObject<Movies>(content);
            return movie;
        }

        public async Task<IEnumerable<Movies>?> GetMovies()
        {

            
            var request = new HttpRequestMessage(HttpMethod.Get, "api/movie/");
            
            var response = await _httpClient.SendAsync(request, HttpCompletionOption.ResponseHeadersRead)
                .ConfigureAwait(false);

            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadAsStringAsync();
            var moviesList = JsonConvert.DeserializeObject<List<Movies>>(content);
            return moviesList;
        }

        public Task<Movies> UpdateMovie(Movies movies)
        {
            throw new NotImplementedException();
        }
    }
}

