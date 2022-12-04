using System;
using System.Collections.Generic;
using System.Data.SQLite;

namespace firstApp.Models
{
    public class Personal_info
    {
        // get all person 
        public List<Person> GetAllPerson()
        {
            List<Person> list = new List<Person>();
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
                        int id = (int)reader["id"];
                        String first_name = (string)reader["first_name"];
                        String last_name = (string)reader["last_name"];
                        String email = (string)reader["email"];
                        string image = (string)reader["image"];
                        string country = (string)reader["country"];
                        list.Add(new Person(id, first_name, last_name, email, image, country));

                    }
                }
            }
            return list;
        }


        public Person GetPerson(int id)
        {
            SQLiteConnection con = new SQLiteConnection(@"Data Source=C:\Users\Salma\Downloads\database.db;");
            con.Open();
            Person p = new Person();

            String query = "SELECT * FROM personal_info where id= " + id;
            using (con)
            {
                SQLiteCommand cmd = new SQLiteCommand(query, con);
                SQLiteDataReader reader = cmd.ExecuteReader();
                if (cmd != null)
                {
                    using (reader)
                    {
                        while (reader.Read())
                        {
                            String first_name = (string)reader["first_name"];
                            String last_name = (string)reader["last_name"];
                            String email = (string)reader["email"];
                            string image = (string)reader["image"];
                            string country = (string)reader["country"];
                            p = new Person(id, first_name, last_name, email, image, country);

                        }
                    }
                }
                else return null;
            }

            return p;
        }


    }
}
