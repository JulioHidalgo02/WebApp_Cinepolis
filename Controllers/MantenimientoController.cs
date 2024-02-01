using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApp_Cinepolis.Context;
using WebApp_Cinepolis.Entities;

namespace WebApp_Cinepolis.Controllers
{
    public class MantenimientoController : Controller

    {
        //Se crea una variable del contexto para poder crear la conexión con la BD
        private readonly CinepolisContext _context;
        public MantenimientoController(CinepolisContext cinepolisContext)
        {
            _context = cinepolisContext; 
        }

        //Acciòn para ver los cines disponibles
        [HttpGet]
        public async Task<IActionResult> Cines()
        {
            //Traer los cines disponibles de la BD
            var cines = await _context.cines.ToListAsync();
            return View(cines);
        }

        //Acciòn para ver las peliculas disponibles por cina
        [HttpGet]
        public async Task<IActionResult> Peliculas(int id)
        {
            //Obtengo primero las salas para utilizar el id para poder ver las peliculas
            var sala = await _context.salas.Where(x => x.IdCine == id).ToListAsync();

            //Obtengo el cine que escogió el cliente
            var cine = await _context.cines.Where(x => x.Id == id).FirstOrDefaultAsync();
            //Lo guardo en una variable de sesión
            HttpContext.Session.SetString("Cine", cine.Nombre);
            
            //Creo una lista de peliculas
            List<Pelicula> peliculas = new List<Pelicula>();

            //Relleno la lista de las peliculas haciendo consultas a la base de datos con los datos que hacen match
            foreach (var pelicula in sala)
            {
                var db = await _context.peliculas.Where(x => x.IdSala == pelicula.IdSala).FirstOrDefaultAsync();
                peliculas.Add(db);
            }

            //Retorno la vista con las peliculas
            return View(peliculas);
        }

        //Acción para ver los horarios disponibles
        [HttpGet]
        public async Task<IActionResult> Horarios(int id)
        {
            //Traer los horarios de la bd
            var horario = await _context.horarios.Where(x => x.IdPelicula == id).ToListAsync();

            //Seleccionar pelicula que escogió el usuario y guardarlo en variable de sesión
            var pelicula = await _context.peliculas.Where(x => x.IdPelicula ==  id).FirstOrDefaultAsync();
            HttpContext.Session.SetString("Pelicula", pelicula.Nombre);

            //Seleccionar sala que escogió el usuario y guardarlo en variable de sesión
            var sala = await _context.salas.Where(x => x.IdSala == pelicula.IdSala).FirstOrDefaultAsync();
            HttpContext.Session.SetString("Sala", sala.IdSala.ToString());

            return View(horario);
        }

        //Acción para ver los combos disponibles 
        [HttpGet]
        public async Task<IActionResult> Combos()
        {
            //Traer los combos de la BD
            var combos = await _context.combos.ToListAsync();

            return View(combos);
        }

        //Acción para ver los detalles de los combos
        [HttpGet]
        public async Task<IActionResult> DetalleCombos(int id)
        {
            //Traer los detalles del Combo de la BD
            var detalle = await _context.Producto.Where(x => x.IdCombo == id).ToListAsync();

            //Seleccionar el combo que escogió el usuario y guardarlo en variable de sesión
            var combo = await _context.combos.Where(x => x.idCombo == id).FirstOrDefaultAsync();
            HttpContext.Session.SetString("Combo", combo.idCombo.ToString());

            return View(detalle);
        }


        //Acción de finalización del sistema
        [HttpGet]
        public async Task<IActionResult> Agradecimiento()
        {
            Agradecimiento obj = new Agradecimiento();
            obj.Cine = HttpContext.Session.GetString("Cine");
            obj.Pelicula = HttpContext.Session.GetString("Pelicula");
            obj.Sala = HttpContext.Session.GetString("Sala");
            obj.Combo = HttpContext.Session.GetString("Combo");
            return View(obj);
        }


    }
}
