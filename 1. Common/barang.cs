using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Akhi_Okhee._1._Common
{
    public class barang
    {
        public static string table = "barang";
        public static string k_id = "id";
        public static string k_prov = "prov";
        public static string k_kab = "kab";
        public static string k_nama = "nama";
        public static string k_jenis = "jenis";
        public static string k_satuan = "satuan";
        public static string k_kbli = "kbli";
        public static string k_nilai_min = "nilai_min";
        public static string k_nilai_max = "nilai_max";


        private variable<string> id = new variable<string>(nama: k_id, panjang: 80, is_null: false);
        private variable<string> prov = new variable<string>(nama: k_prov, panjang: 2, is_null: false);
        private variable<string> kab = new variable<string>(nama: k_kab, panjang: 2, is_null: false);
        private variable<string> nama = new variable<string>(nama: k_nama, panjang: 256, is_null: false);
        private variable<string> jenis = new variable<string>(nama: k_jenis, panjang: 2, is_null: false);
        private variable<string> satuan = new variable<string>(nama: k_satuan, panjang: 20, is_null: false);
        private variable<string> kbli = new variable<string>(nama: k_kbli, panjang: 5, is_null: false);
        private variable<long?> nilai_min = new variable<long?>(nama: k_nilai_min, min: 0, max: 999999999999, is_null: false);
        private variable<long?> nilai_max = new variable<long?>(nama: k_nilai_max, min: 0, max: 999999999999, is_null: false);

        public variable<string> Id { get => id; set => id = value; }
        public variable<string> Nama { get => nama; set => nama = value; }
        public variable<string> Jenis { get => jenis; set => jenis = value; }
        public variable<string> Satuan { get => satuan; set => satuan = value; }
        public variable<long?> Nilai_min { get => nilai_min; set => nilai_min = value; }
        public variable<long?> Nilai_max { get => nilai_max; set => nilai_max = value; }
        public variable<string> Prov { get => prov; set => prov = value; }
        public variable<string> Kab { get => kab; set => kab = value; }
        public variable<string> Kbli { get => kbli; set => kbli = value; }

        private String insert_query = "INSERT INTO {0} ({1}, {2}, {3}, {4}, {5}, {6}, {7}, {8}, {9}) VALUES "
            + "(@{1}, @{2}, @{3}, @{4}, @{5}, @{6}, @{7}, @{8}, @{9})";

        private String update_query = "UPDATE {0} SET {2} = @{2}, {3} = @{3}, {4} = @{4}, {5} = @{5}, {6} = @{6}, {7} = @{7}, {8} = @{8}, {9} = @{9} "
            + "WHERE {1} = @{1}";

        private String delete_query = "DELETE FROM {0} WHERE {1} = @{1}";

        private String select_query = "SELECT * FROM {0} WHERE {1} = @{1}";

        public void InsertData(MySqlCommand cmd)
        {
            String insert_query_populate = String.Format(insert_query, table
                , k_id,k_prov, k_kab, k_nama, k_kbli, k_jenis, k_satuan, k_nilai_min, k_nilai_max);

            cmd.CommandText = insert_query_populate;
            cmd.Parameters.AddWithValue("@" + k_id, Id.Data);
            cmd.Parameters.AddWithValue("@" + k_prov, prov.Data);
            cmd.Parameters.AddWithValue("@" + k_kab, kab.Data);
            cmd.Parameters.AddWithValue("@" + k_nama, Nama.Data);
            cmd.Parameters.AddWithValue("@" + k_jenis, Jenis.Data);
            cmd.Parameters.AddWithValue("@" + k_kbli, Kbli.Data);
            cmd.Parameters.AddWithValue("@" + k_satuan, Satuan.Data);
            cmd.Parameters.AddWithValue("@" + k_nilai_min, ((long)Nilai_min.Data));
            cmd.Parameters.AddWithValue("@" + k_nilai_max, ((long)Nilai_max.Data));

            cmd.ExecuteNonQuery();
            
        }

        public void UpdateData(MySqlCommand cmd)
        {
            String update_query_populate = String.Format(update_query, table
                , k_id, k_prov, k_kab, k_nama, k_kbli, k_jenis, k_satuan, k_nilai_min, k_nilai_max);
            cmd.CommandText = update_query_populate;
            cmd.Parameters.AddWithValue("@" + k_id, Id.Data);
            cmd.Parameters.AddWithValue("@" + k_prov, prov.Data);
            cmd.Parameters.AddWithValue("@" + k_kab, kab.Data);
            cmd.Parameters.AddWithValue("@" + k_nama, Nama.Data);
            cmd.Parameters.AddWithValue("@" + k_jenis, Jenis.Data);
            cmd.Parameters.AddWithValue("@" + k_kbli, Kbli.Data);
            cmd.Parameters.AddWithValue("@" + k_satuan, Satuan.Data);
            cmd.Parameters.AddWithValue("@" + k_nilai_min, ((long)Nilai_min.Data));
            cmd.Parameters.AddWithValue("@" + k_nilai_max, ((long)Nilai_max.Data));
            cmd.ExecuteNonQuery();

        }

        public void DeleteData(MySqlCommand cmd)
        {
            String delete_query_populate = String.Format(delete_query, table, k_id);
            cmd.CommandText = delete_query_populate;
            cmd.Parameters.AddWithValue("@" + k_id, Id.Data);
            cmd.ExecuteNonQuery();
            
        }

        public void Delete301DataByBarang(MySqlCommand cmd)
        {
            string delete301 = "DELETE FROM {0} WHERE {1} = @{1}";
            String delete_query_populate = String.Format(delete301, blok_iii_301.table, blok_iii_301.k_id_barang);
            cmd.CommandText = delete301;
            cmd.Parameters.AddWithValue("@" + blok_iii_301.k_id_barang, Id.Data);
            cmd.ExecuteNonQuery();

        }

        public void populate(MySqlConnection conn)
        {
            String select_query_populate = String.Format(select_query, table, k_id);
            using (MySqlCommand cmd = new MySqlCommand(select_query_populate, conn))
            {
                cmd.Parameters.AddWithValue("@" + k_id, Id);
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        Id.Data = (String)reader[k_id];
                        Prov.Data = (String)reader[k_prov];
                        Kab.Data = (String)reader[k_kab];
                        Nama.Data = (String)reader[k_nama];
                        Jenis.Data = (String)reader[k_jenis];
                        Satuan.Data = (String)reader[k_satuan];
                        Kbli.Data = (String)reader[k_kbli];
                        if (((string)reader[k_nilai_min]).Equals(""))
                        {
                            Nilai_min.Data = null;
                        }
                        else
                        {
                            Nilai_min.Data = long.Parse(((string)reader[k_nilai_min]).Replace("|", CultureInfo.CurrentCulture.NumberFormat.NumberGroupSeparator));
                        }
                        if (((string)reader[k_nilai_max]).Equals(""))
                        {
                            Nilai_max.Data = null;
                        }
                        else
                        {
                            Nilai_max.Data = long.Parse(((string)reader[k_nilai_max]).Replace("|", CultureInfo.CurrentCulture.NumberFormat.NumberGroupSeparator));
                        }
                    }
                }
            }
        }
        public static string getCreateQuery()
        {
            string create = "CREATE TABLE " + table + " ( "
                + k_id + " varchar(80) NOT NULL PRIMARY KEY, "
                + k_prov + " varchar(2) NOT NULL , "
                + k_kab + " varchar(4) NOT NULL , "
                + k_nama + " varchar(256) NOT NULL, "
                + k_jenis + " varchar(2) NOT NULL, "
                + k_satuan + " varchar(20) NOT NULL, "
                + k_kbli + " varchar(5) NOT NULL, "
                + k_nilai_min + " varchar(18) NOT NULL, "
                + k_nilai_max + " varchar(18) NOT NULL "
                + ") ENGINE=InnoDB; ";
            return create;
        }
        public static string getDropQuery()
        {
            string drop = String.Format("DROP TABLE IF EXISTS {0};", table);
            Console.WriteLine(drop);
            return drop;
        }
    }
}
