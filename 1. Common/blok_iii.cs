using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Akhi_Okhee._3._4._Client_Dokumen;
using System.Data;
using MySql.Data.MySqlClient;
using System.Globalization;

namespace Akhi_Okhee._1._Common
{
    public class blok_iii : blok
    {
        public static string table = "blok_iii";
        public static string k_id = "id";
        public static string k_r301J_k6 = "r301J_k6";
        public static string k_r301J_k9 = "r301J_k9";
        public static string k_r301K_k6 = "r301K_k6";
        public static string k_r301K_k9 = "r301K_k9";
        public static string k_r302_k6 = "r302_k6";
        public static string k_r302_k9 = "r302_k9";
        public static string k_r303_k6 = "r303_k6";
        public static string k_r303_k9 = "r303_k9";
        public static string k_r304_k6 = "r304_k6";
        public static string k_r304_k9 = "r304_k9";

        private variable<string> id = new variable<string>(nama: k_id, panjang: 80, is_null: false);
        private variable<double?> r301J_k6 = new variable<double?>(nama: k_r301J_k6, min: 0, max: 999999999999999999, is_null: true);
        private variable<double?> r301J_k9 = new variable<double?>(nama: k_r301J_k9, min: 0, max: 999999999999999999, is_null: false);
        private variable<double?> r301K_k6 = new variable<double?>(nama: k_r301K_k6, min: 0, max: 999999999999999999, is_null: true);
        private variable<double?> r301K_k9 = new variable<double?>(nama: k_r301K_k9, min: 0, max: 999999999999999999, is_null: false);
        private variable<double?> r302_k6 = new variable<double?>(nama: k_r302_k6, min: 0, max: 999999999999999999, is_null: true);
        private variable<double?> r302_k9 = new variable<double?>(nama: k_r302_k9, min: 0, max: 999999999999999999, is_null: false);
        private variable<double?> r303_k6 = new variable<double?>(nama: k_r303_k6, min: 0, max: 999999999999999999, is_null: true);
        private variable<double?> r303_k9 = new variable<double?>(nama: k_r303_k9, min: 0, max: 999999999999999999, is_null: false);
        private variable<double?> r304_k6 = new variable<double?>(nama: k_r304_k6, min: 0, max: 999999999999999999, is_null: true);
        private variable<double?> r304_k9 = new variable<double?>(nama: k_r304_k9, min: 1, max: 999999999999999999, is_null: false);
        private Dokumen dokumen;

        public variable<string> Id { get => id; set => id = value; }
        public variable<double?> R301J_k6 { get => r301J_k6; set => r301J_k6 = value; }
        public variable<double?> R301J_k9 { get => r301J_k9; set => r301J_k9 = value; }
        public variable<double?> R301K_k6 { get => r301K_k6; set => r301K_k6 = value; }
        public variable<double?> R301K_k9 { get => r301K_k9; set => r301K_k9 = value; }
        public variable<double?> R302_k6 { get => r302_k6; set => r302_k6 = value; }
        public variable<double?> R302_k9 { get => r302_k9; set => r302_k9 = value; }
        public variable<double?> R303_k6 { get => r303_k6; set => r303_k6 = value; }
        public variable<double?> R303_k9 { get => r303_k9; set => r303_k9 = value; }
        public variable<double?> R304_k6 { get => r304_k6; set => r304_k6 = value; }
        public variable<double?> R304_k9 { get => r304_k9; set => r304_k9 = value; }
        public Dokumen Dokumen { get => dokumen; set => dokumen = value; }


        private String insert_query = "INSERT INTO {0} ({1}, {2}, {3}, {4}, {5}, {6}, {7}, {8}, {9}, {10}, {11}) VALUES "
           + "(@{1}, @{2}, @{3}, @{4}, @{5}, @{6}, @{7}, @{8}, @{9}, @{10}, @{11});";

        private String update_query = "UPDATE {0} SET {2} = @{2}, {3} = @{3}, {4} = @{4}, {5} = @{5}, {6} = @{6}, {7} = @{7}, {8} = @{8}, "
            + "{9} = @{9}, {10} = @{10}, {11} = @{11} "
            + "WHERE {1} = @{1};";

        private String delete_query = "DELETE FROM {0} WHERE {1} = '{2}';";

        private String select_query = "SELECT * FROM {0} WHERE {1} = @{1};";

        public void InsertData(MySqlCommand cmd)
        {
            String insert_query_populate = String.Format(insert_query, table
                , k_id, k_r301J_k6, k_r301J_k9, k_r301K_k6, k_r301K_k9, k_r302_k6, k_r302_k9, k_r303_k6, k_r303_k9, k_r304_k6, k_r304_k9);
            cmd.Parameters.Clear();
            cmd.CommandText = insert_query_populate;
            cmd.Parameters.AddWithValue("@" + k_id, Id.Data);
            if(R301J_k6.Data != default(double?))
            {
                cmd.Parameters.AddWithValue("@" + k_r301J_k6, (long)R301J_k6.Data);
            }
            else
            {
                cmd.Parameters.AddWithValue("@" + k_r301J_k6, null);
            }
            if (R301J_k9.Data != default(double?))
            {
                cmd.Parameters.AddWithValue("@" + k_r301J_k9, (long)R301J_k9.Data);
            }
            else
            {
                cmd.Parameters.AddWithValue("@" + k_r301J_k9, null);
            }
            if (R301K_k6.Data != default(double?))
            {
                cmd.Parameters.AddWithValue("@" + k_r301K_k6, (long)R301K_k6.Data);
            }
            else
            {
                cmd.Parameters.AddWithValue("@" + k_r301K_k6, null);
            }
            if (R301K_k9.Data != default(double?))
            {
                cmd.Parameters.AddWithValue("@" + k_r301K_k9, (long)R301K_k9.Data);
            }
            else
            {
                cmd.Parameters.AddWithValue("@" + k_r301K_k9, null);
            }
            if (R302_k6.Data != default(double?))
            {
                cmd.Parameters.AddWithValue("@" + k_r302_k6, (long)R302_k6.Data);
            }
            else
            {
                cmd.Parameters.AddWithValue("@" + k_r302_k6, null);
            }
            if (R302_k9.Data != default(double?))
            {
                cmd.Parameters.AddWithValue("@" + k_r302_k9, (long)R302_k9.Data);
            }
            else
            {
                cmd.Parameters.AddWithValue("@" + k_r302_k9, null);
            }
            if (R303_k6.Data != default(double?))
            {
                cmd.Parameters.AddWithValue("@" + k_r303_k6, (long)R303_k6.Data);
            }
            else
            {
                cmd.Parameters.AddWithValue("@" + k_r303_k6, null);
            }
            if (R303_k9.Data != default(double?))
            {
                cmd.Parameters.AddWithValue("@" + k_r303_k9, (long)R303_k9.Data);
            }
            else
            {
                cmd.Parameters.AddWithValue("@" + k_r303_k9, null);
            }
            if (R304_k6.Data != default(double?))
            {
                cmd.Parameters.AddWithValue("@" + k_r304_k6, (long)R304_k6.Data);
            }
            else
            {
                cmd.Parameters.AddWithValue("@" + k_r304_k6, null);
            }
            if (R304_k9.Data != default(double?))
            {
                cmd.Parameters.AddWithValue("@" + k_r304_k9, (long)R304_k9.Data);
            }
            else
            {
                cmd.Parameters.AddWithValue("@" + k_r304_k9, null);
            }
            cmd.ExecuteNonQuery();
            
        }

        public void UpdateData(MySqlCommand cmd)
        {
            String update_query_populate = String.Format(update_query, table
                , k_id, k_r301J_k6, k_r301J_k9, k_r301K_k6, k_r301K_k9, k_r302_k6, k_r302_k9, k_r303_k6, k_r303_k9, k_r304_k6, k_r304_k9);
            cmd.Parameters.Clear();
            cmd.CommandText = update_query_populate;
            cmd.Parameters.AddWithValue("@" + k_id, Id.Data);
            if (R301J_k6.Data != default(double?))
            {
                cmd.Parameters.AddWithValue("@" + k_r301J_k6, (long)R301J_k6.Data);
            }
            else
            {
                cmd.Parameters.AddWithValue("@" + k_r301J_k6, null);
            }
            if (R301J_k9.Data != default(double?))
            {
                cmd.Parameters.AddWithValue("@" + k_r301J_k9, (long)R301J_k9.Data);
            }
            else
            {
                cmd.Parameters.AddWithValue("@" + k_r301J_k9, null);
            }
            if (R301K_k6.Data != default(double?))
            {
                cmd.Parameters.AddWithValue("@" + k_r301K_k6, (long)R301K_k6.Data);
            }
            else
            {
                cmd.Parameters.AddWithValue("@" + k_r301K_k6, null);
            }
            if (R301K_k9.Data != default(double?))
            {
                cmd.Parameters.AddWithValue("@" + k_r301K_k9, (long)R301K_k9.Data);
            }
            else
            {
                cmd.Parameters.AddWithValue("@" + k_r301K_k9, null);
            }
            if (R302_k6.Data != default(double?))
            {
                cmd.Parameters.AddWithValue("@" + k_r302_k6, (long)R302_k6.Data);
            }
            else
            {
                cmd.Parameters.AddWithValue("@" + k_r302_k6, null);
            }
            if (R302_k9.Data != default(double?))
            {
                cmd.Parameters.AddWithValue("@" + k_r302_k9, (long)R302_k9.Data);
            }
            else
            {
                cmd.Parameters.AddWithValue("@" + k_r302_k9, null);
            }
            if (R303_k6.Data != default(double?))
            {
                cmd.Parameters.AddWithValue("@" + k_r303_k6, (long)R303_k6.Data);
            }
            else
            {
                cmd.Parameters.AddWithValue("@" + k_r303_k6, null);
            }
            if (R303_k9.Data != default(double?))
            {
                cmd.Parameters.AddWithValue("@" + k_r303_k9, (long)R303_k9.Data);
            }
            else
            {
                cmd.Parameters.AddWithValue("@" + k_r303_k9, null);
            }
            if (R304_k6.Data != default(double?))
            {
                cmd.Parameters.AddWithValue("@" + k_r304_k6, (long)R304_k6.Data);
            }
            else
            {
                cmd.Parameters.AddWithValue("@" + k_r304_k6, null);
            }
            if (R304_k9.Data != default(double?))
            {
                cmd.Parameters.AddWithValue("@" + k_r304_k9, (long)R304_k9.Data);
            }
            else
            {
                cmd.Parameters.AddWithValue("@" + k_r304_k9, null);
            }
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
                String select_query_populate = String.Format(select_query, table, k_id);
                MySqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = select_query_populate;
                cmd.Parameters.AddWithValue("@" + k_id, Id.Data);
                cmd.CommandType = CommandType.Text;
                MySqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    Id.Data = (String)reader[k_id];
                    if (reader[k_r301J_k6] != DBNull.Value)
                    {
                        R301J_k6.Data = double.Parse(((string)reader[k_r301J_k6]));
                    }
                    if (reader[k_r301J_k9] != DBNull.Value)
                    {
                        R301J_k9.Data = double.Parse(((string)reader[k_r301J_k9]));
                    }
                    if (reader[k_r301K_k6] != DBNull.Value)
                    {
                        R301K_k6.Data = double.Parse(((string)reader[k_r301K_k6]));
                    }
                    if (reader[k_r301K_k9] != DBNull.Value)
                    {
                        R301K_k9.Data = double.Parse(((string)reader[k_r301K_k9]));
                    }
                    if (reader[k_r302_k6] != DBNull.Value)
                    {
                        R302_k6.Data = double.Parse(((string)reader[k_r302_k6]));
                    }
                    if (reader[k_r302_k9] != DBNull.Value)
                    {
                        R302_k9.Data = double.Parse(((string)reader[k_r302_k9]));
                    }
                    if (reader[k_r303_k6] != DBNull.Value)
                    {
                        R303_k6.Data = double.Parse(((string)reader[k_r303_k6]));
                    }
                    if (reader[k_r303_k9] != DBNull.Value)
                    {
                        R303_k9.Data = double.Parse(((string)reader[k_r303_k9]));
                    }
                    if (reader[k_r304_k6] != DBNull.Value)
                    {
                        R304_k6.Data = double.Parse(((string)reader[k_r304_k6]));
                    }
                    if (reader[k_r304_k9] != DBNull.Value)
                    {
                        R304_k9.Data = double.Parse(((string)reader[k_r304_k9]));
                    }
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Populate blok iii");
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);
            }
        }
        public static string getCreateQuery()
        {
            string create = "CREATE TABLE " + table + " ( "
                + k_id + " varchar(80) NOT NULL PRIMARY KEY, "
                + k_r301J_k6 + " varchar(30), "
                + k_r301J_k9 + " varchar(30), "
                + k_r301K_k6 + " varchar(30), "
                + k_r301K_k9 + " varchar(30), "
                + k_r302_k6 + " varchar(30), "
                + k_r302_k9 + " varchar(30), "
                + k_r303_k6 + " varchar(30), "
                + k_r303_k9 + " varchar(30), "
                + k_r304_k6 + " varchar(30), "
                + k_r304_k9 + " varchar(30) "
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
            R301J_k6.Blok = this;
            R301J_k9.Blok = this;
            R301K_k6.Blok = this;
            R301K_k9.Blok = this;
            R302_k6.Blok = this;
            R302_k9.Blok = this;
            R303_k6.Blok = this;
            R303_k9.Blok = this;
            R304_k6.Blok = this;
            R304_k9.Blok = this;
        }

        public void changeValue(object var)
        {
            if (R301J_k9 == var)
            {
                Dokumen.changeValue(var);
            }
            sampaikanPerbuhan();
        }

        public Boolean checkError()
        {
           /* Console.WriteLine(String.Join(", ", R301J_k6.getAllError()));
            Console.WriteLine(String.Join(", ", R301J_k9.getAllError()));
            Console.WriteLine(String.Join(", ", R301K_k6.getAllError()));
            Console.WriteLine(String.Join(", ", R301K_k9.getAllError()));
            Console.WriteLine(String.Join(", ", R302_k6.getAllError()));
            Console.WriteLine(String.Join(", ", R302_k9.getAllError()));
            Console.WriteLine(String.Join(", ", R303_k6.getAllError()));
            Console.WriteLine(String.Join(", ", R303_k9.getAllError()));
            Console.WriteLine(String.Join(", ", R304_k6.getAllError()));
            Console.WriteLine(String.Join(", ", R304_k9.getAllError()));*/
            return !(R301J_k6.isError() ||
                R301J_k9.isError() ||
                R301K_k6.isError() ||
                R301K_k9.isError() ||
                R302_k6.isError() ||
                R302_k9.isError() ||
                R303_k6.isError() ||
                R303_k9.isError() ||
                R304_k6.isError() ||
                R304_k9.isError());
        }

        public static blok_iii getCopyForNextTriwulan(blok_iii from, string uid_dok, string triwulan)
        {
            blok_iii baru = new blok_iii();
            baru.Id.Data = String.Copy(uid_dok);
            if (from == null)
            {
                return baru;
            }

            if (from.R301J_k9.Data != null)
            {
                baru.R301J_k6.Data = Double.Parse(String.Copy(from.R301J_k9.Data.ToString()));
            }
            if (from.R301K_k9.Data != null)
            {
                baru.R301K_k6.Data = Double.Parse(String.Copy(from.R301K_k9.Data.ToString()));
            }
            if (from.R302_k9.Data != null)
            {
                baru.R302_k6.Data = Double.Parse(String.Copy(from.R302_k9.Data.ToString()));
            }
            if (from.R303_k9.Data != null)
            {
                baru.R303_k6.Data = Double.Parse(String.Copy(from.R303_k9.Data.ToString()));
            }
            if (from.R304_k9.Data != null)
            {
                baru.R304_k6.Data = Double.Parse(String.Copy(from.R304_k9.Data.ToString()));
            }
         
            Console.WriteLine("Masuk Blok iii generate "+ baru.R301K_k6.Data);
            return baru;
        }

        private Page_2 page2;
        public void setUserPageii(Page_2 _page1)
        {
            page2 = _page1;
        }
        public void sampaikanPerbuhan()
        {
            if (page2 != null)
            {
                page2.adaPerubahan();
            }
            
        }
    }
}
