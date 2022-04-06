using Microsoft.AspNetCore.Authentication.Cookies;
using UsuariosWeb.Domain.Interfaces.Repositories;
using UsuariosWeb.Domain.Interfaces.Services;
using UsuariosWeb.Domain.Services;
using UsuariosWeb.Infra.Data.Repositories;

namespace UsuariosWeb.Presentation
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Configurando para MVC
            builder.Services.AddControllersWithViews();

            #region Configura��o de Inje��o de Depend�ncia
                var connectionString = builder.Configuration.GetConnectionString("UsuariosWeb");

                // inje��o da connectionString nas classes de reposit�rio
                builder.Services.AddTransient<IPerfilRepository>(map => new PerfilRepository(connectionString));
                builder.Services.AddTransient<IUsuarioRepository>(map => new UsuarioRepository(connectionString));

                // inje��o de depend�ncia para as classes de dom�nio
                builder.Services.AddTransient<IUsuarioDomainService, UsuarioDomainService>();
            #endregion

            // Autentica��o utilizando Cookie
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
    



