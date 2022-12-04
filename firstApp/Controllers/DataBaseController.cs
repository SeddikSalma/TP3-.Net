using firstApp.Models;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Diagnostics;
using System.Web.Mvc;

namespace firstApp.Controllers
{
    public class DataBaseController : Controller
    {
        // GET: DataBase
        //
        public ActionResult Connect()
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
            return null;
        }
        public ActionResult Persons()
        {
            Personal_info p = new Personal_info();
            List<Person> l = p.GetAllPerson();
            return View(l);
        }
        public ActionResult onePerson(int id)
        {
            Personal_info p = new Personal_info();

            Person per = p.GetPerson(id);
            if (per != null)
            {
                return View(per);
            }
            return View();
        }

        [HttpGet]
        public ActionResult search()
        {
            ViewBag.notFound = false;
            return View();
        }

        [HttpPost]
        public ActionResult search(String first_name, String country)
        {
            Debug.WriteLine("salma");
            Personal_info p = new Personal_info();
            List<Person> l = p.GetAllPerson();
            foreach (Person person in l)
            {
                if (person.first_name == first_name && person.country == country)
                {
                    return Redirect("onePerson/"+person.id.ToString());

                }
            }
                return View(l);
        }
    }
}