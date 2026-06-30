using Microsoft.EntityFrameworkCore;

namespace OlympicsAsp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddCors(options =>
            {
                options.AddPolicy("AllowSpecificOrigins", policy =>
                {
                    policy.WithOrigins("http://localhost:5173").AllowAnyMethod().AllowAnyHeader();
                });
            });
            // Add services to the container.
            var connectionString = builder.Configuration.GetConnectionString("PostgresConnection");
            builder.Services.AddDbContext<AppDbContext>(options => options.UseNpgsql(connectionString));
            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

// Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
                // app.MapOpenApi();
            }

            app.UseHttpsRedirection();
            
            app.UseCors("AllowSpecificOrigins");

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}