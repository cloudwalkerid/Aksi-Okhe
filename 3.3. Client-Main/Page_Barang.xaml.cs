using Akhi_Okhee._1._Common;
using Akhi_Okhee._2._Database;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
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
    /// Interaction logic for Page_Barang.xaml
    /// </summary>
    public partial class Page_Barang : Page
    {
        private Main main;
        private Connect connect;
        List<barang> barangs = new List<barang>();
        public Page_Barang(Main _main)
        {
            InitializeComponent();
            main = _main;
            connect = new Connect();
            populate(null, null);
            refresh(null, null);

            hapus.IsEnabled = false;

        }
        private void populate(object sender, EventArgs e)
        {
            provinsi.SelectionChanged -= populate;
            kabupaten.SelectionChanged -= populate;
            Dictionary<string, string> provDict = new Dictionary<string, string>();
            Dictionary<string, string> kabDict = new Dictionary<string, string>();
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


                provinsi.SelectedValue = "";
                kabupaten.SelectedValue = "";
            }
            else
            {
                string provSelected = provinsi.SelectedValue.ToString();
                string kabSelected = kabupaten.SelectedValue.ToString();


                provDict = new Dictionary<string, string>();
                provDict.Add("", "<--Semua Provinsi-->");
                foreach (var item in main.ProvDict)
                {
                    if (kabSelected.StartsWith(item.Key) || kabSelected.Equals(""))
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
                    if (item.Key.StartsWith(provSelected) || provSelected.Equals(""))
                    {
                        kabDict.Add(item.Key, item.Value);
                    }
                }

                kabupaten.ItemsSource = kabDict.ToList();
                kabupaten.DisplayMemberPath = "Value";
                kabupaten.SelectedValuePath = "Key";


                provinsi.SelectedValue = provSelected;
                kabupaten.SelectedValue = kabSelected;
            }
            provinsi.SelectionChanged += populate;
            kabupaten.SelectionChanged += populate;
            refresh(null, null);
        }
        public void refresh(object sender, EventArgs e)
        {
            string stringProv = "";
            string stringKab = "";
            if (provinsi.SelectedValue != null)
            {
                stringProv = provinsi.SelectedValue.ToString();
            }
            if (kabupaten.SelectedValue != null)
            {
                stringKab = kabupaten.SelectedValue.ToString();
            }
            List<barang> barangs = new List<barang>();
            barangs = connect.getListBarang(stringProv, stringKab, search.Text);
            Console.WriteLine("Jumlah Panjang Barang : " + barangs.Count);
            listBarang.ItemsSource = barangs;
            listBarang.Items.Refresh();
        }
       
        private void aksi_tambah(object sender, RoutedEventArgs e)
        {
            Dialog_Barang dialog_barang = new Dialog_Barang(main, this);
            dialog_barang.Owner = main;
            dialog_barang.Show();
        }
        private void aksi_ubah(object sender, RoutedEventArgs e)
        {
            Dialog_Barang dialog_barang = new Dialog_Barang(main, this);
            dialog_barang.setBarangEdit((barang)listBarang.SelectedItem);
            dialog_barang.Owner = main;
            dialog_barang.Show();
        }
        public void simpan()
        {
            refresh(null, null);
        }
        private void aksi_hapus(object sender, RoutedEventArgs e)
        {
            barang item = (barang)listBarang.SelectedItem;
            DialogResult dialogResult = System.Windows.Forms.MessageBox.Show("Yakin menghapus range barang hasil '"+item.Nama._Data+"' produksi ini?", "informasi", MessageBoxButtons.YesNo);
            if (dialogResult == System.Windows.Forms.DialogResult.No)
            {
                return;
            }
            
            try
            {
                MySqlConnection connect1 = connect.getConection();
                connect1.Open();
                MySqlCommand command = connect1.CreateCommand();
                MySqlTransaction transaction;
                transaction = connect1.BeginTransaction();
                command.Connection = connect1;
                command.Transaction = transaction;

                try
                {
                    item.DeleteData(command);
                    item.Delete301DataByBarang(command);
                    transaction.Commit();
                }
                catch (Exception ex1)
                {
                    Console.WriteLine("Barang Dialog Delete 1");
                    Console.WriteLine(ex1.Message);
                    Console.WriteLine(ex1.StackTrace);

                }
                connect1.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Barang Dialog Delete 2");
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);
            }
            refresh(null, null);
        }
    }
}
