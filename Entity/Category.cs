using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entity
{
    [Table("Category")]
    public class Category
    {
        [StringLength(128)]
        public string CategoryID { get; set; }

        [Required]
        [Index(IsUnique = true)]
        [StringLength(50,MinimumLength =3)]
        public string Nombre { get; set; }
    }
}
