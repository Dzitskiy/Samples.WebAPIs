using HotChocolate;
using HotChocolate.AspNetCore;
using HotChocolate.AspNetCore.Voyager;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.SpaServices.ReactDevelopmentServer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using GraphQLApp.Domain;
using GraphQLApp.Types;

namespace GraphQLApp
{
  public class Startup
  {
    public Startup(IConfiguration configuration)
    {
      Configuration = configuration;
    }

    public IConfiguration Configuration { get; }

    // This method gets called by the runtime. Use this method to add services to the container.
    public void ConfigureServices(IServiceCollection services)
    {
      services.AddControllersWithViews();

      // In production, the React files will be served from this directory
      services.AddSpaStaticFiles(configuration => { configuration.RootPath = "ClientApp/build"; });

      services.AddSingleton<IWeatherService, WeatherService>();

      services
        .AddGraphQL(sp => SchemaBuilder.New()
          
          .AddQueryType<WeatherQueries>()

          // .AddMutationType<WeatherQueries>()
          // .AddSubscriptionType<WeatherQueries>()
          // .AddType<>()

          //.AddAuthorizeDirectiveType()

          .Create()
        );

      services.AddAuthentication();
      services.AddAuthorization();
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
      if (env.IsDevelopment())
      {
        app.UseDeveloperExceptionPage();
      }
      else
      {
        app.UseExceptionHandler("/Error");
        // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
        app.UseHsts();
      }

      app.UseStaticFiles();
      app.UseSpaStaticFiles();

      app.UseAuthentication();

      app.UseRouting();
      app.UseAuthorization();

      app
        //.UseGraphQL("/graphql")
        .UsePlayground("/graphql")
        .UseVoyager("/graphql");

      app.UseEndpoints(endpoints =>
      {
          endpoints.MapGraphQL();

          //endpoints.MapGet("/", async context =>
          //{
          //    await context.Response.WriteAsync("Hello World!");
          //});

          //endpoints.MapControllerRoute(
          //"default",
          //"{controller}/{action=Index}/{id?}");
      });

      app.UseSpa(spa =>
      {
        spa.Options.SourcePath = "ClientApp";

        if (env.IsDevelopment())
        {
          spa.UseReactDevelopmentServer("start");
        }
      });
    }
  }
}