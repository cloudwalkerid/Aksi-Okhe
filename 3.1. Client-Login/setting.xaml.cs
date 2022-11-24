using Akhi_Okhee._2._Database;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Resources;
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
    /// Interaction logic for setting.xaml
    /// </summary>
    public partial class setting : Window
    {
        _2._Database.Connect connect;
        public setting()
        {
            InitializeComponent();
            connect = new _2._Database.Connect();
        }
        
        private void aksi_database_buat(object sender, RoutedEventArgs e)
        {
           /* if (File.Exists(Connect.dbFile))
            {
                DialogResult dialogResult = System.Windows.Forms.MessageBox.Show("Yakin menimpa database?", "informasi", MessageBoxButtons.YesNo);
                if (dialogResult == System.Windows.Forms.DialogResult.No)
                {
                    return;
                }
            }
            connect.create_database();
            Boolean hasil2 = connect.create_table();

            if (hasil2)
            {
                System.Windows.Forms.MessageBox.Show("Berhasil membuat database", "informasi"
                    , MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                System.Windows.Forms.MessageBox.Show("Gagal membuat database", "informasi"
                    , MessageBoxButtons.OK, MessageBoxIcon.Error);
            }*/

        }
        private void aksi_database_backup(object sender, RoutedEventArgs e)
        {
           /* using (SaveFileDialog saveFileDialog1 = new SaveFileDialog())
            {
                saveFileDialog1.Filter = "Backup files (*.bak)|*.bak";
                saveFileDialog1.Title = "Simpan backup file";
                //saveFileDialog1.ShowDialog();
                if ( saveFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    string filePath = saveFileDialog1.FileName;
                    if (!filePath.Equals(""))
                    {
                        Console.WriteLine(filePath);
                        try
                        {
                            if (File.Exists(filePath)) File.Delete(filePath);
                            File.Copy(Connect.dbFile, filePath);
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
            */
        }
        private void aksi_database_restore(object sender, RoutedEventArgs e)
        {
          /*  if (File.Exists(Connect.dbFile))
            {
                DialogResult dialogResult = System.Windows.Forms.MessageBox.Show("Yakin menimpa database?", "informasi", MessageBoxButtons.YesNo);
                if (dialogResult == System.Windows.Forms.DialogResult.No)
                {
                    return;
                }
            }
            var fileContent = string.Empty;
            var filePath = string.Empty;

            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = "c:\\";
                openFileDialog.Filter = "Backup files (*.bak)|*.bak";
                //openFileDialog.FilterIndex = 1;
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    //Get the path of specified file
                    filePath = openFileDialog.FileName;

                    //Read the contents of the file into a stream
                    try
                    {
                        if (File.Exists(Connect.dbFile)) File.Delete(Connect.dbFile);
                        File.Copy(filePath, Connect.dbFile);
                        System.Windows.Forms.MessageBox.Show("Berhasil restore database", "informasi"
                            , MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        System.Windows.Forms.MessageBox.Show("Gagal restore database", "informasi"
                           , MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }*/

        }
    }
}
