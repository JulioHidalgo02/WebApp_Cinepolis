using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApp_Cinepolis.Entities
{
    public class Producto
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdProducto { get; set; }
        public string Nombre { get; set;}

        [Column(TypeName = "decimal(18,4)")]
        public decimal precio { get; set; }

        public int IdCombo {  get; set; }

        [ForeignKey("IdCombo")]

        public virtual Combo Combo { get; set; }

    }
}
