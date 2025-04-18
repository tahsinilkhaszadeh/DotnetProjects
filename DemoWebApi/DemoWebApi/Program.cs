using Microsoft.EntityFrameworkCore;


namespace DemoWebApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Adding services to the container.

            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();


            builder.Services.AddDbContext<DemoWebApi.Data.DemoDbContext>(x =>
            {
                var connectionString = builder.Configuration.GetConnectionString("DbConnection");
                x.UseSqlServer(connectionString);
            },
            ServiceLifetime.Scoped, ServiceLifetime.Singleton);

            //builder.Services.AddDbContext<DemoWebApi.Data.DemoDbContext>(options =>
            //    options.UseSqlServer(builder.Configuration.GetConnectionString("DbConnection") ?? throw new InvalidOperationException("Connection string 'MvcMovieContext' not found.")));


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
