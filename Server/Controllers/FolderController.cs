using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MovieManager.Server.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieManager.Server.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class FolderController : Controller
	{
		private readonly ILogger<FolderController> logger;
		private readonly IMovieViewListService mvService;
		private readonly IRenamingService renamingService;

		public FolderController(ILogger<FolderController> logger , IMovieViewListService mvService, IRenamingService renamingService)
		{
			this.logger = logger;
			this.mvService = mvService;
            this.renamingService = renamingService;
        }
		
		[HttpGet]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		public async Task<ActionResult<List<string>>> Get(string root)
		{
			var list = await mvService.GetFolders(root);
			if(!list.Any())
				return NotFound(new ProblemDetails()
				{
					Title = "No Movie found",
					Detail = "There is no entry!",
					Status = 404,
					Type = "https://http.cat/404"
				});

			return Ok(list);
		}


	}
}
