using Akhi_Okhee._1._Common;
using System;
using System.Collections.Generic;
using System.Globalization;
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
    /// Interaction logic for _301.xaml
    /// </summary>
    public partial class _301 : UserControl
    {
        blok_iii_301 Blok_Iii_301;
        List<barang> barangs;
        Main main;
        Page_2 page_2;
        public static string Id_null = "00000-00000-00000-00000-00000-00000-0000";
       

        public blok_iii_301 Blok_Iii_3011 { get => Blok_Iii_301; set => Blok_Iii_301 = value; }

        public _301(Main _main, Page_2 _page_2, blok_iii_301 _blok_Iii_301, List<barang> _barangs)
        {
            InitializeComponent();
            Blok_Iii_3011 = _blok_Iii_301;
            main = _main;
            page_2 = _page_2;
            barangs = _barangs;
            combo_barang.ItemsSource = barangs;
            combo_barang.DisplayMemberPath = "Nama.Data";
            combo_barang.SelectedValuePath = "Id.Data";
            this.DataContext = Blok_Iii_3011;
            Blok_Iii_3011.setUser301Iter(this);
            konversi.Visibility = Visibility.Hidden;
            R301K7.Margin = new Thickness(475, 21, 0, 0);
            if (Blok_Iii_3011.Id_barang.Data == null)
            {
                Blok_Iii_301.Id_barang.Data = Id_null;  
                
            }
            chooseBarang(Blok_Iii_301.Id_barang.Data);
            if (Blok_Iii_301.Barang == null)
            {
                barang barangNull = new barang();
                barangNull.Id.Data = Id_null;
                Blok_Iii_301.Barang = barangNull;
                Blok_Iii_301.Id_barang.Data = Id_null;  
            }
            Blok_Iii_301.changeValue(null);
            adaPerubahan();
            Console.WriteLine("301 Ise Error : ");
            if (Blok_Iii_3011.Is_error.Data.Equals("0"))
            {
                combo_barang.IsHitTestVisible = false;
                combo_barang.Focusable = false;
                delete.Visibility = Visibility.Hidden;
            }
            else if (Blok_Iii_3011.Is_error.Data.Equals("1"))
            {
                combo_barang.IsHitTestVisible = true;
                combo_barang.Focusable = true;
                delete.Visibility = Visibility.Visible;
            }

            if(Blok_Iii_3011.R301k7.Data != null)
            {
                R301K7.Text = ((double)Blok_Iii_3011.R301k7.Data).ToString("N", CultureInfo.CurrentCulture);
            }
            
        }
        private void aksi_ganti_barang(object sender, RoutedEventArgs e)
        {
            chooseBarang(combo_barang.SelectedValue.ToString());
        }
        private void chooseBarang(String Id_barang_baru)
        {
            foreach (barang item in barangs)
            {
                if (Id_barang_baru.Equals(item.Id.Data))
                {
                    combo_barang.SelectedItem = item;
                    Blok_Iii_3011.Barang = item;
                    R301K7.IsEnabled = true;
                    R301K8.IsEnabled = true;
                    /*R301K9.IsEnabled = true;*/
                    R301K10.IsEnabled = true;
                    Blok_Iii_3011.Barang = item;
                    if (!item.Jenis.Data.Equals("04"))
                    {
                        konversi.Visibility = Visibility.Visible;
                        R301K7.Margin = new Thickness(475, 10, 0, 0);
                        R301K3.Content = item.Satuan._Data;
                    }
                    else
                    {
                        konversi.Visibility = Visibility.Hidden;
                        R301K7.Margin = new Thickness(475, 21, 0, 0);
                        R301K3.Content = item.Satuan._Data;
                    }
                    R301K2.Content = item.Kbli._Data;

                    break;
                }
            }
            Blok_Iii_3011.Id_barang.Data = Id_barang_baru;
        }
        public void adaPerubahan()
        {
            Console.WriteLine("301 Ada Perubahan");
            if(Blok_Iii_301.R301k9.Data == default(double?))
            {
                R301K9.Text = "";
            }
            else
            {
                R301K9.Text = ((double)Blok_Iii_301.R301k9.Data).ToString("N0");
            }
            if (Blok_Iii_3011.Id_barang.isError())
            {
                Rect_barang.Fill = new SolidColorBrush(Color.FromArgb(255, (byte)255, (byte)113, (byte)91));
                Rect_barang.ToolTip = new ToolTip { Content = Blok_Iii_3011.Id_barang.getAllError()[0] };
            }
            else
            {
                Rect_barang.Fill = new SolidColorBrush(Colors.White);
                Rect_barang.ToolTip = null;
            }
            if (Blok_Iii_3011.R301k7.isError())
            {
               
               Rect_R301k7.Fill= new SolidColorBrush(Color.FromArgb(255, (byte)255, (byte)113, (byte)91));
               Rect_R301k7.ToolTip = new ToolTip { Content = Blok_Iii_3011.R301k7.getAllError()[0] };
            }
            else
            {
                Rect_R301k7.Fill = new SolidColorBrush(Colors.White);
                Rect_R301k7.ToolTip = null;
            }
            if (Blok_Iii_3011.R301k8.isError())
            {
                Rect_R301k8.Fill = new SolidColorBrush(Color.FromArgb(255, (byte)255, (byte)113, (byte)91));
                Rect_R301k8.ToolTip = new ToolTip { Content = Blok_Iii_3011.R301k8.getAllError()[0] };
            }
            else
            {
                Rect_R301k8.Fill = new SolidColorBrush(Colors.White);
                Rect_R301k8.ToolTip = null;
            }
            if (Blok_Iii_3011.R301k9.isError())
            {
                Rect_R301k9.Fill = new SolidColorBrush(Color.FromArgb(255, (byte)255, (byte)113, (byte)91));
                Rect_R301k9.ToolTip = new ToolTip { Content = Blok_Iii_3011.R301k9.getAllError()[0] };
            }
            else
            {
                Rect_R301k9.Fill = new SolidColorBrush(Colors.White);
                Rect_R301k9.ToolTip = null;
            }
            if (Blok_Iii_3011.R301k10.isError())
            {
                Rect_R301k10.Fill = new SolidColorBrush(Color.FromArgb(255, (byte)255, (byte)113, (byte)91));
                Rect_R301k10.ToolTip = new ToolTip { Content = Blok_Iii_3011.R301k10.getAllError()[0] };
            }
            else
            {
                Rect_R301k10.Fill = new SolidColorBrush(Colors.White);
                Rect_R301k10.ToolTip = null;
            }
        }
        private void aksi_delete(object sender, RoutedEventArgs e)
        {
            if (Blok_Iii_3011.Is_error.Data.Equals("1"))
            {
                Blok_Iii_301.IsDelete = true;
                /*main.Dokumen1.List_blok_iii_301.Remove(Blok_Iii_301);*/
                Blok_Iii_301.changeValue(null);
                page_2.repopulateR301Iter();
                /*if(Dokumen)*/
            }
        }
        private void aksi_konversi(object sender, RoutedEventArgs e)
        {
            double hasil = 0;
            if (!R301K7.Text.Equals(""))
            {
                hasil = double.Parse(R301K7.Text);
            }
            Dialog_Konversi konversi = new Dialog_Konversi(main, this, Blok_Iii_301.Barang.Jenis.Data
                , Blok_Iii_301.Barang.Satuan.Data, hasil);
            konversi.Owner = main;
            konversi.Show();
        }

        public void simpan_konversi(Double _double)
        {
            Blok_Iii_3011.R301k7.Data = _double;
            R301K7.Text = _double.ToString("N");
            R301K7.Focus();
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

        /*private void decimal_key_presssed(object sender, System.Windows.Forms.KeyEventArgs e)
        {
           
               
        }*/

        private void decimal_key_up(object sender, KeyEventArgs e)
        {
            /*Console.WriteLine(R301K7.Text);
            Console.WriteLine("0");*/
            if (R301K7.Text.Length == 0)
            {
                return;
            }
            if ((e.Key>=Key.D0 && e.Key <= Key.D9) || (e.Key >= Key.NumPad0 && e.Key <= Key.NumPad9) || e.Key == Key.Back)
            {
               /* if (e.Key == Key.Decimal)
                {
                    Console.WriteLine("1=>" + R301K7.Text.Split(char.Parse(CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator)).Length);
                    R301K7.Text = R301K7.Text.Substring(0, R301K7.Text.Length - 1) + CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator;
                    if (R301K7.Text.Split(char.Parse(CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator)).Length > 2)
                    {
                        Console.WriteLine("2");
                        R301K7.Text = R301K7.Text.Substring(0, R301K7.Text.Length - 1);
                    }

                }*/
                /*Console.WriteLine("1");
                Console.WriteLine(R301K7.Text);*/
                if (R301K7.Text.Contains(CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator))
                {
                    /*Console.WriteLine("3");*/
                    string [] splites = R301K7.Text.Split(char.Parse(CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator));
                    /*Console.WriteLine(splites[0] + "|" + splites[1]);*/
                    if (!splites[0].Equals("")){
                        R301K7.Text = (Double.Parse(splites[0])).ToString("N0", CultureInfo.CurrentCulture)
                            + CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator + splites[1];
                    }
                    else
                    {
                        R301K7.Text = "0"+CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator + splites[1];
                    }
                   
                }
                else
                {
                    /*Console.WriteLine("4");*/
                    R301K7.Text = (Double.Parse(R301K7.Text)).ToString("N0", CultureInfo.CurrentCulture);
                }
                R301K7.SelectionStart = R301K7.Text.Length;
                R301K7.SelectionLength = 0;
            }
            
            /*else
            {  
                R301K7.Text = R301K7.Text.Substring(0, R301K7.Text.Length - 1);
                if (R301K7.Text.Contains(CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator))
                {
                    Console.WriteLine("3");
                    string[] splites = R301K7.Text.Split(char.Parse(CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator));
                    Console.WriteLine(splites[0] + "|" + splites[1]);
                    R301K7.Text = (Double.Parse(splites[0])).ToString("N0", CultureInfo.CurrentCulture)
                        + CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator + splites[1];
                }
                else
                {
                    Console.WriteLine("4");
                    R301K7.Text = (Double.Parse(R301K7.Text)).ToString("N0", CultureInfo.CurrentCulture);
                }
            }*/

            /*if (e.Key.Equals(Key.Enter) || e.Key.Equals(Key.Tab))
            {
                R301K7.Text = (Double.Parse(R301K7.Text)).ToString("N", CultureInfo.CurrentCulture);
            }*/
        }

       

        private void decimal_keydown(object sender, KeyEventArgs e)
        {
            // allows 0-9, backspace, and decimal
            if(e.Key == Key.Enter || e.Key == Key.Tab)
            {
                e.Handled = false;
                return;
            }
            if (e.Key == Key.Decimal)
            {
                if ((sender as TextBox).Text.Contains(CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator))
                {
                    /*Console.WriteLine("true");*/
                    e.Handled = true;
                }
                else
                {
                    /*Console.WriteLine("false");*/
                    e.Handled = true;
                    if (R301K7.Text.Equals(""))
                    {
                        R301K7.Text = "0"+R301K7.Text + CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator;
                    }
                    else
                    {
                        R301K7.Text = R301K7.Text + CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator;
                    }
                }
                R301K7.SelectionStart = R301K7.Text.Length;
                R301K7.SelectionLength = 0;
                return;
            }
            /*Console.WriteLine("up 0 |" + e.Key.ToString());
            Console.WriteLine("up 1 |" + (e.Key >= Key.NumPad0 && e.Key <= Key.NumPad9));*/
            if ((e.Key >= Key.D0 && e.Key <= Key.D9) || (e.Key >= Key.NumPad0 && e.Key <= Key.NumPad9) || e.Key == Key.Back)
            {
                e.Handled = false;
                return;
            }
            else
            {
                e.Handled = true;
                return;
            }

            // checks to make sure only 1 decimal is allowed
            
        }

        private void R301K7_LostFocus(object sender, RoutedEventArgs e)
        {
            if (!R301K7.Text.Equals(""))
            {
                try
                {
                    Blok_Iii_3011.R301k7.Data = Double.Parse(R301K7.Text);
                    R301K7.Text = (Double.Parse(R301K7.Text)).ToString("N", CultureInfo.CurrentCulture);
                }catch(Exception ex)
                {
                    Console.WriteLine("Lost Focus");
                    Console.WriteLine("Lost Focus : "+ex.Message);
                    Console.WriteLine("Lost Focus : "+ex.StackTrace);
                }
            }
            else
            {
                Blok_Iii_3011.R301k7.Data = null;
            }
            
        }

       
    }
}
