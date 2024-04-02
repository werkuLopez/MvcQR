using Microsoft.AspNetCore.Mvc;
using MvcQR.Helpers;

namespace MvcQR.Controllers
{
    public class QRController : Controller
    {
        public HelperQR helper;

        public QRController(HelperQR helper)
        {
            this.helper = helper;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(string texto)
        {
            if (texto == null)
            {
                ViewData["mensaje"] = "Introduzca un texto";
                return View();
            }
            string qr = await this.helper.GenerarQR(texto);
            ViewData["qr"] = qr;

            return View();
        }
    }
}
