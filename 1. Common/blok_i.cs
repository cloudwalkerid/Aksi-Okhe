using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Akhi_Okhee._3._4._Client_Dokumen;
using System.Data;
using MySql.Data.MySqlClient;

namespace Akhi_Okhee._1._Common
{
    public class blok_i : blok
    {
        public static string table = "blok_i";
        public static string k_id = "id";
        public static string k_nks_nus = "nks_nus";
        public static string k_r101 = "r101";
        public static string k_r102 = "r102";
        public static string k_r103 = "r103";
        public static string k_r104 = "r104";
        public static string k_r105 = "r105";
        public static string k_r106 = "r106";
        public static string k_r107 = "r107";
        public static string k_r108 = "r108";
        public static string k_r109 = "r109";
        public static string k_r110 = "r110";
        public static string k_r111 = "r111";
        public static string k_r112 = "r112";
        public static string k_r113 = "r113";
        public static string k_r114 = "r114";
        public static string k_r115 = "r115";
        public static string k_r116 = "r116";
        public static string k_triwulan = "triwulan";
        public static string k_error = "k_error";
        public static string k_is_lock = "is_lock";
        public static string k_lock_user = "lock_user";
        private Dokumen dokumen;

        private variable<string> id = new variable<string>(nama: k_id, panjang: 80, is_null: false);
        private variable<string> nks_nus = new variable<string>(nama: k_nks_nus, panjang: 11, is_null: false);
        private variable<string> r101 = new variable<string>(nama: k_r101, panjang: 2, is_null: false);
        private variable<string> r102 = new variable<string>(nama: k_r102, panjang: 4, is_null: false);
        private variable<string> r103 = new variable<string>(nama: k_r103, panjang: 7, is_null: false);
        private variable<string> r104 = new variable<string>(nama: k_r104, panjang: 10, is_null: false);
        private variable<string> r105 = new variable<string>(nama: k_r105, panjang: 6, is_null: false);
        private variable<string> r106 = new variable<string>(nama: k_r106, panjang: 7, is_null: false);
        private variable<string> r107 = new variable<string>(nama: k_r107, panjang: 3, is_null: false);
        private variable<string> r108 = new variable<string>(nama: k_r108, panjang: 3, is_null: false);
        private variable<string> r109 = new variable<string>(nama: k_r109, panjang: 256, is_null: false);
        private variable<string> r110 = new variable<string>(nama: k_r110, panjang: 256, is_null: true);
        private variable<string> r111 = new variable<string>(nama: k_r111, panjang: 256, is_null: true);
        private variable<string> r112 = new variable<string>(nama: k_r112, panjang: 20, is_null: true);
        private variable<string> r113 = new variable<string>(nama: k_r113, panjang: 256, is_null: true);
        private variable<string> r114 = new variable<string>(nama: k_r114, panjang: 5, is_null: false);
        private variable<string> r115 = new variable<string>(nama: k_r115, panjang: 1, min: 1, max: 2, is_null: false);
        private variable<string> r116 = new variable<string>(nama: k_r116, panjang: 1, min: 1, max: 2, is_null: false);
        private variable<string> triwulan = new variable<string>(nama: k_triwulan, panjang: 1, is_null: false);
        private variable<string> error = new variable<string>(nama: k_error, panjang: 1, is_null: false); //0:belum 1:benar 2:salah 3:can't edit again
        private variable<string> is_lock = new variable<string>(nama: k_triwulan, panjang: 1, is_null: false); //0: not lock , 1:lock
        private variable<string> lock_user = new variable<string>(nama: k_error, panjang: 80, is_null: true); //
        private int intTriwulan;

        private string nama_r101;
        private string nama_r102;
        private string nama_r103;
        private string nama_r104;
        private string nama_r115;
        private string nama_r116;




        public int IntTriwulan { get => intTriwulan; set => intTriwulan = value; }
        public string Nama_r101 { get => nama_r101; set => nama_r101 = value; }
        public string Nama_r102 { get => nama_r102; set => nama_r102 = value; }
        public string Nama_r103 { get => nama_r103; set => nama_r103 = value; }
        public string Nama_r104 { get => nama_r104; set => nama_r104 = value; }
        public variable<string> Id { get => id; set => id = value; }
        public variable<string> R101 { get => r101; set => r101 = value; }
        public variable<string> R102 { get => r102; set => r102 = value; }
        public variable<string> R103 { get => r103; set => r103 = value; }
        public variable<string> R104 { get => r104; set => r104 = value; }
        public variable<string> R105 { get => r105; set => r105 = value; }
        public variable<string> R106 { get => r106; set => r106 = value; }
        public variable<string> R107 { get => r107; set => r107 = value; }
        public variable<string> R108 { get => r108; set => r108 = value; }
        public variable<string> R109 { get => r109; set => r109 = value; }
        public variable<string> R110 { get => r110; set => r110 = value; }
        public variable<string> R111 { get => r111; set => r111 = value; }
        public variable<string> R112 { get => r112; set => r112 = value; }
        public variable<string> R113 { get => r113; set => r113 = value; }
        public variable<string> R114 { get => r114; set => r114 = value; }
        public variable<string> R115 { get => r115; set => r115 = value; }
        public variable<string> R116 { get => r116; set => r116 = value; }
        public variable<string> Triwulan { get => triwulan; set => triwulan = value; }
        public variable<string> Error { get => error; set => error = value; }
        public Dokumen Dokumen { get => dokumen; set => dokumen = value; }
        public variable<string> Nks_nus { get => nks_nus; set => nks_nus = value; }
        public string Nama_r115 { get => nama_r115; set => nama_r115 = value; }
        public string Nama_r116 { get => nama_r116; set => nama_r116 = value; }
        public variable<string> Is_lock { get => is_lock; set => is_lock = value; }
        public variable<string> Lock_user { get => lock_user; set => lock_user = value; }

        private String insert_query = "INSERT INTO {0} ({1}, {2}, {3}, {4}, {5}, {6}, {7}, {8}, {9}, {10}, {11}, {12}, {13}, {14}, {15}, {16}, {17}, {18}, {19}, {20}, {21}, {22}) VALUES "
            + "(@{1}, @{2}, @{3}, @{4}, @{5}, @{6}, @{7}, @{8}, @{9}, @{10}, @{11}, @{12}, @{13}, @{14}, @{15}, @{16}, @{17}, @{18}, @{19}, @{20}, @{21}, @{22});";

        private String update_query = "UPDATE {0} SET {2} = @{2}, {3} = @{3}, {4} = @{4}, {5} = @{5}, {6} = @{6}, {7} = @{7}, {8} = @{8}, "
            + "{9} = @{9}, {10} = @{10}, {11} = @{11}, {12} = @{12}, {13} = @{13}, {14} = @{14}, "
            + "{15} = @{15}, {16} = @{16}, {17} = @{17}, {18} = @{18}, {19} = @{19} , {20} = @{20}, {21} = @{21} , {22} = @{22} "
            + "WHERE {1} = @{1};";


        private String delete_query = "DELETE FROM {0} WHERE {1} = '{2}';";

        private String delete_query_nks = "DELETE FROM {0} WHERE {1} LIKE '{2}%';";

        private String select_query = "SELECT * FROM {0} WHERE {1} = {1};";

        public string generateUuid()
        {
            Id.Data = "" + Guid.NewGuid();
            return Id.Data;
        }
        public void setTriwulanint(string tri)
        {
            if (tri == "1")
            {
                Triwulan.Data = "1";
                IntTriwulan = 1;
            }
            else if (tri == "2")
            {
                Triwulan.Data = "2";
                IntTriwulan = 2;
            }
            else if (tri == "3")
            {
                Triwulan.Data = "3";
                IntTriwulan = 3;
            }
            else if (tri == "4")
            {
                Triwulan.Data = "4";
                IntTriwulan = 4;
            }
        }

        public void InsertData(MySqlCommand cmd)
        {
            String insert_query_populate = String.Format(insert_query, table
                , k_id, k_nks_nus, k_r101, k_r102, k_r103, k_r104, k_r105, k_r106, k_r107, k_r108, k_r109, k_r110, k_r111
                , k_r112, k_r113, k_r114, k_r115, k_r116, k_triwulan, k_error, k_is_lock, k_lock_user);
           /* Console.WriteLine(insert_query_populate);
            Console.WriteLine(Is_lock.Data);*/
            cmd.Parameters.Clear();
            cmd.CommandText = insert_query_populate;
            cmd.Parameters.AddWithValue("@" + k_id, Id.Data);
            cmd.Parameters.AddWithValue("@" + k_nks_nus, nks_nus.Data);
            cmd.Parameters.AddWithValue("@" + k_r101, R101.Data);
            cmd.Parameters.AddWithValue("@" + k_r102, R102.Data);
            cmd.Parameters.AddWithValue("@" + k_r103, R103.Data);
            cmd.Parameters.AddWithValue("@" + k_r104, R104.Data);
            cmd.Parameters.AddWithValue("@" + k_r105, R105.Data);
            cmd.Parameters.AddWithValue("@" + k_r106, R106.Data);
            cmd.Parameters.AddWithValue("@" + k_r107, R107.Data);
            cmd.Parameters.AddWithValue("@" + k_r108, R108.Data);
            cmd.Parameters.AddWithValue("@" + k_r109, R109.Data);
            cmd.Parameters.AddWithValue("@" + k_r110, R110.Data);
            cmd.Parameters.AddWithValue("@" + k_r111, R111.Data);
            cmd.Parameters.AddWithValue("@" + k_r112, R112.Data);
            cmd.Parameters.AddWithValue("@" + k_r113, R113.Data);
            cmd.Parameters.AddWithValue("@" + k_r114, R114.Data);
            cmd.Parameters.AddWithValue("@" + k_r115, R115.Data);
            cmd.Parameters.AddWithValue("@" + k_r116, R116.Data);
            cmd.Parameters.AddWithValue("@" + k_triwulan, Triwulan.Data);
            cmd.Parameters.AddWithValue("@" + k_error, Error.Data);
            cmd.Parameters.AddWithValue("@" + k_is_lock, Is_lock.Data);
            cmd.Parameters.AddWithValue("@" + k_lock_user, Lock_user.Data);
            cmd.ExecuteNonQuery();
            
        }

        public void UpdateData(MySqlCommand cmd)
        {
            String update_query_populate = String.Format(update_query, table
                , k_id, k_nks_nus, k_r101, k_r102, k_r103, k_r104, k_r105, k_r106, k_r107, k_r108, k_r109, k_r110, k_r111
                , k_r112, k_r113, k_r114, k_r115, k_r116, k_triwulan, k_error, k_is_lock, k_lock_user);
            cmd.Parameters.Clear();
            cmd.CommandText = update_query_populate;
            cmd.Parameters.AddWithValue("@" + k_id, Id.Data);
            cmd.Parameters.AddWithValue("@" + k_nks_nus, nks_nus.Data);
            cmd.Parameters.AddWithValue("@" + k_r101, R101.Data);
            cmd.Parameters.AddWithValue("@" + k_r102, R102.Data);
            cmd.Parameters.AddWithValue("@" + k_r103, R103.Data);
            cmd.Parameters.AddWithValue("@" + k_r104, R104.Data);
            cmd.Parameters.AddWithValue("@" + k_r105, R105.Data);
            cmd.Parameters.AddWithValue("@" + k_r106, R106.Data);
            cmd.Parameters.AddWithValue("@" + k_r107, R107.Data);
            cmd.Parameters.AddWithValue("@" + k_r108, R108.Data);
            cmd.Parameters.AddWithValue("@" + k_r109, R109.Data);
            cmd.Parameters.AddWithValue("@" + k_r110, R110.Data);
            cmd.Parameters.AddWithValue("@" + k_r111, R111.Data);
            cmd.Parameters.AddWithValue("@" + k_r112, R112.Data);
            cmd.Parameters.AddWithValue("@" + k_r113, R113.Data);
            cmd.Parameters.AddWithValue("@" + k_r114, R114.Data);
            cmd.Parameters.AddWithValue("@" + k_r115, R115.Data);
            cmd.Parameters.AddWithValue("@" + k_r116, R116.Data);
            cmd.Parameters.AddWithValue("@" + k_triwulan, Triwulan.Data);
            cmd.Parameters.AddWithValue("@" + k_error, Error.Data);
            cmd.Parameters.AddWithValue("@" + k_is_lock, Is_lock.Data);
            cmd.Parameters.AddWithValue("@" + k_lock_user, Lock_user.Data);
            cmd.ExecuteNonQuery();
        }

        public void MakeDataClaim(MySqlCommand cmd, Akun activeAkun)
        {
            try
            {
                String update_query_claim = "UPDATE " + table + " SET " + k_lock_user + " = '" + activeAkun.Username + "' , " + k_is_lock + " = '1' WHERE " + k_id + " = '" + Id.Data + "' AND " + k_lock_user + " IS NULL AND " + k_is_lock + " = '0' ;";
               /* Console.WriteLine("Data Claim");*/
                cmd.Parameters.Clear();
                cmd.CommandText = update_query_claim;
                int rowUpdate =  cmd.ExecuteNonQuery();
                if (rowUpdate != 1)
                {
                    Console.WriteLine(update_query_claim);
                    Console.WriteLine(rowUpdate);
                    throw new GagalClaimExceptioncs(this);
                }
                Lock_user.Data = activeAkun.Username;
                Is_lock.Data = "1";
            }catch(Exception ex)
            {
                throw new GagalClaimExceptioncs(this);
            }
           
        }

        public void ReleaseDataClaim(MySqlCommand cmd, Akun activeAkun)
        {
            try
            {
                String update_query_claim = "UPDATE " + table + " SET " + k_lock_user + " = NULL , " + k_is_lock + " = '0' WHERE " + k_id + " = '" + Id.Data + "' AND " + k_lock_user + "  = '" + activeAkun.Username + "' AND " + k_is_lock + " = '1' ;";
                /*Console.WriteLine("Release Data Claim");
                Console.WriteLine(update_query_claim);*/
                cmd.Parameters.Clear();
                cmd.CommandText = update_query_claim;
                int rowUpdate = cmd.ExecuteNonQuery();
                if (rowUpdate != 1)
                {
                    Console.WriteLine(update_query_claim);
                    Console.WriteLine(rowUpdate);
                    throw new GagalClaimExceptioncs(this);
                }
                Lock_user.Data = null;
                Is_lock.Data = "0";
            }catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);
                throw new GagalClaimExceptioncs(this);
            }
           
        }

        public void DeleteData(MySqlCommand cmd)
        {
            String delete_query_populate = String.Format(delete_query, table, k_id, Id.Data);
            cmd.CommandText = delete_query_populate;
            cmd.ExecuteNonQuery();
            Console.WriteLine(delete_query_populate);
        }

        public void DeleteDataNKSNUS(MySqlCommand cmd)
        {
            String delete_query_populate = String.Format(delete_query, table, k_nks_nus);
            cmd.CommandText = delete_query_populate;
            cmd.Parameters.AddWithValue("@" + k_nks_nus, nks_nus.Data.Substring(0,10));
            cmd.ExecuteNonQuery();
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
                    Nks_nus.Data = (String)reader[k_nks_nus];
                    R101.Data = (String)reader[k_r101];
                    R102.Data = (String)reader[k_r102];
                    R103.Data = (String)reader[k_r103];
                    R104.Data = (String)reader[k_r104];
                    R105.Data = (String)reader[k_r105];
                    R106.Data = (String)reader[k_r106];
                    R107.Data = (String)reader[k_r107];
                    R108.Data = (String)reader[k_r108];
                    R109.Data = (String)reader[k_r109];
                    R110.Data = (String)reader[k_r110];
                    R111.Data = (String)reader[k_r111];
                    if (reader[k_r112] != DBNull.Value)
                    {
                        R112.Data = (String)reader[k_r112];
                    }
                    
                    R113.Data = (String)reader[k_r113];
                    R114.Data = (String)reader[k_r114];
                    R115.Data = (String)reader[k_r115];
                    R116.Data = (String)reader[k_r116];
                    Triwulan.Data = (String)reader[k_triwulan];
                    setTriwulanint((String)reader[k_triwulan]);
                    Error.Data = (String)reader[k_error];
                    Is_lock.Data = (String)reader[k_is_lock];
                    if (reader[k_lock_user] != DBNull.Value)
                    {
                        Lock_user.Data = (String)reader[k_lock_user];
                    }
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Populate blok i");
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);
            }
        }

        public static string getCreateQuery()
        {
            string create = "CREATE TABLE "+table+" ( "
                + k_id+ " varchar(80) NOT NULL PRIMARY KEY, "
                + k_nks_nus + " varchar(11) UNIQUE NOT NULL , "
                + k_r101+ " varchar(2) NOT NULL , "
                + k_r102+ " varchar(4) NOT NULL , "
                + k_r103+ " varchar(7) NOT NULL , "
                + k_r104+ " varchar(10) NOT NULL , "
                + k_r105+ " varchar(6) NOT NULL , "
                + k_r106+ " varchar(7) NOT NULL , "
                + k_r107+ " varchar(3) NOT NULL , "
                + k_r108+ " varchar(3) NOT NULL , "
                + k_r109+ " varchar(256) NOT NULL , "
                + k_r110+ " varchar(256) NOT NULL , "
                + k_r111+ " varchar(256) NOT NULL , "
                + k_r112+" varchar(20), "
                + k_r113+ " varchar(256) NOT NULL , "
                + k_r114+ " varchar(5) NOT NULL , "
                + k_r115+ " varchar(1) NOT NULL , "
                + k_r116+ " varchar(1) NOT NULL , "
                + k_triwulan+ " varchar(1) NOT NULL , "
                + k_error+ " varchar(1) NOT NULL,  "
                + k_is_lock + " varchar(1) NOT NULL , "
                + k_lock_user + " varchar(80)  "
                + ") ENGINE=InnoDB; ";
            return create;
        }

        public static string getDropQuery()
        {
            string drop = String.Format("DROP TABLE IF EXISTS {0};", table);
            Console.WriteLine(drop);
            return drop;
        }

        public void loadNama(Dictionary<string,string> provDict, Dictionary<string, string> kabDict, Dictionary<string, string> kecDict, Dictionary<string, string> desaDict)
        {
            if (provDict.ContainsKey(R101.Data))
            {
                Nama_r101 = provDict[R101.Data];
            }
            else
            {
                Nama_r101 = "";
            }

            if (kabDict.ContainsKey(R102.Data))
            {
                Nama_r102 = kabDict[R102.Data];
            }
            else
            {
                Nama_r102 = "";
            }

            if (kecDict.ContainsKey(R103.Data))
            {
                Nama_r103 = kecDict[R103.Data];
            }
            else
            {
                Nama_r103 = "";
            }

            if (desaDict.ContainsKey(R104.Data))
            {
                Nama_r104 = desaDict[R104.Data];
            }
            else
            {
                Nama_r104 = "";
            }
            if (R115.Data.Equals("1"))
            {
                Nama_r115 = "INDUSTRI MIKRO";
            }
            else if(R115.Data.Equals("2"))
            {
                Nama_r115 = "INDUSTRI KECIL";
            }
            if (R116.Data.Equals("1"))
            {
                Nama_r116 = "[1] MUSIMAN";
            }
            else if (R116.Data.Equals("2"))
            {
                Nama_r116 = "[2] BUKAN MUSIMAN";
            }

        }

        public List<string> err(Dictionary<string, string> provDict, Dictionary<string, string> kabDict, Dictionary<string, string> kecDict, Dictionary<string, string> desaDict)
        {
            List<string> returnValue = new List<string>();
            returnValue.AddRange(R101.getErrorMetadata());
            if (!provDict.ContainsKey(R101.Data))
            {
                returnValue.Add("Kode provinsi tidak ter-identifikasi");
            }
            returnValue.AddRange(R102.getErrorMetadata());
            if (!kabDict.ContainsKey(R102.Data))
            {
                returnValue.Add("Kode kabupaten tidak ter-identifikasi");
            }
            returnValue.AddRange(R103.getErrorMetadata());
            if (!kecDict.ContainsKey(R103.Data))
            {
                returnValue.Add("Kode kecamatan tidak ter-identifikasi");
            }
            returnValue.AddRange(R104.getErrorMetadata());
            if (!desaDict.ContainsKey(R104.Data))
            {
                returnValue.Add("Kode desa tidak ter-identifikasi");
            }
            
            returnValue.AddRange(R105.getErrorMetadata());
            returnValue.AddRange(R106.getErrorMetadata());
            returnValue.AddRange(R107.getErrorMetadata());
            returnValue.AddRange(R108.getErrorMetadata());
            returnValue.AddRange(R109.getErrorMetadata());
            returnValue.AddRange(R110.getErrorMetadata());
            returnValue.AddRange(R111.getErrorMetadata());
            returnValue.AddRange(R112.getErrorMetadata());
            returnValue.AddRange(R113.getErrorMetadata());
            returnValue.AddRange(R114.getErrorMetadata());
            returnValue.AddRange(R115.getErrorMetadata());
            returnValue.AddRange(R116.getErrorMetadata());
            return returnValue;
        }

        public void setDokumen(Dokumen dokumen)
        {
            Dokumen = dokumen;
            Id.Blok = this;
            R101.Blok = this;
            R102.Blok = this;
            R103.Blok = this;
            R104.Blok = this;
            R105.Blok = this;
            R106.Blok = this;
            R107.Blok = this;
            R108.Blok = this;
            R109.Blok = this;
            R110.Blok = this;
            R111.Blok = this;
            R112.Blok = this;
            R113.Blok = this;
            R114.Blok = this;
            R115.Blok = this;
            R116.Blok = this;
            Triwulan.Blok = this;
            Error.Blok = this;
        }

        public void changeValue(object var)
        {
           
        }
        public Boolean checkError()
        {
           /* Console.WriteLine("Cek Error Blok 1");
            Console.WriteLine(String.Join(", ", R101.getAllError()));
            Console.WriteLine(String.Join(", ", R102.getAllError()));
            Console.WriteLine(String.Join(", ", R103.getAllError()));
            Console.WriteLine(String.Join(", ", R104.getAllError()));
            Console.WriteLine(String.Join(", ", R105.getAllError()));
            Console.WriteLine(String.Join(", ", R106.getAllError()));
            Console.WriteLine(String.Join(", ", R107.getAllError()));
            Console.WriteLine(String.Join(", ", R108.getAllError()));
            Console.WriteLine(String.Join(", ", R109.getAllError()));
            Console.WriteLine(String.Join(", ", R110.getAllError()));
            Console.WriteLine(String.Join(", ", R111.getAllError()));
            Console.WriteLine(String.Join(", ", R112.getAllError()));
            Console.WriteLine(String.Join(", ", R113.getAllError()));
            Console.WriteLine(String.Join(", ", R114.getAllError()));
            Console.WriteLine(String.Join(", ", R115.getAllError()));
            Console.WriteLine(String.Join(", ", R116.getAllError()));*/
            return !(R101.isError() ||
                R102.isError() ||
                R103.isError() ||
                R104.isError() ||
                R105.isError() ||
                R106.isError() ||
                R107.isError() ||
                R108.isError() ||
                R109.isError() ||
                R110.isError() ||
                R111.isError() ||
                R112.isError() ||
                R113.isError() ||
                R114.isError() ||
                R115.isError() ||
                R116.isError());
        }
        public static blok_i getCopy(blok_i from)
        {
            if (from == null) return null;
            blok_i baru = new blok_i();
            baru.Id.Data = System.Guid.NewGuid().ToString();
            baru.R101.Data = String.Copy(from.R101.Data);
            baru.R102.Data = String.Copy(from.R102.Data);
            baru.R103.Data = String.Copy(from.R103.Data);
            baru.R104.Data = String.Copy(from.R104.Data);
            baru.R105.Data = String.Copy(from.R105.Data);
            baru.R106.Data = String.Copy(from.R106.Data);
            baru.R107.Data = String.Copy(from.R107.Data);
            baru.R108.Data = String.Copy(from.R108.Data);
            baru.R109.Data = String.Copy(from.R109.Data);
            baru.R110.Data = String.Copy(from.R110.Data);
            baru.R111.Data = String.Copy(from.R111.Data);
            baru.R112.Data = String.Copy(from.R112.Data);
            baru.R113.Data = String.Copy(from.R113.Data);
            baru.R114.Data = String.Copy(from.R114.Data);
            baru.R115.Data = String.Copy(from.R115.Data);
            baru.R116.Data = String.Copy(from.R116.Data);
            baru.Triwulan.Data = String.Copy(from.Triwulan.Data);
            baru.Error.Data = String.Copy(from.Error.Data);
            baru.Is_lock.Data = String.Copy(from.Is_lock.Data);
            baru.Lock_user.Data = String.Copy(from.Lock_user.Data);
            return baru;
        }

        public static blok_i getCopyForNextTriwulan(blok_i from, string uid_dok, string triwulan)
        {
            if (from == null) return null;
            blok_i baru = new blok_i();
            baru.Id.Data = String.Copy(uid_dok);
            baru.R101.Data = String.Copy(from.R101.Data);
            baru.R102.Data = String.Copy(from.R102.Data);
            baru.R103.Data = String.Copy(from.R103.Data);
            baru.R104.Data = String.Copy(from.R104.Data);
            baru.R105.Data = String.Copy(from.R105.Data);
            baru.R106.Data = String.Copy(from.R106.Data);
            baru.R107.Data = String.Copy(from.R107.Data);
            baru.R108.Data = String.Copy(from.R108.Data);
            baru.R109.Data = String.Copy(from.R109.Data);
            baru.R110.Data = String.Copy(from.R110.Data);
            baru.R111.Data = String.Copy(from.R111.Data);
            baru.R112.Data = String.Copy(from.R112.Data);
            baru.R113.Data = String.Copy(from.R113.Data);
            baru.R114.Data = String.Copy(from.R114.Data);
            baru.R115.Data = String.Copy(from.R115.Data);
            baru.R116.Data = String.Copy(from.R116.Data);
            baru.Triwulan.Data = triwulan;
            baru.Error.Data = "0";
            baru.Nks_nus.Data = String.Copy(baru.R106.Data) + String.Copy(baru.R107.Data) +triwulan;
            baru.setTriwulanint(triwulan);
            baru.Is_lock.Data = "0";
            baru.Lock_user.Data = null;
            return baru;
        }

        private Page_1 Halaman_1;
        public void setUserHalaman1(Page_1 _Halaman_1)
        {
            Halaman_1 = _Halaman_1;
        }
        public void sampaikanPerbuhan()
        {
            Halaman_1.adaPerubahan();
        }
    }
}
