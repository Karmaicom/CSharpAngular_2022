using ProdutosApi.Infra.Data.Interfaces;
using ProdutosApi.Infra.Data.Repositories;

namespace ProdutosApi { 
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllers();
            
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            #region Injeção de Dependência
            var connectionString = builder.Configuration.GetConnectionString("ProdutosApi");
            builder.Services.AddTransient<IProdutoRepository>(map => new ProdutoRepository(connectionString));
            #endregion

            var app = builder.Build();

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }

}
