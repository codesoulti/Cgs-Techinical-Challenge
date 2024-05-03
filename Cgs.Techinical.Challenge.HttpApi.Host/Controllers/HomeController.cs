using Microsoft.AspNetCore.Mvc;

namespace Cgs.Techinical.Challenge.HttpApi.Host.Controllers
{
    public class HomeController : ControllerBase
    {
        public ActionResult Index()
        {
            return Redirect("~/swagger");
        }
    }

}
