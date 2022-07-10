namespace Tarea2v1.Interfaces
{
    public interface IBuilding
    {
        public int id { get; set; }
        public int capacity { get; set; }
        public string register_date { get; set; }
        public string final_date { get; set; }
        public string province { get; set; }
        public string canton { get; set; }
        public string disctrict { get; set; }
        public string building_type { get; set; }
        public string building_name { get; set; }


       

    }
}
