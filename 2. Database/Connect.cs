using Akhi_Okhee._1._Common;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Akhi_Okhee._2._Database
{
    public class Connect
    {
        public static string database_name = "imk_herni_123";
        //private string ip_server = ".";
        //private string instance_sql = "IPDS_2020";
        public static string connetionStringFormat = "server={0};database={1};user={2};pwd={3};";
        public static string connetionStringFormatWithPort = "server={0};database={1};user={2};pwd={3};port={4}";
        private string connetionString;
        private Setting setting;
        public static string folderAppData = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "//AksiOkhhee";
        /*public static string dbFile = folderAppData + "//data.sqlite";*/

        /*private static string connetionString = "Data Source={0};Version=3;";*/

        public Connect()
        {
            /*if (!File.Exists(dbFile))
            {
                System.IO.Directory.CreateDirectory(folderAppData);
                FileStream fs = File.Create(dbFile);
                fs.Close();
                create_table();
            }*/
            setting = new Setting();
            connetionString = String.Format(connetionStringFormat, setting.Ip_server, setting.Database, setting.Db_username, setting.Db_pwd);
        }

        public MySqlConnection getConection()
        {
            setting = new Setting();
            if (setting.Ip_server == null) {
                throw new Exception();
            }else if (setting.Ip_server.Contains(":"))
            {
                string connetion = String.Format(connetionStringFormatWithPort, setting.Ip_server.Split(':')[0], setting.Database, setting.Db_username, setting.Db_pwd, setting.Ip_server.Split(':')[1]);
                Console.WriteLine(connetion);
                MySqlConnection cnn = new MySqlConnection(connetion);
                return cnn;
            }
            else
            {
                string connetion = String.Format(connetionStringFormat, setting.Ip_server, setting.Database, setting.Db_username, setting.Db_pwd);
                Console.WriteLine(connetion);
                MySqlConnection cnn = new MySqlConnection(connetion);
                return cnn;
            }
           
        }

        public MySqlConnection getConection(string l_ip_server, string l_database, string l_username, string l_password)
        {
            if (l_ip_server.Contains(":"))
            {
                string connetion = String.Format(connetionStringFormatWithPort, l_ip_server.Split(':')[0], l_database, l_username, l_password, l_ip_server.Split(':')[1]);
                Console.WriteLine(connetion);
                MySqlConnection cnn = new MySqlConnection(connetion);
                return cnn;
            }
            else
            {
                string connetion = String.Format(connetionStringFormat, l_ip_server, l_database, l_username, l_password);
                Console.WriteLine(connetion);
                MySqlConnection cnn = new MySqlConnection(connetion);
                return cnn;
            }
           

        }

        /*public void create_database(string l_ip_server, string l_database, string l_username, string l_password)
        {
            string connStr = "SERVER=localhost;UID=root;";
            //
            string drop_database = String.Format("DROP DATABASE {0};", l_database);
            string flush = "FLUSH PRIVILEGES;";

            try
            {

            }catch(Exception ex)
            {

            }
        }*/

        public Boolean drop_table()
        {
            try
            {
                MySqlConnection connect = getConection();
                connect.Open();
                Console.WriteLine("0");
                MySqlCommand command = connect.CreateCommand();
                MySqlTransaction transaction;
                Console.WriteLine("01");
                transaction = connect.BeginTransaction();
                command.Connection = connect;
                command.Transaction = transaction;
                Console.WriteLine("02");
                try
                {
                    command.CommandText = blok_i.getDropQuery();
                    command.ExecuteNonQuery();
                    Console.WriteLine("Drop 1");
                    command.CommandText = blok_ii.getDropQuery();
                    command.ExecuteNonQuery();
                    Console.WriteLine("Drop 2");
                    command.CommandText = blok_iii.getDropQuery();
                    command.ExecuteNonQuery();
                    Console.WriteLine("Drop 3");
                    command.CommandText = blok_iii_301.getDropQuery();
                    command.ExecuteNonQuery();
                    Console.WriteLine("Drop 4");
                    command.CommandText = barang.getDropQuery();
                    command.ExecuteNonQuery();
                    Console.WriteLine("Drop 5");
                    command.CommandText = Akun.getDropQuery();
                    command.ExecuteNonQuery();
                    Console.WriteLine("Drop 6");
                    transaction.Commit();
                }
                catch (Exception ex1)
                {
                    Console.WriteLine("Drop Table");
                    Console.WriteLine("Drop Table :" + ex1.Message);
                    Console.WriteLine("Drop Table :" + ex1.StackTrace);
                    transaction.Rollback();
                    return false;
                }
                connect.Close();
            }
            catch (System.Exception ex2)
            {
                Console.WriteLine("Drop Table 1");
                Console.WriteLine("Drop Table :" + ex2.Message);
                Console.WriteLine("Drop Table :" + ex2.StackTrace);
                return false;
            }
            return true;
        }

        public Boolean create_table()
        {
            try
            {
                MySqlConnection connect = getConection();
                connect.Open();
                MySqlCommand command = connect.CreateCommand();
                MySqlTransaction transaction;
                transaction = connect.BeginTransaction();
                command.Connection = connect;
                command.Transaction = transaction;
                try
                {
                    command.CommandText = blok_i.getCreateQuery();
                    command.ExecuteNonQuery();
                    Console.WriteLine("Create 1");
                    command.CommandText = blok_ii.getCreateQuery();
                    command.ExecuteNonQuery();
                    Console.WriteLine("Create 2");
                    command.CommandText = blok_iii.getCreateQuery();
                    command.ExecuteNonQuery();
                    Console.WriteLine("Create 3");
                    command.CommandText = blok_iii_301.getCreateQuery();
                    command.ExecuteNonQuery();
                    Console.WriteLine("Create 4");
                    command.CommandText = barang.getCreateQuery();
                    command.ExecuteNonQuery();
                    Console.WriteLine("Create 5");
                    command.CommandText = Akun.getCreateQuery();
                    command.ExecuteNonQuery();
                    Console.WriteLine("Create 6");

                    transaction.Commit();
                }
                catch (Exception ex1)
                {
                    Console.WriteLine("Create Table");
                    Console.WriteLine("Create Table :" + ex1.Message);
                    Console.WriteLine("Create Table :" + ex1.StackTrace);
                    transaction.Rollback();
                    return false;
                }
                connect.Close();
            }
            catch (System.Exception ex2)
            {
                Console.WriteLine("Create Table 1");
                Console.WriteLine("Create Table :" + ex2.Message);
                Console.WriteLine("Create Table :" + ex2.StackTrace);
                return false;
            }
            return true;
        }
        public List<blok_i> getListBlok_i(string r101, string r102, string r103, string r109)
        {
            List<string> whereList = new List<string>();
            if (!r101.Equals(""))
            {
                whereList.Add(blok_i.k_r101 + " = '" + r101 + "'");
            }
            if (!r102.Equals(""))
            {
                whereList.Add(blok_i.k_r102 + " = '" + r102 + "'");
            }
           
            if (!r103.Equals(""))
            {
                whereList.Add(blok_i.k_r103 + " = '" + r103+"'");
            }
          
            if (!r109.Equals(""))
            {
                whereList.Add(blok_i.k_r109 + " LIKE '%" + r109 + "%' ");
            }
            string resultWhere = "";
            if (whereList.Count > 0)
            {
                resultWhere = " WHERE " + String.Join(" AND ", whereList.ToArray())+" ";
            }
            List<blok_i> returnValue = new List<blok_i>();
            string sql = "SELECT * FROM " + blok_i.table + resultWhere 
                +" ORDER BY " + blok_i.k_r101+", " + blok_i.k_r102+", " + blok_i.k_r103+", " + blok_i.k_r104 + ", " + blok_i.k_triwulan + "; ";
            Console.WriteLine("Search Entri 1 "+sql);
            try
            {
                MySqlConnection connect = getConection();
                connect.Open();
                MySqlCommand command = connect.CreateCommand();
                command.Connection = connect;
                command.CommandText = sql;
                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        blok_i thisbloki = new blok_i();
                        thisbloki.Id.Data = (String)reader[blok_i.k_id];
                        thisbloki.R101.Data = (String)reader[blok_i.k_r101];
                        thisbloki.R102.Data = (String)reader[blok_i.k_r102];
                        thisbloki.R103.Data = (String)reader[blok_i.k_r103];
                        thisbloki.R104.Data = (String)reader[blok_i.k_r104];
                        thisbloki.R105.Data = (String)reader[blok_i.k_r105];
                        thisbloki.R106.Data = (String)reader[blok_i.k_r106];
                        thisbloki.R107.Data = (String)reader[blok_i.k_r107];
                        thisbloki.R108.Data = (String)reader[blok_i.k_r108];
                        thisbloki.R109.Data = (String)reader[blok_i.k_r109];
                        thisbloki.R110.Data = (String)reader[blok_i.k_r110];
                        thisbloki.R111.Data = (String)reader[blok_i.k_r111];
                        if (reader[blok_i.k_r112] != DBNull.Value)
                        {
                            thisbloki.R112.Data = (String)reader[blok_i.k_r112];
                        }
                        else
                        {
                            thisbloki.R112.Data = default(string);
                        }
                        thisbloki.R113.Data = (String)reader[blok_i.k_r113];
                        thisbloki.R114.Data = (String)reader[blok_i.k_r114];
                        thisbloki.R115.Data = (String)reader[blok_i.k_r115];
                        thisbloki.R116.Data = (String)reader[blok_i.k_r116];
                        thisbloki.Triwulan.Data = (String)reader[blok_i.k_triwulan];
                        thisbloki.Nks_nus.Data = (String)reader[blok_i.k_nks_nus];
                        thisbloki.setTriwulanint((String)reader[blok_i.k_triwulan]);
                        thisbloki.Error.Data = (String)reader[blok_i.k_error];
                        thisbloki.Is_lock.Data = (String)reader[blok_i.k_is_lock];
                        if (reader[blok_i.k_lock_user] != DBNull.Value)
                        {
                            thisbloki.Lock_user.Data = (String)reader[blok_i.k_lock_user];
                        }
                        returnValue.Add(thisbloki);
                    }
                }
                connect.Close();
                return returnValue;
            }
            catch (System.Exception ex2)
            {
                Console.WriteLine("Search Entri 1");
                Console.WriteLine("Search Entri :" + ex2.Message);
                Console.WriteLine("Search Entri :" + ex2.StackTrace);
                return null;
            }
        }

        public List<blok_i> getListBlok_iOnlytw(int triwulan)
        {
            List<string> whereList = new List<string>();
            whereList.Add(blok_i.k_triwulan + " = '" + triwulan + "' ");

            string resultWhere = "";
            if (whereList.Count > 0)
            {
                resultWhere = " WHERE " + String.Join(" AND ", whereList.ToArray()) + " ";
            }
            List<blok_i> returnValue = new List<blok_i>();
            string sql = "SELECT * FROM " + blok_i.table + resultWhere
                + " ORDER BY " + blok_i.k_r101 + ", " + blok_i.k_r102 + ", " + blok_i.k_r103 + ", " + blok_i.k_r104 + ", " + blok_i.k_triwulan + "; ";
            Console.WriteLine("Search Entri 1 " + sql);
            try
            {
                MySqlConnection connect = getConection();
                connect.Open();
                MySqlCommand command = connect.CreateCommand();
                command.Connection = connect;
                command.CommandText = sql;
                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        blok_i thisbloki = new blok_i();
                        thisbloki.Id.Data = (String)reader[blok_i.k_id];
                        thisbloki.R101.Data = (String)reader[blok_i.k_r101];
                        thisbloki.R102.Data = (String)reader[blok_i.k_r102];
                        thisbloki.R103.Data = (String)reader[blok_i.k_r103];
                        thisbloki.R104.Data = (String)reader[blok_i.k_r104];
                        thisbloki.R105.Data = (String)reader[blok_i.k_r105];
                        thisbloki.R106.Data = (String)reader[blok_i.k_r106];
                        thisbloki.R107.Data = (String)reader[blok_i.k_r107];
                        thisbloki.R108.Data = (String)reader[blok_i.k_r108];
                        thisbloki.R109.Data = (String)reader[blok_i.k_r109];
                        thisbloki.R110.Data = (String)reader[blok_i.k_r110];
                        thisbloki.R111.Data = (String)reader[blok_i.k_r111];
                        if (reader[blok_i.k_r112] != DBNull.Value)
                        {
                            thisbloki.R112.Data = (String)reader[blok_i.k_r112];
                        }
                        else
                        {
                            thisbloki.R112.Data = default(string);
                        }
                        thisbloki.R113.Data = (String)reader[blok_i.k_r113];
                        thisbloki.R114.Data = (String)reader[blok_i.k_r114];
                        thisbloki.R115.Data = (String)reader[blok_i.k_r115];
                        thisbloki.R116.Data = (String)reader[blok_i.k_r116];
                        thisbloki.Triwulan.Data = (String)reader[blok_i.k_triwulan];
                        thisbloki.Nks_nus.Data = (String)reader[blok_i.k_nks_nus];
                        thisbloki.setTriwulanint((String)reader[blok_i.k_triwulan]);
                        thisbloki.Error.Data = (String)reader[blok_i.k_error];
                        thisbloki.Is_lock.Data = (String)reader[blok_i.k_is_lock];
                        if (reader[blok_i.k_lock_user] != DBNull.Value)
                        {
                            thisbloki.Lock_user.Data = (String)reader[blok_i.k_lock_user];
                        }
                        returnValue.Add(thisbloki);
                    }
                }
                connect.Close();
                return returnValue;
            }
            catch (System.Exception ex2)
            {
                Console.WriteLine("Search Entri 1");
                Console.WriteLine("Search Entri :" + ex2.Message);
                Console.WriteLine("Search Entri :" + ex2.StackTrace);
                return null;
            }
        }

        public List<blok_i> getListBlok_iByNKSNUS(string nks, string nus)
        {
           
            List<blok_i> returnValue = new List<blok_i>();
            string sql = "SELECT * FROM " + blok_i.table + " WHERE "+blok_i.k_r106+" = '"+nks+"' AND "+blok_i.k_r107+" = '"+nus+"'; ";
            Console.WriteLine("Search Entri 2 " + sql);
            try
            {
                MySqlConnection connect = getConection();
                connect.Open();
                MySqlCommand command = connect.CreateCommand();
                command.Connection = connect;
                command.CommandText = sql;
                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        blok_i thisbloki = new blok_i();
                        thisbloki.Id.Data = (String)reader[blok_i.k_id];
                        thisbloki.R101.Data = (String)reader[blok_i.k_r101];
                        thisbloki.R102.Data = (String)reader[blok_i.k_r102];
                        thisbloki.R103.Data = (String)reader[blok_i.k_r103];
                        thisbloki.R104.Data = (String)reader[blok_i.k_r104];
                        thisbloki.R105.Data = (String)reader[blok_i.k_r105];
                        thisbloki.R106.Data = (String)reader[blok_i.k_r106];
                        thisbloki.R107.Data = (String)reader[blok_i.k_r107];
                        thisbloki.R108.Data = (String)reader[blok_i.k_r108];
                        thisbloki.R109.Data = (String)reader[blok_i.k_r109];
                        thisbloki.R110.Data = (String)reader[blok_i.k_r110];
                        thisbloki.R111.Data = (String)reader[blok_i.k_r111];
                        if (reader[blok_i.k_r112] != DBNull.Value)
                        {
                            thisbloki.R112.Data = (String)reader[blok_i.k_r112];
                        }
                        else
                        {
                            thisbloki.R112.Data = default(string);
                        }
                        thisbloki.R113.Data = (String)reader[blok_i.k_r113];
                        thisbloki.R114.Data = (String)reader[blok_i.k_r114];
                        thisbloki.R115.Data = (String)reader[blok_i.k_r115];
                        thisbloki.R116.Data = (String)reader[blok_i.k_r116];
                        thisbloki.Triwulan.Data = (String)reader[blok_i.k_triwulan];
                        thisbloki.setTriwulanint((String)reader[blok_i.k_triwulan]);
                        thisbloki.Error.Data = (String)reader[blok_i.k_error];
                        thisbloki.Is_lock.Data = (String)reader[blok_i.k_is_lock];
                        if (reader[blok_i.k_lock_user] != DBNull.Value)
                        {
                            thisbloki.Lock_user.Data = (String)reader[blok_i.k_lock_user];
                        }
                        returnValue.Add(thisbloki);
                    }
                }
                connect.Close();
                Console.WriteLine("Jumlah blok i :" + returnValue.Count);
                return returnValue;
            }
            catch (System.Exception ex2)
            {
                Console.WriteLine("Search Entri 2");
                Console.WriteLine("Search Entri :" + ex2.Message);
                Console.WriteLine("Search Entri :" + ex2.StackTrace);
                return null;
            }
        }

        public List<blok_i> getListBlok_i_lock()
        {
            List<string> whereList = new List<string>();
     
            whereList.Add(blok_i.k_is_lock + " =  '1' ");
 
            string resultWhere = "";
            if (whereList.Count > 0)
            {
                resultWhere = " WHERE " + String.Join(" AND ", whereList.ToArray()) + " ";
            }
            List<blok_i> returnValue = new List<blok_i>();
            string sql = "SELECT * FROM " + blok_i.table + resultWhere
                + " ORDER BY " + blok_i.k_r101 + ", " + blok_i.k_r102 + ", " + blok_i.k_r103 + ", " + blok_i.k_r104 + ", " + blok_i.k_triwulan + "; ";
            Console.WriteLine("Search Entri 1 " + sql);
            try
            {
                MySqlConnection connect = getConection();
                connect.Open();
                MySqlCommand command = connect.CreateCommand();
                command.Connection = connect;
                command.CommandText = sql;
                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        blok_i thisbloki = new blok_i();
                        thisbloki.Id.Data = (String)reader[blok_i.k_id];
                        thisbloki.R101.Data = (String)reader[blok_i.k_r101];
                        thisbloki.R102.Data = (String)reader[blok_i.k_r102];
                        thisbloki.R103.Data = (String)reader[blok_i.k_r103];
                        thisbloki.R104.Data = (String)reader[blok_i.k_r104];
                        thisbloki.R105.Data = (String)reader[blok_i.k_r105];
                        thisbloki.R106.Data = (String)reader[blok_i.k_r106];
                        thisbloki.R107.Data = (String)reader[blok_i.k_r107];
                        thisbloki.R108.Data = (String)reader[blok_i.k_r108];
                        thisbloki.R109.Data = (String)reader[blok_i.k_r109];
                        thisbloki.R110.Data = (String)reader[blok_i.k_r110];
                        thisbloki.R111.Data = (String)reader[blok_i.k_r111];
                        if (reader[blok_i.k_r112] != DBNull.Value)
                        {
                            thisbloki.R112.Data = (String)reader[blok_i.k_r112];
                        }
                        else
                        {
                            thisbloki.R112.Data = default(string);
                        }
                        thisbloki.R113.Data = (String)reader[blok_i.k_r113];
                        thisbloki.R114.Data = (String)reader[blok_i.k_r114];
                        thisbloki.R115.Data = (String)reader[blok_i.k_r115];
                        thisbloki.R116.Data = (String)reader[blok_i.k_r116];
                        thisbloki.Triwulan.Data = (String)reader[blok_i.k_triwulan];
                        thisbloki.Nks_nus.Data = (String)reader[blok_i.k_nks_nus];
                        thisbloki.setTriwulanint((String)reader[blok_i.k_triwulan]);
                        thisbloki.Error.Data = (String)reader[blok_i.k_error];
                        thisbloki.Is_lock.Data = (String)reader[blok_i.k_is_lock];
                        if (reader[blok_i.k_lock_user] != DBNull.Value)
                        {
                            thisbloki.Lock_user.Data = (String)reader[blok_i.k_lock_user];
                        }
                        returnValue.Add(thisbloki);
                    }
                }
                connect.Close();
                return returnValue;
            }
            catch (System.Exception ex2)
            {
                Console.WriteLine("Search Entri 1");
                Console.WriteLine("Search Entri :" + ex2.Message);
                Console.WriteLine("Search Entri :" + ex2.StackTrace);
                return null;
            }
        }

        public List<Dokumen> getPupulateDokuemn(List<blok_i> list_blok_i)
        {
            List<Dokumen> returnValue = new List<Dokumen>();
            foreach(blok_i itemBloki in list_blok_i)
            {
                Dokumen doku = new Dokumen(itemBloki);
                Boolean hasil =  doku.populate();
                if (!hasil)
                {
                    return null;
                }
                returnValue.Add(doku);
            }
            return returnValue;
        }

        public List<barang> getListBarang(string prov, string kab, string search)
        {
            List<string> whereList = new List<string>();
            if (!prov.Equals(""))
            {
                whereList.Add(barang.k_prov + " = '" + prov+"'");
            }
            if (!kab.Equals(""))
            {
                whereList.Add(barang.k_kab + " = '" + kab+"'");
            }
            if (!search.Equals(""))
            {
                whereList.Add(barang.k_nama + " LIKE '%" + search + "%' ");
            }
            string resultWhere = "";
            if (whereList.Count > 0)
            {
                resultWhere = " WHERE " + String.Join(" AND ", whereList.ToArray()) + " ";
            }

            List<barang> returnValue = new List<barang>();
            string sql = "SELECT * FROM " + barang.table + resultWhere
                + " ORDER BY " + barang.k_prov + ", " + barang.k_kab  + "; ";
            Console.WriteLine("Search Entri 1 " + sql);
            try
            {
                MySqlConnection connect = getConection();
                connect.Open();
                MySqlCommand command = connect.CreateCommand();
                command.Connection = connect;
                command.CommandText = sql;
                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        barang thisbarang = new barang();
                        thisbarang.Id.Data = (String)reader[barang.k_id];
                        thisbarang.Prov.Data = (String)reader[barang.k_prov];
                        thisbarang.Kab.Data = (String)reader[barang.k_kab];
                        thisbarang.Nama.Data = (String)reader[barang.k_nama];
                        thisbarang.Jenis.Data = (String)reader[barang.k_jenis];
                        thisbarang.Satuan.Data = (String)reader[barang.k_satuan];
                        thisbarang.Kbli.Data = (String)reader[barang.k_kbli];
                        if (((string)reader[barang.k_nilai_min]).Equals(""))
                        {
                            thisbarang.Nilai_min.Data = null;
                        }
                        else
                        {
                            thisbarang.Nilai_min.Data = long.Parse(((string)reader[barang.k_nilai_min]).Replace("|", CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator));
                        }
                        if (((string)reader[barang.k_nilai_max]).Equals(""))
                        {
                            thisbarang.Nilai_max.Data = null;
                        }
                        else
                        {
                            thisbarang.Nilai_max.Data = long.Parse(((string)reader[barang.k_nilai_max]).Replace("|", CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator));
                        }
                        returnValue.Add(thisbarang);
                    }
                }
                connect.Close();
                return returnValue;
            }
            catch (System.Exception ex2)
            {
                Console.WriteLine("Search Entri 1");
                Console.WriteLine("Search Entri :" + ex2.Message);
                Console.WriteLine("Search Entri :" + ex2.StackTrace);
                return null;
            }
        }
        
        public Boolean create_Backup(string filepath)
        {
            try
            {
                MySqlConnection conn = getConection();
                MySqlCommand cmd = new MySqlCommand();
                MySqlBackup mb = new MySqlBackup(cmd);
                cmd.Connection = conn;
                conn.Open();
                mb.ExportToFile(filepath);
                conn.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Backup Database");
                Console.WriteLine("Backup Database : " + ex.Message);
                Console.WriteLine("Backup Database : " + ex.StackTrace);
                return false;
            }
            return true;
        }

        public Boolean restore_database(string filepath)
        {
            try
            {
                MySqlConnection conn = getConection();
                MySqlCommand cmd = new MySqlCommand();
                MySqlBackup mb = new MySqlBackup(cmd);
                cmd.Connection = conn;
                conn.Open();
                mb.ImportFromFile(filepath);
                conn.Close();
            }catch(Exception ex)
            {
                Console.WriteLine("Restore Database");
                Console.WriteLine("Restore Database : " + ex.Message);
                Console.WriteLine("Restore Database : " + ex.StackTrace);
                return false;
            }
            return true;
        }
    }
}
