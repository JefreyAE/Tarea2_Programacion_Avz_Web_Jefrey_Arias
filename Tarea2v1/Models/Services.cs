
using Tarea2v1.DataServices;
using Tarea2v1.DataServices.ServiceServices;
using Tarea2v1.Interfaces;

namespace Tarea2v1.Models
{
    public class Services: IServices
    {
		public int id { get; set; }
		public string name { get; set; }
		public string type { get; set; }
		public string unit { get; set; }
		public string company_name { get; set; }

		public Services()
        {
			this.name = "";
			this.type = "";
			this.unit = "";
			this.company_name = "";
        }

        public async Task<IEnumerable<Services>> GetAllServices()
        {
            IEnumerable<Services> list = new List<Services>();

            ServiceServicesHandler originService = new ServiceServicesHandler();
            list = await originService.GetAllServices(new ServiceServiceWCF());

            return list;
        }

        public async Task<Services> GetServicesByID(int id)
        {
            ServiceServicesHandler originService = new ServiceServicesHandler();
            Services service = await originService.GetServcicesById(new ServiceServiceWCF(), id);

            return service;
        }

        public async Task<IEnumerable<Services>> GetServicesByBuildingId(int id)
        {
            IEnumerable<Services> Model = new List<Services>();

            ServiceServicesHandler originService = new ServiceServicesHandler();
            Model = await originService.GetServicesByBuildingId(new ServiceServiceWCF(), id);

            return Model;
        }

        public async Task<Boolean> Save(IFormCollection collection)
        {
            var result = false;

            ServiceServicesHandler originService = new ServiceServicesHandler();
            result = await originService.Save(new ServiceServiceWCF(), collection);

            return result;
        }

        public async Task<Boolean> Edit(IFormCollection collection, int id)
        {
            var result = false;

            ServiceServicesHandler originService = new ServiceServicesHandler();
            result = await originService.Edit(new ServiceServiceWCF(), collection, id);

            return result;
        }

        public async Task<Boolean> Delete(int id)
        {
            var result = false;

            ServiceServicesHandler originService = new ServiceServicesHandler();
            result = await originService.Delete(new ServiceServiceWCF(), id);

            return result;
        }

        public async Task<Boolean> DeleteAllServices_Building(int id)
        {
            var result = false;

            ServiceServicesHandler originService = new ServiceServicesHandler();
            result = await originService.DeleteAllService_Building(new ServiceServiceWCF(), id);

            return result;
        }
    }
}
