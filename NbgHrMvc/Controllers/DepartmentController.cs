using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NbgHr.Model;
using NbgHr.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NbgHrMvc.Controllers
{
    public class DepartmentController : Controller
    {

        private readonly HrService hrService;

        public DepartmentController(HrService hrService)
        {
            this.hrService = hrService;
        }

        // GET: DepartmentController

        public async Task<ActionResult> Index()
        {
            List<Department> departments = await hrService.GetDepartment();
            return View(departments);
        }

        // GET: DepartmentController/Details/5
        public  async Task<ActionResult> Details(int id)
        {
            Department department = await hrService.GetDepartmen(id);
            return View(department);
        }

        // GET: DepartmentController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DepartmentController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Department department)
        {
            try
            {

                _ = await hrService.CreateDepartment(department);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: DepartmentController/Edit/5
        public async Task<ActionResult> Edit([FromRoute] int id)
        {
            Department department = await hrService.GetDepartmen(id);
            return View(department);
        }

        // POST: DepartmentController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([FromRoute] int id, [FromBody] Department department)
        {
            try
            {
                _ = await hrService.EditDepartment(id, department);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: DepartmentController/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            Department department = await hrService.GetDepartmen(id);
            return View(department);
        }

        // POST: DepartmentController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(int id, IFormCollection collection)
        {
            try
            {

                _ = await hrService.DeleteDepartment(id);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
