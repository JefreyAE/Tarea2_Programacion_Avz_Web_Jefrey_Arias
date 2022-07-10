using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

// NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "Service1" en el código, en svc y en el archivo de configuración.
public class BuildingService : IBuildingService
{
	SqlConnection con = new SqlConnection("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=tarea2;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");

    public bool addService(int service_id, int building_id)
    {
		con.Open();
		string values = service_id + "," + building_id ;
		SqlCommand cmd = new SqlCommand("INSERT INTO building_services(public_services_id, building_id) VALUES(" + values + ")", con);

		SqlDataReader registros = cmd.ExecuteReader();

		con.Close();
		return true;
	}

	public bool deleteService_Building(int public_services_id, int building_id)
	{
		con.Open();

		SqlCommand cmd = new SqlCommand("DELETE FROM building_services WHERE public_services_id = " + public_services_id + " AND building_id = " + building_id + "; ", con);

		SqlDataReader registros = cmd.ExecuteReader();

		con.Close();
		return true;
	}

	public bool deleteAllService_Building(int building_id)
	{
		con.Open();

		SqlCommand cmd = new SqlCommand("DELETE FROM building_services WHERE building_id = " + building_id + "; ", con);

		SqlDataReader registros = cmd.ExecuteReader();

		con.Close();
		return true;
	}

	public bool deleteBuilding(int id)
	{
		con.Open();

		SqlCommand cmd = new SqlCommand("DELETE FROM buildings WHERE id = " + id + "; ", con);

		SqlDataReader registros = cmd.ExecuteReader();

		con.Close();
		return true;
	}

	public bool createBuilding(int capacity, string register_date, string final_date, string province, string canton, string disctrict, string bulding_type, string bulding_name)
	{
		con.Open();
		string values = capacity + ",'" + register_date + "','" + final_date + "','" + province + "','" + canton + "','" + disctrict + "','" + bulding_type + "','" + bulding_name + "'";
		SqlCommand cmd = new SqlCommand("INSERT INTO buildings(capacity,register_date,final_date,province,canton,district,bulding_type, building_name) VALUES("+values+")", con);

		SqlDataReader registros = cmd.ExecuteReader();

		con.Close();
		return true;
	}

	public bool editBuilding(int id, int capacity, string register_date, string final_date, string province, string canton, string disctrict, string bulding_type, string bulding_name)
	{
		con.Open();
		string values = "capacity = " + capacity + ", register_date = '" + register_date + "', final_date = '" + final_date + "', province = '" + province + "', canton = '" + canton + "', district = '" + disctrict + "', bulding_type = '" + bulding_type + "', building_name = '" + bulding_name + "' ";
		SqlCommand cmd = new SqlCommand("UPDATE buildings SET " + values + "WHERE id = " + id, con);

		SqlDataReader registros = cmd.ExecuteReader();

		con.Close();
		return true;
	}

	public BuildingServiceObj getBuilding(int value)
    {
		BuildingServiceObj obj = new BuildingServiceObj();

		con.Open();
		SqlCommand cmd = new SqlCommand("SELECT * FROM buildings WHERE id="+value+";", con);

		SqlDataReader registro = cmd.ExecuteReader();

		while (registro.Read())
		{
			obj.id = registro.GetInt32(0);
			obj.capacity = registro.GetInt32(1);
			obj.register_date = registro.GetString(2);
			obj.final_date = registro.GetString(3);
			obj.province = registro.GetString(4);
			obj.canton = registro.GetString(5);
			obj.disctrict = registro.GetString(6);
			obj.building_type = registro.GetString(7);
			obj.building_name = registro.GetString(8);
		}
		return obj;

	}	

    public IEnumerable<BuildingServiceObj> getList()
    {
        List<BuildingServiceObj> list = new List<BuildingServiceObj>();

		con.Open();
		SqlCommand cmd = new SqlCommand("SELECT * FROM buildings", con);

		SqlDataReader registros = cmd.ExecuteReader();

        while (registros.Read())
        {
			BuildingServiceObj obj = new BuildingServiceObj();

			obj.id = registros.GetInt32(0);
			obj.capacity = registros.GetInt32(1);
			obj.register_date = registros.GetString(2);
			obj.final_date = registros.GetString(3);
			obj.province = registros.GetString(4);
			obj.canton = registros.GetString(5);
			obj.disctrict = registros.GetString(6);
			obj.building_type = registros.GetString(7);
			obj.building_name = registros.GetString(8);

			list.Add(obj);

		}
		return list;
    }

	/*
	public CompositeType GetDataUsingDataContract(CompositeType composite)
	{
		if (composite == null)
		{
			throw new ArgumentNullException("composite");
		}
		if (composite.BoolValue)
		{
			composite.StringValue += "Suffix";
		}
		return composite;
	}

	public string GetData(int value)
	{
		return string.Format("You entered: {0}", value);
	}*/
}
