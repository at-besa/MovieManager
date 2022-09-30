using Microsoft.EntityFrameworkCore;
using MovieManager.Server.Extensions;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using MovieManager.Server.Data;
using MovieManager.Server.Interfaces;
using MovieManager.Shared.Collections;
using MovieManager.Shared.Models;

namespace MovieManager.Server.Services
{
	public class MovieViewListService : IMovieViewListService
	{
		private readonly VideoContext context;

		public MovieViewListService(VideoContext context)
		{
			this.context = context;
		}
		public async Task<List<MovieView>> Get()
		{
			return await context.MovieView.ToListAsync();
		}

		public async Task<PaginatedList<MovieView>> GetList(int? pageNumber, string sortField, string sortOrder, int pageSize = 5)
		{
			var movieView = context.MovieView.OrderByDynamic(sortField, sortOrder.ToUpper());
			return await PaginatedList<MovieView>.CreateAsync(movieView.AsNoTracking(), pageNumber ?? 1, pageSize);
		}

		public async Task<MovieView> Get(int id)
		{
			var movieView = await context.MovieView.FindAsync(id);
			return movieView;
		}

		public async Task<MovieView> Add(MovieView movieView)
		{
			await context.MovieView.AddAsync(movieView);
			await context.SaveChangesAsync();
			return movieView;
		}

		public async Task<MovieView> Update(MovieView movieView)
		{
			context.Entry(movieView).State = EntityState.Modified;
			await context.SaveChangesAsync();
			return movieView;
		}

		public async Task<MovieView> Delete(int id)
		{
			var movieView = await context.MovieView.FindAsync(id);
			context.MovieView.Remove(movieView);
			await context.SaveChangesAsync();
			return movieView;
		}


		public async Task<List<string>> GetFolders(string root)
		{
			return await Task.Run(async () =>
			{
				var folders = new List<string>();
				var dirs = Directory.GetDirectories(root).ToList();
				return dirs;
			});
		}



	}
}
