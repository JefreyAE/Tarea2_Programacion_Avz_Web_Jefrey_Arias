using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;


// NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de interfaz "IService1" en el código y en el archivo de configuración a la vez.
[ServiceContract]
public interface IServiceServices
{
	[OperationContract]
	ServicesServiceObj getServiceById(int id);
	[OperationContract]
	IEnumerable<ServicesServiceObj> getServicesByBuilding_id(int id);
	[OperationContract]
	IEnumerable<ServicesServiceObj> getAllServices();
	[OperationContract]
	bool createService(string name, string type, string unit, string company_name);
}

// Utilice un contrato de datos, como se ilustra en el ejemplo siguiente, para agregar tipos compuestos a las operaciones de servicio.
[DataContract]
public class ServicesServiceObj
{
	[DataMember]
	public int id { get; set; }
	[DataMember]
	public string name { get; set; }
	[DataMember]
	public string type { get; set; }
	[DataMember]
	public string unit { get; set; }
	[DataMember]
	public string company_name { get; set; }

}
