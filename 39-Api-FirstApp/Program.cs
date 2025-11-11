namespace _39_Api_FirstApp
{
    public class Program
    {
        /*
         apilerde genel route yapisi tercih edilmez
        Spesific ad verilir ve api ismi degistirilmez.Cunku servisler bozulmasin diye
          [Route("api/[controller]s")] sonuna s eklenir
        //products/id=101
         
         */
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

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

            //Merkezi route kurabilirsin api tercih edilmez Daha cok MVC projelerde 
            //TODO: HOCA

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}