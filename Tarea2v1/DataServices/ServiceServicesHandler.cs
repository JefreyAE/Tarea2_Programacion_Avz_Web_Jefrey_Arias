using Tarea2v1.DataServices.ServicesInterfaces;
using Tarea2v1.Models;

namespace Tarea2v1.DataServices
{
    public class ServiceServicesHandler
    {
        public Task<IEnumerable<Services>> GetAllServices(IServiceServicesApp service)
        {
            return service.GetAllServices();
        }

        public Task<Services> GetServcicesById(IServiceServicesApp service, int id)
        {
            return service.GetServicesById(id);
        }

        public Task<IEnumerable<Services>> GetServicesByBuildingId(IServiceServicesApp service, int id)
        {
            return service.GetServicesByBuildingId(id);
        }

        public Task<bool> Save(IServiceServicesApp service, IFormCollection collection)
        {
            return service.Save(collection);
        }

        public Task<bool> Edit(IServiceServicesApp service, IFormCollection collection, int id)
        {
            return service.Edit(collection, id);
        }

        public Task<bool> Delete(IServiceServicesApp service, int id)
        {
            return service.Delete(id);
        }

        public Task<bool> DeleteAllService_Building(IServiceServicesApp service, int id)
        {
            return service.DeleteAllService_Building(id);
        }
        
    }
}
