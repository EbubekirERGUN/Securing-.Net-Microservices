using System;
using Movie.Client.Models;

namespace Movie.Client.ApiServices
{
	public interface IMovieApiService
	{
		Task<IEnumerable<Movies>> GetMovies();
		Task<Movies> GetMovie();
		Task<Movies> CreateMovie();
		Task<Movies> UpdateMovie();
		Task DeleteMovie();
	}
}

