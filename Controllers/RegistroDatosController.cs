using EjercicioPresentacion.Models;
using EjercicioPresentacion.Services;
using Microsoft.AspNetCore.Mvc;

namespace EjercicioPresentacion.Controllers
{
    public class RegistroDatosController : Controller
    {
        private readonly IRegistroDatosService _registroDatosService;

        public RegistroDatosController(IRegistroDatosService registroDatosService)
        {
            _registroDatosService = registroDatosService;
        }

        [HttpPost]
        public IActionResult Registrar(RegistroDatos datos)
        {
            _registroDatosService.RegistrarDatos(datos);
            return RedirectToAction("Index", "Home"); // Redirigir a la página principal u otra página después del registro
        }

        public IActionResult MostrarRegistro()
        {
            return View(); // Devuelve la vista correspondiente al formulario de registro
        }

    }
}
