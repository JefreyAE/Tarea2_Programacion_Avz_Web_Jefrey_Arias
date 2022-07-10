
using Tarea2v1.DataServices;
using Tarea2v1.DataServices.BuildingServices;
using Tarea2v1.Interfaces;

namespace Tarea2v1.Models
{
    public class Building : IBuilding
    {
       
        public int id { get; set; }
        public int capacity { get; set; }
        public string register_date { get; set; }
        public string final_date { get; set; }
        public string province { get; set; }
        public string canton { get; set; }
        public string disctrict { get; set; }
        public string building_type { get; set; }
        public string building_name { get; set; }

        public Building()
        {
            this.register_date = "";
            this.final_date = "";
            this.province = "";
            this.canton = "";
            this.disctrict = "";
            this.building_type = "";
        }

        public async Task<IEnumerable<Building>> GetAllBuildings()
        {
            BuildingServicesHandler origingService = new BuildingServicesHandler();
            IEnumerable<Building> Model = await origingService.GetAllBuildings(new BuildingServiceWCF());

            return Model;
        }

        public async Task<Building> GetBuildingsById(int id)
        {
            BuildingServicesHandler origingService = new BuildingServicesHandler();
            Building building = await origingService.GetBuildingsById(new BuildingServiceWCF(), id);

            return building;
        }

        public async Task<Boolean> AddService(IFormCollection collection)
        {
            var result = false;
            BuildingServicesHandler origingService = new BuildingServicesHandler();
            result = await origingService.AddService(new BuildingServiceWCF(), collection);
            return result;
        }

        public async Task<Boolean> Save(IFormCollection collection)
        {
            var result = false;
            BuildingServicesHandler origingService = new BuildingServicesHandler();
            result = await origingService.Save(new BuildingServiceWCF(), collection);
            return result;
        }

        public async Task<Boolean> Edit(IFormCollection collection, int id)
        {
            var result = false;
            BuildingServicesHandler origingService = new BuildingServicesHandler();
            result = await origingService.Edit(new BuildingServiceWCF(), collection, id);
            return result;
        }


        public async Task<Boolean> Delete(int id)
        {
            var result = false;
            BuildingServicesHandler origingService = new BuildingServicesHandler();
            result = await origingService.Delete(new BuildingServiceWCF(), id);
            return result;
        }

        public async Task<Boolean> DeleteAllServices_Building(int id)
        {
            var result = false;
            BuildingServicesHandler origingService = new BuildingServicesHandler();
            result = await origingService.DeleteAllService_Building(new BuildingServiceWCF(), id);
            return result;
        }

        public async Task<Boolean> DeleteServices_Building(int public_services_id, int building_id)
        {
            var result = false;
            BuildingServicesHandler origingService = new BuildingServicesHandler();
            result = await origingService.DeleteService_Building(new BuildingServiceWCF(), public_services_id, building_id);
            return result;
        }


    }
}
