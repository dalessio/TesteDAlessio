using Microsoft.AspNetCore.Mvc;

namespace TesteDAlessio.UI.WebApp.Controllers
{
    public class TesteDAlessioController : Controller
    {
        public bool isLoginValid = false;

        public TesteDAlessioController()
        {
            isLoginValid = true;
        }
    }
}
