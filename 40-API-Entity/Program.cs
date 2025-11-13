using _40_API_Entity.Contexts;
using Microsoft.EntityFrameworkCore;

namespace _40_API_Entity
{
    //e-TAH KONTROLUNUE BAK PRODUCT PUT ANLAMADIM ONA BAK
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllers();

            // DbContext ekleme
            var conn = builder.Configuration.GetConnectionString("DeafaultConn");
            builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(conn));

            //hoca automapper bu yapiya internetten bak

            // Swagger
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

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
