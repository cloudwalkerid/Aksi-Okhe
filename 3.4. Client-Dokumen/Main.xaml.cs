using Akhi_Okhee._1._Common;
using Akhi_Okhee._2._Database;
using Akhi_Okhee._3._3._Client_Main;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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
using System.Windows.Shapes;

namespace Akhi_Okhee._3._4._Client_Dokumen
{
    /// <summary>
    /// Interaction logic for Main.xaml
    /// </summary>
    public partial class Main : Window
    {
        private Dokumen Dokumen;
        private Page_Entri_Item Page_Entri_Item;
        private Connect connect;
        private Page_1 Halaman1;
        private Page_2 Halaman2;
        private List<barang> barangs;
        private Akun active_akun;
        public Dokumen Dokumen1 { get => Dokumen; set => Dokumen = value; }
        public List<barang> Barangs { get => barangs; set => barangs = value; }
        public Page_1 Halaman11 { get => Halaman1; set => Halaman1 = value; }
        public Page_2 Halaman21 { get => Halaman2; set => Halaman2 = value; }

        public Main(Dokumen dokumen, Page_Entri_Item page_Entri_Item, Akun active_account)
        {
            InitializeComponent();

            if (!dokumen.IsPopulate)
            {
                dokumen.populate();
            }

            active_akun = active_account;
            Dokumen1 = dokumen;
            Console.WriteLine("Dokumen nus : " + dokumen.Blok_i.Nks_nus.Data);
            Console.WriteLine("Dokumen blok 1 : " + dokumen.Blok_i.Id.Data);
            Console.WriteLine("Dokumen blok 2 : " + dokumen.Blok_ii.Id.Data);
            Console.WriteLine("Dokumen blok 3 : " + dokumen.Blok_iii.Id.Data);
            Page_Entri_Item = page_Entri_Item;
            connect = new Connect();
            Closing += OnWindowClosing;
            Barangs = connect.getListBarang(dokumen.Blok_i.R101.Data, dokumen.Blok_i.R102.Data, "");
            Console.WriteLine("banyak barang : " + Barangs.Count);
            Halaman11 = new Page_1(this, Dokumen1);
            Halaman21 = new Page_2(this, Dokumen1);
            Halaman11.changeToTriwulan(dokumen.Blok_i.IntTriwulan);
            Halaman21.changeToTriwulan(dokumen.Blok_i.IntTriwulan);
            Halaman1.adaPerubahan();
            //main_content.Content = Halaman11;
            Page1(null, null);
            dokumen.MainDokuPage = this;
        }
        public void OnWindowClosing(object sender, CancelEventArgs e)
        {
            DialogResult dialogResult = System.Windows.Forms.MessageBox.Show("Menyimpan Data Sebelum Keluar?", "informasi", MessageBoxButtons.YesNoCancel);
            if (dialogResult == System.Windows.Forms.DialogResult.No)
            {
               if(!Dokumen.release_claim_entri(active_akun))
                {
                    e.Cancel = true;
                    System.Windows.Forms.MessageBox.Show("Gagal Menutup Dokumen", "informasi"
                      , System.Windows.Forms.MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            else if (dialogResult == System.Windows.Forms.DialogResult.Cancel)
            {
                e.Cancel = true;
            }
            else if (dialogResult == System.Windows.Forms.DialogResult.Yes)
            {
                String errpr = "";
                Boolean berhasilSimpan = Dokumen.save(error: errpr, realese_claim: true, active_akun: active_akun);
                if (berhasilSimpan)
                {
                    Console.WriteLine("Berhasil Simpan");
                    System.Windows.Forms.MessageBox.Show("Berhasil Menyimpan Dokumen", "informasi"
                         , System.Windows.Forms.MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Page_Entri_Item.refreshDoku(Dokumen1.Blok_i);
                }
                else
                {
                    System.Windows.Forms.MessageBox.Show(errpr, "informasi"
                       , System.Windows.Forms.MessageBoxButtons.OK, MessageBoxIcon.Error);
                    e.Cancel = true;
                }


            }

            Page_Entri_Item.refreshDoku(Dokumen1.Blok_i);
            Dokumen.MainDokuPage = null;
        }
        public void Page1(object sender, RoutedEventArgs e)
        {
            main_content.Content = Halaman11;
            scrool.ScrollToTop();
            Halaman1.R201a.Focus();
        }
        public void Page2(object sender, RoutedEventArgs e)
        {
            main_content.Content = Halaman21;
            scrool.ScrollToTop();
        }
        public void Simpan(object sender, RoutedEventArgs e)
        {

            String errpr = "";
            Boolean berhasilSimpan =  Dokumen.save(errpr);
            if (berhasilSimpan)
            {
                Console.WriteLine("Berhasil Simpan");
                System.Windows.Forms.MessageBox.Show("Berhasil Menyimpan Dokumen", "informasi"
                     , System.Windows.Forms.MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                System.Windows.Forms.MessageBox.Show(errpr, "informasi"
                   , System.Windows.Forms.MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            Page_Entri_Item.refreshDoku(Dokumen1.Blok_i);
        }
        public void Keluar(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
