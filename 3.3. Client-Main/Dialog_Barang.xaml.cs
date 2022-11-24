using Akhi_Okhee._1._Common;
using Akhi_Okhee._2._Database;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Akhi_Okhee._3._3._Client_Main
{
    /// <summary>
    /// Interaction logic for Dialog_Barang.xaml
    /// </summary>
    public partial class Dialog_Barang : Window , INotifyPropertyChanged
    {
        private Main main;
        private Page_Barang page_barang;
        private barang barangO;
        private Boolean isNew;
        private Connect conn;
        private Dictionary<string, Jenis_satuan> jenisDictSatuan;
        private Dictionary<string, string> jenisString;
        private long? dataNilaiMin = 0;
        private long? dataNilaiMax = 0;

        public long? DataNilaiMin { get => dataNilaiMin; set => dataNilaiMin = value; }
        public long? DataNilaiMax { get => dataNilaiMax; set => dataNilaiMax = value; }

        public Dialog_Barang(Main _main, Page_Barang _page)
        {
            InitializeComponent();
            main = _main;
            page_barang = _page;
            barangO = new barang();
            isNew = true;
            DataContext = this;
            judul.Content = "Tambah Barang Range";
            Title = "Tambah Barang Range";
            conn = new Connect();
            provinsi.SelectedValue = "";
            kabupaten.SelectedValue = "";
            errorText.Foreground = new SolidColorBrush(Colors.Red);
            errorText.Content = "";
            jenisDictSatuan = new Dictionary<string, Jenis_satuan>();
            jenisDictSatuan = Jenis_satuan.getAllSatuanStandar();

            jenisString = new Dictionary<string, string>();
            jenisString.Add("01", "Berat");
            jenisString.Add("02", "Luas");
            jenisString.Add("03", "Panjang");
            jenisString.Add("04", "Lainnya");
            jenis.ItemsSource = jenisString.ToList();
            jenis.DisplayMemberPath = "Value";
            jenis.SelectedValuePath = "Key";

            satuan_lainnya.Visibility = Visibility.Hidden;
            populate(null, null);
            provinsi.SelectedValue = "";
            kabupaten.SelectedValue = "";
            
        }
        private void populate_satuan(object sender, EventArgs e)
        {
            if (!jenis.SelectedValue.ToString().Equals("04"))
            {
                satuan.Visibility = Visibility.Visible;
                satuan_lainnya.Visibility = Visibility.Hidden;

                satuan.ItemsSource = jenisDictSatuan[jenis.SelectedValue.ToString()].Satuans;
                satuan.DisplayMemberPath = "Value.Nama_lengkap";
                satuan.SelectedValuePath = "Key";
            }
            else
            {
                satuan.Visibility = Visibility.Hidden;
                satuan_lainnya.Visibility = Visibility.Visible;
            }
        }
        public void setBarangEdit(barang _barang)
        {
            barangO = _barang;
            isNew = false;
            provinsi.SelectedValue = _barang.Prov.Data;
            kabupaten.SelectedValue = _barang.Kab.Data;
            nama.Text = _barang.Nama.Data;
            jenis.SelectedValue = _barang.Jenis.Data;
            kbli.Text = _barang.Kbli.Data;
            if (!_barang.Jenis.Data.Equals("04"))
            {
                populate_satuan(null, null);
                satuan.SelectedValue = _barang.Satuan.Data;
                satuan.Visibility = Visibility.Visible;
                satuan_lainnya.Visibility = Visibility.Hidden;
            }
            else
            {
                satuan_lainnya.Text = _barang.Satuan.Data;
                satuan.Visibility = Visibility.Hidden;
                satuan_lainnya.Visibility = Visibility.Visible;
            }
            DataNilaiMin = _barang.Nilai_min.Data;
            DataNilaiMax = _barang.Nilai_max.Data;
        }
        private void aksi_simpan(object sender, EventArgs e)
        {
            if (provinsi.SelectedValue == null)
            {
                errorText.Content = "Provinsi tidak boleh kosong";
                return;
            }
            else if (kabupaten.SelectedValue == null)
            {
                errorText.Content = "Kabupaten tidak boleh kosong";
                return;
            }
            else if (nama.Text.Equals(""))
            {
                errorText.Content = "Nama tidak boleh kosong";
                return;
            }
            else if (kbli.Text.Equals(""))
            {
                errorText.Content = "Kbli 5 digit tidak boleh kosong";
                return;
            }
            else if (kbli.Text.Length!=5)
            {
                errorText.Content = "Kbli 5 digit harus 5 digit";
                return;
            }
            else if (jenis.SelectedValue == null)
            {
                errorText.Content = "Jenis satuan tidak boleh kosong";
                return;
            }
            else if (satuan_lainnya.Text.Equals("") && satuan.SelectedValue==null)
            {
                errorText.Content = "Satuan tidak boleh kosong";
                return;
            }
            else if (DataNilaiMin==0)
            {
                errorText.Content = "Range Nilai Min tidak boleh kosong";
                return;
            }
            else if (DataNilaiMax==0)
            {
                errorText.Content = "Range Nilai tidak boleh kosong";
                return;
            }
            else if (DataNilaiMin > DataNilaiMax)
            {
                errorText.Content = "Nilai min lebih besar dari nilai max";
                return;
            }

            errorText.Content = "";
            barangO.Prov.Data = provinsi.SelectedValue.ToString();
            barangO.Kab.Data = kabupaten.SelectedValue.ToString();
            Console.WriteLine("Dilag barang kabupatem" + kabupaten.SelectedValue.ToString().Substring(2, 2));
            barangO.Nama.Data = nama.Text;
            barangO.Kbli.Data = kbli.Text;
            barangO.Jenis.Data = jenis.SelectedValue.ToString();
            if (barangO.Jenis.Data.Equals("04"))
            {
                barangO.Satuan.Data = satuan_lainnya.Text;
            }
            else
            {
                barangO.Satuan.Data = satuan.SelectedValue.ToString();
            }
            barangO.Nilai_min.Data = DataNilaiMin;
            barangO.Nilai_max.Data = DataNilaiMax;
         
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
                    if (isNew)
                    {
                        barangO.Id.Data = Guid.NewGuid().ToString();
                        DialogResult dialogResult = System.Windows.Forms.MessageBox.Show("Yakin menyimpan barang baru ini?", "informasi", MessageBoxButtons.YesNo);
                        if (dialogResult == System.Windows.Forms.DialogResult.No)
                        {
                            return;
                        }
                        barangO.InsertData(command);
                    }
                    else
                    {
                        DialogResult dialogResult = System.Windows.Forms.MessageBox.Show("Yakin menyimpan perubahan barang ini?", "informasi", MessageBoxButtons.YesNo);
                        if (dialogResult == System.Windows.Forms.DialogResult.No)
                        {
                            return;
                        }
                        barangO.UpdateData(command);
                    }
                    transaction.Commit();
                }
                catch (Exception ex1)
                {
                    System.Windows.Forms.MessageBox.Show("Gagal mentimpan range barang " + Environment.NewLine + " Error " + ex1.Message, "informasi"
                               , MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Console.WriteLine("Barang Dialog Save 1");
                    Console.WriteLine(ex1.Message);
                    Console.WriteLine(ex1.StackTrace);

                }
                connect.Close();
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("Gagal mentimpan range barang" + Environment.NewLine + " Error " + ex.Message, "informasi"
                               , MessageBoxButtons.OK, MessageBoxIcon.Error);
                Console.WriteLine("Barang Dialog Save 2");
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);
            }
            page_barang.simpan();
            Close();
        }
        private void aksi_cancel(object sender, EventArgs e)
        {
            Close();
        }
        private void populate(object sender, EventArgs e)
        {
            Dictionary<string, string> provDict = new Dictionary<string, string>();
            provDict.Add("", "<--Semua Provinsi-->");
            foreach (var item in main.ProvDict)
            {
                provDict.Add(item.Key, item.Value);
            }
            provinsi.ItemsSource = provDict.ToList();
            provinsi.DisplayMemberPath = "Value";
            provinsi.SelectedValuePath = "Key";


            Dictionary<string, string> kabDict = new Dictionary<string, string>();
            kabDict.Add("", "<--Semua Kabupaten-->");
            foreach (var item in main.KabDict)
            {
                if (provinsi.SelectedValue == null)
                {
                    kabDict.Add(item.Key, item.Value);
                }
                else if (item.Key.StartsWith(provinsi.SelectedValue.ToString()))
                {
                    kabDict.Add(item.Key, item.Value);
                }
            }

            kabupaten.ItemsSource = kabDict.ToList();
            kabupaten.DisplayMemberPath = "Value";
            kabupaten.SelectedValuePath = "Key";
        }
        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        void RaisePropertyChanged(string prop)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
        public event PropertyChangedEventHandler PropertyChanged;

    }
}
