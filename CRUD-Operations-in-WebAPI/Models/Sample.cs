using System.ComponentModel.DataAnnotations;

namespace CRUD_Operations_in_WebAPI.Models
{
    public class Sample
    {
        public int id { get; set; }
        public string Column1 { get; set; } = "";
        public decimal Column2 { get; set; }
        public DateTime Column3 { get; set; }
        public string Column4 { get; set; } = "";
        public DateTime Create_Date { get; set; }
    }
}
