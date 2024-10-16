using MediatR;
using Microsoft.EntityFrameworkCore;
using ToDoTelDat.Entities;
using ToDoTelDat.Models;
using ToDoTelDat.Queries;

namespace ToDoTelDat
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            var apiConfiguration = new AppSettings();
            builder.Configuration.Bind(apiConfiguration);
            builder.Services.AddSingleton(apiConfiguration);

            builder.Services.AddDbContext<ToDoContext>(opt => opt.UseSqlServer(apiConfiguration.ConnectionString));

            builder.Services.AddMediatR(c => c.RegisterServicesFromAssemblyContaining<GetByDayQuery>());
                


            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

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
