using System.ComponentModel.DataAnnotations;

namespace CRUD_Operations_in_WebAPI.Models
{
    public class CRUDOperationsModel
    {
        [Required]
        public string Column1 { get; set; } = "";
        [Required]
        public decimal Column2 { get; set; }
        [Required]
        public DateTime Column3 { get; set; }
        [Required]
        public string Column4 { get; set; } = "";
    }
}
