using Akhi_Okhee._1._Common;
using Akhi_Okhee._2._Database;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
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
    /// Interaction logic for Page_Akun.xaml
    /// </summary>
    public partial class Page_Akun : Page
    {
        private Main main;
        private List<Akun> akuns;
        public Page_Akun(Main _main)
        {
            InitializeComponent();
            main = _main;
            refresh();
        }

        public void refresh()
        {
            akuns = Akun.getAkun();
            akuns.RemoveAt(0);
            listAkun.ItemsSource = akuns;
        }

        private void add_Click(object sender, RoutedEventArgs e)
        {
            Akun selectedAkun = (Akun)listAkun.SelectedItem;
            Dialog_Akun dialog_Akun = new Dialog_Akun(selectedAkun, this, 0);
            dialog_Akun.Owner = main;
            dialog_Akun.Show();
        }
        private void edit_Click(object sender, RoutedEventArgs e)
        {
            Akun selectedAkun = (Akun)listAkun.SelectedItem;
            Dialog_Akun dialog_Akun = new Dialog_Akun(selectedAkun, this, 1);
            dialog_Akun.Owner = main;
            dialog_Akun.Show();
        }
        private void del_Click(object sender, RoutedEventArgs e)
        {
            Akun selectedAkun = (Akun)listAkun.SelectedItem;
            DialogResult dialogResult = System.Windows.Forms.MessageBox.Show("Yakin Hapus Akun "+ selectedAkun.Username+" ?", "informasi", MessageBoxButtons.YesNo);
            if (dialogResult == System.Windows.Forms.DialogResult.Yes)
            {
                try
                {
                    Connect connect = new Connect();
                    MySqlConnection conection = connect.getConection();
                    conection.Open();
                    MySqlCommand cmd = conection.CreateCommand();
                    selectedAkun.DeleteData(cmd);
                    conection.Close();
                    System.Windows.Forms.MessageBox.Show("Berhasil menghapus user", "informasi"
                         , MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Hapus Akun");
                    Console.WriteLine("Hapus Akun : " + ex.Message);
                    Console.WriteLine("Hapus Akun : " + ex.StackTrace);
                    System.Windows.Forms.MessageBox.Show("Gagal menghapus user", "informasi"
                        , MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                
            }
            if (selectedAkun.Id.Equals(main.Akun_active.Id))
            {
                Akhi_Okhee._3._1._Client_Login.Main loginWindow = new Akhi_Okhee._3._1._Client_Login.Main();
                loginWindow.Show();
                main.Close();
            }
            refresh();
        }
        public void edit_akun_yes(Akun akun, int Kegiatan)
        {
            if(Kegiatan == 1)
            {
                akuns.Add(akun);
            }
            refresh();
            /* Boolean berubah = akun.simpan();
             if (berubah)
             {
                 akuns = Akun.getAkun();
                 listAkun.ItemsSource = akuns;
                 listAkun.Items.Refresh();
                 main.refreshAkun(akun);
             }*/
        }
    }
}
