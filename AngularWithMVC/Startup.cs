using System.IO;
using AngularWithMVC.App.Services;
using AngularWithMVC.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace AngularWithMVC
{
	public class Startup
	{
		public Startup(IHostingEnvironment env)
		{
			var builder = new ConfigurationBuilder()
				.SetBasePath(env.ContentRootPath)
				.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
				.AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
				.AddEnvironmentVariables();
			Configuration = builder.Build();
		}

		public IConfigurationRoot Configuration { get; }

		// This method gets called by the runtime. Use this method to add services to the container.
		public void ConfigureServices(IServiceCollection services)
		{
			services.AddTransient<BlogService>();

			services.AddDbContextPool<BlogContext>(opt =>
					opt.UseSqlServer(@"Data Source=.\SQLEXPRESS;Initial Catalog=blog;Integrated Security=true;MultipleActiveResultSets=True"));
			// Add framework services.
			services.AddMvc();
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}
			else
			{
				app.UseExceptionHandler("/error");
			}

			app.Use(async (context, next) =>
				  {
					  await next();
					  if (context.Response.StatusCode == 404 &&
						!Path.HasExtension(context.Request.Path.Value) &&
						!context.Request.Path.Value.StartsWith("/api/"))
					  {
						  context.Request.Path = "/index.html";
						  await next();
					  }
				  });

			app.UseMvcWithDefaultRoute();

			app.UseDefaultFiles();
			app.UseStaticFiles();
		}
	}
}
