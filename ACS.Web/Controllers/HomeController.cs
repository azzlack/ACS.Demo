namespace ACS.Web.Controllers
{
    using System.Web.Mvc;

    public class HomeController : Controller
    {
        [AllowAnonymous]
        public ActionResult Index()
        {
            return View();
        } 
    }
}