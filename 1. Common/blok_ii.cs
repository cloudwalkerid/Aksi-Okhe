using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Akhi_Okhee._3._4._Client_Dokumen;
using System.Data;
using MySql.Data.MySqlClient;

namespace Akhi_Okhee._1._Common
{
    public class blok_ii : blok
    {
        public static string table = "blok_ii";
        public static string k_id = "id";
        public static string k_r201a = "r201a";
        public static string k_r201b = "r201b";
        public static string k_r202 = "r202";
        public static string k_r203 = "r203";
        public static string k_r204 = "r204";
        public static string k_r205k2 = "r205k2";
        public static string k_r205k3 = "r205k3";
        public static string k_r206k2 = "r206k2";
        public static string k_r206k3 = "r206k3";
        public static string k_r207k2 = "r207k2";
        public static string k_r207k3 = "r207k3";
        public static string k_r208k2 = "r208k2";
        public static string k_r208k3 = "r208k3";
        public static string k_catatan = "catatan";

        private variable<string> id = new variable<string>(nama: k_id, panjang: 80, is_null: false);
        private variable<string> r201a = new variable<string>(nama: k_r201a, panjang: 1, min: 1, max: 6, is_null: false);
        private variable<string> r201b = new variable<string>(nama: k_r201b, panjang: 1, min: 1, max: 2, is_null: false);
        private variable<string> r202 = new variable<string>(nama: k_r202, panjang: 256, is_null: true);
        private variable<string> r203 = new variable<string>(nama: k_r203, panjang: 256, is_null: true);
        private variable<string> r204 = new variable<string>(nama: k_r204, panjang: 20, is_null: true);
        private variable<string> r205k2 = new variable<string>(nama: k_r205k2, panjang: 256, is_null: true);
        private variable<string> r205k3 = new variable<string>(nama: k_r205k3, panjang: 256, is_null: true);
        private variable<DateTime?> r206k2 = new variable<DateTime?>(nama: k_r206k2, min: null, max: null, is_null: true);
        private variable<DateTime?> r206k3 = new variable<DateTime?>(nama: k_r206k3, min: null, max: null, is_null: true);
        private variable<string> r207k2 = new variable<string>(nama: k_r207k2, panjang: 20, is_null: true);
        private variable<string> r207k3 = new variable<string>(nama: k_r207k3, panjang: 20, is_null: true);
        private variable<string> r208k2 = new variable<string>(nama: k_r208k2, panjang: 1, min: 1, max: 1, is_null: true);
        private variable<string> r208k3 = new variable<string>(nama: k_r208k3, panjang: 1, min: 1, max: 1, is_null: true);
        private variable<string> catatan = new variable<string>(nama: k_catatan, panjang: null, is_null: true);
        private Dokumen dokumen;

        public variable<string> Id { get => id; set => id = value; }
        public variable<string> R201a { get => r201a; set => r201a = value; }
        public variable<string> R201b { get => r201b; set => r201b = value; }
        public variable<string> R202 { get => r202; set => r202 = value; }
        public variable<string> R203 { get => r203; set => r203 = value; }
        public variable<string> R204 { get => r204; set => r204 = value; }
        public variable<string> R205k2 { get => r205k2; set => r205k2 = value; }
        public variable<string> R205k3 { get => r205k3; set => r205k3 = value; }
        public variable<DateTime?> R206k2 { get => r206k2;
            set
            {
                r206k2 = value;
                if (value != null)
                {
                    r206k2_tl = value.Data.Value.Day.ToString();
                    r206k2_bl = value.Data.Value.Month.ToString();
                    r206k2_tahun = value.Data.Value.Year.ToString();
                }
            }
        }
        public variable<DateTime?> R206k3 { get => r206k3; 
            set{
                r206k3 = value;
                if (value != null)
                {
                    r206k3_tl = value.Data.Value.Day.ToString();
                    r206k3_bl = value.Data.Value.Month.ToString();
                    r206k3_tahun = value.Data.Value.Year.ToString();
                }
            }
        }
        public variable<string> R207k2 { get => r207k2; set => r207k2 = value; }
        public variable<string> R207k3 { get => r207k3; set => r207k3 = value; }
        public variable<string> R208k2 { get => r208k2; set => r208k2 = value; }
        public variable<string> R208k3 { get => r208k3; set => r208k3 = value; }
        public variable<string> Catatan { get => catatan; set => catatan = value; }
        public Dokumen Dokumen { get => dokumen; set => dokumen = value; }
        public string R206k2_tl { get => r206k2_tl;
            set {
                r206k2_tl = value;
                setDatePetugas();
            }  
        }
        public string R206k2_bl { get => r206k2_bl; 
            set
            {
                r206k2_bl = value;
                setDatePetugas();
            }
        }
        public string R206k2_tahun { get => r206k2_tahun;
            set
            {
                r206k2_tahun = value;
                setDatePetugas();
            }
        }
        public string R206k3_tl { get => r206k3_tl;
            set
            {
                r206k3_tl = value;
                setDatePengawas();
            }
        }
        public string R206k3_bl { get => r206k3_bl;
            set
            {
                r206k3_bl = value;
                setDatePengawas();
            }
        }
        public string R206k3_tahun { get => r206k3_tahun;
            set
            {
                r206k3_tahun = value;
                setDatePengawas();
            }
        }

        private String insert_query = "INSERT INTO {0} ({1}, {2}, {3}, {4}, {5}, {6}, {7}, {8}, {9}, {10}, {11}, {12}, {13}, {14}, {15}) VALUES "
           + "(@{1}, @{2}, @{3}, @{4}, @{5}, @{6}, @{7}, @{8}, @{9}, @{10}, @{11}, @{12}, @{13}, @{14}, @{15});";

        private String update_query = "UPDATE {0} SET {2} = @{2}, {3} = @{3}, {4} = @{4}, {5} = @{5}, {6} = @{6}, {7} = @{7}, {8} = @{8}, "
            + "{9} = @{9}, {10} = @{10}, {11} = @{11}, {12} = @{12}, {13} = @{13}, {14} = @{14}, {15} = @{15} "
            + "WHERE {1} = @{1};";

        private String delete_query = "DELETE FROM {0} WHERE {1} = '{2}';";

        private String select_query = "SELECT * FROM {0} WHERE {1} = @{1};";

        private string r206k2_tl="";
        private string r206k2_bl="";
        private string r206k2_tahun="2020";

        private string r206k3_tl="";
        private string r206k3_bl="";
        private string r206k3_tahun="2020";


        public void InsertData(MySqlCommand cmd)
        {
            Console.WriteLine("Insert blok 2 :" + R201a.Data);
            String insert_query_populate = String.Format(insert_query, table
                , k_id, k_r201a, k_r201b, k_r202, k_r203, k_r204, k_r205k2, k_r205k3, k_r206k2, k_r206k3, k_r207k2, k_r207k3, k_r208k2, k_r208k3, k_catatan);
            cmd.Parameters.Clear();
            cmd.CommandText = insert_query_populate;
            cmd.Parameters.AddWithValue("@" + k_id, Id.Data);
            cmd.Parameters.AddWithValue("@" + k_r201a, R201a.Data);
            cmd.Parameters.AddWithValue("@" + k_r201b, R201b.Data);
            cmd.Parameters.AddWithValue("@" + k_r202, R202.Data);
            cmd.Parameters.AddWithValue("@" + k_r203, R203.Data);
            cmd.Parameters.AddWithValue("@" + k_r204, R204.Data);
            cmd.Parameters.AddWithValue("@" + k_r205k2, R205k2.Data);
            cmd.Parameters.AddWithValue("@" + k_r205k3, R205k3.Data);
            if (R206k2.Data != default(DateTime?))
            {
                cmd.Parameters.AddWithValue("@" + k_r206k2, ((DateTime)R206k2.Data).ToString("yyyy-MM-dd HH:mm:ss"));
            }
            else
            {
                cmd.Parameters.AddWithValue("@" + k_r206k2, null);
            }

            if (R206k3.Data != default(DateTime?))
            {
                cmd.Parameters.AddWithValue("@" + k_r206k3, ((DateTime)R206k3.Data).ToString("yyyy-MM-dd HH:mm:ss"));
            }
            else
            {
                cmd.Parameters.AddWithValue("@" + k_r206k3, null);
            }
            cmd.Parameters.AddWithValue("@" + k_r207k2, R207k2.Data);
            cmd.Parameters.AddWithValue("@" + k_r207k3, R207k3.Data);
            cmd.Parameters.AddWithValue("@" + k_r208k2, R208k2.Data);
            cmd.Parameters.AddWithValue("@" + k_r208k3, R208k3.Data);
            cmd.Parameters.AddWithValue("@" + k_catatan, Catatan.Data);
            cmd.ExecuteNonQuery();
        }

        public void UpdateData(MySqlCommand cmd)
        {
           
            String update_query_populate = String.Format(update_query, table
                , k_id, k_r201a, k_r201b, k_r202, k_r203, k_r204, k_r205k2, k_r205k3, k_r206k2, k_r206k3, k_r207k2, k_r207k3, k_r208k2, k_r208k3, k_catatan);
            cmd.Parameters.Clear();
            cmd.CommandText = update_query_populate;
            cmd.Parameters.AddWithValue("@" + k_id, Id.Data);
            cmd.Parameters.AddWithValue("@" + k_r201a, R201a.Data);
            cmd.Parameters.AddWithValue("@" + k_r201b, R201b.Data);
            cmd.Parameters.AddWithValue("@" + k_r202, R202.Data);
            cmd.Parameters.AddWithValue("@" + k_r203, R203.Data);
            cmd.Parameters.AddWithValue("@" + k_r204, R204.Data);
            cmd.Parameters.AddWithValue("@" + k_r205k2, R205k2.Data);
            cmd.Parameters.AddWithValue("@" + k_r205k3, R205k3.Data);
            if (R206k2.Data != default(DateTime?))
            {
                cmd.Parameters.AddWithValue("@" + k_r206k2, ((DateTime)R206k2.Data).ToString("yyyy-MM-dd HH:mm:ss"));
            }
            else
            {
                cmd.Parameters.AddWithValue("@" + k_r206k2, null);
            }

            if (R206k3.Data != default(DateTime?))
            {
                cmd.Parameters.AddWithValue("@" + k_r206k3, ((DateTime)R206k3.Data).ToString("yyyy-MM-dd HH:mm:ss"));
            }
            else
            {
                cmd.Parameters.AddWithValue("@" + k_r206k3, null);
            }
            cmd.Parameters.AddWithValue("@" + k_r207k2, R207k2.Data);
            cmd.Parameters.AddWithValue("@" + k_r207k3, R207k3.Data);
            cmd.Parameters.AddWithValue("@" + k_r208k2, R208k2.Data);
            cmd.Parameters.AddWithValue("@" + k_r208k3, R208k3.Data);
            cmd.Parameters.AddWithValue("@" + k_catatan, Catatan.Data);
            Console.WriteLine("Update blok 2 "+cmd.CommandText);
            cmd.ExecuteNonQuery();
        }

        public void DeleteData(MySqlCommand cmd)
        {
            String delete_query_populate = String.Format(delete_query, table, k_id, Id.Data);
            cmd.CommandText = delete_query_populate;
            cmd.ExecuteNonQuery();
            Console.WriteLine(delete_query_populate);
        }

        public void populate(MySqlConnection conn)
        {
            try
            {
                //String select_query_populate_2 = "SELECT * FROM " + table + " WHERE " + k_id + " = '" + Id.Data + "'";
                String select_query_populate = String.Format(select_query, table, k_id);
                MySqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = select_query_populate;
                cmd.Parameters.AddWithValue("@" + k_id, Id.Data);
                cmd.CommandType = CommandType.Text;
                //Console.WriteLine("Masuk " + select_query_populate);
                //Console.WriteLine("Masuk " + select_query_populate_2);
                MySqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    Id.Data = (String)reader[k_id];
                    if (reader[k_r201a] != DBNull.Value)
                    {
                        R201a.Data = (String)reader[k_r201a];
                    }
                   
                    if (reader[k_r201b] != DBNull.Value)
                    {
                        R201b.Data = (String)reader[k_r201b];
                    }
                    
                    if (reader[k_r202] != DBNull.Value)
                    {
                        R202.Data = (String)reader[k_r202];
                    }
                    
                    if (reader[k_r203] != DBNull.Value)
                    {
                        R203.Data = (String)reader[k_r203];
                    }
                    
                    if ( reader[k_r204] != DBNull.Value)
                    {
                        R204.Data = (String)reader[k_r204];
                    }
                    
                    if (reader[k_r205k2] != DBNull.Value)
                    {
                        R205k2.Data = (String)reader[k_r205k2];
                    }
                    
                    if (reader[k_r205k3] != DBNull.Value)
                    {
                        R205k3.Data = (String)reader[k_r205k3];
                    }
                   
                    if (reader[k_r206k2] != DBNull.Value)
                    {
                        Console.WriteLine("" + reader[k_r206k2]);
                        R206k2.Data = DateTime.ParseExact("" + reader[k_r206k2], "yyyy-MM-dd HH:mm:ss", null);
                    }
                    
                    if (reader[k_r206k3] != DBNull.Value)
                    {
                        R206k3.Data = DateTime.ParseExact("" + reader[k_r206k3], "yyyy-MM-dd HH:mm:ss", null);
                    }
                    
                    if (reader[k_r207k2] != DBNull.Value)
                    {
                        R207k2.Data = (String)reader[k_r207k2];
                    }
                   
                    if (reader[k_r207k3] != DBNull.Value)
                    {
                        R207k3.Data = (String)reader[k_r207k3];
                    }
                    
                    if (reader[k_r208k2] != DBNull.Value)
                    {
                        R208k2.Data = (String)reader[k_r208k2];
                    }
                    
                    if (reader[k_r208k3] != DBNull.Value)
                    {
                        R208k3.Data = (String)reader[k_r208k3];
                    }
                   
                    if (reader[k_catatan] != DBNull.Value)
                    {
                        Catatan.Data = (String)reader[k_catatan];
                    }

                    //Console.WriteLine("Masuk " + (String)reader[k_r201a]);
                }
                reader.Close();

            }
            catch(Exception ex)
            {
                Console.WriteLine("Populate blok ii");
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);
            }
            
        }
        public static string getCreateQuery()
        {
            string create = "CREATE TABLE "+table+" ( "
                + k_id + " varchar(80) NOT NULL PRIMARY KEY, "
                + k_r201a + " varchar(1), "
                + k_r201b + " varchar(1), "
                + k_r202 + " varchar(256), "
                + k_r203 + " varchar(256), "
                + k_r204 + " varchar(20), "
                + k_r205k2 + " varchar(256), "
                + k_r205k3 + " varchar(256), "
                + k_r206k2 + " varchar(20), "
                + k_r206k3 + " varchar(20), "
                + k_r207k2 + " varchar(20), "
                + k_r207k3 + " varchar(20), "
                + k_r208k2 + " varchar(1), "
                + k_r208k3 + " varchar(1), "
                + k_catatan + " text "
                + ") ENGINE=InnoDB; ";
            return create;
        }

        public static string getDropQuery()
        {
            string drop = String.Format("DROP TABLE IF EXISTS {0};", table);
            Console.WriteLine(drop);
            return drop;
        }
        public void setDokumen(Dokumen dokumen)
        {
            Dokumen = dokumen;
            Id.Blok = this;
            R201a.Blok = this;
            R201b.Blok = this;
            R202.Blok = this;
            R203.Blok = this;
            R204.Blok = this;
            R205k2.Blok = this;
            R205k3.Blok = this;
            R206k2.Blok = this;
            R206k3.Blok = this;
            R207k2.Blok = this;
            R207k3.Blok = this;
            R208k2.Blok = this;
            R208k3.Blok = this;
            Catatan.Blok = this;
        }

        public void dateAwal()
        {
            try
            {
                if (R206k2.Data != null)
                {
                    r206k2_tl = R206k2.Data.Value.Day.ToString();
                    r206k2_bl = R206k2.Data.Value.Month.ToString();
                    r206k2_tahun = R206k2.Data.Value.Year.ToString();
                }
            }
            catch(Exception ex)
            {

            }

            try
            {
                if (R206k3.Data != null)
                {
                    r206k3_tl = R206k3.Data.Value.Day.ToString();
                    r206k3_bl = R206k3.Data.Value.Month.ToString();
                    r206k3_tahun = R206k3.Data.Value.Year.ToString();
                }
            }
            catch (Exception ex)
            {

            }

        }
        public void changeValue(object var)
        {
            sampaikanPerbuhan();
        }

        public Boolean checkError()
        {
          /*  Console.WriteLine("Cek Error Blok 2");
            Console.WriteLine(String.Join(", ", R201a.getAllError()));
            Console.WriteLine(String.Join(", ", R201b.getAllError()));
            Console.WriteLine(String.Join(", ", R202.getAllError()));
            Console.WriteLine(String.Join(", ", R203.getAllError()));
            Console.WriteLine(String.Join(", ", R204.getAllError()));
            Console.WriteLine(String.Join(", ", R205k2.getAllError()));
            Console.WriteLine(String.Join(", ", R205k3.getAllError()));
            Console.WriteLine(String.Join(", ", R206k2.getAllError()));
            Console.WriteLine(String.Join(", ", R206k3.getAllError()));
            Console.WriteLine(String.Join(", ", R207k2.getAllError()));
            Console.WriteLine(String.Join(", ", R207k3.getAllError()));
            Console.WriteLine(String.Join(", ", R208k2.getAllError()));
            Console.WriteLine(String.Join(", ", R208k3.getAllError()));
            Console.WriteLine(String.Join(", ", Catatan.getAllError()));*/
            return !(R201a.isError() ||
                R201b.isError() ||
                R202.isError() ||
                R203.isError() ||
                R204.isError() ||
                R205k2.isError() ||
                R205k3.isError() ||
                R206k2.isError() ||
                R206k3.isError() ||
                R207k2.isError() ||
                R207k3.isError() ||
                R208k2.isError() ||
                R208k3.isError() ||
                Catatan.isError());
        }

        public static blok_ii getCopyForNextTriwulan(blok_ii from, string uid_dok, string triwulan)
        {
            blok_ii baru = new blok_ii();
            baru.Id.Data = String.Copy(uid_dok);
            if (from == null)
            {
                return baru;
            }
            if (triwulan.Equals("1"))
            {
                baru.R206k2.Min = 1;
                baru.R206k2.Max = 3;
            }
            else if (triwulan.Equals("2"))
            {
                baru.R206k2.Min = 4;
                baru.R206k2.Max = 6;
            }
            else if (triwulan.Equals("3"))
            {
                baru.R206k2.Min = 7;
                baru.R206k2.Max = 9;
            }
            else if (triwulan.Equals("4"))
            {
                baru.R206k2.Min = 10;
                baru.R206k2.Max = 12;
            }
            return baru;
        }

        private Page_1 page1;
        public void setUserPagei(Page_1 _page1)
        {
            page1 = _page1;
        }
        public void sampaikanPerbuhan()
        {
            if (page1 != null)
            {
                page1.adaPerubahan();
            }
        }

        private void setDatePetugas()
        {
            if(!R206k2_tl.Equals("") && !R206k2_bl.Equals("") && !R206k2_tahun.Equals(""))
            {
                R206k2.Data = new DateTime(int.Parse(R206k2_tahun), int.Parse(R206k2_bl), int.Parse(R206k2_tl));
            }
            else
            {
                R206k2.Data = null;
            }
            
        }
        private void setDatePengawas()
        {
            if (!R206k3_tl.Equals("") && !R206k3_bl.Equals("") && !R206k3_tahun.Equals(""))
            {
                R206k3.Data = new DateTime(int.Parse(R206k3_tahun), int.Parse(R206k3_bl), int.Parse(R206k3_tl));
            }
            else
            {
                R206k3.Data = null;
            }
        }

    }
}
