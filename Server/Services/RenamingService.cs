using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using MovieManager.Server.CustomModels;
using MovieManager.Server.Data;
using MovieManager.Server.Interfaces;
using MovieManager.Shared.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//using Path = MovieManager.Shared.Models.Path;

namespace MovieManager.Server.Services
{
	public class RenamingService : IRenamingService
	{
		private readonly ILogger<RenamingService> logger;
		private readonly VideoContext context;
		public RenamingService(ILogger<RenamingService> logger, VideoContext context)
		{
			this.logger = logger;
			this.context = context;
		}

		public async Task<string> RenameFoldersInDirectory(string path, bool preview = false)
		{
			var universalPath = path.Replace("\\\\", "smb://").Replace("\\", "/");
			StringBuilder sb = new StringBuilder();
			return await Task.Run(async () =>
			{
				var detailMoviesinDirectory = await GetMovieInformation(universalPath);
				var renamecount = 0;
				foreach (var directory in Directory.EnumerateDirectories(path))
				{
					var foldernameWithoutPath = System.IO.Path.GetFileName(directory.TrimEnd(System.IO.Path.DirectorySeparatorChar));
					var detailmovie = detailMoviesinDirectory.FirstOrDefault(movie => movie.Path.Contains(foldernameWithoutPath));
					if (detailmovie == null)
					{
						logger.LogWarning($"Could not find movie {directory} in Kodi Database, skipping");
						continue;
					}
					if (!detailmovie.Details.Any())
					{
						logger.LogWarning($"Could not find details for movie {detailmovie.Title} in Kodi Database, skipping");
						continue;
					}


					var videoWidth = detailmovie.Details.SingleOrDefault(streamdetails => streamdetails.IStreamType == 0)?.IVideoWidth ?? 1920;
					var videoType = GetVideoType(videoWidth);
					var audios = detailmovie.Details.Where(streamdetails => streamdetails.IStreamType == 1).ToList();
					var audioStreams = GetAudioStreams(audios);
					var audioType = AudioType(audios);
					var ripType = RipType(directory, detailmovie.Filename, videoType); 
					var year = "0000";
					if (DateTime.TryParse(detailmovie.MovieDetails.Premiered, out var dateTime))
						year = dateTime.Year.ToString();
					else if (int.TryParse(detailmovie.MovieDetails.Premiered, out var date))
						year = date.ToString();
					else
					{
						logger.LogWarning($"Movie has missing information, not recognized {directory}");
					}
					var validTitle = ValidTitle(detailmovie.Title);
					var resultName = $"{validTitle} [{year}][{videoType}][{audioType}][{audioStreams}][{ripType}]";
					
					if (foldernameWithoutPath != resultName)
					{
						try
						{
							if (!preview)
								Directory.Move(directory, $"{path}{System.IO.Path.DirectorySeparatorChar}{resultName}");
							else
								Console.WriteLine($"{foldernameWithoutPath}  |  {resultName}");

							sb.AppendLine($"{foldernameWithoutPath};{resultName}");
							++renamecount;
						}
						catch (Exception e)
						{
							logger.LogError($"Cannot move Directoy {directory} : IO Message: {e.Message} ");

						}
					}
					else
					{
						logger.LogTrace($"{foldernameWithoutPath} is the same so dont rename it");
					}
				}

				return sb.ToString();
			});
		}

		private string ValidTitle(string detailmovieTitle)
		{
			var invalid = new string(System.IO.Path.GetInvalidFileNameChars()) + new string(System.IO.Path.GetInvalidPathChars());

			return invalid.Aggregate(detailmovieTitle, (current, c) => current.Replace(c.ToString(), ""));
		}

		private string RipType(string directory, string detailmovieFilename, string videoType)
		{
			var filepath = $"{directory}{System.IO.Path.DirectorySeparatorChar}{detailmovieFilename}";
			if (detailmovieFilename.Contains("stack:"))
				return "rip";
			var filesize = new FileInfo(filepath).Length;
			var sizeInGb = filesize / 1024 / 1024 / 1024;
			var extension = System.IO.Path.GetExtension(filepath);
			if (extension == "iso")
				return "bluray";
			if (videoType.Contains("4K") || videoType.Contains("5K"))
				sizeInGb /= 2;
			if (videoType.Contains("6K"))
				sizeInGb /= 3;
			if (videoType.Contains("8K"))
				sizeInGb /= 4;
			// go on a fixed value of 15 on every streamtype, when 4k this would be 30gb
			return sizeInGb switch
			{
				<= 15 => "rip",
				> 15 => "remux"
			};
		}

		private static string AudioType(List<Streamdetails> audios)
		{
			var codec = audios.FirstOrDefault()?.StrAudioCodec.ToUpper() ?? "AC3";
			return codec switch
			{
				"DCA" => "DTS",
				"DTSHD_MA" => "DTSHD",
				"DTSHD_HRA" => "DTSHD",
				_ => codec
			};
		}

		private static string GetAudioStreams(ICollection<Streamdetails> audios) => audios.Count switch
		{
			<= 1 => "SL",
			2 => "DL",
			> 2 => "ML"
		};

		private static string GetVideoType(int? videoWidth)
		{
			return videoWidth switch
			{
				null or < 1200 => "SD",
				>= 1200 and < 1900 => "720p",
				>= 1900 and < 2540 => "1080p",
				>= 2540 and < 3800 => "1440p",
				>= 3800 and < 5000 => "4K",
				>= 5000 and < 6000 => "5K",
				>= 6000 and < 7500 => "6K",
				>= 7500 => "8K"
			};
		}

		public Task<List<MovieView>> GetFolderPreviews(string pathInterface)
		{
			// TODO: dont override path
			string path = "D:\\Download\\Filme";

			var movies = new List<MovieView>();

			return Task.Run(() =>
			{
				//var test = GetMovieInformation(path);
				//foreach (var detailMovie in test)
				//{

				//	Console.WriteLine(detailMovie.Filename);
				//	foreach (var detailMovieDetail in detailMovie.Details)
				//	{
				//		Console.WriteLine($"video width: {detailMovieDetail.IVideoWidth} \n");
				//	}
				//}

				//foreach (var directory in Directory.EnumerateDirectories(path))
				//{
				//	string folderName;
				//	try
				//	{
				//		folderName = System.IO.Path.GetDirectoryName(directory);
				//		if (folderName == null)
				//			continue;
				//	}
				//	catch (PathTooLongException e)
				//	{
				//		Console.WriteLine(e.StackTrace);
				//		continue;
				//	}
				//	var movieInformation = GetMovieInformation(folderName);
				//	foreach (var streamdetail in movieInformation)
				//	{
				//		Console.WriteLine(streamdetail.Title);
				//	}
				//	movies.Add(new MovieView());

				//	//Directory.Move(directory, $"{path}{System.IO.Path.DirectorySeparatorChar}{folderName}");
				//}

				return movies;
			});
		}

		private async Task<List<DetailMovie>> GetMovieInformation(string directoryName)
		{
			var movies = await context.MovieView.Where(view => view.StrPath.Contains(directoryName.Replace('/','\\')) && view.UniqueidValue != null).ToListAsync();
			var details = await context.Streamdetails.ToListAsync();

			var result = (from b in movies
				join s in details on b.IdFile equals s.IdFile into grouping
				select new DetailMovie
				{
					Title = b.Title,
					Path = b.StrPath,
					Filename = b.StrFileName,
					MovieDetails = b,
					Details = grouping
				}).ToList();

			//var result= context.Set<MovieView>()
   //             .GroupJoin(
   //                 context.Set<Streamdetails>(), 
   //                 mv => mv.IdFile, 
   //                 sd => sd.IdFile,
   //                 (mv, streamdetails) => new DetailMovie
   //                 {
   //                     Title = mv.Title, 
   //                     Path = mv.StrPath, 
   //                     Filename = mv.StrFileName, 
   //                     Details = streamdetails
			//		})
   //             .ToList();
            
            return result;
        }
	}
}
