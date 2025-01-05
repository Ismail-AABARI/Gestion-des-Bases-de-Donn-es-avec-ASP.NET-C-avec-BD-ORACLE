using Application_webOracle.Models;
using Application_webOracle.Business;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

public class EditDepartmentModel : PageModel
{
    private readonly DepartmentService _departmentService;

    public EditDepartmentModel(DepartmentService departmentService)
    {
        _departmentService = departmentService;
    }

    [BindProperty]
    public Departement Department { get; set; }

    public async Task<IActionResult> OnGetAsync(int id)
    {
        Department = await _departmentService.GetDepartmentByIdAsync(id);
        if (Department == null)
            return NotFound();

        return Page();
    }

    // Mise à jour du département
    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid)
        {
            // Log des erreurs si besoin
            foreach (var error in ModelState.Values.SelectMany(v => v.Errors))
            {
                Console.WriteLine(error.ErrorMessage);
            }
            return Page();
        }


        // Essayer de mettre à jour le département dans la base de données
        var existingDepartment = await _departmentService.GetDepartmentByIdAsync(Department.DeptNo);
        if (existingDepartment == null)
        {
            return NotFound(); // Si le département n'existe pas dans la base, renvoyer une erreur
        }

        // Mise à jour réussie
        await _departmentService.UpdateDepartmentAsync(Department);
        TempData["Message"] = "Employé modifié avec succès.";
        return RedirectToPage("IndexDept"); // Rediriger vers la page de liste après modification
    }
}
