using System;
using Movie.Client.Models;

namespace Movie.Client.ApiServices
{
	public interface IMovieApiService
	{
		Task<IEnumerable<Movies>?> GetMovies();
		Task<Movies?> GetMovie(int id);
		Task<Movies?> CreateMovie(Movies movies);
		Task<Movies> UpdateMovie(Movies movies);
		Task DeleteMovie(int id);
	}
}

