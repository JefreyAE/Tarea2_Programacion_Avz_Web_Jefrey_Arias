
using ServiceBuildingReference;
using Tarea2v1.DataServices.ServicesInterfaces;
using Tarea2v1.Models;

namespace Tarea2v1.DataServices.BuildingServices
{
    public class BuildingServiceWCF : IServiceBuildingApp
    {
        public async Task<IEnumerable<Building>> GetAllBuildings()
        {
            List<Building> Model = new List<Building>();

            using (BuildingServiceClient cl = new BuildingServiceClient())
            {
                Array list_result = await cl.getListAsync();
                foreach (BuildingServiceObj obj in list_result)
                {
                    Building brg = new Building()
                    {
                        id = obj.id,
                        capacity = obj.capacity,
                        register_date = obj.register_date,
                        final_date = obj.final_date,
                        province = obj.province,
                        canton = obj.canton,
                        disctrict = obj.disctrict,
                        building_type = obj.building_type,
                        building_name = obj.building_name
                    };

                    Model.Add(brg);
                }
                return Model;
            }
        }

        public async Task<Building> GetBuildingsById(int id)
        {
            Building building = new Building();

            using (BuildingServiceClient cl = new BuildingServiceClient())
            {
                var obj = await cl.getBuildingAsync(id);

                building.id = obj.id;
                building.capacity = obj.capacity;
                building.register_date = obj.register_date;
                building.final_date = obj.final_date;
                building.province = obj.province;
                building.canton = obj.canton;
                building.disctrict = obj.disctrict;
                building.building_type = obj.building_type;
                building.building_name = obj.building_name;

                return building;
            }
        }
        public async Task<bool> AddService(IFormCollection collection)
        {
            var result = false;
            using (BuildingServiceClient cliente = new BuildingServiceClient())
            {
                result = await cliente.addServiceAsync(Convert.ToInt32(collection["service_id"]), Convert.ToInt32(collection["building_id"]));
            }

            return result;
        }

        public async Task<bool> Save(IFormCollection collection)
        {
            var result = false;

            using (BuildingServiceClient cliente = new BuildingServiceClient())
            {
                result = await cliente.createBuildingAsync(Convert.ToInt32(collection["capacity"]), collection["register_date"], collection["final_date"], collection["province"], collection["canton"], collection["disctrict"], collection["building_type"], collection["building_name"]);
            }

            return result;
        }

        public async Task<bool> Edit(IFormCollection collection, int id)
        {
            var result = false;

            using (BuildingServiceClient cliente = new BuildingServiceClient())
            {
                result = await cliente.editBuildingAsync(id, Convert.ToInt32(collection["capacity"]), collection["register_date"], collection["final_date"], collection["province"], collection["canton"], collection["disctrict"], collection["building_type"], collection["building_name"]);
            }

            return result;
        }

        public async Task<bool> Delete(int id)
        {
            var result = false;

            using (BuildingServiceClient cliente = new BuildingServiceClient())
            {
                result = await cliente.deleteBuildingAsync(id);
            }

            return result;
        }

        public async Task<bool> DeleteService_Building(int public_services_id, int building_id)
        {
            var result = false;

            using (BuildingServiceClient cliente = new BuildingServiceClient())
            {
                result = await cliente.deleteService_BuildingAsync(public_services_id, building_id);
            }

            return result;
        }

        public async Task<bool> DeleteAllService_Building(int building_id)
        {
            var result = false;

            using (BuildingServiceClient cliente = new BuildingServiceClient())
            {
                result = await cliente.deleteAllService_BuildingAsync(building_id);
            }

            return result;
        }
    }
}
