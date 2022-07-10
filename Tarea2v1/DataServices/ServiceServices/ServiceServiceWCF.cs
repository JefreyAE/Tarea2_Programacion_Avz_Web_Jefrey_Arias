
using ServiceServicesReference;
using Tarea2v1.DataServices.ServicesInterfaces;
using Tarea2v1.Models;

namespace Tarea2v1.DataServices.ServiceServices
{
    public class ServiceServiceWCF : IServiceServicesApp
    {
        public async Task<IEnumerable<Services>> GetAllServices()
        {
            List<Services> Model = new List<Services>();
           
            using (ServiceServicesClient cl = new ServiceServicesClient())
            {
                Array list_result = await cl.getAllServicesAsync();
                foreach (ServicesServiceObj obj in list_result)
                {
                    Services brg = new Services()
                    {
                        id = obj.id,
                        name = obj.name,
                        type = obj.type,
                        unit = obj.unit,
                        company_name = obj.company_name
                    };

                    Model.Add(brg);
                }
                return Model;
            }
        }

        public async Task<Services> GetServicesById(int id)
        {
            Services service = new Services();

            using (ServiceServicesClient cl = new ServiceServicesClient())
            {
                var obj = await cl.getServiceByIdAsync(id);

                service.id = obj.id ;
                service.name = obj.name;
                service.type = obj.type;
                service.unit = obj.unit;
                service.company_name = obj.company_name;

                return service;
            }
        }
        public async Task<IEnumerable<Services>> GetServicesByBuildingId(int id)
        {
            List<Services> Model = new List<Services>();

            using (ServiceServicesClient cl = new ServiceServicesClient())
            {
                Array list_result = await cl.getServicesByBuilding_idAsync(id);
                foreach (ServicesServiceObj obj in list_result)
                {
                    Services brg = new Services()
                    {
                        id = obj.id,
                        name = obj.name,
                        type = obj.type,
                        unit = obj.unit,
                        company_name = obj.company_name
                    };

                    Model.Add(brg);
                }

                return Model;

            }
        }

        public async Task<bool> Save(IFormCollection collection)
        {
            var result = false;

            using (ServiceServicesClient cliente = new ServiceServicesClient())
            {
                result = await cliente.createServiceAsync(collection["name"], collection["type"], collection["unit"], collection["company_name"]);
            }

            return result;
        }

        public async Task<bool> Delete(int public_services_id)
        {
            var result = false;

            using (ServiceServicesClient cliente = new ServiceServicesClient())
            {
                result = await cliente.deleteServiceAsync(public_services_id);
            }

            return result;
        }

        public async Task<bool> DeleteAllService_Building(int public_services_id)
        {
            var result = false;

            using (ServiceServicesClient cliente = new ServiceServicesClient())
            {
                result = await cliente.deleteAllService_BuildingAsync(public_services_id);
            }

            return result;
        }

        public async Task<bool> Edit(IFormCollection collection, int id)
        {
            var result = false;

            using (ServiceServicesClient cliente = new ServiceServicesClient())
            {
                result = await cliente.editServiceAsync(id, collection["name"], collection["type"], collection["unit"], collection["company_name"]);
            }

            return result;
        }
    }
}
