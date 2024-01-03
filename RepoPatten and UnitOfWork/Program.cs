
using Microsoft.EntityFrameworkCore;
using RepoPatten_and_UnitOfWork.DB;
using RepoPatten_and_UnitOfWork.repo.Classess;
using RepoPatten_and_UnitOfWork.repo.Interfaces;
using RepoPatten_and_UnitOfWork.Unit_Of_Work;

namespace RepoPatten_and_UnitOfWork
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
            builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
            //builder.Services.AddScoped( typeof(IBaseRepo<>) , typeof(BaseRepo<>) );
            builder.Services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer( builder.Configuration.GetConnectionString("default"))
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
