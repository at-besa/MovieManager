using System.Collections.Generic;
using System.Threading.Tasks;
using MovieManager.Shared.Models;

namespace MovieManager.Server.Interfaces
{
	public interface IRenamingService
	{
		Task<string> RenameFoldersInDirectory(string pathToRename, bool preview);
		Task<List<MovieView>> GetFolderPreviews(string pathToRename);

	}
}
