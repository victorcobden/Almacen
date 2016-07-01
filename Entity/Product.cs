using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entity
{
    [Table("Product")]
    public class Product
    {
        [StringLength(128)]
        public string ProductID { get; set; }

        [Required]
        [Index(IsUnique = true)]
        [StringLength(70, MinimumLength = 3)]
        public string Nombre { get; set; }

        [StringLength(100, MinimumLength = 3)]
        public string Descripcion { get; set; }

        [Required]
        public int Cantidad { get; set; }

        public string CategoryID { get; set; }

        public virtual Category Category { get; set; }

        public string SupplierID { get; set; }

        public virtual Supplier Supplier { get; set; }
    }
}
