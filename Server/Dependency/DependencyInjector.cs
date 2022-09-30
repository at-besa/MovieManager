using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MovieManager.Server.Data;
using MovieManager.Server.Interfaces;
using MovieManager.Server.Services;

namespace MovieManager.Server.Dependency
{
	
	public static class DependencyInjector
	{

		public static void InjectDependencies(this IServiceCollection services)
		{
			var config = ConfigurationUtil.GetConfiguration();
			var constringAuth = $"{config["DB_AUTH"]};uid={config["DB_USER"]};password={config["DB_PASS"]}"; 
			var constringKodi = $"{config["DB_CONN"]};uid={config["DB_USER"]};password={config["DB_PASS"]}"; 

			services.AddDbContext<ApplicationDbContext>(options => options.UseMySql(constringAuth, new MariaDbServerVersion(new Version(10, 1, 9))));

			services.AddDbContext<VideoContext>(options => options.UseMySql(constringKodi, new MariaDbServerVersion(new Version(10,1,9))));


			//services.AddDbContext<VideoContext>();
			services.AddTransient<IMovieViewListService, MovieViewListService>();
			services.AddTransient<IRenamingService, RenamingService>();
		}

	}
}
