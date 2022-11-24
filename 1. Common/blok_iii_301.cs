using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Akhi_Okhee._3._4._Client_Dokumen;
using MySql.Data.MySqlClient;

namespace Akhi_Okhee._1._Common
{
    public class blok_iii_301 : blok
    {
        public static string table = "blok_iii_301";
        public static string k_id = "id";
        public static string k_id_blok_i = "id_blok_i";
        public static string k_id_barang = "id_barang";
        public static string k_r301k4 = "r301k4";
        public static string k_r301k5 = "r301k5";
        public static string k_r301k6 = "r301k6";
        public static string k_r301k7 = "r301k7";
        public static string k_r301k8 = "r301k8";
        public static string k_r301k9 = "r301k9";
        public static string k_r301k10 = "r301k10";
        public static string k_r301catatan = "r301catatan";
        public static string k_is_error = "is_error";
        private Boolean awalbaru;

        private variable<string> id = new variable<string>(nama: k_id, panjang: 80, is_null: false);
        private variable<string> id_blok_i = new variable<string>(nama: k_id_blok_i, panjang: 80, is_null: false);
        private variable<string> id_barang = new variable<string>(nama: k_id_barang, panjang: 80, is_null: false);
        private variable<double?> r301k4 = new variable<double?>(nama: k_r301k4, min: 0, max: 999999, is_null: true);
        private variable<double?> r301k5 = new variable<double?>(nama: k_r301k5, min: 0, max: 999999999999, is_null: true);
        private variable<double?> r301k6 = new variable<double?>(nama: k_r301k6, min: 0, max: 999999999999999999, is_null: true);
        private variable<double?> r301k7 = new variable<double?>(nama: k_r301k7, min: 0, max: 999999, is_null: true);
        private variable<double?> r301k8 = new variable<double?>(nama: k_r301k8, min: 0, max: 999999999999, is_null: true);
        private variable<double?> r301k9 = new variable<double?>(nama: k_r301k9, min: 0, max: 999999999999999999, is_null: true);
        private variable<string> r301k10 = new variable<string>(nama: k_r301k10, panjang: 1, min: 1, max: 2, is_null: true);
        private variable<string> r301catatan = new variable<string>(nama: k_r301catatan, panjang: 256, is_null: true);
        private variable<string> is_error = new variable<string>(nama: k_is_error, panjang: 1, is_null: false); //0 tidak boleh dihapus 1:boleh dihapus
        private barang barang;
        private Dokumen dokumen;
        private Boolean isDelete = false;
        public variable<string> Id { get => id; set => id = value; }
        public variable<string> Id_blok_i { get => id_blok_i; set => id_blok_i = value; }
        public variable<string> Id_barang { get => id_barang; set => id_barang = value; }
        public variable<double?> R301k4 { get => r301k4; set => r301k4 = value; }
        public variable<double?> R301k5 { get => r301k5; set => r301k5 = value; }
        public variable<double?> R301k6 { get => r301k6; set => r301k6 = value; }
        public variable<double?> R301k7 { get => r301k7; set => r301k7 = value; }
        public variable<double?> R301k8 { get => r301k8; set => r301k8 = value; }
        public variable<double?> R301k9 { get => r301k9; set => r301k9 = value; }
        public variable<string> R301k10 { get => r301k10; set => r301k10 = value; }
        public variable<string> R301catatan { get => r301catatan; set => r301catatan = value; }
        public variable<string> Is_error { get => is_error; set => is_error = value; }
        public barang Barang { get => barang; set => barang = value; }
        public bool Awalbaru { get => awalbaru; set => awalbaru = value; }
        public Dokumen Dokumen { get => dokumen; set => dokumen = value; }
        public bool IsDelete { get => isDelete; set => isDelete = value; }

        private String insert_query = "INSERT INTO {0} ({1}, {2}, {3}, {4}, {5}, {6}, {7}, {8}, {9}, {10}, {11}, {12}) VALUES "
           + "(@{1}, @{2}, @{3}, @{4}, @{5}, @{6}, @{7}, @{8}, @{9}, @{10}, @{11}, @{12});";

        private String update_query = "UPDATE {0} SET {2} = @{2}, {3} = @{3}, {4} = @{4}, {5} = @{5}, {6} = @{6}, {7} = @{7}, {8} = @{8}, "
            + "{9} = @{9}, {10} = @{10}, {11} = @{11}, {12} = @{12} "
            + "WHERE {1} = @{1};";

        private String delete_query = "DELETE FROM {0} WHERE {1} = '{2}';";

        private String select_query = "SELECT * FROM {0} WHERE {1} = @{1};";

        public blok_iii_301()
        {
            Awalbaru = true;
        }

        public void InsertData(MySqlCommand cmd)
        {
            String insert_query_populate = String.Format(insert_query, table
                , k_id, k_id_blok_i, k_id_barang, k_r301k4, k_r301k5, k_r301k6, k_r301k7, k_r301k8, k_r301k9, k_r301k10, k_r301catatan, k_is_error);
            cmd.Parameters.Clear();
            cmd.CommandText = insert_query_populate;
            cmd.Parameters.AddWithValue("@" + k_id, Id.Data);
            Console.WriteLine("Data Idblok "+Id_blok_i.Data);
            cmd.Parameters.AddWithValue("@" + k_id_blok_i, Id_blok_i.Data);
            cmd.Parameters.AddWithValue("@" + k_id_barang, Id_barang.Data);
            if(R301k4.Data != default(double?))
            {
                cmd.Parameters.AddWithValue("@" + k_r301k4, ((double)R301k4.Data).ToString("N").Replace(CultureInfo.CurrentCulture.NumberFormat.NumberGroupSeparator, "").Replace(CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator, "|"));
            }
            else
            {
                cmd.Parameters.AddWithValue("@" + k_r301k4, null);
            }
            if (R301k5.Data != default(double?))
            {
                cmd.Parameters.AddWithValue("@" + k_r301k5, (long)R301k5.Data);
            }
            else
            {
                cmd.Parameters.AddWithValue("@" + k_r301k5, null);
            }
            if (R301k6.Data != default(double?))
            {
                cmd.Parameters.AddWithValue("@" + k_r301k6, (long)R301k6.Data);
            }
            else
            {
                cmd.Parameters.AddWithValue("@" + k_r301k6, null);
            }
            if (R301k7.Data != default(double?))
            {
                cmd.Parameters.AddWithValue("@" + k_r301k7, ((double)R301k7.Data).ToString("N").Replace(CultureInfo.CurrentCulture.NumberFormat.NumberGroupSeparator, "").Replace(CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator,"|"));
            }
            else
            {
                cmd.Parameters.AddWithValue("@" + k_r301k7, null);
            }
            if (R301k8.Data != default(double?))
            {
                cmd.Parameters.AddWithValue("@" + k_r301k8, (long)R301k8.Data);
            }
            else
            {
                cmd.Parameters.AddWithValue("@" + k_r301k8, null);
            }
            if (R301k9.Data != default(double?))
            {
                cmd.Parameters.AddWithValue("@" + k_r301k9, (long)R301k9.Data);
            }
            else
            {
                cmd.Parameters.AddWithValue("@" + k_r301k9, null);
            }
            
            cmd.Parameters.AddWithValue("@" + k_r301k10, R301k10.Data);
            cmd.Parameters.AddWithValue("@" + k_r301catatan, R301catatan.Data);
            cmd.Parameters.AddWithValue("@" + k_is_error, Is_error.Data);
            cmd.ExecuteNonQuery();
        }

        public void UpdateData(MySqlCommand cmd)
        {
            String update_query_populate = String.Format(update_query, table
               , k_id, k_id_blok_i, k_id_barang, k_r301k4, k_r301k5, k_r301k6, k_r301k7, k_r301k8, k_r301k9, k_r301k10, k_r301catatan, k_is_error);
            cmd.Parameters.Clear();
            cmd.CommandText = update_query_populate;
            cmd.Parameters.AddWithValue("@" + k_id, Id.Data);
            cmd.Parameters.AddWithValue("@" + k_id_blok_i, Id_blok_i.Data);
            cmd.Parameters.AddWithValue("@" + k_id_barang, Id_barang.Data);
            if (R301k4.Data != default(double?))
            {
                cmd.Parameters.AddWithValue("@" + k_r301k4, ((double)R301k4.Data).ToString("N").Replace(CultureInfo.CurrentCulture.NumberFormat.NumberGroupSeparator, "").Replace(CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator, "|"));
            }
            else
            {
                cmd.Parameters.AddWithValue("@" + k_r301k4, null);
            }
            if (R301k5.Data != default(double?))
            {
                cmd.Parameters.AddWithValue("@" + k_r301k5, (long)R301k5.Data);
            }
            else
            {
                cmd.Parameters.AddWithValue("@" + k_r301k5, null);
            }
            if (R301k6.Data != default(double?))
            {
                cmd.Parameters.AddWithValue("@" + k_r301k6, (long)R301k6.Data);
            }
            else
            {
                cmd.Parameters.AddWithValue("@" + k_r301k6, null);
            }
            if (R301k7.Data != default(double?))
            {
                cmd.Parameters.AddWithValue("@" + k_r301k7, ((double)R301k7.Data).ToString("N").Replace(CultureInfo.CurrentCulture.NumberFormat.NumberGroupSeparator, "").Replace(CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator, "|"));
            }
            else
            {
                cmd.Parameters.AddWithValue("@" + k_r301k7, null);
            }
            if (R301k8.Data != default(double?))
            {
                cmd.Parameters.AddWithValue("@" + k_r301k8, (long)R301k8.Data);
            }
            else
            {
                cmd.Parameters.AddWithValue("@" + k_r301k8, null);
            }
            if (R301k9.Data != default(double?))
            {
                cmd.Parameters.AddWithValue("@" + k_r301k9, (long)R301k9.Data);
            }
            else
            {
                cmd.Parameters.AddWithValue("@" + k_r301k9, null);
            }
            cmd.Parameters.AddWithValue("@" + k_r301k10, R301k10.Data);
            cmd.Parameters.AddWithValue("@" + k_r301catatan, R301catatan.Data);
            cmd.Parameters.AddWithValue("@" + k_is_error, Is_error.Data);
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
            String select_query_populate = String.Format(select_query, table, k_id);
            using (MySqlCommand cmd = new MySqlCommand(select_query_populate, conn))
            {
                cmd.Parameters.AddWithValue("@" + k_id, Id.Data);
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        Id.Data = (String)reader[k_id];
                        Id_blok_i.Data = (String)reader[k_id_blok_i];
                        Id_barang.Data = (String)reader[k_id_barang];
                        if (reader[k_r301k4] != DBNull.Value)
                        {
                            R301k4.Data = double.Parse(((string)reader[k_r301k4]).Replace("|", CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator));
                        }
                        if (reader[k_r301k5] != DBNull.Value)
                        {
                            R301k5.Data = double.Parse(((string)reader[k_r301k5]));
                        }
                        if (reader[k_r301k6] != DBNull.Value)
                        {
                            R301k6.Data = double.Parse(((string)reader[k_r301k6]));
                        }
                        if (reader[k_r301k7] != DBNull.Value)
                        {
                            R301k7.Data = double.Parse(((string)reader[k_r301k7]).Replace("|", CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator));
                        }
                        if (reader[k_r301k8] != DBNull.Value)
                        {
                            R301k8.Data = double.Parse(((string)reader[k_r301k8]));
                        }
                        if (reader[k_r301k9] != DBNull.Value)
                        {
                            R301k9.Data = double.Parse(((string)reader[k_r301k9]));
                        }
                        if (reader[k_r301k10] != DBNull.Value)
                        {
                            R301k10.Data = (string)reader[k_r301k10];
                        }
                        if (reader[k_r301catatan] != DBNull.Value)
                        {
                            R301catatan.Data = (string)reader[k_r301catatan];
                        }
                        if (reader[k_is_error] != DBNull.Value)
                        {
                            Is_error.Data = (String)reader[k_is_error];
                        }
                    }
                    reader.Close();
                }
            }
            Barang = new barang();
            Barang.Id.Data = Id_barang.Data;
            Barang.populate(conn);
            Awalbaru = false;
        }
        public void populate(MySqlDataReader reader)
        {
            Id.Data = (String)reader[k_id];
            Id_blok_i.Data = (String)reader[k_id_blok_i];
            Id_barang.Data = (String)reader[k_id_barang];
            if (reader[k_r301k4] != DBNull.Value)
            {
                R301k4.Data = double.Parse(((string)reader[k_r301k4]).Replace("|", CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator));
            }
            if (reader[k_r301k5] != DBNull.Value)
            {
                R301k5.Data = double.Parse(((string)reader[k_r301k5]));
            }
            if (reader[k_r301k6] != DBNull.Value)
            {
                R301k6.Data = double.Parse(((string)reader[k_r301k6]));
            }
            if (reader[k_r301k7] != DBNull.Value)
            {
                R301k7.Data = double.Parse(((string)reader[k_r301k7]).Replace("|", CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator));
            }
            if (reader[k_r301k8] != DBNull.Value)
            {
                R301k8.Data = double.Parse(((string)reader[k_r301k8]));
            }
            if (reader[k_r301k9] != DBNull.Value)
            {
                R301k9.Data = double.Parse(((string)reader[k_r301k9]));
            }
            if (reader[k_r301k10] != DBNull.Value)
            {
                R301k10.Data = (string)reader[k_r301k10];
            }
            if (reader[k_r301catatan] != DBNull.Value)
            {
                R301catatan.Data = (string)reader[k_r301catatan];
            }
            if (reader[k_is_error] != DBNull.Value)
            {
                Is_error.Data = (String)reader[k_is_error];
            }
            Awalbaru = false;
        }
        public static string getCreateQuery()
        {
            string create = "CREATE TABLE " + table + " ( "
                + k_id + " varchar(80) NOT NULL PRIMARY KEY, "
                + k_id_blok_i + " varchar(80) NOT NULL, "
                + k_id_barang + " varchar(80) NOT NULL, "
                + k_r301k4 + " varchar(30), "
                + k_r301k5 + " varchar(30), "
                + k_r301k6 + " varchar(30), "
                + k_r301k7 + " varchar(30), "
                + k_r301k8 + " varchar(30), "
                + k_r301k9 + " varchar(30), "
                + k_r301k10 + " varchar(1), "
                + k_r301catatan + " varchar(256), "
                + k_is_error + " varchar(1) "
                + ") ENGINE=InnoDB ;";
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
            Id_blok_i.Blok = this;
            Id_barang.Blok = this;
            R301k4.Blok = this;
            R301k5.Blok = this;
            R301k6.Blok = this;
            R301k7.Blok = this;
            R301k8.Blok = this;
            R301k9.Blok = this;
            R301k10.Blok = this;
            R301catatan.Blok = this;
            Is_error.Blok = this;
        }

        public void changeValue(object var)
        {
            if (var == null)
            {

            }
            else if (var != R301k7 && var != R301k8 && var != R301k10 && var != Id_barang)
            {
                return;
            }
            Id_barang.Err_konsistensi = new List<string>();
            R301k7.Err_konsistensi = new List<string>();
            R301k8.Err_konsistensi = new List<string>();
            R301k9.Err_konsistensi = new List<string>();
            R301k10.Err_konsistensi = new List<string>();

            if (Id_barang.Data.Equals(_301.Id_null))
            {
                Id_barang.Err_konsistensi.Add("Belum Memilih Barang");
            }
            if (R301k7.Data != default(double?) && R301k8.Data != default(double?))
            {
                R301k9.Data = R301k7.Data * R301k8.Data;
                Console.WriteLine("Tulis K9 |" + R301k7.Data * R301k8.Data);
                if (dokumen != null)
                {
                    dokumen.changeValue(var);
                }
            }
            else
            {
                R301k9.Data = default(double?);
                if (dokumen != null)
                {
                    dokumen.changeValue(var);
                }
            }

            if (Is_error.Data.Equals("1"))
            {
                Console.WriteLine("1 . 1");
                if (R301k7.Data == default(double?))
                {
                    R301k7.Err_konsistensi.Add("Isian R301k7 tidak boleh kosong");
                    //Console.WriteLine("1 . 1");
                }
                if (R301k8.Data == default(double?))
                {
                    R301k8.Err_konsistensi.Add("Isian R301k8 tidak boleh kosong");
                    //Console.WriteLine("1 . 2");
                }
                if (R301k9.Data == default(double?))
                {
                    R301k9.Err_konsistensi.Add("Isian R301k9 tidak boleh kosong");
                    //Console.WriteLine("1 . 2");
                }
                if (R301k10.Data == default(string))
                {
                    R301k10.Err_konsistensi.Add("Isian R301k10 tidak boleh kosong");
                    //Console.WriteLine("1 . 2");
                }
            }
            if (R301k7.Data != default(double?))
            {
                if (R301k8.Data == default(double?))
                {
                    R301k8.Err_konsistensi.Add("Isian R301k8 tidak boleh kosong jika R301k7 ada isi");
                }
                if (R301k9.Data == default(double?))
                {
                    R301k9.Err_konsistensi.Add("Isian R301k9 tidak boleh kosong jika R301k7 ada isi");
                }
                if (R301k10.Data == default(string))
                {
                    R301k10.Err_konsistensi.Add("Isian R301k10 tidak boleh kosong jika R301k7 ada isi");
                    //Console.WriteLine("1 . 2");
                }
            }
            if (R301k8.Data != default(double?))
            {
                if (R301k7.Data == default(double?))
                {
                    R301k7.Err_konsistensi.Add("Isian R301k7 tidak boleh kosong jika R301k8 ada isi");
                }
                if (R301k9.Data == default(double?))
                {
                    R301k9.Err_konsistensi.Add("Isian R301k9 tidak boleh kosong jika R301k8 ada isi");
                }
                if (R301k10.Data == default(string))
                {
                    R301k10.Err_konsistensi.Add("Isian R301k10 tidak boleh kosong jika R301k8 ada isi");
                    //Console.WriteLine("1 . 2");
                }
                if (Barang != null)
                {
                    if (R301k8.Data < Barang.Nilai_min.Data || R301k8.Data > Barang.Nilai_max.Data)
                    {
                        R301k8.Err_konsistensi.Add("Isian R301k8 tidak berada dalam range harga satuan " + Barang.Nama.Data + "( min: " + ((long)Barang.Nilai_min.Data).ToString("N0") + " sampai max : " + ((long)Barang.Nilai_max.Data).ToString("N0") + " per " + Barang.Satuan.Data);
                    }
                }
            }
            if (R301k10.Data != default(string))
            {
                if (R301k7.Data == default(double?))
                {
                    R301k7.Err_konsistensi.Add("Isian R301k7 tidak boleh kosong jika R301k10 ada isi");
                    //Console.WriteLine("1 . 2");
                }
                if (R301k8.Data == default(double?))
                {
                    R301k8.Err_konsistensi.Add("Isian R301k8 tidak boleh kosong jika R301k10 ada isi");
                }
                if (R301k9.Data == default(double?))
                {
                    R301k9.Err_konsistensi.Add("Isian R301k9 tidak boleh kosong jika R301k10 ada isi");
                }
               
            }
            if (dokumen != null && var==dokumen.Blok_ii.R201a)
            {
                if (dokumen.Blok_ii.R201a.Data != default(string))
                {
                    if (!dokumen.Blok_ii.R201a.Data.Equals("1") && !dokumen.Blok_ii.R201a.Data.Equals("2"))
                    {
                        Console.WriteLine("Perubahan Perubahan");
                        if (R301k7.Data != default(double?))
                        {
                            R301k7.Err_konsistensi.Add("Isian R201A berisi selain 1 atau 2 tapi Isian R301k7 tidak kosong");
                        }
                        if (R301k8.Data != default(double?))
                        {
                            R301k8.Err_konsistensi.Add("Isian R201A berisi selain 1 atau 2 tapi Isian R301k8 tidak kosong");
                        }
                        if (R301k9.Data != default(double?))
                        {
                            R301k9.Err_konsistensi.Add("Isian R201A berisi selain 1 atau 2 tapi Isian R301k9 tidak kosong");
                        }
                        if(R301k10.Data != default(string))
                        {
                            R301k10.Err_konsistensi.Add("Isian R201A berisi selain 1 atau 2 tapi Isian R301k10 tidak kosong");
                        }
                        /*sampaikanPerbuhan();*/
                    }
                }
            }
           
            /*if (R301k9.Data != default(double?))
            {
                if (R301k7.Data == default(double?))
                {
                    R301k7.Err_konsistensi.Add("Isian R301k7 tidak boleh kosong jika R301k9 ada isi");
                }
                if (R301k8.Data == default(double?))
                {
                    R301k8.Err_konsistensi.Add("Isian R301k8 tidak boleh kosong jika R301k9 ada isi");
                }
                if (R301k7.Data != default(double?) && R301k8.Data != default(double?))
                {
                    if (R301k9.Data != R301k7.Data * R301k8.Data)
                    {
                        R301k9.Err_konsistensi.Add("Isian R301k9 tidak sama dengan hasil perkalian kolom 7 dan 8 ");
                    }
                    if (Barang != null)
                    {
                        if (R301k9.Data < Barang.Nilai_min.Data * R301k7.Data || R301k9.Data > Barang.Nilai_max.Data * R301k7.Data)
                        {
                            R301k9.Err_konsistensi.Add("Isian R301k9 tidak berada dalam range harga satuan " + Barang.Nama.Data);
                        }
                    }
                }
            }*/


            if (R301k7.Err_konsistensi.Count > 0)
            {
                R301k7.Is_error_konsistensi = true;
            }
            else
            {
                R301k7.Is_error_konsistensi = false;
            }
            if (R301k8.Err_konsistensi.Count > 0)
            {
                R301k8.Is_error_konsistensi = true;
            }
            else
            {
                R301k8.Is_error_konsistensi = false;
            }
            if (var != null)
            {
                sampaikanPerbuhan();
            }
        }
        public Boolean checkError()
        {
            return  !(R301k4.isError() ||
                R301k5.isError() ||
                R301k6.isError() ||
                R301k7.isError() ||
                R301k8.isError() ||
                R301k9.isError() ||
                R301k10.isError() ||
                R301catatan.isError());
        }

        public Boolean checkErrorReval()
        {
            Id_barang.Err_konsistensi = new List<string>();
            R301k7.Err_konsistensi = new List<string>();
            R301k8.Err_konsistensi = new List<string>();
            R301k9.Err_konsistensi = new List<string>();
            R301k10.Err_konsistensi = new List<string>();

            if (Id_barang.Data.Equals(_301.Id_null))
            {
                Id_barang.Err_konsistensi.Add("Belum Memilih Barang");
            }

            if (Is_error.Data.Equals("1"))
            {
                Console.WriteLine("1 . 1");
                if (R301k7.Data == default(double?))
                {
                    R301k7.Err_konsistensi.Add("Isian R301k7 tidak boleh kosong");
                    //Console.WriteLine("1 . 1");
                }
                if (R301k8.Data == default(double?))
                {
                    R301k8.Err_konsistensi.Add("Isian R301k8 tidak boleh kosong");
                    //Console.WriteLine("1 . 2");
                }
                if (R301k9.Data == default(double?))
                {
                    R301k9.Err_konsistensi.Add("Isian R301k9 tidak boleh kosong");
                    //Console.WriteLine("1 . 2");
                }
                if (R301k10.Data == default(string))
                {
                    R301k10.Err_konsistensi.Add("Isian R301k10 tidak boleh kosong");
                    //Console.WriteLine("1 . 2");
                }
            }
            if (R301k7.Data != default(double?))
            {
                if (R301k8.Data == default(double?))
                {
                    R301k8.Err_konsistensi.Add("Isian R301k8 tidak boleh kosong jika R301k7 ada isi");
                }
                if (R301k9.Data == default(double?))
                {
                    R301k9.Err_konsistensi.Add("Isian R301k9 tidak boleh kosong jika R301k7 ada isi");
                }
                if (R301k10.Data == default(string))
                {
                    R301k10.Err_konsistensi.Add("Isian R301k10 tidak boleh kosong jika R301k7 ada isi");
                    //Console.WriteLine("1 . 2");
                }
            }
            if (R301k8.Data != default(double?))
            {
                if (R301k7.Data == default(double?))
                {
                    R301k7.Err_konsistensi.Add("Isian R301k7 tidak boleh kosong jika R301k8 ada isi");
                }
                if (R301k9.Data == default(double?))
                {
                    R301k9.Err_konsistensi.Add("Isian R301k9 tidak boleh kosong jika R301k8 ada isi");
                }
                if (R301k10.Data == default(string))
                {
                    R301k10.Err_konsistensi.Add("Isian R301k10 tidak boleh kosong jika R301k8 ada isi");
                    //Console.WriteLine("1 . 2");
                }
                if (Barang != null)
                {
                    if (R301k8.Data < Barang.Nilai_min.Data || R301k8.Data > Barang.Nilai_max.Data)
                    {
                        R301k8.Err_konsistensi.Add("Isian R301k8 tidak berada dalam range harga satuan " + Barang.Nama.Data + "( min: " + ((long)Barang.Nilai_min.Data).ToString("N0") + " sampai max : " + ((long)Barang.Nilai_max.Data).ToString("N0") + " per " + Barang.Satuan.Data);
                    }
                }
            }
            if (R301k10.Data != default(string))
            {
                if (R301k7.Data == default(double?))
                {
                    R301k7.Err_konsistensi.Add("Isian R301k7 tidak boleh kosong jika R301k10 ada isi");
                    //Console.WriteLine("1 . 2");
                }
                if (R301k8.Data == default(double?))
                {
                    R301k8.Err_konsistensi.Add("Isian R301k8 tidak boleh kosong jika R301k10 ada isi");
                }
                if (R301k9.Data == default(double?))
                {
                    R301k9.Err_konsistensi.Add("Isian R301k9 tidak boleh kosong jika R301k10 ada isi");
                }

            }
            if (dokumen != null)
            {
                if (dokumen.Blok_ii.R201a.Data != default(string))
                {
                    if (!dokumen.Blok_ii.R201a.Data.Equals("1") && !dokumen.Blok_ii.R201a.Data.Equals("2"))
                    {
                        Console.WriteLine("Perubahan Perubahan");
                        if (R301k7.Data != default(double?))
                        {
                            R301k7.Err_konsistensi.Add("Isian R201A berisi selain 1 atau 2 tapi Isian R301k7 tidak kosong");
                        }
                        if (R301k8.Data != default(double?))
                        {
                            R301k8.Err_konsistensi.Add("Isian R201A berisi selain 1 atau 2 tapi Isian R301k8 tidak kosong");
                        }
                        if (R301k9.Data != default(double?))
                        {
                            R301k9.Err_konsistensi.Add("Isian R201A berisi selain 1 atau 2 tapi Isian R301k9 tidak kosong");
                        }
                        if (R301k10.Data != default(string))
                        {
                            R301k10.Err_konsistensi.Add("Isian R201A berisi selain 1 atau 2 tapi Isian R301k10 tidak kosong");
                        }
                        /*sampaikanPerbuhan();*/
                    }
                }
            }

           


            if (R301k7.Err_konsistensi.Count > 0)
            {
                R301k7.Is_error_konsistensi = true;
            }
            else
            {
                R301k7.Is_error_konsistensi = false;
            }
            if (R301k8.Err_konsistensi.Count > 0)
            {
                R301k8.Is_error_konsistensi = true;
            }
            else
            {
                R301k8.Is_error_konsistensi = false;
            }
            
            return  !(R301k4.isError() ||
                R301k5.isError() ||
                R301k6.isError() ||
                R301k7.isError() ||
                R301k8.isError() ||
                R301k9.isError() ||
                R301k10.isError() ||
                R301catatan.isError());
        }

        public static blok_iii_301 getCopyForNextTriwulan(blok_iii_301 from, string uid_dok, string triwulanan)
        {
            if (from == null) return null;

            if (from.Id_barang.Data == null) return null;
           
            if (from.R301k7.Data == null && from.R301k8.Data == null && from.R301k9.Data == null)
            {
                return null;
            }
            else
            {
                blok_iii_301 baru = new blok_iii_301();
                baru.Id.Data = System.Guid.NewGuid().ToString();
                baru.Id_barang.Data = String.Copy(from.Id_barang.Data);
                baru.id_blok_i.Data = String.Copy(uid_dok);

                if (from.R301k7.Data != null)
                {
                    baru.R301k4.Data = Double.Parse(String.Copy(from.R301k7.Data.ToString()));
                }

                if (from.R301k8.Data != null)
                {
                    baru.R301k5.Data = Double.Parse(String.Copy(from.R301k8.Data.ToString()));
                }

                if (from.R301k9.Data != null)
                {
                    baru.R301k6.Data = Double.Parse(String.Copy(from.R301k9.Data.ToString()));
                }
               
                baru.Is_error.Data = "0";
                return baru;
            }
        }

        private _301 item_301;
        public void setUser301Iter(_301 _item_301)
        {
            item_301 = _item_301;
        }
        public void sampaikanPerbuhan()
        {
            if (item_301 != null)
            {
                item_301.adaPerubahan();
            }
        }
    }
}
