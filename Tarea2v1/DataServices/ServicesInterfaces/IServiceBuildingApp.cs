using Tarea2v1.Models;

namespace Tarea2v1.DataServices.ServicesInterfaces
{
    public interface IServiceBuildingApp
    {
        public Task<Boolean> Save(IFormCollection collection);
        public Task<Boolean> Edit(IFormCollection collection, int id);
        public Task<IEnumerable<Building>> GetAllBuildings();
        public Task<Building> GetBuildingsById(int id);
        public Task<Boolean> AddService(IFormCollection collection);
        public Task<Boolean> Delete(int id);
        public Task<Boolean> DeleteAllService_Building(int id);
        public Task<Boolean> DeleteService_Building(int public_services_id, int building_id);

    }
}
