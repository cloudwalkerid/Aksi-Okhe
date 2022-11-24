using Akhi_Okhee._1._Common;
using Akhi_Okhee._2._Database;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Akhi_Okhee._3._3._Client_Main
{
    /// <summary>
    /// Interaction logic for Page_DSRT.xaml
    /// </summary>
    public partial class Page_DSRT : Page
    {
        private Main main;
        private Connect conn;
        int triulanTinggi = 0;

        public Page_DSRT(Main _main)
        {
            InitializeComponent();
            main = _main;
            conn = new Connect();
            tw2.IsEnabled = false;
            tw3.IsEnabled = false;
            tw4.IsEnabled = false;
            populate(null, null);
            refresh(null, null);
        }

        private void populate(object sender, EventArgs e)
        {
            provinsi.SelectionChanged -= populate;
            kabupaten.SelectionChanged -= populate;
            kecamatan.SelectionChanged -= populate;
            Dictionary<string, string> provDict = new Dictionary<string, string>();
            Dictionary<string, string> kabDict = new Dictionary<string, string>();
            Dictionary<string, string> kecDict = new Dictionary<string, string>();
            if (sender == null)
            {
                provDict = new Dictionary<string, string>();
                provDict.Add("", "<--Semua Provinsi-->");
                foreach (var item in main.ProvDict)
                {
                    provDict.Add(item.Key, item.Value);
                }
                provinsi.ItemsSource = provDict.ToList();
                provinsi.DisplayMemberPath = "Value";
                provinsi.SelectedValuePath = "Key";


                kabDict = new Dictionary<string, string>();
                kabDict.Add("", "<--Semua Kabupaten-->");
                foreach (var item in main.KabDict)
                {
                    kabDict.Add(item.Key, item.Value);
                }

                kabupaten.ItemsSource = kabDict.ToList();
                kabupaten.DisplayMemberPath = "Value";
                kabupaten.SelectedValuePath = "Key";

                kecDict = new Dictionary<string, string>();
                kecDict.Add("", "<--Semua Kecamatan-->");

                foreach (var item in main.KecDict)
                {
                    kecDict.Add(item.Key, item.Value);
                }
                kecamatan.ItemsSource = kecDict.ToList();
                kecamatan.DisplayMemberPath = "Value";
                kecamatan.SelectedValuePath = "Key";

                provinsi.SelectedValue = "";
                kabupaten.SelectedValue = "";
                kecamatan.SelectedValue = "";
            }
            else 
            {
                string provSelected = provinsi.SelectedValue.ToString();
                string kabSelected = kabupaten.SelectedValue.ToString();
                string kecSelected = kecamatan.SelectedValue.ToString();

                Console.WriteLine(provSelected + "|" + kabSelected + "|" + kecSelected);

                provDict = new Dictionary<string, string>();
                provDict.Add("", "<--Semua Provinsi-->");
                foreach (var item in main.ProvDict)
                {
                    if ((kabSelected.StartsWith(item.Key) || kabSelected.Equals(""))
                            && (kecSelected.StartsWith(item.Key) || kecSelected.Equals("")))
                    {
                        provDict.Add(item.Key, item.Value);
                    }
                }
                provinsi.ItemsSource = provDict.ToList();
                provinsi.DisplayMemberPath = "Value";
                provinsi.SelectedValuePath = "Key";


                kabDict = new Dictionary<string, string>();
                kabDict.Add("", "<--Semua Kabupaten-->");
                foreach (var item in main.KabDict)
                {
                    if ((item.Key.StartsWith(provSelected) || provSelected.Equals(""))
                            && (kecSelected.StartsWith(item.Key) || kecSelected.Equals("")))
                    {
                        kabDict.Add(item.Key, item.Value);
                    }
                }

                kabupaten.ItemsSource = kabDict.ToList();
                kabupaten.DisplayMemberPath = "Value";
                kabupaten.SelectedValuePath = "Key";

                kecDict = new Dictionary<string, string>();
                kecDict.Add("", "<--Semua Kecamatan-->");

                foreach (var item in main.KecDict)
                {
                    if ((item.Key.StartsWith(provSelected) || provSelected.Equals(""))
                           && (item.Key.StartsWith(kabSelected) || kabSelected.Equals("")))
                    {
                        kecDict.Add(item.Key, item.Value);
                    }
                }
                kecamatan.ItemsSource = kecDict.ToList();
                kecamatan.DisplayMemberPath = "Value";
                kecamatan.SelectedValuePath = "Key";

                provinsi.SelectedValue = provSelected;
                kabupaten.SelectedValue = kabSelected;
                kecamatan.SelectedValue = kecSelected;
            }
            provinsi.SelectionChanged += populate;
            kabupaten.SelectionChanged += populate;
            kecamatan.SelectionChanged += populate;
            refresh(null, null);
        }
        public void refresh(object sender, EventArgs e)
        {
            string stringProv = "";
            string stringKab = "";
            string stringkec = "";
            if (provinsi.SelectedValue != null)
            {
                stringProv = provinsi.SelectedValue.ToString();
            }
            if (kabupaten.SelectedValue != null)
            {
                stringKab = kabupaten.SelectedValue.ToString();
            }
            if (kecamatan.SelectedValue != null)
            {
                stringkec = kecamatan.SelectedValue.ToString();
            }
            List<blok_i> list_blok_i = new List<blok_i>();
            list_blok_i = conn.getListBlok_i(stringProv, stringKab, stringkec, search.Text);
            List<blok_i> list_hasil = new List<blok_i>();
            Console.WriteLine("Jumlah Entri :" + list_blok_i.Count);

            triulanTinggi = 0; 
            if (list_blok_i != null)
            {
                foreach (blok_i itemBlok_i in list_blok_i)
                {
                    if (triulanTinggi < itemBlok_i.IntTriwulan)
                    {
                        triulanTinggi = itemBlok_i.IntTriwulan;
                    }
                    Boolean baru = true;
                    foreach (blok_i item_list in list_hasil)
                    {
                        if (itemBlok_i.R101.Data.Equals(item_list.R101.Data) && itemBlok_i.R102.Data.Equals(item_list.R102.Data) && itemBlok_i.R103.Data.Equals(item_list.R103.Data) && itemBlok_i.R104.Data.Equals(item_list.R104.Data)
                                && itemBlok_i.R105.Data.Equals(item_list.R105.Data) && itemBlok_i.R106.Data.Equals(item_list.R106.Data) && itemBlok_i.R107.Data.Equals(item_list.R107.Data) && itemBlok_i.R108.Data.Equals(item_list.R108.Data))
                        {
                            baru = false;
                            break;
                        }
                    }
                    if (baru)
                    {
                        list_hasil.Add(itemBlok_i);
                    }
                }
            }
            if (triulanTinggi == 1)
            {
                tw2.IsEnabled = true;
                tw3.IsEnabled = false;
                tw4.IsEnabled = false;
            }else if(triulanTinggi == 2)
            {
                tw2.IsEnabled = false;
                tw3.IsEnabled = true;
                tw4.IsEnabled = false;
            }
            else if (triulanTinggi == 3)
            {
                tw2.IsEnabled = false;
                tw3.IsEnabled = false;
                tw4.IsEnabled = true;
            }
            else if (triulanTinggi == 4)
            {
                tw2.IsEnabled = false;
                tw3.IsEnabled = false;
                tw4.IsEnabled = false;
            }
            list_DSRT.ItemsSource = list_hasil;
            list_DSRT.Items.Refresh();
        }

        private void aksi_template(object sender, RoutedEventArgs e)
        {
            using (SaveFileDialog saveFileDialog1 = new SaveFileDialog())
            {
                saveFileDialog1.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                saveFileDialog1.Filter = "Excel files (*.xls)|*.xls";
                saveFileDialog1.Title = "Simpan Template DSRT";
                //saveFileDialog1.ShowDialog();
                if (saveFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    string filePath = saveFileDialog1.FileName;
                    if (!filePath.Equals(""))
                    {
                        Console.WriteLine(filePath);
                        try
                        {
                            if (File.Exists(filePath)) File.Delete(filePath);
                            File.Copy(Connect.folderAppData + "/import_dsrt.xls", filePath);
                            System.Windows.Forms.MessageBox.Show("Berhasil membuat template dsrt", "informasi"
                                , MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        catch (Exception ex)
                        {
                            System.Windows.Forms.MessageBox.Show("Gagal membuat template dsrt", "informasi"
                               , MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        System.Windows.Forms.MessageBox.Show("Masukkan nama file", "informasi"
                               , MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
        private void aksi_import(object sender, RoutedEventArgs e)
        {
            var fileContent = string.Empty;
            var filePath = string.Empty;
            List<blok_i> disimpan = new List<blok_i>();
            List<blok_i> tidak_disimpan = new List<blok_i>();

            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                openFileDialog.Filter = "Excel (*.xls)|*.xls";
                openFileDialog.Title = "Import Template DSRT";
                //openFileDialog.FilterIndex = 1;
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    //Get the path of specified file
                    filePath = openFileDialog.FileName;

                    //Read the contents of the file into a stream
                    try
                    {
                        string connectionString = "Provider=Microsoft.Jet.OLEDB.4.0; Data Source = '" + filePath+"';" + "Extended Properties=\"Excel 8.0;HDR=YES;\"";
                        Console.WriteLine(connectionString);
                        string queryString = "SELECT * FROM [Sheet1$]";
                        using (OleDbConnection connection = new OleDbConnection(connectionString))
                        {
                            Console.WriteLine("0");
                            connection.Open();
                            OleDbCommand command = new OleDbCommand(queryString, connection);
                            OleDbDataReader reader = command.ExecuteReader();
                            Console.WriteLine("1");
                            Boolean awal = true;
                            while (reader.Read())
                            {
                                //if (awal)
                                //{
                                 //   awal = false;
                                  //  continue;
                                //}
                                if (reader.GetValue(0).ToString().Equals(""))
                                {
                                    continue;
                                }
                                blok_i newBlok_ = new blok_i();
                                newBlok_.Id.Data = Guid.NewGuid().ToString().ToUpper();
                                newBlok_.R101.Data = reader.GetValue(0).ToString().ToUpper();
                                //Console.WriteLine(reader.GetValue(0).ToString()+"|"+ reader[1].ToString());
                                newBlok_.R102.Data = reader.GetValue(0).ToString().ToUpper() + reader.GetValue(1).ToString().ToUpper();
                                newBlok_.R103.Data = reader.GetValue(0).ToString().ToUpper() + reader.GetValue(1).ToString().ToUpper() + reader.GetValue(2).ToString().ToUpper();
                                newBlok_.R104.Data = reader.GetValue(0).ToString().ToUpper() + reader.GetValue(1).ToString().ToUpper() + reader.GetValue(2).ToString().ToUpper() + reader.GetValue(3).ToString().ToUpper();
                                if (reader[5].ToString().Equals(""))
                                {
                                    newBlok_.R105.Data = reader.GetValue(4).ToString() + "00";
                                }
                                else
                                {
                                    newBlok_.R105.Data = reader.GetValue(4).ToString() + reader.GetValue(5).ToString();
                                }
                                newBlok_.R106.Data = reader.GetValue(6).ToString().ToUpper();
                                newBlok_.R107.Data = reader.GetValue(7).ToString().ToUpper();
                                newBlok_.R108.Data = reader.GetValue(8).ToString().ToUpper();
                                newBlok_.R109.Data = reader.GetValue(9).ToString().ToUpper();
                                newBlok_.R110.Data = reader.GetValue(10).ToString().ToUpper();
                                newBlok_.R111.Data = reader.GetValue(11).ToString().ToUpper();
                                newBlok_.R112.Data = reader.GetValue(12).ToString().ToUpper();
                                newBlok_.R113.Data = reader.GetValue(13).ToString().ToUpper();
                                newBlok_.R114.Data = reader.GetValue(14).ToString().ToUpper();
                                newBlok_.R115.Data = reader.GetValue(15).ToString().ToUpper();
                                newBlok_.R116.Data = reader.GetValue(16).ToString().ToUpper();
                               // Console.WriteLine("3");
                                newBlok_.Nks_nus.Data = reader.GetValue(6).ToString() + reader.GetValue(7).ToString()+ "1";
                                newBlok_.Triwulan.Data = "1";
                                newBlok_.Error.Data = "0";
                                newBlok_.Is_lock.Data = "0";
                                List<string> errorList = newBlok_.err(main.ProvDict, main.KabDict, main.KecDict, main.DesaDict);
                                
                                if (errorList.Count > 0)
                                {
                                    tidak_disimpan.Add(newBlok_);
                                    Console.WriteLine(String.Join(" , ", errorList.ToArray())+"|"+ newBlok_.R101.Data+newBlok_.R102.Data+newBlok_.R103.Data+ newBlok_.R104.Data);
                                }
                                else
                                {
                                    disimpan.Add(newBlok_);
                                }
                            }
                            reader.Close();
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("DSRT Dialog Save 0");
                        Console.WriteLine(ex.Message);
                        Console.WriteLine(ex.StackTrace);
                        System.Windows.Forms.MessageBox.Show("Gagal mengimport dsrt", "informasi"
                           , MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            simpanDatabase(disimpan, tidak_disimpan);
        }

        public void simpanDatabase(List<blok_i> disimpan, List<blok_i> tidak_disimpan)
        {
            Console.WriteLine(disimpan.Count + "|" + tidak_disimpan.Count);
            if (tidak_disimpan.Count > 0)
            {
                string messageM = "Terdapat error di dsrt template" + Environment.NewLine;
                foreach(blok_i itemTidakDisimpan in tidak_disimpan)
                {
                    messageM = messageM + "NKS : "+itemTidakDisimpan.R106.Data+", NUS :" + itemTidakDisimpan.R107.Data
                        +", Nama : "+itemTidakDisimpan.R109.Data + Environment.NewLine;
                    messageM = messageM + "   Error : " + String.Join(", ", itemTidakDisimpan.err(main.ProvDict, main.KabDict, main.KecDict, main.DesaDict).ToArray()) + Environment.NewLine;
                }
                messageM = messageM + "Yakin tetap menyimpan Data DSRT yang tidak error dari file ini?";

                DialogResult dialogResult = System.Windows.Forms.MessageBox.Show(messageM, "informasi", MessageBoxButtons.YesNo);
                if (dialogResult == System.Windows.Forms.DialogResult.No)
                {
                    return;
                }
            }
            if (disimpan.Count == 0)
            {
                return;
            }

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
                    int i = 0;
                    foreach(blok_i itemDisimpan in disimpan)
                    {
                        Console.WriteLine(""+i);
                        itemDisimpan.InsertData(command);
                        i = i + 1;
                    }
                    transaction.Commit();
                    System.Windows.Forms.MessageBox.Show("Berhasil mengimport template dsrt", "informasi"
                               , MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex1)
                {
                    transaction.Rollback();
                    System.Windows.Forms.MessageBox.Show("Gagal mengimport template dsrt "+Environment.NewLine+" Error "+ex1.Message, "informasi"
                               , MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Console.WriteLine("DSRT Dialog Save 1");
                    Console.WriteLine(ex1.Message);
                    Console.WriteLine(ex1.StackTrace);

                }
                connect.Close();
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("Gagal mengimport template dsrt" + Environment.NewLine + " Error " + ex.Message, "informasi"
                               , MessageBoxButtons.OK, MessageBoxIcon.Error);
                Console.WriteLine("DSRT Dialog Save 2");
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);
            }
            refresh(null, null);
            main.Entri.refresh(null, null);
        }
        
        private void aksi_hapus(object sender, RoutedEventArgs e)
        {
            blok_i itemdelete = (blok_i)list_DSRT.SelectedItem;
            string messageM = "Hapus NKS : " + itemdelete.R106.Data + ", NUS :" + itemdelete.R107.Data
                       + ", Nama : " + itemdelete.R109.Data + " ?";
            DialogResult dialogResult = System.Windows.Forms.MessageBox.Show(messageM, "informasi", MessageBoxButtons.YesNo);
            if (dialogResult == System.Windows.Forms.DialogResult.No)
            {
                return;
            }
            try
            {
                conn = new Connect();
                List<blok_i> blok_i_delete = conn.getListBlok_iByNKSNUS(itemdelete.R106.Data, itemdelete.R107.Data);
                conn = new Connect();
                List<Dokumen> akan_dihapus = conn.getPupulateDokuemn(blok_i_delete);
                conn = new Connect();
                if (akan_dihapus == null)
                {
                    throw new Exception();
                }
                conn = null;
                conn = new Connect();
                Console.WriteLine("Jumlah akan dihapus :" + akan_dihapus.Count);

                if (!Dokumen.delete(akan_dihapus))
                {
                    throw new Exception();
                }

                System.Windows.Forms.MessageBox.Show("Berhasil menghapus dsrt", "informasi"
                           , MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("Gagal menghapus dsrt karena " + Environment.NewLine + " Error " + ex.Message, "informasi"
                               , MessageBoxButtons.OK, MessageBoxIcon.Error);
                Console.WriteLine("DSRT Dialog Delete 2");
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);
            }
            refresh(null, null);
            main.Entri.refresh(null, null);
        }
        private void aksi_generate(object sender, RoutedEventArgs e)
        {
            if (sender == tw2)
            {
                List<blok_i> list_blok_i = conn.getListBlok_iOnlytw(1);
                if (!checkLock(list_blok_i))
                {
                    return;
                }
                List<Dokumen> list_dokumen = conn.getPupulateDokuemn(list_blok_i);
                List<Dokumen> resultDokumen = new List<Dokumen>();
                foreach (Dokumen itemDok in list_dokumen)
                {
                    resultDokumen.Add(Dokumen.createCopyForNextTrw(itemDok, "2"));
                }
                String error = "";
                if(Dokumen.saveAllNewDokumen(error, resultDokumen))
                {
                    System.Windows.Forms.MessageBox.Show("Berhasil membuat dokumen triwulan 2",  "informasi"
                              , MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    System.Windows.Forms.MessageBox.Show(error, "informasi"
                              , MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                
            }else if(sender == tw3)
            {
                List<blok_i> list_blok_i = conn.getListBlok_iOnlytw(2);
                if (!checkLock(list_blok_i))
                {
                    return;
                }
                List<Dokumen> list_dokumen = conn.getPupulateDokuemn(list_blok_i);
                List<Dokumen> resultDokumen = new List<Dokumen>();
                foreach (Dokumen itemDok in list_dokumen)
                {
                    resultDokumen.Add(Dokumen.createCopyForNextTrw(itemDok, "3"));
                }
                String error = "";
                if (Dokumen.saveAllNewDokumen(error, resultDokumen))
                {
                    System.Windows.Forms.MessageBox.Show("Berhasil membuat dokumen triwulan 3", "informasi"
                              , MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    System.Windows.Forms.MessageBox.Show(error, "informasi"
                              , MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else if (sender == tw4)
            {
                List<blok_i> list_blok_i = conn.getListBlok_iOnlytw(3);
                if (!checkLock(list_blok_i))
                {
                    return;
                }
                List<Dokumen> list_dokumen = conn.getPupulateDokuemn(list_blok_i);
                List<Dokumen> resultDokumen = new List<Dokumen>();
                foreach (Dokumen itemDok in list_dokumen)
                {
                    resultDokumen.Add(Dokumen.createCopyForNextTrw(itemDok, "4"));
                }
                String error = "";
                if (Dokumen.saveAllNewDokumen(error, resultDokumen))
                {
                    System.Windows.Forms.MessageBox.Show("Berhasil membuat dokumen triwulan 4", "informasi"
                              , MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    System.Windows.Forms.MessageBox.Show(error, "informasi"
                              , MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            refresh(null, null);
        }
        public Boolean checkLock(List<blok_i> list_blok_i)
        {
            foreach(blok_i itemBlokI in list_blok_i)
            {
                if(itemBlokI.Is_lock.Data.Equals("1") || (itemBlokI.Lock_user.Data!=null && !itemBlokI.Lock_user.Data.Equals("")))
                {
                    return false;
                }
            }
            return true;
        }
    }
}
