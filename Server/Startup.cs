using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MovieManager.Server.Data;
using MovieManager.Server.Dependency;
using MovieManager.Shared.Models;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json.Converters;

namespace MovieManager.Server
{
	public class Startup
	{
		public Startup(IConfiguration configuration)
		{
			Configuration = configuration;
			ConfigurationUtil.SetConfiguration(configuration);
		}

		public IConfiguration Configuration { get; }
		private readonly string allowAnyOriginsHeaderAndMethods = "allowAnyOrigin";


		// This method gets called by the runtime. Use this method to add services to the container.
		// For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
		public void ConfigureServices(IServiceCollection services)
		{
            services.InjectDependencies();
			
			services.AddDatabaseDeveloperPageExceptionFilter();

			services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = true)
				.AddEntityFrameworkStores<ApplicationDbContext>();

			services.AddIdentityServer()
				.AddApiAuthorization<ApplicationUser, ApplicationDbContext>();

			services.AddAuthentication()
				.AddIdentityServerJwt();

			services.AddCors(options =>
			{
				options.AddPolicy(allowAnyOriginsHeaderAndMethods,
					builder => { builder.AllowAnyMethod().AllowAnyHeader().AllowAnyOrigin(); });
			});

			services.AddControllers()
	            .AddNewtonsoftJson(options =>
		            options.SerializerSettings.Converters.Add(new StringEnumConverter()));

            services.AddRouting(options => options.LowercaseUrls = true);

			services.AddSwaggerGen(c =>
            {
	            var assmebly = GetType().Assembly;

	            c.AddSecurityDefinition("basic", new OpenApiSecurityScheme
	            {
		            In = ParameterLocation.Header,
		            Name = "http basic auth",
		            Scheme = "basic",
		            Type = SecuritySchemeType.Http
	            });

	            c.AddSecurityRequirement(new OpenApiSecurityRequirement
	            {
		            {
			            new OpenApiSecurityScheme
			            {
				            Reference = new OpenApiReference
				            {
					            Type = ReferenceType.SecurityScheme,
					            Id = "basic"
				            }
			            },
			            System.Array.Empty<string>()
		            }
	            });

	
            });
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
				app.UseSwagger();
				app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Moviemanager v1"));
				app.UseMigrationsEndPoint();
			}
			else
			{
				app.UseExceptionHandler("/Error");
				// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
				app.UseHsts();
			}

			app.UseHttpsRedirection();


			app.UseRouting();
			app.UseCors(allowAnyOriginsHeaderAndMethods);

			app.UseIdentityServer();
			app.UseAuthentication();
			app.UseAuthorization();

			app.UseStaticFiles();

			app.UseEndpoints(endpoints =>
			{
				endpoints.MapControllers();
			});
		}
	}
}
