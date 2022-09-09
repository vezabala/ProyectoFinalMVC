using Actividad7.Models;
using Actividad7.Services;
using Microsoft.AspNetCore.Mvc;

namespace Actividad7.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly EmployeeService employeeServicee;

        public EmployeeController(EmployeeService employeeServicee)
        {
            this.employeeServicee = employeeServicee;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var employees = await employeeServicee.GetAllEmployees();
            return View(employees);
        }

        [HttpPost]
        public async Task<IActionResult> Create(int id,string identification, string name, DateTime fechaDeIngreso, int enterpriseId)
        {
            var employee = Employee.Build(id, identification, name , fechaDeIngreso, enterpriseId);
            await this.employeeServicee.Create(employee);
            return View();
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPut]
        public async Task<IActionResult> Update(int id, string identification, string name, DateTime fechaDeIngreso, int enterpriseId)
        {
            var employee = Employee.Build(id, identification, name, fechaDeIngreso, enterpriseId);
            await this.employeeServicee.Update(employee);
            return View();
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id, string identification, string name, DateTime fechaDeIngreso, int enterpriseId)
        {
            var employee = Employee.Build(id, identification, name, fechaDeIngreso, enterpriseId);
            await this.employeeServicee.Delete(employee);
            return View();
        }
    }
}
