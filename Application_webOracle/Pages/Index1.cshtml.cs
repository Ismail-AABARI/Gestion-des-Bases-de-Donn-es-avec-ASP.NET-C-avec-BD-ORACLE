using Application_webOracle.Business;
using Application_webOracle.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc;

public class IndexModel : PageModel
{
    private readonly EmployeeService _employeeService;

    public IndexModel(EmployeeService employeeService)
    {
        _employeeService = employeeService;
    }

    public IEnumerable<Employee> Employees { get; set; }

    public async Task OnGetAsync()
    {
        Employees = await _employeeService.GetEmployeesAsync();
    }

    public async Task<IActionResult> OnPostDeleteAsync(int id)
    {
        if (id > 0) // Si un ID valide est passé
        {
            await _employeeService.DeleteEmployeeAsync(id);
        }
        return RedirectToPage(); // Redirige vers la même page après la suppression
    }

}
