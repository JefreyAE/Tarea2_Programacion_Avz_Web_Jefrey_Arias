using Tarea2v1.Models;

namespace Tarea2v1.DataServices.ServicesInterfaces
{
    public interface IServiceServicesApp
    {
        public Task<IEnumerable<Services>> GetAllServices();
        public Task<Services> GetServicesById(int id);
        public Task<IEnumerable<Services>> GetServicesByBuildingId(int id);
        public Task<Boolean> Save(IFormCollection collection);
        public Task<Boolean> Edit(IFormCollection collection, int id);
        public Task<Boolean> Delete(int id);
        public Task<Boolean> DeleteAllService_Building(int id);

    }
}
