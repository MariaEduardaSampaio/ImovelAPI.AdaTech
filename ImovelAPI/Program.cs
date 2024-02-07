
using Microsoft.Extensions.Options;

namespace ImovelAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddHttpClient();

            // esta � a configura��o caso n�o haja valida��o de data Annotations nas propriedades das classes q seguem o padr�o IOption
            //var configOptions = builder.Configuration.GetSection(ImovelApi.Imovel);
            //builder.Services.Configure<ImovelApi>(configOptions); 

            builder.Services.AddOptions<ImovelApi>()
                .Bind(builder.Configuration.GetSection(ImovelApi.Imovel)).ValidateDataAnnotations();
            builder.Services.AddControllers();

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
