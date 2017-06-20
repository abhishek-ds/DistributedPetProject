using System.Web.Mvc;
using DistributedPetProject.Models;
using System.Linq;
using System.Data.SqlClient;
using System;

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

        public ActionResult Dashboard()
        {
            return View();
        }

        public ActionResult CreateForm()
        {
            return View();
        }

        public ActionResult GetData()
        {
            using (ModifiedPetDBEntities pde = new ModifiedPetDBEntities())
            {
                var petData = pde.CustomTables.OrderBy(a => a.DateTime).ToList();
                return Json(new { data = petData }, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public ActionResult AddForm(FormCollection form)
        {
            var title = form["title"];
            var price = Convert.ToDecimal(form["price"]);
            var loc = form["location"];
            var category = form["category"];
            var desc = form["desc"];
            Random rnd = new Random();
            int rand = rnd.Next();
            DateTime now = DateTime.Now;
            string timeStamp = now.ToString();
            SqlConnection con = new SqlConnection();
            con.ConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;
                          AttachDbFilename=|DataDirectory|\PetDB.mdf;
                          Integrated Security=True;
                          Connect Timeout=30";
            SqlCommand cmd = new SqlCommand();
            con.Open();
            cmd.Connection = con;
            cmd.CommandText = "Insert into CustomTable(Id, Title, Category, Price, Location, Description, DateTime)" +
                              "Values(" + rand + ",'" + title + "','" + category + "'," + price + ",'" + loc + "','" + desc + "','" + timeStamp + "')";
            cmd.ExecuteNonQuery();
            con.Close();
            return RedirectToAction("Dashboard", "Home");
        }

        [HttpPost]
        public ActionResult AddNew(FormCollection form)
        {
            Random rnd = new Random();
            int rand = rnd.Next();
            int trans = rnd.Next();
            ViewBag.TransactionID = trans;
            DateTime now = DateTime.Now;
            string timeStamp = now.ToString();
            SqlConnection con = new SqlConnection();
            con.ConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;
                          AttachDbFilename=|DataDirectory|\PetDB.mdf;
                          Integrated Security=True;
                          Connect Timeout=30";
            SqlCommand cmd = new SqlCommand();
            con.Open();
            cmd.Connection = con;
            cmd.CommandText = "Insert into TransactionTable(Id, TransactionNo, DateTime)" + "Values(" + rand + "," + trans + ",'" + timeStamp + "')";
            try
            {
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

            }
            con.Close();
            return RedirectToAction("RedirectToDashboard", "Home", new { value = trans });

        }

        public ActionResult RedirectToDashboard(string value)
        {
            ViewBag.Value = value;
            if(value == null)
            {
              return RedirectToAction("Dashboard", "Home");
            }
            return View();
        }
    }
}