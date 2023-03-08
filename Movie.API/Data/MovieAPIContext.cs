using System;
using Microsoft.EntityFrameworkCore;
using Movie.API.Model;

namespace Movie.API.Data
{
	public class MovieAPIContext : DbContext
	{
		public MovieAPIContext(DbContextOptions<MovieAPIContext> options) :base(options)
		{
		}


		public DbSet<Movies> Movies { get; set; }
	}
}

