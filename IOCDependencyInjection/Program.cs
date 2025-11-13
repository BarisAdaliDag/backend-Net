using IOCDependencyInjection.Services;

namespace IOCDependencyInjection
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();

            // EKLENEN — Dependency Injection (DI) ile servis ömürleri

            // 1️ Transient
            // Her istek (veya her kullanım) için servisten yeni bir örnek (instance) oluşturur.
            // Kısa ömürlü işlemler veya bağımlılığı olmayan, hafif servisler için uygundur.
            // builder.Services.AddTransient<IShowDateTime, ShowDateTime>();

            // 2️ Scoped
            // Her HTTP isteği (request) boyunca aynı servis örneğini kullanır.
            // İstek süresince servis tek bir örneğe sahip olur, istek bittiğinde atılır.
            // Özellikle repository, unit of work gibi veri tabanı işlemlerinde tercih edilir.
            // builder.Services.AddScoped<IShowDateTime, ShowDateTime>();

            // 3️ Singleton
            // Uygulama çalıştığı sürece yalnızca bir kez oluşturulur ve hep aynı örnek paylaşılır.
            // Uygulama genelinde değişmeyen, ortak veri tutan servislerde kullanılır.
            //  Ancak dikkat: thread-safe olmasına özen gösterilmelidir.
             builder.Services.AddSingleton<IShowDateTime, ShowDateTime>();

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