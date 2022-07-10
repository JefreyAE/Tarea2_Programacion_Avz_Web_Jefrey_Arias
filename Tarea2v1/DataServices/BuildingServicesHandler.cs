using Tarea2v1.DataServices.ServicesInterfaces;
using Tarea2v1.Models;

namespace Tarea2v1.DataServices
{
    public class BuildingServicesHandler
    {
        public Task<bool> AddService(IServiceBuildingApp service, IFormCollection collection)
        {
            return service.AddService(collection);
        }

        public Task<IEnumerable<Building>> GetAllBuildings(IServiceBuildingApp service)
        {
            return service.GetAllBuildings();
        }

        public Task<Building> GetBuildingsById(IServiceBuildingApp service, int id)
        {
            return service.GetBuildingsById(id);
        }

        public Task<bool> Save(IServiceBuildingApp service, IFormCollection collection)
        {
            return service.Save(collection);
        }

        public Task<bool> Edit(IServiceBuildingApp service, IFormCollection collection, int id)
        {
            return service.Edit(collection, id);
        }

        public Task<bool> Delete(IServiceBuildingApp service, int id)
        {
            return service.Delete(id);
        }

        public Task<bool> DeleteAllService_Building(IServiceBuildingApp service, int id)
        {
            return service.DeleteAllService_Building(id);
        }

        public Task<bool> DeleteService_Building(IServiceBuildingApp service, int public_services_id, int building_id)
        {
            return service.DeleteService_Building(public_services_id, building_id);
        }


    }
}
