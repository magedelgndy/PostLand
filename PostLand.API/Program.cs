using FluentAssertions.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PostLand.Application.Interfaces;
using PostLand.Application.Profiles;
using PostLand.Persistence;
using PostLand.Persistence.Repositories;
using System;
using System.Reflection;

namespace PostLand.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddDbContext<PostDbContext>(
                options => options.UseSqlServer(builder.Configuration.GetConnectionString("PostConnectionString")
                ));
            builder.Services.AddScoped(typeof(IAsyncRepository<>), typeof(BaseRepository<>));
            builder.Services.AddScoped(typeof(IPostRepository), typeof(PostRepository));
            builder.Services.AddMediatR(Cfg => Cfg.RegisterServicesFromAssemblies(AppDomain.CurrentDomain.GetAssemblies()));
            builder.Services.AddAutoMapper(typeof(AutoMapperProfile));




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