using Application_webOracle.Models;
using Application_webOracle.Business;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

public class CreateEmployeeModel : PageModel
{
    private readonly EmployeeService _employeeService;

    public CreateEmployeeModel(EmployeeService employeeService)
    {
        _employeeService = employeeService;
    }

    [BindProperty]
    public Employee Employee { get; set; }

    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid)
            return Page();

        await _employeeService.AddEmployeeAsync(Employee);
        return RedirectToPage("Index1");
    }
}
