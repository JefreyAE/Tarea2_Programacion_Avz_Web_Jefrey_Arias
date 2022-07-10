using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections;
using Tarea2v1.Models;

namespace Tarea2v1.Controllers
{
    public class BuildingController : Controller
    {
        // GET: BuildingController
        public async Task<ActionResult> Index()
        {
            var building = new Building();
            var listBuildings = await building.GetAllBuildings();
            return View(listBuildings);

        }

        // GET: BuildingController/Create
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(IFormCollection collection)
        {
            var building = new Building();
            var result = building.Save(collection);

            return Redirect("/Building");
        }

        [HttpPost]
        public async Task<ActionResult> AddService(IFormCollection collection)
        {
            var building = new Building();
            var result = building.AddService(collection);

            return Redirect("/Building/Details/"+collection["building_id"]);
        }

        // GET: BuildingController/Details/5
        public async Task<ActionResult> Details(int id)
        {
            var services = new Services();
            var listServices = await services.GetAllServices();
            var list_building_services = await services.GetServicesByBuildingId(id);
            var list_aux = new List<Services>();

            HashSet<Services> servicesSet = listServices.ToHashSet<Services>();
            HashSet<Services> servicesSetB = list_building_services.ToHashSet<Services>();

            foreach (var item in servicesSet)
            {
                foreach (var itemB in servicesSetB)
                {
                    if (item.type == itemB.type)
                    {
                        servicesSet.Remove(item);
                    }
                }    
            }

            ViewBag.services = servicesSet.ToList<Services>();
            ViewBag.services_building = list_building_services;

            var obj_building = new Building();
            var building = await obj_building.GetBuildingsById(id);
            ViewBag.building_id = building.id;
            return View(building);

        }

        // GET: BuildingController/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            var obj_building = new Building();
            var building = await obj_building.GetBuildingsById(id);

            return View(building);
        }

        // POST: BuildingController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, IFormCollection collection)
        {
            var building = new Building();
            var result = building.Edit(collection, id);

            return Redirect($"/Building/Details/{id}");
        }

        // GET: BuildingController/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            var building = new Building();
            await building.DeleteAllServices_Building(id);
            await building.Delete(id);

            return Redirect("/Building");
        }

        public async Task<ActionResult> Delete_Service(int id, int building_id)
        {
            var building = new Building();
            await building.DeleteServices_Building(id,building_id);

            return Redirect($"/Building/Details/{building_id}");
        }

        // POST: BuildingController/Delete/5
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
