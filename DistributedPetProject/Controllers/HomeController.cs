using System;
using System.Data.SqlClient;
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
            //need to add database name passing connection string
            string connectionString = "";
            SqlConnection con = new SqlConnection(connectionString);
            try
            {
                SqlCommand sqlCommand = new SqlCommand("slect * from dashboardtable");
                con.Open();
                //map the data to models
                //modelsomething = sqlCommand.ExecuteReader();
            }
            catch
            {
                Console.WriteLine("error");
            }
            finally
            {
                con.Close();
            }

            return View();
        }
    }
}