
using ASP_lez03_EF_Manuale_Ferramenta.Models;
using Microsoft.EntityFrameworkCore;
using Task_MarioKart.Models;
using Task_MarioKart.Repositories;
using Task_MarioKart.Services;

namespace Task_MarioKart
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


            builder.Services.AddDbContext<MarioKartContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

            builder.Services.AddScoped<PersonaggiRepo>();
            builder.Services.AddScoped<PersonaggiService>();
            builder.Services.AddScoped<SquadraRepo>();
            builder.Services.AddScoped<SquadraService>();



            var app = builder.Build();



            app.UseCors(builder =>
                 builder
                 .WithOrigins("*")
                 .AllowAnyMethod()
                 .AllowAnyHeader());
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
    }
}
