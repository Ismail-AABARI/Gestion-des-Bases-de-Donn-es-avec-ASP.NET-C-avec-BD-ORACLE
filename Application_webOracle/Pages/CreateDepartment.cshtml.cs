using Application_webOracle.Models;
using Application_webOracle.Business;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

public class CreateDepartmentModel : PageModel
{
    private readonly DepartmentService _departmentService;

    public CreateDepartmentModel(DepartmentService departmentService)
    {
        _departmentService = departmentService;
    }

    [BindProperty]
    public Departement Department { get; set; }

    public async Task<IActionResult> OnPostAsync()
    {
        if (ModelState.IsValid)
        {
            await _departmentService.AddDepartmentAsync(Department);
            return RedirectToPage("/IndexDept");
        }
        return Page();
    }
}
