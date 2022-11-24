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
using System.Windows.Shapes;

namespace Akhi_Okhee._3._3._Client_Main
{
    /// <summary>
    /// Interaction logic for Dialog_Akun.xaml
    /// </summary>
    public partial class Dialog_Akun : Window
    {
        Akun akun;
        Page_Akun page_Akun;
        int Kegiatan;
        Connect connect;
        public Dialog_Akun(Akun _akun, Page_Akun _page, int kegiatan)
        {
            InitializeComponent();
            connect = new Connect();
            page_Akun = _page;
            Kegiatan = kegiatan; //0: Tambah 1:Ubah

            username.CharacterCasing = System.Windows.Controls.CharacterCasing.Upper;
            nama.CharacterCasing = System.Windows.Controls.CharacterCasing.Upper;


            Dictionary<int, string> statusDict = new Dictionary<int, string>();
            statusDict.Add(1, "Admin");
            statusDict.Add(2, "Pengguna");

            status.ItemsSource = statusDict.ToList();
            status.DisplayMemberPath = "Value";
            status.SelectedValuePath = "Key";

            if (kegiatan == 0)
            {
                Title = "Tambah Akun";
                akun = new Akun();
                akun.Id = Guid.NewGuid().ToString();

                errorText.Foreground = new SolidColorBrush(Colors.Red);
                errorText.Content = "";
            }
            else if(kegiatan == 1)
            {
                Title = "Ubah Akun";
                akun = _akun;
                username.Text = _akun.Username;
                nama.Text = _akun.Nama;
                password.Password = _akun.Password;
                status.SelectedValue = _akun.Status;

                errorText.Foreground = new SolidColorBrush(Colors.Red);
                errorText.Content = "";
            }   
        }
        private void aksi_simpan(object sender, EventArgs e)
        {
            if (username.Text.Equals(""))
            {
                errorText.Content = "Username tidak boleh kosong";
            }else if (nama.Text.Equals(""))
            {
                errorText.Content = "Nama tidak boleh kosong";
            }else if (password.Password.Equals(""))
            {
                errorText.Content = "Password tidak boleh kosong";
            }
            else
            {
                if (Kegiatan == 0)
                {
                    DialogResult dialogResult = System.Windows.Forms.MessageBox.Show("Yakin menambahkan user "+username.Text+"?", "informasi", MessageBoxButtons.YesNo);
                    if (dialogResult == System.Windows.Forms.DialogResult.No)
                    {
                        return;
                    }
                    akun.Username = username.Text.ToUpper();
                    akun.Password = password.Password.ToUpper();
                    akun.Nama = nama.Text.ToUpper();
                    akun.Status = (int)status.SelectedValue;
                    try
                    {
                        MySqlConnection conection= connect.getConection();
                        conection.Open();
                        MySqlCommand cmd = conection.CreateCommand();
                        akun.InsertData(cmd);
                        page_Akun.edit_akun_yes(akun, 0);
                        conection.Close();
                        Close();
                        System.Windows.Forms.MessageBox.Show("Berhasil menyimpan user", "informasi"
                             , MessageBoxButtons.OK, MessageBoxIcon.Information);
                        
                    }
                    catch(Exception ex)
                    {
                        Console.WriteLine("Tambah Akun");
                        Console.WriteLine("Tambah Akun : "+ex.Message);
                        Console.WriteLine("Tambah Akun : "+ex.StackTrace);
                        System.Windows.Forms.MessageBox.Show("Gagal menyimpan user", "informasi"
                            , MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else if(Kegiatan == 1)
                {
                    DialogResult dialogResult = System.Windows.Forms.MessageBox.Show("Yakin menyimpan perubahan akun?", "informasi", MessageBoxButtons.YesNo);
                    if (dialogResult == System.Windows.Forms.DialogResult.No)
                    {
                        return;
                    }
                    akun.Username = username.Text.ToUpper();
                    akun.Password = password.Password.ToUpper();
                    akun.Nama = nama.Text.ToUpper();
                    akun.Status = (int)status.SelectedValue;
                    try
                    {
                        MySqlConnection conection = connect.getConection();
                        conection.Open();
                        MySqlCommand cmd = conection.CreateCommand();
                        akun.UpdateData(cmd);
                        page_Akun.edit_akun_yes(akun, 1);
                        conection.Close();
                        Close();
                        System.Windows.Forms.MessageBox.Show("Berhasil mengubah user", "informasi"
                             , MessageBoxButtons.OK, MessageBoxIcon.Information);
                        
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Ubah Akun");
                        Console.WriteLine("Ubah Akun : " + ex.Message);
                        Console.WriteLine("Ubah Akun : " + ex.StackTrace);
                        System.Windows.Forms.MessageBox.Show("Gagal mengubah user", "informasi"
                            , MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
        private void aksi_cancel(object sender, EventArgs e)
        {
            Close();
        }
    }
}
