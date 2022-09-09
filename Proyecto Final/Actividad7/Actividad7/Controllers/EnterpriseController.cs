using Actividad7.Models;
using Actividad7.Services;
using Microsoft.AspNetCore.Mvc;

namespace Actividad7.Controllers
{
    public class EnterpriseController : Controller
    {
        private readonly EnterpriseService enterpriseService;

        public EnterpriseController(EnterpriseService enterpriseService)
        {
            this.enterpriseService = enterpriseService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var enterprises = await enterpriseService.GetAllEnterprises();
            return View(enterprises);
        }

        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            var enterprise = await enterpriseService.GetById(id);
            return View(enterprise);
        }

        [HttpPost]
        public async Task<IActionResult> Create(int id,string nit, string name, string direccion)
        {
            if (ModelState.IsValid)
            {
                var enterprise = Enterprise.Build(id, nit, name, direccion);
                await this.enterpriseService.Create(enterprise);
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return NotFound();
            }
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Update(int id, string nit, string name, string direccion)
        {
            if (ModelState.IsValid)
            {
                var enterprise = Enterprise.Build(id, nit, name, direccion);
                await this.enterpriseService.Update(enterprise);
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var consulta = await enterpriseService.GetById(id);
           // var enterprise = Enterprise.Build(id, consulta.Nit, consulta.Name, consulta.Direccion);
            await this.enterpriseService.Delete(consulta);
            return Content("1");
        }
    }
}
