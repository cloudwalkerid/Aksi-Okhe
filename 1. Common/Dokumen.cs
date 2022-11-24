using Akhi_Okhee._2._Database;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Akhi_Okhee._3._4._Client_Dokumen;
using MySql.Data.MySqlClient;

namespace Akhi_Okhee._1._Common
{
    public class Dokumen
    {
        private string id;
        private blok_i _blok_i;
        private blok_ii _blok_ii;
        private List<blok_iii_301> list_blok_iii_301;
        private blok_iii _blok_iii;
        private List<barang> list_barang;
        private Boolean awal_error;
        private Boolean isPopulate;
        private Akhi_Okhee._3._4._Client_Dokumen.Main main;
        private Boolean is_generate = false;

        public blok_i Blok_i { get => _blok_i; set => _blok_i = value; }
        public blok_ii Blok_ii { get => _blok_ii; set => _blok_ii = value; }
        public List<blok_iii_301> List_blok_iii_301 { get => list_blok_iii_301; set => list_blok_iii_301 = value; }
        public blok_iii Blok_iii { get => _blok_iii; set => _blok_iii = value; }
        public List<barang> List_barang { get => list_barang; set => list_barang = value; }
        public bool IsPopulate { get => isPopulate; set => isPopulate = value; }
        public Main MainDokuPage { get => main; set => main = value; }
        public bool Is_generate { get => is_generate; set => is_generate = value; }

        public Dokumen(string _id)
        {
            id = _id;
            awal_error = true;
            List_blok_iii_301 = new List<blok_iii_301>();
            IsPopulate = false;
        }

        public Dokumen(blok_i _blok_i)
        {
            id = _blok_i.Id.Data;
            Blok_i = _blok_i;
            awal_error = _blok_i.Error.Data.Equals("0");
            List_blok_iii_301 = new List<blok_iii_301>();
            IsPopulate = false;
        }

        public Boolean claim_entri(Akun myActiveAkun)
        {
            if (Blok_i == null)
            {
                return false;
            }
            try
            {
                Connect conn = new Connect();
                MySqlConnection connect = conn.getConection();
                connect.Open();
                MySqlCommand command = new MySqlCommand();
                command.Connection = connect;
                Blok_i.MakeDataClaim(command, myActiveAkun);
                connect.Close();
                return true;
            }
            catch(Exception ex)
            {
                Console.WriteLine("Gagal Buat Claim : ");
                Console.WriteLine("Gagal Buat Claim : "+ex.Message);
                Console.WriteLine("Gagal Buat Claim : "+ex.StackTrace);
                return false;
            }
        }

        public Boolean release_claim_entri(Akun myActiveAkun)
        {
            if (Blok_i == null)
            {
                return false;
            }
            try
            {
                Connect conn = new Connect();
                MySqlConnection connect = conn.getConection();
                connect.Open();
                MySqlCommand command = new MySqlCommand();
                command.Connection = connect;
                Blok_i.ReleaseDataClaim(command, myActiveAkun);
                connect.Close();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Gagal Release Claim : ");
                Console.WriteLine("Gagal Release Claim : " + ex.Message);
                Console.WriteLine("Gagal Release Claim : " + ex.StackTrace);
                return false;
            }
        }

        public Boolean populate()
        {
            Boolean returnValue = true;
            Connect conn = new Connect();
            MySqlConnection connect = conn.getConection();
            Console.WriteLine("Mulai Populate");
            try
            {
                connect.Open();
                if (Blok_i == null)
                {
                    blok_i _blok_i = new blok_i();
                    _blok_i.Id.Data = id;
                    _blok_i.populate(connect);
                    Blok_i = _blok_i;
                }
                Console.WriteLine("Populate 1");
                blok_ii _blok_ii = new blok_ii();
                _blok_ii.Id.Data = id;
                Blok_ii = _blok_ii;
                blok_iii _blok_iii = new blok_iii();
                _blok_iii.Id.Data = id;
                Blok_iii = _blok_iii;

                Blok_i.setDokumen(this);
                Blok_ii.setDokumen(this);
                Blok_iii.setDokumen(this);

                if (Blok_i.Error.Equals("0"))
                {
                    awal_error = true;
                    /* connect.Close();
                     return returnValue;*/
                }
                else
                {
                    awal_error = false;
                }
                
                Blok_ii.populate(connect);
                Blok_ii.dateAwal();
                Console.WriteLine("Populate 2");
                if (Blok_i.IntTriwulan == 1)
                {
                    Blok_ii.R206k2.Min = 1;
                    Blok_ii.R206k2.Max = 3;
                }
                else if (Blok_i.IntTriwulan == 2)
                {
                    Blok_ii.R206k2.Min = 4;
                    Blok_ii.R206k2.Max = 6;
                }
                else if (Blok_i.IntTriwulan == 3)
                {
                    Blok_ii.R206k2.Min = 7;
                    Blok_ii.R206k2.Max = 9;
                }
                else if (Blok_i.IntTriwulan == 4)
                {
                    Blok_ii.R206k2.Min = 10;
                    Blok_ii.R206k2.Max = 12;
                }
                String select_query_populate = "SELECT * FROM blok_iii_301 WHERE id_blok_i = '"+id+"'";
                using (MySqlCommand cmd = new MySqlCommand(select_query_populate, connect))
                {
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while(reader.Read())
                        {
                            Console.WriteLine("Populate Blok 3 Iter");
                            blok_iii_301 _blok_iii_301 = new blok_iii_301();
                            _blok_iii_301.populate(reader);
                            _blok_iii_301.setDokumen(this);
                            List_blok_iii_301.Add(_blok_iii_301);
                        }
                    }
                }
                if(List_barang != null)
                {
                    foreach (blok_iii_301 itemk in List_blok_iii_301)
                    {
                        foreach (barang itemB in List_barang)
                        {
                            if (itemk.Id_barang.Data.Equals(itemB.Id.Data))
                            {
                                itemk.Barang = itemB;
                                itemk.setDokumen(this);
                                break;
                            }
                        }
                    }
                }
                Blok_iii.populate(connect);
                Console.WriteLine("Populate 3");
                IsPopulate = true;
                connect.Close();
            }
            catch(Exception ex)
            {
                Console.WriteLine("Dokumen Populate");
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);
                returnValue = false;
            }
            connect.Close();
            return returnValue;
        }

        public Boolean save(String error, Boolean realese_claim=false, Akun active_akun=null)
        {
            Boolean returnValue = true;
            Connect conn = new Connect();
            try
            {
                MySqlConnection connect = conn.getConection();
                connect.Open();
                MySqlCommand command = connect.CreateCommand();
                MySqlTransaction transaction;
                transaction = connect.BeginTransaction();
                command.Connection = connect;
                command.Transaction = transaction;
                try
                {
                    if (realese_claim)
                    {
                        Blok_i.ReleaseDataClaim(command, active_akun);
                    }
                    if (Blok_i.Error.Data.Equals("0"))
                    {
                        Console.WriteLine("Insert Doku");
                        if (Blok_ii != null)
                        {
                            try
                            {
                                Blok_ii.InsertData(command);
                            }
                            catch (Exception ex)
                            {
                                Blok_ii.UpdateData(command);
                            }
                        }
                        if (Blok_iii != null)
                        {
                            try
                            {
                                Blok_iii.InsertData(command);
                            }
                            catch (Exception ex)
                            {
                                Blok_iii.UpdateData(command);
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine("Update Doku");
                        if (Blok_ii != null)
                            if (Blok_ii != null)
                        {
                            Blok_ii.UpdateData(command);
                        }
                        if (Blok_iii != null)
                        {
                            Blok_iii.UpdateData(command);
                        }
                    }
                    foreach (blok_iii_301 itemBlok3 in List_blok_iii_301)
                    {
                        Console.WriteLine("Id :" + itemBlok3.Id.Data);
                        Console.WriteLine("Id blok :" + itemBlok3.Id_blok_i.Data);
                        Console.WriteLine("Id barang:" + itemBlok3.Id_barang.Data);
                        Console.WriteLine();
                    }
                    foreach (blok_iii_301 itemBlok3 in List_blok_iii_301)
                    {
                        itemBlok3.Id_blok_i.Data = Blok_i.Id.Data;
                        //itemBlok3.checkError();
                        if (itemBlok3.IsDelete)
                        {
                            itemBlok3.DeleteData(command);
                        }
                        else if (itemBlok3.Awalbaru)
                        {
                            itemBlok3.InsertData(command);
                        }
                        else
                        {
                            itemBlok3.UpdateData(command);
                        }
                    }
                    Boolean dokumenbenar = true;
                    dokumenbenar = dokumenbenar && Blok_i.checkError();
                    dokumenbenar = dokumenbenar && Blok_ii.checkError();
                    dokumenbenar = dokumenbenar && Blok_iii.checkError();
                    foreach (blok_iii_301 itemBlok3 in List_blok_iii_301)
                    {
                        dokumenbenar = dokumenbenar && itemBlok3.checkError();
                    }
                    if (dokumenbenar)
                    {
                        Blok_i.Error.Data = "1";
                    }
                    else
                    {
                        Blok_i.Error.Data = "2";
                        Console.WriteLine("Ada Error");
                    }

                    if (Is_generate)
                    {
                        Blok_i.InsertData(command);
                        Is_generate = false;
                    }
                    else
                    {
                        Blok_i.UpdateData(command);
                    }
                    
                    
                    foreach (blok_iii_301 itemBlok3 in List_blok_iii_301)
                    {
                        if (itemBlok3.Awalbaru)
                        {
                            itemBlok3.Awalbaru = false;
                        }
                       
                    }
                    transaction.Commit();
                }
                catch (GagalClaimExceptioncs ex1)
                {
                    Console.WriteLine("Dokumen Save 1");
                    Console.WriteLine(ex1.Message);
                    Console.WriteLine(ex1.StackTrace);
                    error = "Gagal menyimpan karena dokumen sedang dientri oleh orang lain";
                    returnValue = false;
                    try
                    {
                        //Blok_i.UpdateData(command);

                        transaction.Rollback();
                    }
                    catch (Exception ex2)
                    {
                        // This catch block will handle any errors that may have occurred
                        // on the server that would cause the rollback to fail, such as
                        // a closed connection.
                        Console.WriteLine("Rollback Exception Type: {0}", ex2.GetType());
                        Console.WriteLine("  Message: {0}", ex2.Message);
                        Console.WriteLine(ex2.StackTrace);
                    }
                }
                catch (Exception ex1)
                {
                    Console.WriteLine("Dokumen Save 1");
                    Console.WriteLine(ex1.Message);
                    Console.WriteLine(ex1.StackTrace);
                    error = "Gagal menyimpan dokumen";
                    returnValue = false;
                    try
                    {
                        //Blok_i.UpdateData(command);
                        
                        transaction.Rollback();
                    }
                    catch (Exception ex2)
                    {
                        // This catch block will handle any errors that may have occurred
                        // on the server that would cause the rollback to fail, such as
                        // a closed connection.
                        Console.WriteLine("Rollback Exception Type: {0}", ex2.GetType());
                        Console.WriteLine("  Message: {0}", ex2.Message);
                        Console.WriteLine(ex2.StackTrace);
                    }
                }
                connect.Close();
            }
            catch (Exception ex)
            {
                error = "Gagal menyimpan dokumen karena tidak dapat menghubungi basis data";
                Console.WriteLine("Dokumen Save");
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);
                returnValue = false;
            }
            return returnValue;
        }

        public static Boolean saveAllNewDokumen(String error, List<Dokumen> newDokemens)
        {
            Boolean returnValue = true;
            Connect conn = new Connect();
            try
            {
                MySqlConnection connect = conn.getConection();
                connect.Open();
                MySqlCommand command = connect.CreateCommand();
                MySqlTransaction transaction;
                transaction = connect.BeginTransaction();
                command.Connection = connect;
                command.Transaction = transaction;
                try
                {
                    foreach(Dokumen item in newDokemens)
                    {
                        item.Blok_i.InsertData(command);
                        if (item.Blok_ii != null)
                        {
                            item.Blok_ii.InsertData(command);
                        }
                        if (item.Blok_iii != null)
                        {
                            item.Blok_iii.InsertData(command);
                        }

                        foreach (blok_iii_301 itemBlok3 in item.List_blok_iii_301)
                        {
                            itemBlok3.Id_blok_i.Data = item.Blok_i.Id.Data;
                            //itemBlok3.checkError();
                            itemBlok3.InsertData(command);
                        }
                    }
                    transaction.Commit();
                }
                
                catch (Exception ex1)
                {
                    Console.WriteLine("Dokumen Save 1");
                    Console.WriteLine(ex1.Message);
                    Console.WriteLine(ex1.StackTrace);
                    error = "Gagal menyimpan dokumen baru";
                    returnValue = false;
                    try
                    {
                        //Blok_i.UpdateData(command);

                        transaction.Rollback();
                    }
                    catch (Exception ex2)
                    {
                        // This catch block will handle any errors that may have occurred
                        // on the server that would cause the rollback to fail, such as
                        // a closed connection.
                        Console.WriteLine("Rollback Exception Type: {0}", ex2.GetType());
                        Console.WriteLine("  Message: {0}", ex2.Message);
                        Console.WriteLine(ex2.StackTrace);
                    }
                }
                connect.Close();
            }
            catch (Exception ex)
            {
                error = "Gagal menyimpan dokumen baru karena tidak dapat menghubungi basis data";
                Console.WriteLine("Dokumen Save");
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);
                returnValue = false;
            }
            return returnValue;
        }

        public Boolean reval(List<barang> list_barang)
        {
            Boolean returnValue = true;
            Connect conn = new Connect();
            try
            {
                MySqlConnection connect = conn.getConection();
                connect.Open();
                MySqlCommand command = connect.CreateCommand();
                MySqlTransaction transaction;
                transaction = connect.BeginTransaction();
                command.Connection = connect;
                command.Transaction = transaction;
                try
                {
                    if (!Blok_i.Error.Data.Equals("0"))
                    { 
                        Boolean dokumenbenar = true;
                        if (Blok_ii.R201a.Data != default(string))
                        {
                            if (!Blok_ii.R201a.Data.Equals("1") && !Blok_ii.R201a.Data.Equals("2"))
                            {
                                Blok_ii.R201a.Err_konsistensi = new List<string>();
                                if (adaPertambahan())
                                {
                                    Blok_ii.R201a.Err_konsistensi.Add("R201A berkode selain 1 atau 2 namun ada pertambahan bahan barang yang dihasilkan");
                                }
                                if (!(Blok_iii.R301K_k9.Data == default(double?)) && !(Blok_iii.R301K_k9.Data == ((double)0)))
                                {
                                    Blok_ii.R201a.Err_konsistensi.Add("R201A berkode selain 1 atau 2 namun R301 Baris K (Jumlah Nilai Produksi tidak kosong)");
                                }
                                foreach (blok_iii_301 item in List_blok_iii_301)
                                {
                                    /*item.R301k10.Null = true;*/
                                    item.changeValue(Blok_ii.R201a);
                                }
                            }
                        }
                        dokumenbenar = dokumenbenar && Blok_i.checkError();
                        dokumenbenar = dokumenbenar && Blok_ii.checkError();
                        dokumenbenar = dokumenbenar && Blok_iii.checkError();
                        Console.WriteLine(Blok_i.R109.Data + " Blok 1 : " + Blok_i.checkError());
                        Console.WriteLine(Blok_i.R109.Data + " Blok 2 : " + Blok_ii.checkError());
                        Console.WriteLine(Blok_i.R109.Data + " Blok 3 : " + Blok_iii.checkError());
                        foreach (blok_iii_301 itemBlok3 in List_blok_iii_301)
                        {
                            foreach(barang itemBarang in list_barang)
                            {
                                if (itemBarang.Id.Data.Equals(itemBlok3.Id_barang.Data)){
                                    itemBlok3.Barang = itemBarang;
                                    break;
                                }
                            }
                            dokumenbenar = dokumenbenar && itemBlok3.checkErrorReval();
                        }
                        if (dokumenbenar)
                        {
                            Blok_i.Error.Data = "1";
                        }
                        else
                        {
                            Blok_i.Error.Data = "2";
                            Console.WriteLine("Ada Error");
                        }

                        Blok_i.UpdateData(command);
                    }
                    returnValue = true;
                    transaction.Commit();
                }
                catch (Exception ex1)
                {
                    Console.WriteLine("Dokumen Save 1");
                    Console.WriteLine(ex1.Message);
                    Console.WriteLine(ex1.StackTrace);
                    returnValue = false;
                    try
                    {
                        //Blok_i.UpdateData(command);

                        transaction.Rollback();
                    }
                    catch (Exception ex2)
                    {
                        // This catch block will handle any errors that may have occurred
                        // on the server that would cause the rollback to fail, such as
                        // a closed connection.
                        Console.WriteLine("Rollback Exception Type: {0}", ex2.GetType());
                        Console.WriteLine("  Message: {0}", ex2.Message);
                        Console.WriteLine(ex2.StackTrace);
                    }
                }
                connect.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Dokumen Save");
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);
                returnValue = false;
            }
            return returnValue;
        }

        public static Boolean delete(List<Dokumen> dokumens)
        {
            Boolean returnValue = true;
            Connect conn = new Connect();
            try
            {
                MySqlConnection connect = conn.getConection();
                connect.Open();
                MySqlCommand command = new MySqlCommand();
                command.Connection = connect;
                MySqlTransaction transaction;
                transaction = connect.BeginTransaction();
                command.Transaction = transaction;
                try
                {
                    foreach(Dokumen itemDok in dokumens)
                    {
                        itemDok.Blok_i.DeleteData(command);
                        if (itemDok.Blok_ii != null)
                        {
                            itemDok.Blok_ii.DeleteData(command);
                        }
                        if (itemDok.Blok_iii != null)
                        {
                            itemDok.Blok_iii.DeleteData(command);
                        }
                        if (itemDok.List_blok_iii_301 != null)
                        {
                            foreach (blok_iii_301 itemIter in itemDok.List_blok_iii_301)
                            {
                                itemIter.DeleteData(command);
                            }
                        }
                    }
                    Console.WriteLine("Akhir delete");
                    transaction.Commit();
                    connect.Close();
                }
                catch (Exception ex1)
                {
                    Console.WriteLine("Dokumen Delete 1");
                    Console.WriteLine(ex1.Message);
                    Console.WriteLine(ex1.StackTrace);
                    try
                    {
                        transaction.Rollback();
                    }
                    catch (Exception ex2)
                    {
                        // This catch block will handle any errors that may have occurred
                        // on the server that would cause the rollback to fail, such as
                        // a closed connection.
                        Console.WriteLine("Rollback Exception Type: {0}", ex2.GetType());
                        Console.WriteLine("  Message: {0}", ex2.Message);
                        Console.WriteLine(ex2.StackTrace);
                    }
                }
                connect.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Dokumen Delete");
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);
                returnValue = false;
            }
            return returnValue;
        }
        public void cekError()
        {

        }
        public void changeValue(Object variab)
        {
            Blok_iii.R301K_k9.Err_konsistensi = new List<string>();
            double sum301k9 = 0;
            foreach (blok_iii_301 itemk in List_blok_iii_301)
            {
                if (!itemk.IsDelete && itemk.R301k9.Data != default(double?))
                {
                    sum301k9 = sum301k9 + (double)itemk.R301k9.Data;
                }
            }
            if (Blok_iii.R301J_k9.Data != default(double?))
            {
                sum301k9 = sum301k9 + (double)Blok_iii.R301J_k9.Data;
            }
            /*if (Blok_iii.R301K_k9.Data != sum301k9)
            {
                Blok_iii.R301K_k9.Err_konsistensi.Add("Isian 301 Baris K (Jumlah Produksi) Triwulan ini tidak konsisten dengan isian penjumlahannya");
            }*/
            Blok_iii.R301K_k9.Data = sum301k9;
            Console.WriteLine("Nilai jumlah : " + sum301k9);
            if (main != null)
            {
                main.Halaman21.adaPerubahan();
            }
        }
        public void add301Iter()
        {
            blok_iii_301 newBlok_ii = new blok_iii_301();
            newBlok_ii.Id.Data = Guid.NewGuid().ToString().ToUpper();
            newBlok_ii.Id_blok_i.Data = String.Copy(Blok_i.Id.Data);
            newBlok_ii.Is_error.Data = "1";
            newBlok_ii.setDokumen(this);
            List_blok_iii_301.Add(newBlok_ii);
        }
        /*public static Dokumen createCopyForNextTrw(blok_i blok_awal, string triwulan, Akun activeAkun)
        {
            Dokumen dokumen_awal = new Dokumen(blok_awal);
            dokumen_awal.populate();

            string uid_baru = Guid.NewGuid().ToString();
            Dokumen returnValue = new Dokumen(blok_i.getCopyForNextTriwulan(dokumen_awal.Blok_i, uid_baru, triwulan));
            returnValue.Blok_ii = blok_ii.getCopyForNextTriwulan(dokumen_awal.Blok_ii, uid_baru, triwulan);
            foreach(blok_iii_301 itemB in dokumen_awal.List_blok_iii_301)
            {
                blok_iii_301 baruItem = blok_iii_301.getCopyForNextTriwulan(itemB, uid_baru, triwulan);
                if (baruItem != null)
                {
                    baruItem.setDokumen(returnValue);
                    returnValue.List_blok_iii_301.Add(baruItem);
                }
            }
            returnValue.Blok_iii = blok_iii.getCopyForNextTriwulan(dokumen_awal.Blok_iii, uid_baru, triwulan);
            returnValue.IsPopulate = true;
            returnValue.Blok_i.setDokumen(returnValue);
            returnValue.Blok_ii.setDokumen(returnValue);
            returnValue.Blok_iii.setDokumen(returnValue);
            try
            {
                Connect conn = new Connect();
                MySqlConnection connect = conn.getConection();
                connect.Open();
                MySqlCommand command = new MySqlCommand();
                command.Connection = connect;
                returnValue.Blok_i.Is_lock.Data = "1";
                returnValue.Blok_i.Lock_user.Data = activeAkun.Username;
                returnValue.Blok_i.InsertData(command);
                connect.Close();
                return returnValue;
            }
            catch(Exception ex)
            {
                Console.WriteLine("Gagal clian triwulan : ");
                Console.WriteLine("Gagal clian triwulan : "+ex.Message);
                Console.WriteLine("Gagal clian triwulan : "+ex.StackTrace);
                return null;
            }
        }*/

        public static Dokumen createCopyForNextTrw(Dokumen dokumen_awal, string triwulan)
        {
            
            string uid_baru = Guid.NewGuid().ToString();
            Dokumen returnValue = new Dokumen(blok_i.getCopyForNextTriwulan(dokumen_awal.Blok_i, uid_baru, triwulan));
            /*returnValue.Blok_ii = blok_ii.getCopyForNextTriwulan(dokumen_awal.Blok_ii, uid_baru, triwulan);*/
            foreach (blok_iii_301 itemB in dokumen_awal.List_blok_iii_301)
            {
                blok_iii_301 baruItem = blok_iii_301.getCopyForNextTriwulan(itemB, uid_baru, triwulan);
                if (baruItem != null)
                {
                    baruItem.setDokumen(returnValue);
                    returnValue.List_blok_iii_301.Add(baruItem);
                }
            }
            returnValue.Blok_iii = blok_iii.getCopyForNextTriwulan(dokumen_awal.Blok_iii, uid_baru, triwulan);
            returnValue.Blok_i.setDokumen(returnValue);
            /*returnValue.Blok_ii.setDokumen(returnValue);*/
            returnValue.Blok_iii.setDokumen(returnValue);
            returnValue.Is_generate = true;
            return returnValue;
        }

        public Boolean adaPertambahan()
        {
            Boolean returnvalue = false;
            foreach (blok_iii_301 itemB in List_blok_iii_301)
            { 
                if (itemB.Is_error.Data.Equals("1") && !itemB.IsDelete)
                {
                    return true;
                }
            }
            return returnvalue;
        }
    }
}
