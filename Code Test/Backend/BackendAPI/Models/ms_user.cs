using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BackendAPI.Models
{
    public class ms_user
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long user_id { get; set; }

        [MaxLength(20)]
        public string user_name { get; set; }

        [MaxLength(50)]
        public string password { get; set; }

        public bool is_active { get; set; }
    }
}
