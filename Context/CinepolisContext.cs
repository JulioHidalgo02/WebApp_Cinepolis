using Microsoft.EntityFrameworkCore;
using WebApp_Cinepolis.Entities;

namespace WebApp_Cinepolis.Context
{
    public class CinepolisContext : DbContext
    {
        //Construtor de la clase del Contexto de la base de datos con sus instancias
        public CinepolisContext(DbContextOptions<CinepolisContext> options) 
            : base(options) 
        {

        }
        //Instancias
        public DbSet<Cine> cines { get; set; }
        public DbSet<Combo> combos { get; set; }

        public DbSet<Producto> Producto { get; set; }
        public DbSet<Horario> horarios { get; set; }
        public DbSet<Pelicula> peliculas { get; set; }

        public DbSet<Sala> salas { get; set; }
    }
}
