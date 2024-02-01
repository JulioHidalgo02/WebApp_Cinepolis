using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApp_Cinepolis.Entities
{
    public class Sala
    {
        
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdSala { get; set; }
        public int CapacidadPersonas { get; set; }

        public int IdCine { get; set; }
        [ForeignKey("IdCine")]

        public virtual Cine cine { get; set; }

        public ICollection<Pelicula> Peliculas { get; set;}

    }
}
