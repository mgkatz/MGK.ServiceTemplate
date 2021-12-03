using FluentValidation.AspNetCore;
using MGK.ServiceBase.Infrastructure.Extensions;
using MGK.ServiceTemplate.API.Infrastructure.Extensions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json.Serialization;

namespace MGK.ServiceTemplate.API
{
	public class Startup
	{
		private readonly IConfiguration _configuration;

		public Startup(IConfiguration configuration)
		{
			_configuration = configuration;
		}

		// This method gets called by the runtime. Use this method to add services to the container.
		public void ConfigureServices(IServiceCollection services)
		{
			services.AddMvc()
				.AddNewtonsoftJson(options =>
				{
					// Use the default property (Pascal) casing
					options.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
				})
				.SetCompatibilityVersion(CompatibilityVersion.Version_3_0)
				.AddControllersAsServices()
				.AddFluentValidation(fv =>
				{
					fv.RegisterValidatorsFromAssemblyContaining<Startup>();
					fv.RunDefaultMvcValidationAfterFluentValidationExecutes = false;
				});

			services.AddLocalization();
			services.AddHttpContextAccessor();
			services.AddControllers();

			// Configure the services declared in the assembly
			services.AddServices(_configuration);
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			app.UseDeveloperExceptionPage();
			app.UseLogMiddleware();

			// Configure the app configurations declared in the assembly
			app.AddAppConfigurations(_configuration);

			app.UseHsts();
			app.UseStatusCodePages();
			app.UseHttpsRedirection();
			app.UseRouting();
			app.UseAuthorization();

			if (!env.IsProduction())
			{
				app.UseDevMiddleware();
			}

			app.UseEndpoints(ep =>
				ep.MapControllers());
				//.RequireAuthorization());
		}
	}
}
