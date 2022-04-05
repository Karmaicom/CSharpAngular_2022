using Microsoft.AspNetCore.Authentication.Cookies;

namespace UsuariosWeb.Presentation
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Configurando para MVC
            builder.Services.AddControllersWithViews();

            // Autenticação utilizando Cookie
            builder.Services.Configure<CookiePolicyOptions>(options => { options.MinimumSameSitePolicy = SameSiteMode.None; });
            builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseCookiePolicy();
            app.UseAuthentication();
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
    



