
namespace WebApplicationTEST
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            

            builder.Services.AddControllers();
            
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();


            builder.Services.AddCors(options =>
            {

                options.AddPolicy("nuevaPolitica", opt =>
                {

                    opt.AllowAnyHeader();
                    opt.AllowAnyMethod();
                    opt.AllowAnyOrigin();

                });


            });

            var app = builder.Build();





           
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseCors("nuevaPolitica");

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}