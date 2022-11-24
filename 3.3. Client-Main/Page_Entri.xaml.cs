using Akhi_Okhee._1._Common;
using Akhi_Okhee._2._Database;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Akhi_Okhee._3._3._Client_Main
{
    /// <summary>
    /// Interaction logic for Page_Entri.xaml
    /// </summary>
    public partial class Page_Entri : Page
    {
        private Main main;
        Connect connect;
        public Page_Entri(Main _main)
        {
            InitializeComponent();
            main = _main;
            connect = new Connect();
            populate(null, null);
            refresh(null, null);
        }
        private void populate(object sender, EventArgs e)
        {
            provinsi.SelectionChanged -= populate;
            kabupaten.SelectionChanged -= populate;
            kecamatan.SelectionChanged -= populate;
            Dictionary<string, string> provDict = new Dictionary<string, string>();
            Dictionary<string, string> kabDict = new Dictionary<string, string>();
            Dictionary<string, string> kecDict = new Dictionary<string, string>();
            if (sender == null)
            {
                provDict = new Dictionary<string, string>();
                provDict.Add("", "<--Semua Provinsi-->");
                foreach (var item in main.ProvDict)
                {
                    provDict.Add(item.Key, item.Value);
                }
                provinsi.ItemsSource = provDict.ToList();
                provinsi.DisplayMemberPath = "Value";
                provinsi.SelectedValuePath = "Key";


                kabDict = new Dictionary<string, string>();
                kabDict.Add("", "<--Semua Kabupaten-->");
                foreach (var item in main.KabDict)
                {
                    kabDict.Add(item.Key, item.Value);
                }

                kabupaten.ItemsSource = kabDict.ToList();
                kabupaten.DisplayMemberPath = "Value";
                kabupaten.SelectedValuePath = "Key";

                kecDict = new Dictionary<string, string>();
                kecDict.Add("", "<--Semua Kecamatan-->");

                foreach (var item in main.KecDict)
                {
                    kecDict.Add(item.Key, item.Value);
                }
                kecamatan.ItemsSource = kecDict.ToList();
                kecamatan.DisplayMemberPath = "Value";
                kecamatan.SelectedValuePath = "Key";

                provinsi.SelectedValue = "";
                kabupaten.SelectedValue = "";
                kecamatan.SelectedValue = "";
            }
            else
            {
                string provSelected = provinsi.SelectedValue.ToString();
                string kabSelected = kabupaten.SelectedValue.ToString();
                string kecSelected = kecamatan.SelectedValue.ToString();

                Console.WriteLine(provSelected + "|" + kabSelected + "|" + kecSelected);

                provDict = new Dictionary<string, string>();
                provDict.Add("", "<--Semua Provinsi-->");
                foreach (var item in main.ProvDict)
                {
                    if ((kabSelected.StartsWith(item.Key) || kabSelected.Equals(""))
                            && (kecSelected.StartsWith(item.Key) || kecSelected.Equals("")))
                    {
                        provDict.Add(item.Key, item.Value);
                    }
                }
                provinsi.ItemsSource = provDict.ToList();
                provinsi.DisplayMemberPath = "Value";
                provinsi.SelectedValuePath = "Key";


                kabDict = new Dictionary<string, string>();
                kabDict.Add("", "<--Semua Kabupaten-->");
                foreach (var item in main.KabDict)
                {
                    if ((item.Key.StartsWith(provSelected) || provSelected.Equals(""))
                            && (kecSelected.StartsWith(item.Key) || kecSelected.Equals("")))
                    {
                        kabDict.Add(item.Key, item.Value);
                    }
                }

                kabupaten.ItemsSource = kabDict.ToList();
                kabupaten.DisplayMemberPath = "Value";
                kabupaten.SelectedValuePath = "Key";

                kecDict = new Dictionary<string, string>();
                kecDict.Add("", "<--Semua Kecamatan-->");

                foreach (var item in main.KecDict)
                {
                    if ((item.Key.StartsWith(provSelected) || provSelected.Equals(""))
                           && (item.Key.StartsWith(kabSelected) || kabSelected.Equals("")))
                    {
                        kecDict.Add(item.Key, item.Value);
                    }
                }
                kecamatan.ItemsSource = kecDict.ToList();
                kecamatan.DisplayMemberPath = "Value";
                kecamatan.SelectedValuePath = "Key";

                provinsi.SelectedValue = provSelected;
                kabupaten.SelectedValue = kabSelected;
                kecamatan.SelectedValue = kecSelected;
            }
            provinsi.SelectionChanged += populate;
            kabupaten.SelectionChanged += populate;
            kecamatan.SelectionChanged += populate;
            refresh(null, null);
        }
        public void refresh(object sender, EventArgs e)
        {
            Console.WriteLine("Entri refresh");
            List<blok_i> list_blok_i = new List<blok_i>();
            string stringProv = "";
            string stringKab = "";
            string stringkec = "";
            if (provinsi.SelectedValue != null)
            {
                stringProv = provinsi.SelectedValue.ToString();
            }
            if(kabupaten.SelectedValue != null)
            {
                stringKab = kabupaten.SelectedValue.ToString();
            }
            if(kecamatan.SelectedValue != null)
            {
                stringkec = kecamatan.SelectedValue.ToString();
            }
            list_blok_i = connect.getListBlok_i(stringProv, stringKab, stringkec, search.Text);
            List<Page_Entri_Item> list_page_entri = new List<Page_Entri_Item>();
            Console.WriteLine("Jumlah Entri :" + list_page_entri.Count);
            if (list_blok_i != null)
            {
                foreach (blok_i itemBlok_i in list_blok_i)
                {
                    itemBlok_i.loadNama(main.ProvDict, main.KabDict, main.KecDict, main.DesaDict);
                    Boolean baru = true;
                    foreach (Page_Entri_Item item_entri in list_page_entri)
                    {
                        if (item_entri.sama(itemBlok_i))
                        {
                            baru = false;
                            break;
                        }
                    }
                    if (baru)
                    {
                        Page_Entri_Item item_i = new Page_Entri_Item(main, itemBlok_i);
                        list_page_entri.Add(item_i);
                    }
                }
            }
            Console.WriteLine("PageEntri : " + list_page_entri.Count);
            Entri_Container.Children.RemoveRange(0, Entri_Container.Children.Count);
            foreach (Page_Entri_Item item_entri in list_page_entri)
            {
                Entri_Container.Children.Add(item_entri);
            }
            //Entri_Container.
        }
    }
}
