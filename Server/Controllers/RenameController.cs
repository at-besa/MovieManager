using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MovieManager.Server.Services;
using System.IO;
using MovieManager.Server.Interfaces;
using MovieManager.Shared.Models;

namespace MovieManager.Server.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class RenameController : Controller
	{
		private readonly ILogger<RenameController> logger;
		private readonly IRenamingService renamingService;

		public RenameController(ILogger<RenameController> logger , IRenamingService renamingService)
		{
			this.logger = logger;
            this.renamingService = renamingService;
        }
		
		[HttpGet]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		public async Task<ActionResult<string>> Rename(string path)
		{
			if (!Directory.Exists(path))
				return BadRequest();

			var result = await renamingService.RenameFoldersInDirectory(path, false);
			

			return Ok(result);
		}

		[HttpGet("previewconsole")]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		public async Task<ActionResult<string>> RenamePreview(string path)
		{
			if (!Directory.Exists(path))
				return BadRequest();

			var result = await renamingService.RenameFoldersInDirectory(path, true);


			return Ok(result);
		}

		[HttpGet("preview")]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		public async Task<ActionResult<List<MovieView>>> GetNamingPreview(int? pageNumber, string sortField, string sortOrder, string path, int pageSize = 5)
		{
			if (sortField == null || sortOrder == null)
				return BadRequest();
			
			var list = await renamingService.GetFolderPreviews(path);
	
			return Ok(list);
		}

	}
}
