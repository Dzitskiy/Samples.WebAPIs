using Microsoft.AspNetCore.OData;
using Microsoft.EntityFrameworkCore;
using Microsoft.OData.Edm;
using Microsoft.OData.ModelBuilder;
using OdataApp.Data;
using OdataApp.Data.Models;

namespace OdataApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddDbContext<AppDbContext>(options =>
            options.UseNpgsql(builder.Configuration.GetConnectionString("Default")));



            builder.Services.AddControllers()
                .AddOData(
                options => options.SetMaxTop(10).Count().Filter().OrderBy().Expand().Select()
                .AddRouteComponents(
                    routePrefix: "odata",
                    model: GetEdmModel()));


            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }

        private static IEdmModel GetEdmModel()
        {
            var modelBuilder = new ODataConventionModelBuilder();

            modelBuilder.EntityType<Comment>();
            modelBuilder.EntityType<User>();
            modelBuilder.EntityType<Country>();
            modelBuilder.EntitySet<User>("OdataUsers");
            return modelBuilder.GetEdmModel();
        }
    }
}