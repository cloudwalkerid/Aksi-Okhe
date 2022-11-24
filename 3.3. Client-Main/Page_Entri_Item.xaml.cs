using Akhi_Okhee._1._Common;
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
    /// Interaction logic for Page_Entri_Item.xaml
    /// </summary>
    public partial class Page_Entri_Item : System.Windows.Controls.UserControl
    {
        private blok_i _blok_i_1;
        private blok_i _blok_i_2;
        private blok_i _blok_i_3;
        private blok_i _blok_i_4;
        private Main main;
        public blok_i Blok_i_1 { get => _blok_i_1; 
            set{
                _blok_i_1 = value;
                configureButton(Button_1, value);
                Button_1.IsEnabled = true;
                Button_2.IsEnabled = false;
                Button_3.IsEnabled = false;
                Button_4.IsEnabled = false;
            } 
        }
        public blok_i Blok_i_2 { get => _blok_i_2; 
            set
            {
                _blok_i_2 = value;
                configureButton(Button_2, value);
                Button_1.IsEnabled = false;
                Button_2.IsEnabled = true;
                Button_3.IsEnabled = false;
                Button_4.IsEnabled = false;
            }
        }
        public blok_i Blok_i_3 { get => _blok_i_3;
            set
            {
                _blok_i_3 = value;
                configureButton(Button_3, value);
                Button_1.IsEnabled = false;
                Button_2.IsEnabled = false;
                Button_3.IsEnabled = true;
                Button_4.IsEnabled = false;
            }
        }
        public blok_i Blok_i_4 { get => _blok_i_4;
            set
            {
                _blok_i_4 = value;
                configureButton(Button_4, value);
                Button_1.IsEnabled = false;
                Button_2.IsEnabled = false;
                Button_3.IsEnabled = false;
                Button_4.IsEnabled = true;
            }
        }

        public Page_Entri_Item(Main __main, blok_i __blok_i)
        {
            InitializeComponent();
            setDokumen(__blok_i);
            main = __main;
        }
        public void configureButton(System.Windows.Controls.Button button, blok_i value)
        {
            /*button.IsEnabled = true;*/
            if (value.Error.Data.Equals("0"))
            {
                button.Background = new SolidColorBrush(Colors.White);
            }
            else if (value.Error.Data.Equals("1"))
            {
                button.Background = new SolidColorBrush(Color.FromArgb(255, (byte)153, (byte)214, (byte)182));
            }
            if (value.Error.Data.Equals("2"))
            {
                button.Background = new SolidColorBrush(Color.FromArgb(255, (byte)255, (byte)113, (byte)91));
            }
        }
        public void setDokumen(blok_i __blok_i)
        {
            if (__blok_i.IntTriwulan == 1)
            {
                Blok_i_1 = __blok_i;
            }
            else if (__blok_i.IntTriwulan == 2)
            {
                Blok_i_2 = __blok_i;
            }
            else if (__blok_i.IntTriwulan == 3)
            {
                Blok_i_3 = __blok_i;
            }
            else if (__blok_i.IntTriwulan == 4)
            {
                Blok_i_4 = __blok_i;
            }
            provinsi.Content = "PROV : " + __blok_i.Nama_r101;
            kabupaten.Content = "KAB : " + __blok_i.Nama_r102;
            kecamatan.Content = "KEC : " + __blok_i.Nama_r103;
            nama.Content = __blok_i.R109.Data;
        }
        public Boolean sama(blok_i __blok_i)
        {
            blok_i blok_reference = null;
            if(Blok_i_1 != null)
            {
                blok_reference = Blok_i_1;
            }else if (Blok_i_2 != null)
            {
                blok_reference = Blok_i_2;
            }else if (Blok_i_3 != null)
            {
                blok_reference = Blok_i_3;
            }
            else if (Blok_i_4 != null)
            {
                blok_reference = Blok_i_4;
            }
            if (blok_reference !=null && blok_reference.R101.Data.Equals(__blok_i.R101.Data) && blok_reference.R102.Data.Equals(__blok_i.R102.Data) && blok_reference.R103.Data.Equals(__blok_i.R103.Data) && blok_reference.R104.Data.Equals(__blok_i.R104.Data)
                && blok_reference.R105.Data.Equals(__blok_i.R105.Data) && blok_reference.R106.Data.Equals(__blok_i.R106.Data) && blok_reference.R107.Data.Equals(__blok_i.R107.Data) && blok_reference.R108.Data.Equals(__blok_i.R108.Data))
            {
                setDokumen(__blok_i);
                return true;
            }
            else
            {
                return false;
            }
        }
        private blok_i notnull()
        {
            if (Blok_i_1 != null)
            {
                return Blok_i_1;
            }
            else if (Blok_i_2 != null)
            {
                return Blok_i_2;
            }
            else if (Blok_i_3 != null)
            {
                return Blok_i_3;
            }
            else if (Blok_i_4 != null)
            {
                return Blok_i_4;
            }
            return null;
        }
        private void load_dokumen(object sender, RoutedEventArgs e)
        {
            if (sender == Button_1)
            {
                blok_i awal = Blok_i_1;
                Dokumen dokuemn = new Dokumen(awal);
                if (dokuemn.claim_entri(main.Akun_active))
                {
                    dokuemn.Blok_i.loadNama(main.ProvDict, main.KabDict, main.KecDict, main.DesaDict);
                    Akhi_Okhee._3._4._Client_Dokumen.Main mainDokumen = new Akhi_Okhee._3._4._Client_Dokumen.Main(dokuemn, this, main.Akun_active);
                    mainDokumen.Owner = main;
                    mainDokumen.Show();
                }
                else
                {
                    System.Windows.Forms.MessageBox.Show("Gagal membuka dokumen karena sedang dientri oleh user lain", "informasi"
                            , MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                
            }
            else if (sender == Button_2)
            {
                blok_i awal = Blok_i_2;
                Dokumen dokuemn = new Dokumen(awal);
                if (dokuemn.claim_entri(main.Akun_active))
                {
                    dokuemn.Blok_i.loadNama(main.ProvDict, main.KabDict, main.KecDict, main.DesaDict);
                    Akhi_Okhee._3._4._Client_Dokumen.Main mainDokumen = new Akhi_Okhee._3._4._Client_Dokumen.Main(dokuemn, this, main.Akun_active);
                    mainDokumen.Owner = main;
                    mainDokumen.Show();
                }
                else
                {
                    System.Windows.Forms.MessageBox.Show("Gagal membuka dokumen karena sedang dientri oleh user lain", "informasi"
                            , MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            else if (sender == Button_3)
            {
                blok_i awal = Blok_i_3;
                Dokumen dokuemn = new Dokumen(awal);
                if (dokuemn.claim_entri(main.Akun_active))
                {
                    dokuemn.Blok_i.loadNama(main.ProvDict, main.KabDict, main.KecDict, main.DesaDict);
                    Akhi_Okhee._3._4._Client_Dokumen.Main mainDokumen = new Akhi_Okhee._3._4._Client_Dokumen.Main(dokuemn, this, main.Akun_active);
                    mainDokumen.Owner = main;
                    mainDokumen.Show();
                }
                else
                {
                    System.Windows.Forms.MessageBox.Show("Gagal membuka dokumen karena sedang dientri oleh user lain", "informasi"
                            , MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            else if (sender == Button_4)
            {
                blok_i awal = Blok_i_4;
                Dokumen dokuemn = new Dokumen(awal);
                if (dokuemn.claim_entri(main.Akun_active))
                {
                    dokuemn.Blok_i.loadNama(main.ProvDict, main.KabDict, main.KecDict, main.DesaDict);
                    Akhi_Okhee._3._4._Client_Dokumen.Main mainDokumen = new Akhi_Okhee._3._4._Client_Dokumen.Main(dokuemn, this, main.Akun_active);
                    mainDokumen.Owner = main;
                    mainDokumen.Show();
                }
                else
                {
                    System.Windows.Forms.MessageBox.Show("Gagal membuka dokumen karena sedang dientri oleh user lain", "informasi"
                            , MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
        }
        public void refreshDoku(blok_i __blok_i)
        {
            main.Entri.refresh(null, null);
        }
    }
}
