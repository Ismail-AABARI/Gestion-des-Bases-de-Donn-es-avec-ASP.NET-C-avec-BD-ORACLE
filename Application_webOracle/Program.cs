using Application_webOracle.Business;
using Application_webOracle.Data;
using Microsoft.AspNetCore.Builder;

namespace Application_webOracle
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Ajouter les services n�cessaires
            builder.Services.AddRazorPages();
            builder.Services.AddDistributedMemoryCache(); // Pour stocker les sessions
            builder.Services.AddSession(); // Activer les sessions

            // Enregistrer OracleDbContext en tant que service singleton
            builder.Services.AddSingleton<OracleDbContext>();

            // Enregistrer EmployeeService en tant que service scoped
            builder.Services.AddScoped<EmployeeService>();

            // Enregistrer DepartmentService en tant que service scoped
            builder.Services.AddScoped<DepartmentService>(); // Ajoutez cette ligne

            var app = builder.Build();

            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseRouting();

            app.UseSession(); // Utiliser les sessions
            app.UseAuthorization();

            // Middleware pour rediriger vers Login si l'utilisateur n'est pas authentifi�
            app.Use(async (context, next) =>
            {
                // V�rifiez si l'utilisateur tente d'acc�der � une page publique (comme Login ou FormationOracle)
                var publicPages = new[] { "/Login", "/FormationOracle", "/ButProjet" };

                // Si l'utilisateur n'est pas authentifi� et essaie d'acc�der � une page priv�e, redirigez vers la page de login
                if (context.Session.GetString("IsAuthenticated") != "true" &&
                    !publicPages.Any(page => context.Request.Path.StartsWithSegments(page)))
                {
                    context.Response.Redirect("/Login");
                    return;
                }

                await next();
            });

            app.MapRazorPages();
            app.Run();
        }
    }
}
