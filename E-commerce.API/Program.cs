using E_commerce.API.Errors;
using E_commerce.API.Helpers;
using E_commerce.Core.Entities;
using E_commerce.Core.Interfaces;
using E_commerce.Repository.Data;
using E_commerce.Repository.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Writers;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace E_commerce.API
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            #region Configure Service
            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddDbContext<StoreContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));

            });

            builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            //builder.Services.AddAutoMapper(M => M.AddProfile(new MappingProfile()));
            builder.Services.AddAutoMapper(typeof(MappingProfile));

            #endregion

            builder.Services.Configure<ApiBehaviorOptions>((options) =>
            {
                options.InvalidModelStateResponseFactory= (actionContext) =>
                {
                    var errors = actionContext.ModelState.Where(p => p.Value.Errors.Count() > 0)
                                                            .SelectMany(p => p.Value.Errors)
                                                            .Select(p => p.ErrorMessage)
                                                            .ToList();
                    
                    ApiValidationErrorResponse errorResponse = new ApiValidationErrorResponse() { Errors= errors };
                    return new BadRequestObjectResult(errorResponse);
                };
               

            });

            var app = builder.Build();
            #region Configure Pipeline
            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();
            #endregion

            //Update Database
            using var scope = app.Services.CreateScope();
            var services = scope.ServiceProvider;
            var _dbContext = services.GetRequiredService<StoreContext>();

            var loggerFactory= services.GetRequiredService<ILoggerFactory>();

            try
            {
                await _dbContext.Database.MigrateAsync();       //Update DataBase
                await StoreCotextSeed.SeedAsync(_dbContext);    //Data Seeding
                
            }
            catch (Exception ex)
            {
                var logger = loggerFactory.CreateLogger<Program>();
                logger.LogError(ex, "Error while update Database (Applying Migrations)");
            }
         
            app.Run();
        }
    }
}
