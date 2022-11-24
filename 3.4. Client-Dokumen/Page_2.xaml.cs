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
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Akhi_Okhee._3._4._Client_Dokumen
{
    /// <summary>
    /// Interaction logic for Page_2.xaml
    /// </summary>
    public partial class Page_2 : Page
    {
        Main main;
        private Dokumen dokumen;
        public Page_2(Main _main, Dokumen _dokumen)
        {
            InitializeComponent();
            main = _main;
            dokumen = _dokumen;
            this.DataContext = dokumen;
            dokumen.Blok_iii.setUserPageii(this);
            adaPerubahan();
            repopulateR301Iter();
        }
        public void adaPerubahan()
        {
            Console.WriteLine("Ada perubahan");
            if(dokumen.Blok_iii.R301K_k9.Data == default(double?))
            {
                R301K_k9.Text = "";
            }
            else
            {
                R301K_k9.Text = ((double)dokumen.Blok_iii.R301K_k9.Data).ToString("N0");
            }
            if (dokumen.Blok_iii.R301J_k9.isError())
            {
                Rect_301J_k9.Fill = new SolidColorBrush(Color.FromArgb(255, (byte)255, (byte)113, (byte)91));
                Rect_301J_k9.ToolTip = new System.Windows.Controls.ToolTip { Content = dokumen.Blok_iii.R301J_k9.getAllError()[0] };
            }
            else
            {
                Rect_301J_k9.Fill = new SolidColorBrush(Colors.White);
                Rect_301J_k9.ToolTip = null;
            }
            if (dokumen.Blok_iii.R301K_k9.isError())
            {
                Rect_301K_k9.Fill = new SolidColorBrush(Color.FromArgb(255, (byte)255, (byte)113, (byte)91));
                Rect_301K_k9.ToolTip = new System.Windows.Controls.ToolTip { Content = dokumen.Blok_iii.R301K_k9.getAllError()[0] };
            }
            else
            {
                if (dokumen.Blok_iii.R303_k9.Data != default(double?))
                {
                    if (dokumen.Blok_iii.R301K_k9.Data < dokumen.Blok_iii.R303_k9.Data)
                    {
                        Rect_301K_k9.Fill = new SolidColorBrush(Color.FromArgb(255, (byte)252, (byte)192, (byte)95)); // kuning
                        Rect_301K_k9.ToolTip = new System.Windows.Controls.ToolTip { Content = "Apakah benar nilai pengeluaran (R302) lebih kecil dari pada nilai pendapatan (R301K)?" };
                    }
                    else
                    {
                        Rect_301K_k9.Fill = new SolidColorBrush(Colors.White);
                        Rect_301K_k9.ToolTip = null;
                    }
                }
                else
                {
                    Rect_301K_k9.Fill = new SolidColorBrush(Colors.White);
                    Rect_301K_k9.ToolTip = null;
                }
            }
            if (dokumen.Blok_iii.R302_k9.isError())
            {
                Rect_302_k9.Fill = new SolidColorBrush(Color.FromArgb(255, (byte)255, (byte)113, (byte)91));
                Rect_302_k9.ToolTip = new System.Windows.Controls.ToolTip { Content = dokumen.Blok_iii.R302_k9.getAllError()[0] };
            }
            else
            {
                Rect_302_k9.Fill = new SolidColorBrush(Colors.White);
                Rect_302_k9.ToolTip = null;
            }
            if (dokumen.Blok_iii.R303_k9.isError())
            {
                Rect_303_k9.Fill = new SolidColorBrush(Color.FromArgb(255, (byte)255, (byte)113, (byte)91));
                Rect_303_k9.ToolTip = new System.Windows.Controls.ToolTip { Content = dokumen.Blok_iii.R303_k9.getAllError()[0] };
            }
            else
            {
                if (dokumen.Blok_iii.R301K_k9.Data != default(double?))
                {
                    if (dokumen.Blok_iii.R301K_k9.Data < dokumen.Blok_iii.R303_k9.Data)
                    {
                        Rect_303_k9.Fill = new SolidColorBrush(Color.FromArgb(255, (byte)252, (byte)192, (byte)95)); // kuning
                        Rect_303_k9.ToolTip = new System.Windows.Controls.ToolTip { Content = "Apakah benar nilai pengeluaran (R303) lebih kecil dari pada nilai pendapatan (R301K)?" };
                    }
                    else
                    {
                        Rect_303_k9.Fill = new SolidColorBrush(Colors.White);
                        Rect_303_k9.ToolTip = null;
                    }
                }
                else
                {
                    Rect_303_k9.Fill = new SolidColorBrush(Colors.White);
                    Rect_303_k9.ToolTip = null;
                }
               
            }
            if (dokumen.Blok_iii.R304_k9.isError())
            {
                Rect_304_k9.Fill = new SolidColorBrush(Color.FromArgb(255, (byte)255, (byte)113, (byte)91));
                Rect_304_k9.ToolTip = new System.Windows.Controls.ToolTip { Content = dokumen.Blok_iii.R304_k9.getAllError()[0] };
            }
            else
            {
                Rect_304_k9.Fill = new SolidColorBrush(Colors.White);
                Rect_304_k9.ToolTip = null;
            }
        }
        private void aksi_tambah(object sender, RoutedEventArgs e)
        {
            if (main.Barangs.Count == 0)
            {
                System.Windows.Forms.MessageBox.Show("Data barang harus dibuat terlebih dahulu", "informasi"
                              , MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            dokumen.add301Iter();
            repopulateR301Iter();
        }

        public void repopulateR301Iter()
        {
            Container_301.Children.RemoveRange(0, Container_301.Children.Count);
            foreach (blok_iii_301 item_iii_301 in dokumen.List_blok_iii_301)
            {
                if (!item_iii_301.IsDelete)
                {
                    Console.WriteLine("nilai " + item_iii_301.Id_blok_i.Data);
                    _301 item301 = new _301(main, this, item_iii_301, main.Barangs);
                    Container_301.Children.Add(item301);
                }
                
            }
            if (main.Halaman11 != null)
            {
                main.Halaman11.adaPerubahan();
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
                trw_past.Content = "Triwulan IV - 2019";
                trw_past_range.Content = "(Oktober – Desember)";
                trw_now.Content = "Triwulan I 2020";
                trw_now_range.Content = "(Januari - Maret)";
            }
            else if (triw == 2)
            {
                trw_past.Content = "Triwulan I - 2020";
                trw_past_range.Content = "(Januari - Maret)";
                trw_now.Content = "Triwulan II 2020";
                trw_now_range.Content = "(April - Juni)";
            }
            else if (triw == 3)
            {
                trw_past.Content = "Triwulan II 2020";
                trw_past_range.Content = "(April - Juni)";
                trw_now.Content = "Triwulan III 2020";
                trw_now_range.Content = "(Juli - September)";
            }
            else if (triw == 4)
            {
                trw_past.Content = "Triwulan III 2020";
                trw_past_range.Content = "(Juli - September)";
                trw_now.Content = "Triwulan IV 2020";
                trw_now_range.Content = "(Oktober - Desember)";
            }
        }
    }
}
