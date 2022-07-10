using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

// NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "Service1" en el código, en svc y en el archivo de configuración.
public class ServiceServices : IServiceServices
{
    SqlConnection con = new SqlConnection("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=tarea2;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
    public bool createService(string name, string type, string unit, string company_name)
    {
        con.Open();

        string values = "'" + name + "','" + type + "','" + unit + "','" + company_name + "'";
        SqlCommand cmd = new SqlCommand("INSERT INTO public_services(name,type,unit,company_name) VALUES(" + values + ")", con);

        SqlDataReader registros = cmd.ExecuteReader();

        con.Close();
        return true;
    }

    public bool editService(int id, string name, string type, string unit, string company_name)
    {
        con.Open();
        string values = "name = '" + name + "', type = '" + type + "', unit = '" + unit + "', company_name = '" + company_name + "' ";
        SqlCommand cmd = new SqlCommand("UPDATE public_services SET " + values + "WHERE id = " + id, con);

        SqlDataReader registros = cmd.ExecuteReader();

        con.Close();
        return true;
    }

    public bool deleteService(int id)
    {
        con.Open();
        SqlCommand cmd = new SqlCommand("DELETE FROM building_services WHERE public_services_id = " + id + "; ", con);
        cmd.ExecuteReader();

        con.Close();
        con.Open();
        SqlCommand cmd2 = new SqlCommand("DELETE FROM public_services WHERE id = " + id + "; ", con);
        cmd2.ExecuteReader();

        con.Close();
        return true;
    }

    public bool deleteAllService_Building(int public_services_id)
    {
        con.Open();

        SqlCommand cmd = new SqlCommand("DELETE FROM building_services WHERE public_services_id = " + public_services_id + "; ", con);

        SqlDataReader registros = cmd.ExecuteReader();

        con.Close();
        return true;
    }

    public IEnumerable<ServicesServiceObj> getAllServices()
    {
        List<ServicesServiceObj> list = new List<ServicesServiceObj>();

        con.Open();
        SqlCommand cmd = new SqlCommand("SELECT * FROM public_services", con);

        SqlDataReader registros = cmd.ExecuteReader();

        while (registros.Read())
        {
            ServicesServiceObj obj = new ServicesServiceObj();

            obj.id = registros.GetInt32(0);
            obj.name = registros.GetString(1);
            obj.type = registros.GetString(2);
            obj.unit = registros.GetString(3);
            obj.company_name = registros.GetString(4);

            list.Add(obj);

        }
        return list;
    }
    public ServicesServiceObj getServiceById(int id)
    {
        ServicesServiceObj obj = new ServicesServiceObj();

        con.Open();
        SqlCommand cmd = new SqlCommand("SELECT * FROM public_services WHERE id=" + id + ";", con);

        SqlDataReader registro = cmd.ExecuteReader();

        while (registro.Read())
        {
            obj.id = registro.GetInt32(0);
            obj.name = registro.GetString(1);
            obj.type = registro.GetString(2);
            obj.unit = registro.GetString(3);
            obj.company_name = registro.GetString(4);

        }
        return obj;
    }
    public IEnumerable<ServicesServiceObj> getServicesByBuilding_id(int id)
    {
        List<ServicesServiceObj> list = new List<ServicesServiceObj>();

        con.Open();

        string command = "SELECT * FROM public_services " +
        "INNER JOIN building_services ON public_services.id = building_services.public_services_id " +
        "INNER JOIN buildings ON buildings.id = building_services.building_id " +
        "WHERE buildings.id = " + id;
        SqlCommand cmd = new SqlCommand(command + ";", con);

        SqlDataReader registros = cmd.ExecuteReader();

        while (registros.Read())
        {
            ServicesServiceObj obj = new ServicesServiceObj();

            obj.id = registros.GetInt32(0);
            obj.name = registros.GetString(1);
            obj.type = registros.GetString(2);
            obj.unit = registros.GetString(3);
            obj.company_name = registros.GetString(4);

            list.Add(obj);

        }
        return list;
    }
}
