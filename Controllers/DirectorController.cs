using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using WebApp_Cinepolis.Entities;
using WebApp_Cinepolis.Models;

namespace WebApp_Cinepolis.Controllers
{
    public class DirectorController : Controller
    {
        //Instacia al Modelo de Director
        DirectorModel modelo = new DirectorModel();

        //Acción para mostrar los directores
        [HttpGet]
        public IActionResult MostrarDirectores()
        {
            try
            {
                //Se consulta al método en el modelo para mostrar los directores y se retorna a la vista con los datos
                var resultado = modelo.MostrarDirectores();
                return View(resultado);
            }
            catch (Exception e)
            {
                //En caso de que no funcione se retorna una excepción con el mensaje.
                return BadRequest(e.Message);
            }
        }

        //Acción para mostrar un director en especifico
        [HttpGet]
        public IActionResult MostrarDirector(int id)
        {
            //Se crea un instacia del objeto Director porque es necesario para el metodo en el modelo
            Director director = new Director();
            director.Id = id;
            try
            {
                //Se realiza la consulta al modelo y se retorna a la vista con la información del director
                var resultado = modelo.MostrarDirector(director);
                return View(resultado);
            }
            catch (Exception e)
            {
                //En caso de que no funcione se retorna una excepción con el mensaje.
                return BadRequest(e.Message);
            }
        }

        //Acción para eliminar un Director
        [HttpGet]
        public IActionResult EliminarDirector(int id)
        {
            //Se crea un instacia del objeto Director porque es necesario para el metodo en el modelo
            Director director = new Director();
            director.Id = id;
            try
            {
                //Se realiza la acción en el modelo y se retorna a la vista de Directores
                var resultado = modelo.EliminarDirector(director);
                return RedirectToAction("MostrarDirectores", "Director");
            }
            catch (Exception e)
            {
                //En caso de que no funcione se retorna una excepción con el mensaje.
                return BadRequest(e.Message);
            }
        }

        //Acción de ingresar a la vista Editar Director
        [HttpGet]
        public IActionResult EditarDirector(int id)
        {
            //Se crea un instacia del objeto Director porque es necesario para el metodo en el modelo
            Director obj = new Director() { Id = id };
            //Se solicita la información del director y se retorna a la vista con esta información
            var director = modelo.MostrarDirector(obj);

            return View(director);
        }

        //Acción de Editar Director
        [HttpPost]
        public IActionResult EditarDirector(Director director)
        {
            try
            {
                //Desde la vista viene cargada la información y se pasa atravez del metodo Editar en el Modelo
                var resultado = modelo.EditarDirector(director);
                //Si el resulta retorna un 1 significa que se realizó el cambio correctamente
                if (resultado == 1)
                {
                    return RedirectToAction("MostrarDirectores", "Director");
                }
                else
                {
                    //En caso de que no funcione se retorna a la misma vista de editar 
                    return RedirectToAction("EditarDirector", "Director");
                }
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        //Acción de ingresar a la vista de Agregar Director
        [HttpGet]
        public IActionResult AgregarDirector()
        {

            return View();
        }

        [HttpPost]
        public IActionResult AgregarDirector(Director director)
        {
            try
            {
                //Desde la vista viene cargada la información y se pasa atravez del metodo Agregar en el Modelo
                var resultado = modelo.AgregarDirector(director);
                //Si el resulta retorna un 1 significa que se realizó el cambio correctamente
                if (resultado == 1)
                {
                    return RedirectToAction("MostrarDirectores", "Director");
                }
                else
                {
                    //En caso de que no funcione se retorna a la misma vista de Agregar 
                    return RedirectToAction("AgregarDirector", "Director");
                }
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
