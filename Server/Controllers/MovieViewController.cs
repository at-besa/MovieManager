using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MovieManager.Server.Interfaces;
using MovieManager.Server.Services;
using MovieManager.Shared.Collections;
using MovieManager.Shared.Models;

namespace MovieManager.Server.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class MovieViewController : Controller
	{
		private readonly ILogger<MovieViewController> logger;
		private readonly IMovieViewListService mvService;

		public MovieViewController(ILogger<MovieViewController> logger , IMovieViewListService mvService)
		{
			this.logger = logger;
			this.mvService = mvService;
        }
		
		[HttpGet]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		public async Task<ActionResult<PaginatedList<MovieView>>> Get(int? pageNumber, string sortField, string sortOrder, int pageSize = 5)
		{
			if (sortField == null || sortOrder == null)
				return BadRequest(new ProblemDetails()
				{
					Title = "Invalid Request",
					Detail = "sortField or sortOrder null",
					Status = 400,
					Type = "https://http.cat/400"
				});


			var list = await mvService.GetList(pageNumber, sortField, sortOrder, pageSize);
			if(!list.Items.Any())
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
