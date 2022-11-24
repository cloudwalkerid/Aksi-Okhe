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
    /// Interaction logic for Page_Lock.xaml
    /// </summary>
    public partial class Page_Lock : Page
    {
        private Main main;
        private Connect conn;
        private List<blok_i> list_blok_i;
        public Page_Lock(Main _main)
        {
            InitializeComponent();
            main = _main;
            conn = new Connect();
            refresh();
            /*populate(null, null);
            refresh(null, null);*/
        }

        public void refresh()
        {
            list_blok_i = conn.getListBlok_i_lock();
            listLock.ItemsSource = list_blok_i;
        }

        public void unlock(object sender, RoutedEventArgs e)
        {
            blok_i selectedItem = (blok_i)listLock.SelectedItem;

            DialogResult dialogResult = System.Windows.Forms.MessageBox.Show("Yakin melakukan unlock dokumen kepada usaha "+selectedItem.R109.Data+" ?", "informasi", MessageBoxButtons.YesNo);
            if (dialogResult == System.Windows.Forms.DialogResult.No)
            {
                return;
            }

            selectedItem.Is_lock.Data = "0";
            selectedItem.Lock_user.Data = null;
            try
            {
                MySqlConnection connect = conn.getConection();
                connect.Open();
                MySqlCommand command = connect.CreateCommand();
                command.Connection = connect;
                selectedItem.UpdateData(command);
                connect.Close();
                System.Windows.Forms.MessageBox.Show("Berhasil melakukan unlock", "informasi"
                            , MessageBoxButtons.OK, MessageBoxIcon.Information);
                refresh();
            }
            catch (System.Exception ex2)
            {
                Console.WriteLine("Unlock 1");
                Console.WriteLine("Unlock :" + ex2.Message);
                Console.WriteLine("Unlock :" + ex2.StackTrace);
                System.Windows.Forms.MessageBox.Show("Gagal melakukan unlock", "informasi"
                            , MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
