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
using System.Windows.Shapes;

namespace Akhi_Okhee._3._1._Client_Login
{
    /// <summary>
    /// Interaction logic for Database.xaml
    /// </summary>
    public partial class Database : Window
    {
        private Connect connect;
        private Setting setting;
        private Boolean berhasiltest = false;
        public Database()
        {
            InitializeComponent();
            connect = new _2._Database.Connect();
            setting = new Setting();

            konfigurasi.Visibility = Visibility.Hidden;
            backup.Visibility = Visibility.Hidden;
            restore.Visibility = Visibility.Hidden;

            ip_server.Text = setting.Ip_server;
            database.Text = setting.Database;
            username.Text = setting.Db_username;
            password.Password = setting.Db_pwd;
            tes_koneksi(null, null);
        }

        public Boolean cek_kesamaan()
        {
            if(ip_server.Text.Equals(setting.Ip_server) && database.Text.Equals(setting.Database) && username.Text.Equals(setting.Db_username) && password.Password.Equals(setting.Db_pwd))
            {

                return true;
            }
            else
            {
                if (berhasiltest)
                {
                    System.Windows.Forms.MessageBox.Show("Simpan perubahan data koneksi terlebih dahulu", "informasi"
                              , MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    System.Windows.Forms.MessageBox.Show("Test lalu Simpan perubahan data koneksi terlebih dahulu", "informasi"
                              , MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
               
                return false;
            }
        }

        private void aksi_konfigure_buat(object sender, RoutedEventArgs e)
        {
            if (!cek_kesamaan())
            {
                return;
            }
            if (berhasiltest)
            {
                connect.drop_table();
                if (connect.create_table())
                {
                    System.Windows.Forms.MessageBox.Show("Berhasil mengkonfigurasi basis data", "informasi"
                                , MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    System.Windows.Forms.MessageBox.Show("Gagal mengkonfigurasi basis data", "informasi"
                               , MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void aksi_database_backup(object sender, RoutedEventArgs e)
        {
            if (!cek_kesamaan())
            {
                return;
            }
            if (!berhasiltest)
            {
                return;
            }
            using (SaveFileDialog saveFileDialog1 = new SaveFileDialog())
            {
                saveFileDialog1.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                saveFileDialog1.Filter = "Backup files (*.sql)|*.sql";
                saveFileDialog1.Title = "Simpan backup file";
                saveFileDialog1.RestoreDirectory = true;
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
                            if (!connect.create_Backup(filePath))
                            {
                                throw new Exception();
                            }
                            System.Windows.Forms.MessageBox.Show("Berhasil membuat backup database", "informasi"
                                , MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        catch (Exception ex)
                        {
                            System.Windows.Forms.MessageBox.Show("Gagal membuat backup database", "informasi"
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
        private void aksi_database_restore(object sender, RoutedEventArgs e)
        {
            if (!cek_kesamaan())
            {
                return;
            }
            if (!berhasiltest)
            {
                return;
            }
            DialogResult dialogResult = System.Windows.Forms.MessageBox.Show("Yakin menimpa database?", "informasi", MessageBoxButtons.YesNo);
            if (dialogResult == System.Windows.Forms.DialogResult.No)
            {
                return;
            }
            var fileContent = string.Empty;
            var filePath = string.Empty;

            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                openFileDialog.Filter = "Backup files (*.sql)|*.sql";
                openFileDialog.Title = "Restore backup file";
                openFileDialog.RestoreDirectory = true;
                //openFileDialog.FilterIndex = 1;
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    //Get the path of specified file
                    filePath = openFileDialog.FileName;

                    //Read the contents of the file into a stream
                    try
                    {
                        connect.drop_table();
                        if (!connect.restore_database(filePath))
                        {
                            throw new Exception();
                        }
                        System.Windows.Forms.MessageBox.Show("Berhasil restore database", "informasi"
                            , MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        System.Windows.Forms.MessageBox.Show("Gagal restore database", "informasi"
                           , MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }

        }

        private void tes_koneksi(object sender, RoutedEventArgs e)
        {
            try
            {
                MySqlConnection conn =  connect.getConection(ip_server.Text, database.Text, username.Text, password.Password);
                conn.Open();
                conn.Close();
                berhasiltest = true;
                Simpan_button.IsEnabled = true;
                konfigurasi.IsEnabled = true;
                backup.IsEnabled = true;
                restore.IsEnabled = true;
                if (sender != null)
                {
                    System.Windows.Forms.MessageBox.Show("Berhasil membuat koneksi", "informasi"
                               , MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
               
            }
            catch(Exception ex)
            {
                berhasiltest = false;
                Simpan_button.IsEnabled = false;
                konfigurasi.IsEnabled = false;
                backup.IsEnabled = false;
                restore.IsEnabled = false;

                Console.WriteLine("Tes koneksi DB");
                Console.WriteLine("Tes koneksi DB: "+ex.Message);
                Console.WriteLine("Tes koneksi DB: " + ex.StackTrace);
                if (sender != null)
                {
                    System.Windows.Forms.MessageBox.Show("Gagal membuat koneksi", "informasi"
                           , MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                
            }
        }

        private void simpan(object sender, RoutedEventArgs e)
        {
            if (berhasiltest)
            {
                setting.Ip_server = ip_server.Text;
                setting.Database = database.Text;
                setting.Db_username = username.Text;
                setting.Db_pwd = password.Password;
                if (setting.simpan())
                {
                    System.Windows.Forms.MessageBox.Show("Berhasil menyimpan data koneksi", "informasi"
                               , MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    System.Windows.Forms.MessageBox.Show("Gagal menyimpan data koneksi", "informasi"
                           , MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void ip_server_TextChanged(object sender, TextChangedEventArgs e)
        {
            if(ip_server.Text.StartsWith("localhost") || ip_server.Text.StartsWith("127.0.0.1"))
            {
                konfigurasi.Visibility = Visibility.Visible;
                backup.Visibility = Visibility.Visible;
                restore.Visibility = Visibility.Visible;
            }
            else
            {
                konfigurasi.Visibility = Visibility.Hidden;
                backup.Visibility = Visibility.Hidden;
                restore.Visibility = Visibility.Hidden;
            }
        }
    }
}
