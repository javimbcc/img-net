using Microsoft.AspNetCore.Mvc;
using Npgsql;
using SubirImagenesAbbdd.Models;
using SubirImagenesAbbdd.Models.Consultas;
using SubirImagenesAbbdd.Models.Conversiones;
using System.Diagnostics;
using System.Web;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
namespace SubirImagenesAbbdd.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private readonly IConfiguration _config;

        public HomeController(ILogger<HomeController> logger, IConfiguration config)
        {
            _logger = logger;
            _config = config;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(IFormFile name)
        {
            //Declaramos una instancia de nuestra clase que convierte la imagen a array de bytes
            ConvertirIMGaBYTE conv = new ConvertirIMGaBYTE();
            //Usamos el metodo que tenemos para convertir la imagen a array de bytes
            Console.WriteLine("CONVIERTO IMAGEN A ARRAY DE BYTES");
            String img = conv.Convertir(name).ToString();
            Console.WriteLine("IMAGEN CONVERTIDA");
            //Ahora la insertamos en la base de datos como un string
            Console.WriteLine("INSERTANDO IMAGEN EN BASE DE DATOS");
            ConsultasPostgreSQL.insertarImagen(_config, img);
            Console.WriteLine("IMAGEN INSERTADA CON EXITO");
            return View();
        }

    }
}