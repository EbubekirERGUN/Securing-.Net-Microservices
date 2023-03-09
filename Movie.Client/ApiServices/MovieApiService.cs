using System;
using Movie.Client.Models;

namespace Movie.Client.ApiServices
{
	public class MovieApiService : IMovieApiService
	{
		public MovieApiService()
		{
		}

        public Task<Movies> CreateMovie()
        {
            throw new NotImplementedException();
        }

        public Task DeleteMovie()
        {
            throw new NotImplementedException();
        }

        public Task<Movies> GetMovie()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Movies>> GetMovies()
        {
            throw new NotImplementedException();
        }

        public Task<Movies> UpdateMovie()
        {
            throw new NotImplementedException();
        }
    }
}

