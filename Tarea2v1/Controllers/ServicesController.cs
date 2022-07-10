using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Tarea2v1.Models;

namespace Tarea2v1.Controllers
{
    public class ServicesController : Controller
    {
        // GET: ServicesController
        public async Task<ActionResult> Index()
        {
            var services = new Services();

            var listServices = await services.GetAllServices();

            return View(listServices);
        }

        // GET: ServicesController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ServicesController/Create
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(IFormCollection collection)
        {
            var services = new Services();
            var result = services.Save(collection);

            return Redirect("/Services");
        }

        

        // GET: ServicesController/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            var service = new Services();
            var result = await service.GetServicesByID(id);

            return View(result);
        }

        // POST: ServicesController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {

            var service = new Services();
            var result = service.Edit(collection, id);

            return RedirectToAction("Index");
        }

        // GET: ServicesController/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            var services = new Services();
            await services.DeleteAllServices_Building(id);
            await services.Delete(id);
            
            return Redirect("/Services");
        }

        // POST: ServicesController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
