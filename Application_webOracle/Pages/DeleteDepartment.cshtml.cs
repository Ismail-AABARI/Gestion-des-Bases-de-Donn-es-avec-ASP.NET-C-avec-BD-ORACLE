using Application_webOracle.Models;
using Application_webOracle.Business;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

public class DeleteDepartmentModel : PageModel
{
    private readonly DepartmentService _departmentService;

    public DeleteDepartmentModel(DepartmentService departmentService)
    {
        _departmentService = departmentService;
    }

    [BindProperty]
    public Departement Department { get; set; }

    public async Task OnGetAsync(int id)
    {
        // R�cup�rer le d�partement en fonction de l'ID
        Department = await _departmentService.GetDepartmentByIdAsync(id);
    }

    public async Task<IActionResult> OnPostAsync(int id)
    {
        if (Department != null)
        {
            // Supprimer le d�partement
            await _departmentService.DeleteDepartmentAsync(id);
        }
        // Rediriger vers la page de liste des d�partements apr�s suppression
        return RedirectToPage("/IndexDept");
    }
}
