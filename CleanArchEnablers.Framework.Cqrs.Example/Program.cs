using System.Reflection;
using CleanArchEnablers.Framework.Cqrs.Example.Infrastructure.Context;
using CleanArchEnablers.Framework.Cqrs.Example.Infrastructure.Repositories;
using CleanArchEnablers.Framework.Cqrs.Example.Infrastructure.Repositories.Implementation;
using Microsoft.EntityFrameworkCore;

namespace CleanArchEnablers.Framework.Cqrs.Example;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        builder.Services.AddDbContext<DatabaseContext>(options =>
        {
            options.UseInMemoryDatabase("InMemoryDb");
        });
        builder.Services.AddControllers();
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();
        
        // Adding CaeCqrs on Asp Pipeline
        builder.Services.AddCaeCqrs(Assembly.GetExecutingAssembly());
        
        // Adding Services
        builder.Services.AddScoped<IUserRepository, UserRepository>();

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