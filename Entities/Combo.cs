using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace WebApp_Cinepolis.Entities
{
    public class Combo
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int idCombo { get; set; }

        [Column(TypeName = "decimal(18,4)")]
        public decimal precio { get; set; }

        public virtual ICollection<Producto> Productos { get; set; }
    }
}
