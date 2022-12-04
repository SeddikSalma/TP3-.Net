using System;
using System.Data.SQLite;
using System.Diagnostics;
using System.Web.Mvc;

namespace firstApp.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult test()

        {
            SQLiteConnection con = new SQLiteConnection(@"Data Source=C:\Users\Salma\Downloads\database.db;");
            con.Open();


            String query = "SELECT * FROM personal_info ";
            using (con)
            {
                SQLiteCommand cmd = new SQLiteCommand(query, con);
                SQLiteDataReader reader = cmd.ExecuteReader();
                using (reader)
                {

                    while (reader.Read())
                    {
                        String first_name = (string)reader["first_name"];
                        String last_name = (string)reader["last_name"];
                        String email = (string)reader["email"];
                        Debug.WriteLine("{0} {1} {2}", email, first_name, last_name);
                        string image = (string)reader["image"];
                        string country = (string)reader["country"];
                        Debug.WriteLine("{0} {1}", image, country);

                    }
                }
            }
            return View();
        }
        public ActionResult Index()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}