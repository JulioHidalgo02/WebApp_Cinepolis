using WebApp_Cinepolis.Entities;

namespace WebApp_Cinepolis.Models
{
    public class DirectorModel
    {
        //Ruta del API
        public string ruta = "https://localhost:7109/";

        //Método de Mostrar todos los directores
        public List<Director>? MostrarDirectores( )
        {
            //Se utiliza la estructura HttpClient para consumir un API
            using (var client = new HttpClient())
            {
                //Se le coloca el Nombre del metodo del API
                string metodo = "api/Directores";
                //Se utiliza la siguiente linea de codigo para hacer la pedición al API
                HttpResponseMessage respuesta = client.GetAsync(ruta + metodo).Result;

                //Si el resultado es exitoso y el contenido de la respuesta es direfernte de nulo se devuelve el resultado en formato Json.
                if (respuesta.IsSuccessStatusCode && respuesta.Content != null)
                {
                    return respuesta.Content.ReadFromJsonAsync<List<Director>>().Result;
                }
                else
                {
                    //Si no se cumple se devuelve un nulo
                    return null;
                }


            }
        }
        
        //Método de Mostrar un Director en especifico
        public Director? MostrarDirector(Director director)
        {
            //Se utiliza la estructura HttpClient para consumir un API
            using (var client = new HttpClient())
            {
                //Se le coloca el Nombre del metodo del API
                string metodo = "api/Directores/"+director.Id;
                //Se utiliza la siguiente linea de codigo para hacer la pedición al API
                HttpResponseMessage respuesta = client.GetAsync(ruta + metodo).Result;

                //Si el resultado es exitoso y el contenido de la respuesta es direfernte de nulo se devuelve el resultado en formato Json.
                if (respuesta.IsSuccessStatusCode && respuesta.Content != null)
                {
                    return respuesta.Content.ReadFromJsonAsync<Director>().Result;
                }
                else
                {
                    //Si no se cumple se devuelve un nulo
                    return null;
                }


            }
        }

        //Método para Editar un Director
        public int EditarDirector(Director director)
        {
            //Se utiliza la estructura HttpClient para consumir un API
            using (var client = new HttpClient())
            {
                //Al ser un llamado PUT se le debe pasar el body para eso se utiliza la siguiente linea
                JsonContent body = JsonContent.Create(director);

                //Se le coloca el Nombre del metodo del API
                string metodo = "api/Directores/"+director.Id;

                //Si el resultado es exitoso se devuelve una bandera positiva sino negativa.
                HttpResponseMessage respuesta = client.PutAsync(ruta + metodo, body).Result;

                if (respuesta.IsSuccessStatusCode)
                {
                    return 1;
                }
                else
                {
                    return -1;
                }


            }
        }

        //Método para Agregar un  Director
        public int AgregarDirector(Director director)
        {
            //Se utiliza la estructura HttpClient para consumir un API
            using (var client = new HttpClient())
            {
                //Al ser un llamado POST se le debe pasar el body para eso se utiliza la siguiente linea
                JsonContent body = JsonContent.Create(director);

                //Se le coloca el Nombre del metodo del API
                string metodo = "Api/Directores/";

                //Si el resultado es exitoso se devuelve una bandera positiva sino negativa.
                HttpResponseMessage respuesta = client.PostAsync(ruta + metodo, body).Result;

                if (respuesta.IsSuccessStatusCode)
                {
                    return 1;
                }
                else
                {
                    return -1;
                }


            }
        }

        //Método para Eliminar un Director
        public int EliminarDirector(Director director)
        {
            //Se utiliza la estructura HttpClient para consumir un API
            using (var client = new HttpClient())
            {
                //Se le coloca el Nombre del metodo del API
                string metodo = "Api/Directores/"+director.Id;

                //Si el resultado es exitoso se devuelve una bandera positiva sino negativa.
                HttpResponseMessage respuesta = client.DeleteAsync(ruta + metodo).Result;

                if (respuesta.IsSuccessStatusCode)
                {
                    return 1;
                }
                else
                {
                    return -1;
                }


            }
        }
    }
}
