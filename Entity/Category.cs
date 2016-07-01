using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    [Table("Category")]
    public class Category
    {
        [StringLength(128)]
        public string CategoryID { get; set; }
        [Required]
        [StringLength(50,MinimumLength =3)]
        public string Nombre { get; set; }
    }
}
