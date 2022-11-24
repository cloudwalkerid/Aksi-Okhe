using System;
using System.IO;
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
using System.Windows.Forms;
using Akhi_Okhee._1._Common;
using Akhi_Okhee._2._Database;

namespace Akhi_Okhee._3._3._Client_Main
{
    /// <summary>
    /// Interaction logic for Main.xaml
    /// </summary>
    public partial class Main : Window
    {
        private Akun akun_active;
        private Dictionary<string, string> provDict;
        private Dictionary<string, string> kabDict;
        private Dictionary<string, string> kecDict;
        private Dictionary<string, string> desaDict;
        private Page_Beranda _beranda;
        private Page_Entri _entri;
        private Page_DSRT _dsrt;
        private Page_Barang _barang;
        private Page_Akun _akun;
        private Page_Lock _lock_page;

        public Dictionary<string, string> ProvDict { get => provDict; set => provDict = value; }
        public Dictionary<string, string> KabDict { get => kabDict; set => kabDict = value; }
        public Dictionary<string, string> KecDict { get => kecDict; set => kecDict = value; }
        public Dictionary<string, string> DesaDict { get => desaDict; set => desaDict = value; }
        public Page_Beranda Beranda { get => _beranda; set => _beranda = value; }
        public Page_Entri Entri { get => _entri; set => _entri = value; }
        public Page_DSRT Dsrt { get => _dsrt; set => _dsrt = value; }
        public Page_Barang Barang { get => _barang; set => _barang = value; }
        public Page_Akun Akun { get => _akun; set => _akun = value; }
        public Page_Lock Lock_page { get => _lock_page; set => _lock_page = value; }
        public Akun Akun_active { get => akun_active; set => akun_active = value; }

        public Main(Akun __akun, int role)
        {
            Akun_active = __akun;
            InitializeComponent();
            getProvDict();
            getKabDict();
            getKecDict();
            getDesaDict();
            Beranda = new Page_Beranda();
            Entri = new Page_Entri(this);
            Dsrt = new Page_DSRT(this);
            Akun = new Page_Akun(this);
            Barang = new Page_Barang(this);
            Lock_page = new Page_Lock(this);
            nama.Content = Akun_active.Nama;
            main_content.Content = Beranda;
            versi.Content = "APLIKASI VERSI 2";

            if (Akun_active.Status == 0 || Akun_active.Status == 1)
            {
                menu_button.Children.Remove(entri);
                
            }
            else if(Akun_active.Status == 2)
            {
                menu_button.Children.Remove(dsrt);
                menu_button.Children.Remove(akun);
                menu_button.Children.Remove(barang);
                menu_button.Children.Remove(revalidasi);
                menu_button.Children.Remove(lock_doc);
                menu_button.Children.Remove(export);
            }

        }
        public void getProvDict()
        {
            ProvDict = new Dictionary<string, string>();
            ProvDict.Add("76", "SULAWESI BARAT");
        }

        public void getKabDict()
        {
            KabDict = new Dictionary<string, string>();
            KabDict.Add("7603", "MAMASA");
        }

        public void getKecDict()
        {
            KecDict = new Dictionary<string, string>();
            using (var reader = new StreamReader(Connect.folderAppData + "/kec.csv"))
            {
                Boolean awal = true;
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    if (awal)
                    {
                        awal = false;
                        continue;
                    }
                    var values = line.Split(';');
                    KecDict.Add(values[0], values[1].ToUpper());
                }
            }
        }

        public void getDesaDict()
        {
            DesaDict = new Dictionary<string, string>();
            using (var reader = new StreamReader(Connect.folderAppData + "/desa.csv"))
            {
                Boolean awal = true;
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    if (awal)
                    {
                        awal = false;
                        continue;
                    }
                    var values = line.Split(';');
                    DesaDict.Add(values[0], values[1]);
                }
            }
        }
        private void aksi_beranda(object sender, RoutedEventArgs e)
        {
            main_content.Content = Beranda;
        }
        private void aksi_entri(object sender, RoutedEventArgs e)
        {
            Entri.refresh(null, null);
            main_content.Content = Entri;
        }
        private void aksi_dsrt(object sender, RoutedEventArgs e)
        {
            Dsrt.refresh(null, null);
            main_content.Content = Dsrt;
        }
        private void aksi_barang(object sender, RoutedEventArgs e)
        {
            Barang.refresh(null, null);
            main_content.Content = Barang;
        }
        private void aksi_akun(object sender, RoutedEventArgs e)
        {
            Akun.refresh();
            main_content.Content = Akun;
        }
        private void aksi_revalidasi(object sender, RoutedEventArgs e)
        {
            DialogResult dialogResult = System.Windows.Forms.MessageBox.Show("Yakin melakukan revalidasi?", "informasi", MessageBoxButtons.YesNo);
            if (dialogResult == System.Windows.Forms.DialogResult.Yes)
            {
                Connect conn = new Connect();
                List<barang> list_barang = conn.getListBarang("", "", "");
                List <blok_i> allBlok_i = conn.getListBlok_i("", "", "", "");
                List<Dokumen> allDokuemn = conn.getPupulateDokuemn(allBlok_i);
                int banyakBerhasil = 0;
                int banyakGagal = 0;
                foreach (Dokumen itemdok  in allDokuemn)
                {
                    if (itemdok.reval(list_barang))
                    {
                        banyakBerhasil = banyakBerhasil + 1;
                    }
                    else
                    {
                        banyakGagal = banyakGagal + 1;
                    }
                }
                if (banyakGagal == 0)
                {
                    System.Windows.Forms.MessageBox.Show("Berhasil melakukan revalidasi ke semua dokumen !", "informasi"
                                    , MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    System.Windows.Forms.MessageBox.Show("Berhasil melakukan revalidasi ke "+banyakBerhasil+" dokumen, dan Gagal di "+banyakGagal+" dokumen !", "informasi"
                                    , MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
        private void aksi_export(object sender, RoutedEventArgs e)
        {
            Dialog_Export export = new Dialog_Export(this);
            export.Owner = this;
            export.Show();
        }
        private void aksi_lock(object sender, RoutedEventArgs e)
        {
            Lock_page.refresh();
            main_content.Content = Lock_page;
        }
        private void aksi_logout(object sender, RoutedEventArgs e)
        {
            DialogResult dialogResult = System.Windows.Forms.MessageBox.Show("Yakin menutup aplikasi?", "informasi", MessageBoxButtons.YesNo);
            if (dialogResult == System.Windows.Forms.DialogResult.Yes)
            {
                Akhi_Okhee._3._1._Client_Login.Main loginWindow = new Akhi_Okhee._3._1._Client_Login.Main();
                loginWindow.Show();
                Close();
            }
        }
       
        public void refreshAkun(Akun akunBerubah)
        {
           if(Akun_active.Status == akunBerubah.Status)
            {
                Akun_active = akunBerubah;
                nama.Content = Akun_active.Nama;
            }
        }
    }
}
