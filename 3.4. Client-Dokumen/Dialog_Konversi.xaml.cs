using Akhi_Okhee._1._Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Akhi_Okhee._3._4._Client_Dokumen
{
    /// <summary>
    /// Interaction logic for Dialog_Konversi.xaml
    /// </summary>
    public partial class Dialog_Konversi : Window
    {
        private Dictionary<string, Jenis_satuan> jenisDictSatuan;
        Jenis_satuan digunakan;
        private Dictionary<string, string> jenisString;
        private Main main;
        _301 _301;
        public Dialog_Konversi(Main main, _301 _t301,   string _jenis, string kode_standar,  double nilai)
        {
            InitializeComponent();
            jenisDictSatuan = Jenis_satuan.getAllSatuanStandar();
            digunakan = jenisDictSatuan[_jenis];

            jenisString = new Dictionary<string, string>();
            jenisString.Add("01", "Berat");
            jenisString.Add("02", "Luas");
            jenisString.Add("03", "Panjang");
            jenis.ItemsSource = jenisString.ToList();
            jenis.DisplayMemberPath = "Value";
            jenis.SelectedValuePath = "Key";
            jenis.SelectedValue = _jenis;
            jenis.IsEnabled = false;
            Console.WriteLine("Masuk konversi | " + _jenis + "|" + kode_standar);
            populate_satuan(null, null);
            satuan_akhir.SelectedValue = digunakan.Satuans[kode_standar].Simbol;
            satuan_akhir.IsEnabled = false;
            akhir.IsEnabled = false;
            Console.WriteLine("terpilih : " + digunakan.Satuans[kode_standar].Nama);
            _301 = _t301;
            awal.TextChanged += do_konversi;
            satuan_awal.SelectionChanged += do_konversi;
            awal.Text = nilai.ToString();
        }

        private void populate_satuan(object sender, EventArgs e)
        {
            satuan_awal.ItemsSource = digunakan.Satuans;
            satuan_awal.DisplayMemberPath = "Value.Nama_lengkap";
            satuan_awal.SelectedValuePath = "Key";

            satuan_akhir.ItemsSource = digunakan.Satuans;
            satuan_akhir.DisplayMemberPath = "Value.Nama_lengkap";
            satuan_akhir.SelectedValuePath = "Key";
        }
        private void aksi_simpan(object sender, EventArgs e)
        {
            _301.simpan_konversi(double.Parse(akhir.Text));
            Close();
        }
        private void aksi_cancel(object sender, EventArgs e)
        {
            Close();
        }
        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }
        private void DoubleValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            //Regex regex = new Regex("[^0-9]+"); "^[.][0-9]+$|^[0-9]*[.]{0,1}[0-9]*$"
            Regex regex = new Regex("^[.][0-9]+$|^[0-9]*[.]{0,1}[0-9]*$");
            e.Handled = !regex.IsMatch((sender as System.Windows.Controls.TextBox).Text.Insert((sender as System.Windows.Controls.TextBox).SelectionStart, e.Text));
        }
        private void do_konversi(object sender, RoutedEventArgs e)
        {
            if (sender == awal || sender == satuan_awal)
            {
                if (satuan_awal.SelectedValue != null && satuan_akhir.SelectedValue != null)
                {
                    akhir.Text = (digunakan.Satuans[satuan_awal.SelectedValue.ToString()].Konversi
                        / digunakan.Satuans[satuan_akhir.SelectedValue.ToString()].Konversi * long.Parse(awal.Text)).ToString();
                }
                
            }
            else if(sender == akhir)
            {

            }
        }
    }
}
