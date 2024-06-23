using System.ComponentModel.DataAnnotations;

namespace BackendAPI.Models
{
    public class ms_storage_location
    {
        [Key]
        [MaxLength(10)]
        public string location_id { get; set; }

        [MaxLength(100)]
        public string location_name { get; set; }
    }
}
