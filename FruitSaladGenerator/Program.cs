
using FruitSaladGenerator.Repositories;
using FruitSaladGenerator.Services;

namespace FruitSaladGenerator
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
            builder.Services.AddMemoryCache();
            builder.Services.AddHttpClient("FruityViceAPI", c =>
            {
                c.BaseAddress = new Uri("https://www.fruityvice.com/");
                c.DefaultRequestHeaders.Add("Accept", "application/json");
            });
            builder.Services.AddScoped<IFruitSaladService, FruitSaladService>();
            builder.Services.AddScoped<IFruitRepository, FruitRepository>();

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
