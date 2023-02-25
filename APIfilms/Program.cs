using APIfilms.Models.EntityFramework;
using Microsoft.EntityFrameworkCore;

namespace APIfilms
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

            builder.Services.AddDbContext<FilmRatingsDBContext>(options =>
            options.UseNpgsql(builder.Configuration.GetConnectionString("FilmRatingsDBContext")));
            builder.Services.AddSwaggerGen(
                doc =>
                {
                    var xmlFile = Path.ChangeExtension(typeof(Program).Assembly.Location, "xml");
                    doc.IncludeXmlComments(xmlFile);

                }
                
                );

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}