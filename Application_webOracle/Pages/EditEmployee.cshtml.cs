using Application_webOracle.Models;
using Application_webOracle.Business;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

public class EditEmployeeModel : PageModel
{
    private readonly EmployeeService _employeeService;

    public EditEmployeeModel(EmployeeService employeeService)
    {
        _employeeService = employeeService;
    }

    [BindProperty]
    public Employee Employee { get; set; }

    public async Task<IActionResult> OnGetAsync(int id)
    {
        Employee = await _employeeService.GetEmployeeByIdAsync(id);
        if (Employee == null)
            return NotFound();

        return Page();
    }

    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid)
            return Page();

        await _employeeService.UpdateEmployeeAsync(Employee);
        TempData["Message"] = "Employé modifié avec succès.";
        return RedirectToPage("Index1");
    }
}
