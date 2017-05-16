using System.Web.Mvc;

namespace DistributedPetProject.Controllers
{
    public class HomeController : Controller
    {
        // disabled as of now
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            return View();
        }

        public ActionResult Contact()
        {
            return View();
        }

        // To be implemented
        public ActionResult Dashboard()
        {
            return View();
        }
    }
}