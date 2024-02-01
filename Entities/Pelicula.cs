using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApp_Cinepolis.Entities
{
    public class Pelicula
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdPelicula { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public string Genero { get; set; } = string.Empty;
            
        public string Director { get; set; } = string.Empty;
        public string Resumen { get; set; } = string.Empty;         

        public string Actores { get; set; } = string.Empty;

        public string Acciones {  get; set; } = string.Empty;

        public int IdSala { get; set; }
        [ForeignKey("IdSala")]
        public virtual Sala sala { get; set; }



    }

    
}
