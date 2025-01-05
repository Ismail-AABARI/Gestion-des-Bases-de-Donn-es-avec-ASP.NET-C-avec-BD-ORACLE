using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Application_webOracle.Pages
{
    public class LoginModel : PageModel
    {
        [BindProperty]
        public string Username { get; set; }
        [BindProperty]
        public string Password { get; set; }
        public string ErrorMessage { get; set; }

        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            // V�rifiez les informations d'identification
            if (Username == "scott" && Password == "tiger")
            {
                // Cr�ez un cookie ou une session pour garder l'utilisateur connect�
                HttpContext.Session.SetString("IsAuthenticated", "true");

                // Redirigez vers la page d'accueil (Index)
                return RedirectToPage("Index");
            }
            else
            {
                ErrorMessage = "Nom d'utilisateur ou mot de passe incorrect.";
                return Page();
            }
        }
    }
}
