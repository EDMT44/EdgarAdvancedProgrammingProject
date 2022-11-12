using WineFactory;
using Repository;

namespace WebAPI
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

            // Add repository as service
            var connectionString = @"Data Source=Edgar_Diego-PC\SQLEXPRESS;AttachDBFilename=C:\Escuela\CUJAE\Tercero\Programación Avanzada\Código\DB\ProductionAreaDB.mdf;Initial Catalog=ProductionAreaDB;User ID=sa;Password=12345";
            builder.Services.AddSingleton(connectionString);
            builder.Services.AddScoped<IWineRepository, DBRepository>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.UseRouting();

            app.MapControllers();

            app.Run();
        }
    }
}