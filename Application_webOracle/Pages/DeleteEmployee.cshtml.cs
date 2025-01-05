using Application_webOracle.Business;
using Application_webOracle.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Application_webOracle.Pages
{
    public class DeleteEmployeeModel : PageModel
    {
        private readonly EmployeeService _employeeService;

        public DeleteEmployeeModel(EmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        [BindProperty]
        public Employee Employee { get; set; }

        public async Task OnGetAsync(int id)
        {
            // R�cup�rer l'employ� en fonction de l'ID
            Employee = await _employeeService.GetEmployeeByIdAsync(id);
        }

        public async Task<IActionResult> OnPostAsync(int id)
        {
            if (Employee != null)
            {
                // Supprimer l'employ�
                await _employeeService.DeleteEmployeeAsync(id);
            }
            // Rediriger vers la page de liste des employ�s apr�s suppression
            return RedirectToPage("/Index1");
        }
    }
}
