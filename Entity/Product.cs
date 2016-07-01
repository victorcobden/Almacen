using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    [Table("Product")]
    public class Product
    {
        [StringLength(128)]
        public string ProductID { get; set; }
        [Required]
        [StringLength(70, MinimumLength = 3)]
        public string Nombre { get; set; }
        [StringLength(100, MinimumLength = 3)]
        public string Descripcion { get; set; }
        [Required]
        public int Cantidad { get; set; }
        [Required]
        public string CategoryID { get; set; }
        public virtual Category Category { get; set; }
        [Required]
        public string SupplierID { get; set; }
        public virtual Supplier Supplier { get; set; }
    }
}
