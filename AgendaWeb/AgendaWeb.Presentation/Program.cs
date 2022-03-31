using AgendaWeb.Infra.Data.Repositories;

namespace AgendaWeb.Presentation
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            var connectionString = builder.Configuration.GetConnectionString("BDAgendaWeb");

            builder.Services.AddTransient<ITarefaRepository>(
                map => new TarefaRepository(connectionString)
            );


            builder.Services.AddControllersWithViews();

            var app = builder.Build();

            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}"
            );

            app.Run();
        }
    }
}


