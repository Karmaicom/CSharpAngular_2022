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

            #region Configuração de Injeção de Dependência
                var connectionString = builder.Configuration.GetConnectionString("UsuariosWeb");

                // injeção da connectionString nas classes de repositório
                builder.Services.AddTransient<IPerfilRepository>(map => new PerfilRepository(connectionString));
                builder.Services.AddTransient<IUsuarioRepository>(map => new UsuarioRepository(connectionString));

                // injeção de dependência para as classes de domínio
                builder.Services.AddTransient<IUsuarioDomainService, UsuarioDomainService>();
            #endregion

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
    



