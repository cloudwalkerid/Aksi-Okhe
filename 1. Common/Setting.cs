using Akhi_Okhee._2._Database;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;

namespace Akhi_Okhee._1._Common
{
    public class Setting
    {
        private Akun admin;
        private string ip_server;
        private string database;
        private string db_username;
        private string db_pwd;

        public string Ip_server { get => ip_server; set => ip_server = value; }
        public string Database { get => database; set => database = value; }
        public Akun Admin { get => admin; set => admin = value; }
        public string Db_username { get => db_username; set => db_username = value; }
        public string Db_pwd { get => db_pwd; set => db_pwd = value; }

        public Setting()
        {
            Admin = new Akun();
            using (ResXResourceSet resx = new ResXResourceSet(Connect.folderAppData + "//Res1.resx"))
            {
                Admin.Username = resx.GetString("username_1");
                Admin.Password = resx.GetString("password_1");
                Admin.Nama = resx.GetString("nama_1");
                Ip_server = resx.GetString("ip_server");
                Database = resx.GetString("database");
                Db_username = resx.GetString("database_user");
                Db_pwd = resx.GetString("database_pwd");
            }
            Admin.Status = 0;
            /*Console.WriteLine(Admin.Username + "|" + Admin.Password);*/
        }

        public Boolean simpan()
        {
            try
            {
                var resx = new List<DictionaryEntry>();
                using (ResXResourceReader reader = new ResXResourceReader(Connect.folderAppData + "//Res1.resx"))
                {
                    resx = reader.Cast<DictionaryEntry>().ToList();
                }
                using (var writer = new ResXResourceWriter(Connect.folderAppData + "//Res1.resx"))
                {
                    foreach (DictionaryEntry item in resx)
                    {
                        if (item.Key.ToString().Equals("username_1"))
                        {
                            writer.AddResource("username_1", Admin.Username);
                        }
                        else if (item.Key.ToString().Equals("password_1"))
                        {
                            writer.AddResource("password_1", Admin.Password);
                        }
                        else if (item.Key.ToString().Equals("nama_1"))
                        {
                            writer.AddResource("nama_1", Admin.Nama);
                        }
                        else if (item.Key.ToString().Equals("ip_server"))
                        {
                            writer.AddResource("ip_server", Ip_server);
                        }
                        else if (item.Key.ToString().Equals("database"))
                        {
                            writer.AddResource("database", Database);
                        }
                        else if (item.Key.ToString().Equals("database_user"))
                        {
                            writer.AddResource("database_user", Db_username);
                        }
                        else if (item.Key.ToString().Equals("database_pwd"))
                        {
                            writer.AddResource("database_pwd", Db_pwd);
                        }
                        else
                        {
                            writer.AddResource(item.Key.ToString(), item.Value.ToString());
                        }
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Simpan Akun : ");
                Console.WriteLine("Simpan Akun : " + ex.Message);
                Console.WriteLine("Simpan Akun : " + ex.StackTrace);
                return false;
            }

        }
       
    }
}
