using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entity
{
    [Table("Supplier")]
    public class Supplier
    {
        public Supplier()
        {
            Products = new HashSet<Product>();
        }
        [StringLength(128)]
        public string SupplierID { get; set; }
        [Required]
        [StringLength(11, MinimumLength = 11)]
        public string RUC { get; set; }
        [Required]
        [StringLength(100, MinimumLength = 3)]
        public string Razon { get; set; }
        [StringLength(40, MinimumLength = 7)]
        public string Email { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}
