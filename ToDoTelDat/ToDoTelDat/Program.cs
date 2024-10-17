using FluentValidation;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using ToDoTelDat.Entities;
using ToDoTelDat.Middlewares;
using ToDoTelDat.Models;
using ToDoTelDat.Pipelines;
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
            builder.Services.AddValidatorsFromAssemblyContaining<ToDoContext>();   
            builder.Services.AddMediatR(c =>
            {
                c.RegisterServicesFromAssemblyContaining<GetByDayQuery>();
                c.AddOpenBehavior(typeof(ValidationBehavior<,>));
            });

            


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
            app.UseCors(options =>
                options.AllowAnyOrigin()
            );

            app.UseHttpsRedirection();

            app.UseAuthorization();
            app.UseMiddleware<GlobalExceptionHandlingMiddleware>();

            app.MapControllers();

            app.Run();
        }
    }
}
