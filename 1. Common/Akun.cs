using Akhi_Okhee._2._Database;
using MySql.Data.MySqlClient;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;

namespace Akhi_Okhee._1._Common
{
    public class Akun
    {
        public static string table = "akun";
        public static string k_id = "id";
        public static string k_username = "username";
        public static string k_nama = "nama";
        public static string k_status = "status";
        public static string k_password = "passwod";

        private string id;
        private string username;
        private string nama;
        private int status;
        private string status_string;
        private string password;

        public string Username { get => username; set => username = value; }
        public string Nama { get => nama; set => nama = value; }
        public string Password { get => password; set => password = value; }
        public int Status { get => status;
            set
            {
                status = value;
                if (value == 0)
                {
                    status_string = "Super Admin";
                }
                else if(value == 1)
                {
                    status_string = "Admin";
                }
                else if (value == 2)
                {
                    status_string = "Pengguna";
                }
            } 
        }
        public string Status_string { get => status_string; set => status_string = value; }
        public string Id { get => id; set => id = value; }

        private String insert_query = "INSERT INTO {0} ({1}, {2}, {3}, {4}, {5}) VALUES "
            + "(@{1}, @{2}, @{3}, @{4}, @{5});";

        private String update_query = "UPDATE {0} SET {2} = @{2}, {3} = @{3}, {4} = @{4}, {5} = @{5} "
            + "WHERE {1} = @{1};";

        private String delete_query = "DELETE FROM {0} WHERE {1} = '{2}';";

        private String select_query = "SELECT * FROM {0} WHERE {1} = {1};";

        public static string getCreateQuery()
        {
            string create = "CREATE TABLE " + table + " ( "
                + k_id + " varchar(80) NOT NULL PRIMARY KEY, "
                + k_username + " varchar(80) UNIQUE NOT NULL, "
                + k_nama + " varchar(256) UNIQUE NOT NULL , "
                + k_status + " varchar(1) NOT NULL , "
                + k_password + " varchar(256) NOT NULL  "
                + ") ENGINE=InnoDB;";
            return create;
        }

        public static string getDropQuery()
        {
            string drop = String.Format("DROP TABLE IF EXISTS {0};", table);
            Console.WriteLine(drop);
            return drop;
        }

        public void InsertData(MySqlCommand cmd)
        {
            String insert_query_populate = String.Format(insert_query, table
                , k_id, k_username, k_nama, k_status, k_password);
            cmd.CommandText = insert_query_populate;
            cmd.Parameters.AddWithValue("@" + k_id, Id);
            cmd.Parameters.AddWithValue("@" + k_username, Username);
            cmd.Parameters.AddWithValue("@" + k_nama, Nama);
            cmd.Parameters.AddWithValue("@" + k_status, status);
            cmd.Parameters.AddWithValue("@" + k_password, password);
            cmd.ExecuteNonQuery();

        }

        public void UpdateData(MySqlCommand cmd)
        {
            String update_query_populate = String.Format(update_query, table
                , k_id, k_username, k_nama, k_status, k_password);
            /*Console.WriteLine(update_query_populate);
            Console.WriteLine(id);
            Console.WriteLine(Nama);*/
            cmd.CommandText = update_query_populate;
            cmd.Parameters.AddWithValue("@" + k_id, Id);
            cmd.Parameters.AddWithValue("@" + k_username, Username);
            cmd.Parameters.AddWithValue("@" + k_nama, Nama);
            cmd.Parameters.AddWithValue("@" + k_status, status);
            cmd.Parameters.AddWithValue("@" + k_password, password);
            cmd.ExecuteNonQuery();
        }

        public void DeleteData(MySqlCommand cmd)
        {
            String delete_query_populate = String.Format(delete_query, table, k_id, Id);
            cmd.CommandText = delete_query_populate;
            cmd.ExecuteNonQuery();
            Console.WriteLine(delete_query_populate);
        }
        public static List<Akun> getAkun()
        {
            List<Akun> returnValue = new List<Akun>();
            Setting setting = new Setting();
            returnValue.Add(setting.Admin);
            String select_query_populate = "SELECT * FROM "+table;
            try
            {
                Connect conn = new Connect();
                MySqlConnection connect = conn.getConection();
                connect.Open();
                using (MySqlCommand cmd = new MySqlCommand(select_query_populate, connect))
                {
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Console.WriteLine("Populate Akun");
                            Akun itemAkun = new Akun();
                            itemAkun.Id = (String)reader[k_id];
                            itemAkun.Username = (String)reader[k_username];
                            itemAkun.Nama = (String)reader[k_nama];
                            itemAkun.Status = int.Parse((String)reader[k_status]);
                            itemAkun.Password = (String)reader[k_password];
                            returnValue.Add(itemAkun);
                        }
                    }
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine("Akun get Akun");
                Console.WriteLine("Akun get Akun : " + ex.Message);
                Console.WriteLine("Akun get Akun : " + ex.StackTrace);
            }
           
            return returnValue;
        }

    }
}
