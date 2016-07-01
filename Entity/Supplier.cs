using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entity
{
    [Table("Supplier")]
    public class Supplier
    {
        [StringLength(128)]
        public string SupplierID { get; set; }

        [Required]
        [Index(IsUnique =true)]
        [StringLength(11, MinimumLength = 11)]
        public string RUC { get; set; }

        [Required]
        [Index(IsUnique = true)]
        [StringLength(100, MinimumLength = 3)]
        public string Razon { get; set; }

        [StringLength(40, MinimumLength = 7)]
        [Index(IsUnique = true)]
        public string Email { get; set; }
    }
}
