using System.Collections.Generic;
using System.Threading.Tasks;
using MovieManager.Shared.Collections;
using MovieManager.Shared.Models;

namespace MovieManager.Server.Interfaces
{
	public interface IMovieViewListService
	{
		Task<List<MovieView>> Get();
		Task<PaginatedList<MovieView>> GetList(int? pageNumber, string sortField, string sortOrder, int pageSize = 5);
		Task<MovieView> Get(int id);
		Task<MovieView> Add(MovieView movieView);
		Task<MovieView> Update(MovieView movieView);
		Task<MovieView> Delete(int id);
		Task<List<string>> GetFolders(string root);

	}
}
