using Application_webOracle.Models;
using Application_webOracle.Business;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc;

public class IndexDeptModel : PageModel
{
    private readonly DepartmentService _departmentService;

    public IndexDeptModel(DepartmentService departmentService)
    {
        _departmentService = departmentService;
    }

    public IEnumerable<Departement> Departments { get; set; }

    public async Task OnGetAsync()
    {
        Departments = await _departmentService.GetDepartmentsAsync();
    }
}
