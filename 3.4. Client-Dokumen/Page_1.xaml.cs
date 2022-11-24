using Akhi_Okhee._1._Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Akhi_Okhee._3._4._Client_Dokumen
{
    /// <summary>
    /// Interaction logic for Page_1.xaml
    /// </summary>
    public partial class Page_1 : Page
    {
        private Main main;
        private Dokumen dokumen;
        
        public Page_1(Main _main, Dokumen _dokumen)
        {
            InitializeComponent();
            main = _main;
            dokumen = _dokumen;
            this.DataContext = dokumen;
            Console.WriteLine("R201a:" + dokumen.Blok_ii.R201a.Data);
            Console.WriteLine("Dokumen 1 nus : " + dokumen.Blok_i.Nks_nus.Data);
            Console.WriteLine("Dokumen 1 blok 1 : " + dokumen.Blok_i.Id.Data);
            Console.WriteLine("Dokumen 1 blok 2 : " + dokumen.Blok_ii.Id.Data);
            Console.WriteLine("Dokumen 1 blok 3 : " + dokumen.Blok_iii.Id.Data);
            dokumen.Blok_i.setUserHalaman1(this);
            dokumen.Blok_ii.setUserPagei(this);
            adaPerubahan();
        }
        public void adaPerubahan()
        {
            Console.WriteLine("Ada perubahan");
            if (dokumen.Blok_ii.R201b.isError())
            {
                Rect_R201b.Fill = new SolidColorBrush(Color.FromArgb(255, (byte)255, (byte)113, (byte)91));
                Rect_R201b.ToolTip = new ToolTip { Content = dokumen.Blok_ii.R201b.getAllError()[0] };
            }
            else
            {
                Rect_R201b.Fill = new SolidColorBrush(Colors.White);
                Rect_R201b.ToolTip = null;
            }
            if (dokumen.Blok_ii.R202.isError())
            {
                Rect_R202.Fill = new SolidColorBrush(Color.FromArgb(255, (byte)255, (byte)113, (byte)91));
                Rect_R202.ToolTip = new ToolTip { Content = dokumen.Blok_ii.R202.getAllError()[0] };
            }
            else
            {
                Rect_R202.Fill = new SolidColorBrush(Colors.White);
                Rect_R202.ToolTip = null;
            }
            if (dokumen.Blok_ii.R203.isError())
            {
                Rect_R203.Fill = new SolidColorBrush(Color.FromArgb(255, (byte)255, (byte)113, (byte)91));
                Rect_R203.ToolTip = new ToolTip { Content = dokumen.Blok_ii.R203.getAllError()[0] };
            }
            else
            {
                Rect_R203.Fill = new SolidColorBrush(Colors.White);
                Rect_R203.ToolTip = null;
            }
            if (dokumen.Blok_ii.R204.isError())
            {
                Rect_R204.Fill = new SolidColorBrush(Color.FromArgb(255, (byte)255, (byte)113, (byte)91));
                Rect_R204.ToolTip = new ToolTip { Content = dokumen.Blok_ii.R204.getAllError()[0]};
            }
            else
            {
                Rect_R204.Fill = new SolidColorBrush(Colors.White);
                Rect_R204.ToolTip = null;
            }
            if (dokumen.Blok_ii.R205k2.isError())
            {
                Rect_205k2.Fill = new SolidColorBrush(Color.FromArgb(255, (byte)255, (byte)113, (byte)91));
                Rect_205k2.ToolTip = new ToolTip { Content = dokumen.Blok_ii.R205k2.getAllError()[0] };
            }
            else
            {
                Rect_205k2.Fill = new SolidColorBrush(Colors.White);
                Rect_205k2.ToolTip = null;
            }
            if (dokumen.Blok_ii.R205k3.isError())
            {
                Rect_205k3.Fill = new SolidColorBrush(Color.FromArgb(255, (byte)255, (byte)113, (byte)91));
                Rect_205k3.ToolTip = new ToolTip { Content = dokumen.Blok_ii.R205k3.getAllError()[0]};
            }
            else
            {
                Rect_205k3.Fill = new SolidColorBrush(Colors.White);
                Rect_205k3.ToolTip = null;
            }
            if (dokumen.Blok_ii.R206k2.isError())
            {
                Rect_206k2.Fill = new SolidColorBrush(Color.FromArgb(255, (byte)255, (byte)113, (byte)91));
                Rect_206k2.ToolTip = new ToolTip { Content = dokumen.Blok_ii.R206k2.getAllError()[0] };
            }
            else
            {
                Rect_206k2.Fill = new SolidColorBrush(Colors.White);
                Rect_206k2.ToolTip = null;
            }
            if (dokumen.Blok_ii.R206k3.isError())
            {
                Rect_206k3.Fill = new SolidColorBrush(Color.FromArgb(255, (byte)255, (byte)113, (byte)91));
                Rect_206k3.ToolTip = new ToolTip { Content = dokumen.Blok_ii.R206k3.getAllError()[0] };
            }
            else
            {
                Rect_206k3.Fill = new SolidColorBrush(Colors.White);
                Rect_206k3.ToolTip = null;
            }
            if (dokumen.Blok_ii.R207k2.isError())
            {
                Rect_207k2.Fill = new SolidColorBrush(Color.FromArgb(255, (byte)255, (byte)113, (byte)91));
                Rect_207k2.ToolTip = new ToolTip { Content = dokumen.Blok_ii.R207k2.getAllError()[0] };
            }
            else
            {
                Rect_207k2.Fill = new SolidColorBrush(Colors.White);
                Rect_207k2.ToolTip = null;
            }
            if (dokumen.Blok_ii.R207k3.isError())
            {
                Rect_207k3.Fill = new SolidColorBrush(Color.FromArgb(255, (byte)255, (byte)113, (byte)91));
                Rect_207k3.ToolTip = new ToolTip { Content = dokumen.Blok_ii.R207k3.getAllError()[0] };
            }
            else
            {
                Rect_207k3.Fill = new SolidColorBrush(Colors.White);
                Rect_207k3.ToolTip = null;
            }
            if (dokumen.Blok_ii.R208k2.isError())
            {
                Rect_208k2.Fill = new SolidColorBrush(Color.FromArgb(255, (byte)255, (byte)113, (byte)91));
                Rect_208k2.ToolTip = new ToolTip { Content = dokumen.Blok_ii.R208k2.getAllError()[0] };
            }
            else
            {
                Rect_208k2.Fill = new SolidColorBrush(Colors.White);
                Rect_208k2.ToolTip = null;
            }
            if (dokumen.Blok_ii.R208k3.isError())
            {
                Rect_208k3.Fill = new SolidColorBrush(Color.FromArgb(255, (byte)255, (byte)113, (byte)91));
                Rect_208k3.ToolTip = new ToolTip { Content = dokumen.Blok_ii.R208k3.getAllError()[0] };
            }
            else
            {
                Rect_208k3.Fill = new SolidColorBrush(Colors.White);
                Rect_208k3.ToolTip = null;
            }
            if (dokumen.Blok_ii.Catatan.isError())
            {
                Rect_catatn.Fill = new SolidColorBrush(Color.FromArgb(255, (byte)255, (byte)113, (byte)91));
                Rect_catatn.ToolTip = new ToolTip { Content = dokumen.Blok_ii.R208k3.getAllError()[0]};
            }
            else
            {
                Rect_catatn.Fill = new SolidColorBrush(Colors.White);
                Rect_catatn.ToolTip = null;
            }
            Console.WriteLine("dokumen.Blok_ii.R201a.Data : " + dokumen.Blok_ii.R201a.Data);
            if (dokumen.Blok_ii.R201a.Data != default(string) && main.Halaman21!=null)
            {
                Console.WriteLine("dokumen.Blok_ii.R201a.Data 1 : " + dokumen.Blok_ii.R201a.Data);
                if (!dokumen.Blok_ii.R201a.Data.Equals("1") && !dokumen.Blok_ii.R201a.Data.Equals("2"))
                {
                    main.Halaman21.entri.IsEnabled = false;
                    main.Halaman21.entri.Visibility = Visibility.Hidden;
                    dokumen.Blok_ii.R201a.Err_konsistensi = new List<string>();
                    if (dokumen.adaPertambahan())
                    {
                        dokumen.Blok_ii.R201a.Err_konsistensi.Add("R201A berkode selain 1 atau 2 namun ada pertambahan bahan barang yang dihasilkan");
                    }
                    if (!(dokumen.Blok_iii.R301K_k9.Data == default(double?)) && !(dokumen.Blok_iii.R301K_k9.Data == ((double)0)))
                    {
                        dokumen.Blok_ii.R201a.Err_konsistensi.Add("R201A berkode selain 1 atau 2 namun R301 Baris K (Jumlah Nilai Produksi tidak kosong)");
                    }
                    foreach (blok_iii_301 item in dokumen.List_blok_iii_301)
                    {
                        /*item.R301k10.Null = true;*/
                        item.changeValue(dokumen.Blok_ii.R201a);
                    }
                }
                else
                {
                    main.Halaman21.entri.IsEnabled = true;
                    main.Halaman21.entri.Visibility = Visibility.Visible;
                    foreach (blok_iii_301 item in dokumen.List_blok_iii_301)
                    {
                        /*item.R301k10.Null = false;*/
                        item.changeValue(dokumen.Blok_ii.R201a);
                    }
                }

            }
            if (dokumen.Blok_ii.R201a.isError())
            {
                Rect_R201a.Fill = new SolidColorBrush(Color.FromArgb(255, (byte)255, (byte)113, (byte)91));
                Rect_R201a.ToolTip = new ToolTip { Content = dokumen.Blok_ii.R201a.getAllError()[0] };
            }
            else
            {
                Rect_R201a.Fill = new SolidColorBrush(Colors.White);
                Rect_R201a.ToolTip = null;
            }
        }
        private void DoubleValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            //Regex regex = new Regex("[^0-9]+"); "^[.][0-9]+$|^[0-9]*[.]{0,1}[0-9]*$"
            Regex regex = new Regex("^[.][0-9]+$|^[0-9]*[.]{0,1}[0-9]*$");
            e.Handled = !regex.IsMatch((sender as System.Windows.Controls.TextBox).Text.Insert((sender as System.Windows.Controls.TextBox).SelectionStart, e.Text));
        }

        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }
        public void changeToTriwulan(int triw)
        {
            if (triw == 1)
            {
                judul.Content = "SURVEI INDUSTRO MIKRO DAN KECIL  TRIWULAN I - TAHUN 2020";
            }
            else if (triw == 2)
            {
                judul.Content = "SURVEI INDUSTRO MIKRO DAN KECIL  TRIWULAN II - TAHUN 2020";
            }
            else if(triw == 3)
            {
                judul.Content = "SURVEI INDUSTRO MIKRO DAN KECIL  TRIWULAN III - TAHUN 2020";
            }
            else if(triw==4)
            {
                judul.Content = "SURVEI INDUSTRO MIKRO DAN KECIL  TRIWULAN IV - TAHUN 2020";
            }
        }
    }
}
