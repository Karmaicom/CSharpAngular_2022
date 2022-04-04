namespace UsuariosWeb.Presentation
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Configurando para MVC
            builder.Services.AddControllersWithViews();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            //app.MapRazorPages();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Account}/{action=Login}"
            );

            app.Run();
        }
    }
}
    



