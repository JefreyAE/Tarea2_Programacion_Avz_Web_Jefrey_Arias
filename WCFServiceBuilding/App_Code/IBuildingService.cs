using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

// NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de interfaz "IService1" en el código y en el archivo de configuración a la vez.
[ServiceContract]
public interface IBuildingService
{

	[OperationContract]
	BuildingServiceObj getBuilding(int value);

	[OperationContract]
	IEnumerable<BuildingServiceObj> getList();

	[OperationContract]
	bool createBuilding(int capacity, string register_date, string final_date, string province, string canton, string disctrict, string bulding_type, string bulding_name);

	[OperationContract]
	bool editBuilding(int id, int capacity, string register_date, string final_date, string province, string canton, string disctrict, string bulding_type, string bulding_name);

	[OperationContract]
	bool addService(int service_id, int building_id);
	[OperationContract]
	bool deleteBuilding(int id);
	[OperationContract]
	bool deleteService_Building(int public_services_id, int building_id);
	[OperationContract]
	bool deleteAllService_Building(int building_id);

}

// Utilice un contrato de datos, como se ilustra en el ejemplo siguiente, para agregar tipos compuestos a las operaciones de servicio.
[DataContract]
public class BuildingServiceObj
{
	[DataMember]
	public int id { get; set; }
	[DataMember]
	public string building_name { get; set; }
	[DataMember]
	public int capacity { get; set; }
	[DataMember]
	public string register_date { get; set; }
	[DataMember]
	public string final_date { get; set; }
	[DataMember]
	public string province { get; set; }
	[DataMember]
	public string canton { get; set; }
	[DataMember]
	public string disctrict { get; set; }
	[DataMember]
	public string building_type { get; set; }

	
}

public class CompositeType
{
	bool boolValue = true;
	string stringValue = "Hello ";

	[DataMember]
	public bool BoolValue
	{
		get { return boolValue; }
		set { boolValue = value; }
	}

	[DataMember]
	public string StringValue
	{
		get { return stringValue; }
		set { stringValue = value; }
	}
}
