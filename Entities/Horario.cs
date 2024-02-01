using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApp_Cinepolis.Entities
{
    public class Horario
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdHorario {  get; set; } 
        public string Horarios { get; set; } = string.Empty;
        
        public int IdPelicula { get; set; }
        [ForeignKey("IdPelicula")]
        public virtual Pelicula Pelicula { get; set; }


    }
}
