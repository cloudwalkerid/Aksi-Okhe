using Akhi_Okhee._3._1._Client_Login;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Resources;
using System.IO;
using Akhi_Okhee._2._Database;
using Akhi_Okhee._1._Common;
using MySql.Data.MySqlClient;
using System.Globalization;

namespace Akhi_Okhee._3._1._Client_Login
{
    /// <summary>
    /// Interaction logic for Main.xaml
    /// </summary>
    public partial class Main : Window
    {
        List<Akun> akuns;
        Connect connect;
        public Main()
        {
            InitializeComponent();
            akuns = Akun.getAkun();
            Console.WriteLine("Jumlah Akun : " + akuns.Count);
            errorText.Foreground = new SolidColorBrush(Colors.Red);
            errorText.Content = "";
            username.CharacterCasing = CharacterCasing.Upper;
            connect = new Connect();
            Console.WriteLine(CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator + "|" + CultureInfo.CurrentCulture.NumberFormat.NumberGroupSeparator);
        }

        private void aksi_login(object sender, RoutedEventArgs e)
        {
            try
            {
                MySqlConnection conn = connect.getConection();
                conn.Open();
                conn.Close();
            }catch(Exception ex)
            {
                errorText.Content = "Basis data belum diatur";
                return;
            }
            /* if (!File.Exists(Connect.dbFile))
             {
                 errorText.Content = "Basis data belum diatur";
             }*/
            if (username.Text.Equals(""))
            {
                errorText.Content = "username tidak boleh kosong";
            }
            if (password.Password.Equals(""))
            {
                errorText.Content = "password tidak boleh kosong";
            }
            foreach(Akun item in akuns)
            {
                if (username.Text.ToUpper().Equals(item.Username) && password.Password.ToUpper().Equals(item.Password))
                {
                    Akhi_Okhee._3._3._Client_Main.Main main = new Akhi_Okhee._3._3._Client_Main.Main(item, item.Status);
                    main.Show();
                    Close();
                }
            }
            errorText.Content = "username dan password tidak ditemukan";
        }
        private void aksi_seting(object sender, RoutedEventArgs e)
        {
            Database sett = new Database();
            sett.Owner = this;
            sett.Show();
        }
    }
}
