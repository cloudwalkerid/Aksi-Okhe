using Akhi_Okhee._1._Common;
using Akhi_Okhee._2._Database;
using ExcelLibrary.SpreadSheet;
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

namespace Akhi_Okhee._3._3._Client_Main
{
    /// <summary>
    /// Interaction logic for Dialog_Export.xaml
    /// </summary>
    public partial class Dialog_Export : Window
    {
        private Main main;
        private List<barang> barangs;
        private Connect conn;
        public Dialog_Export(Main _main)
        {
            InitializeComponent();
            progres.Visibility = Visibility.Hidden;
            main = _main;
            conn = new Connect();
            barangs = conn.getListBarang("","","");
        }

        private void pilih_Click(object sender, RoutedEventArgs e)
        {
            using (System.Windows.Forms.SaveFileDialog saveFileDialog1 = new System.Windows.Forms.SaveFileDialog())
            {
                saveFileDialog1.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                saveFileDialog1.Filter = "Excel fail (*.xls)|*.xls";
                saveFileDialog1.Title = "Pilih fail penyimpanan";
                saveFileDialog1.RestoreDirectory = true;
                //saveFileDialog1.ShowDialog();
                if (saveFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    string filePath_ = saveFileDialog1.FileName;
                    filepath.Text = filePath_;
                    Export_button.IsEnabled = true;
                }
            }

        }

        private void Export_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                List<blok_i> list_blok_i = conn.getListBlok_i("", "", "", "");
                List<Dokumen> list_dokumen = conn.getPupulateDokuemn(list_blok_i);

                progres.Visibility = Visibility.Visible;
                progres.Value = 0;
                progres.Maximum = list_dokumen.Count;

                Workbook workbook = new Workbook();
                Worksheet usaha = new Worksheet("Usaha");
                Worksheet branganng = new Worksheet("produksi");

                int index = 0;
                int index_r301_barang = 0;

                usaha.Cells[index, 0] = new Cell(blok_i.k_r101);
                usaha.Cells[index, 1] = new Cell(blok_i.k_r102);
                usaha.Cells[index, 2] = new Cell(blok_i.k_r103);
                usaha.Cells[index, 3] = new Cell(blok_i.k_r104);
                usaha.Cells[index, 4] = new Cell(blok_i.k_r105);
                usaha.Cells[index, 5] = new Cell(blok_i.k_r106);
                usaha.Cells[index, 6] = new Cell(blok_i.k_r107);
                usaha.Cells[index, 7] = new Cell(blok_i.k_r108);
                usaha.Cells[index, 8] = new Cell(blok_i.k_r109);
                usaha.Cells[index, 9] = new Cell(blok_i.k_r110);
                usaha.Cells[index, 10] = new Cell(blok_i.k_r111);
                usaha.Cells[index, 11] = new Cell(blok_i.k_r112);
                usaha.Cells[index, 12] = new Cell(blok_i.k_r113);
                usaha.Cells[index, 13] = new Cell(blok_i.k_r114);
                usaha.Cells[index, 14] = new Cell(blok_i.k_r115);
                usaha.Cells[index, 15] = new Cell(blok_i.k_r116);
                usaha.Cells[index, 16] = new Cell(blok_i.k_triwulan);
                usaha.Cells[index, 17] = new Cell("Status");
                usaha.Cells[index, 18] = new Cell(blok_ii.k_r201a);
                usaha.Cells[index, 19] = new Cell(blok_ii.k_r201b);
                usaha.Cells[index, 20] = new Cell(blok_ii.k_r202);
                usaha.Cells[index, 21] = new Cell(blok_ii.k_r203);
                usaha.Cells[index, 22] = new Cell(blok_ii.k_r204);
                usaha.Cells[index, 23] = new Cell(blok_ii.k_r205k2);
                usaha.Cells[index, 24] = new Cell(blok_ii.k_r205k3);
                usaha.Cells[index, 25] = new Cell(blok_ii.k_r206k2);
                usaha.Cells[index, 26] = new Cell(blok_ii.k_r206k3);
                usaha.Cells[index, 27] = new Cell(blok_ii.k_r207k2);
                usaha.Cells[index, 28] = new Cell(blok_ii.k_r207k3);
                usaha.Cells[index, 29] = new Cell(blok_ii.k_r208k2);
                usaha.Cells[index, 30] = new Cell(blok_ii.k_r208k3);
                usaha.Cells[index, 31] = new Cell(blok_iii.k_r301J_k6);
                usaha.Cells[index, 32] = new Cell(blok_iii.k_r301J_k9);
                usaha.Cells[index, 33] = new Cell(blok_iii.k_r301K_k6);
                usaha.Cells[index, 34] = new Cell(blok_iii.k_r301K_k9);
                usaha.Cells[index, 35] = new Cell(blok_iii.k_r302_k6);
                usaha.Cells[index, 36] = new Cell(blok_iii.k_r302_k9);
                usaha.Cells[index, 37] = new Cell(blok_iii.k_r303_k6);
                usaha.Cells[index, 38] = new Cell(blok_iii.k_r303_k9);
                usaha.Cells[index, 39] = new Cell(blok_iii.k_r304_k6);
                usaha.Cells[index, 40] = new Cell(blok_iii.k_r304_k9);

                branganng.Cells[index_r301_barang, 0] = new Cell(blok_i.k_r101);
                branganng.Cells[index_r301_barang, 1] = new Cell(blok_i.k_r102);
                branganng.Cells[index_r301_barang, 2] = new Cell(blok_i.k_r103);
                branganng.Cells[index_r301_barang, 3] = new Cell(blok_i.k_r104);
                branganng.Cells[index_r301_barang, 4] = new Cell(blok_i.k_r105);
                branganng.Cells[index_r301_barang, 5] = new Cell(blok_i.k_r106);
                branganng.Cells[index_r301_barang, 6] = new Cell(blok_i.k_r107);
                branganng.Cells[index_r301_barang, 7] = new Cell(blok_i.k_r108);
                branganng.Cells[index_r301_barang, 8] = new Cell(blok_i.k_r109);
                branganng.Cells[index_r301_barang, 9] = new Cell("r301k1");
                branganng.Cells[index_r301_barang, 10] = new Cell("r301k2");
                branganng.Cells[index_r301_barang, 11] = new Cell("r301k3");
                branganng.Cells[index_r301_barang, 12] = new Cell(blok_iii_301.k_r301k4);
                branganng.Cells[index_r301_barang, 13] = new Cell(blok_iii_301.k_r301k5);
                branganng.Cells[index_r301_barang, 14] = new Cell(blok_iii_301.k_r301k6);
                branganng.Cells[index_r301_barang, 15] = new Cell(blok_iii_301.k_r301k7);
                branganng.Cells[index_r301_barang, 16] = new Cell(blok_iii_301.k_r301k8);
                branganng.Cells[index_r301_barang, 17] = new Cell(blok_iii_301.k_r301k9);
                branganng.Cells[index_r301_barang, 18] = new Cell(blok_iii_301.k_r301k10);
                branganng.Cells[index_r301_barang, 19] = new Cell(blok_iii_301.k_r301catatan);
                branganng.Cells[index_r301_barang, 20] = new Cell(blok_i.k_triwulan);

                index = index + 1;
                index_r301_barang = index_r301_barang + 1;


                foreach (Dokumen itemDok in list_dokumen)
                {
                    if (itemDok.Blok_i.Error.Data.Equals(0))
                    {
                        usaha.Cells[index, 0] = new Cell(blok_i.k_r101);
                        usaha.Cells[index, 1] = new Cell(blok_i.k_r102);
                        usaha.Cells[index, 2] = new Cell(blok_i.k_r103);
                        usaha.Cells[index, 3] = new Cell(blok_i.k_r104);
                        usaha.Cells[index, 4] = new Cell(blok_i.k_r105);
                        usaha.Cells[index, 5] = new Cell(blok_i.k_r106);
                        usaha.Cells[index, 6] = new Cell(blok_i.k_r107);
                        usaha.Cells[index, 7] = new Cell(blok_i.k_r108);
                        usaha.Cells[index, 8] = new Cell(blok_i.k_r109);
                        usaha.Cells[index, 9] = new Cell(blok_i.k_r110);
                        usaha.Cells[index, 10] = new Cell(blok_i.k_r111);
                        usaha.Cells[index, 11] = new Cell(blok_i.k_r112);
                        usaha.Cells[index, 12] = new Cell(blok_i.k_r113);
                        usaha.Cells[index, 13] = new Cell(blok_i.k_r114);
                        usaha.Cells[index, 14] = new Cell(blok_i.k_r115);
                        usaha.Cells[index, 15] = new Cell(blok_i.k_r116);
                        usaha.Cells[index, 16] = new Cell(blok_i.k_triwulan);
                        usaha.Cells[index, 17] = new Cell("Belum");
                    }
                    else
                    {
                        usaha.Cells[index, 0] = new Cell(itemDok.Blok_i.R101._Data);
                        usaha.Cells[index, 1] = new Cell(itemDok.Blok_i.R102._Data);
                        usaha.Cells[index, 2] = new Cell(itemDok.Blok_i.R103._Data);
                        usaha.Cells[index, 3] = new Cell(itemDok.Blok_i.R104._Data);
                        usaha.Cells[index, 4] = new Cell(itemDok.Blok_i.R105._Data);
                        usaha.Cells[index, 5] = new Cell(itemDok.Blok_i.R106._Data);
                        usaha.Cells[index, 6] = new Cell(itemDok.Blok_i.R107._Data);
                        usaha.Cells[index, 7] = new Cell(itemDok.Blok_i.R108._Data);
                        usaha.Cells[index, 8] = new Cell(itemDok.Blok_i.R109._Data);
                        usaha.Cells[index, 9] = new Cell(itemDok.Blok_i.R110._Data);
                        usaha.Cells[index, 10] = new Cell(itemDok.Blok_i.R111._Data);
                        usaha.Cells[index, 11] = new Cell(itemDok.Blok_i.R112._Data);
                        usaha.Cells[index, 12] = new Cell(itemDok.Blok_i.R113._Data);
                        usaha.Cells[index, 13] = new Cell(itemDok.Blok_i.R114._Data);
                        usaha.Cells[index, 14] = new Cell(itemDok.Blok_i.R115._Data);
                        usaha.Cells[index, 15] = new Cell(itemDok.Blok_i.R116._Data);
                        usaha.Cells[index, 16] = new Cell("Triwulan " + itemDok.Blok_i.Triwulan._Data);
                        if (itemDok.Blok_i.Error.Data.Equals("1"))
                        {
                            usaha.Cells[index, 17] = new Cell("Clean");
                        }
                        else if (itemDok.Blok_i.Error.Data.Equals("2"))
                        {
                            usaha.Cells[index, 17] = new Cell("Error");
                        }

                        usaha.Cells[index, 18] = new Cell(itemDok.Blok_ii.R201a._Data);
                        usaha.Cells[index, 19] = new Cell(itemDok.Blok_ii.R201b._Data);
                        usaha.Cells[index, 20] = new Cell(itemDok.Blok_ii.R202._Data);
                        usaha.Cells[index, 21] = new Cell(itemDok.Blok_ii.R203._Data);
                        usaha.Cells[index, 22] = new Cell(itemDok.Blok_ii.R204._Data);
                        usaha.Cells[index, 23] = new Cell(itemDok.Blok_ii.R205k2._Data);
                        usaha.Cells[index, 24] = new Cell(itemDok.Blok_ii.R205k3._Data);
                        if (!itemDok.Blok_ii.R206k2_tl.Equals("") && !itemDok.Blok_ii.R206k2_bl.Equals("") && !itemDok.Blok_ii.R206k2_tahun.Equals(""))
                        {
                            usaha.Cells[index, 25] = new Cell(itemDok.Blok_ii.R206k2_tl + "/" + itemDok.Blok_ii.R206k2_bl + "/" + itemDok.Blok_ii.R206k2_tahun);
                        }
                        else
                        {
                            usaha.Cells[index, 25] = new Cell("");
                        }

                        if (!itemDok.Blok_ii.R206k3_tl.Equals("") && !itemDok.Blok_ii.R206k3_tl.Equals("") && !itemDok.Blok_ii.R206k3_tl.Equals(""))
                        {
                            usaha.Cells[index, 26] = new Cell(itemDok.Blok_ii.R206k3_tl + "/" + itemDok.Blok_ii.R206k3_bl + "/" + itemDok.Blok_ii.R206k3_tahun);
                        }
                        else
                        {
                            usaha.Cells[index, 26] = new Cell("");
                        }


                        usaha.Cells[index, 27] = new Cell(itemDok.Blok_ii.R207k2._Data);
                        usaha.Cells[index, 28] = new Cell(itemDok.Blok_ii.R207k3._Data);
                        usaha.Cells[index, 29] = new Cell(itemDok.Blok_ii.R208k2._Data);
                        usaha.Cells[index, 30] = new Cell(itemDok.Blok_ii.R208k3._Data); ;
                        usaha.Cells[index, 31] = new Cell(itemDok.Blok_iii.R301J_k6._Data);
                        usaha.Cells[index, 32] = new Cell(itemDok.Blok_iii.R301J_k9._Data);
                        usaha.Cells[index, 33] = new Cell(itemDok.Blok_iii.R301K_k6._Data);
                        usaha.Cells[index, 34] = new Cell(itemDok.Blok_iii.R301K_k9._Data);
                        usaha.Cells[index, 35] = new Cell(itemDok.Blok_iii.R302_k6._Data);
                        usaha.Cells[index, 36] = new Cell(itemDok.Blok_iii.R302_k9._Data);
                        usaha.Cells[index, 37] = new Cell(itemDok.Blok_iii.R303_k6._Data);
                        usaha.Cells[index, 38] = new Cell(itemDok.Blok_iii.R303_k9._Data);
                        usaha.Cells[index, 39] = new Cell(itemDok.Blok_iii.R304_k6._Data);
                        usaha.Cells[index, 40] = new Cell(itemDok.Blok_iii.R304_k9._Data);

                        foreach (blok_iii_301 item301 in itemDok.List_blok_iii_301)
                        {
                            branganng.Cells[index_r301_barang, 0] = new Cell(itemDok.Blok_i.R101._Data);
                            branganng.Cells[index_r301_barang, 1] = new Cell(itemDok.Blok_i.R102._Data);
                            branganng.Cells[index_r301_barang, 2] = new Cell(itemDok.Blok_i.R103._Data);
                            branganng.Cells[index_r301_barang, 3] = new Cell(itemDok.Blok_i.R104._Data);
                            branganng.Cells[index_r301_barang, 4] = new Cell(itemDok.Blok_i.R105._Data);
                            branganng.Cells[index_r301_barang, 5] = new Cell(itemDok.Blok_i.R106._Data);
                            branganng.Cells[index_r301_barang, 6] = new Cell(itemDok.Blok_i.R107._Data);
                            branganng.Cells[index_r301_barang, 7] = new Cell(itemDok.Blok_i.R108._Data);
                            branganng.Cells[index_r301_barang, 8] = new Cell(itemDok.Blok_i.R109._Data);
                            foreach (barang itemBarang in barangs)
                            {
                                if (item301.Id_barang.Data.Equals(itemBarang.Id.Data))
                                {
                                    branganng.Cells[index_r301_barang, 9] = new Cell(itemBarang.Nama.Data);
                                    branganng.Cells[index_r301_barang, 10] = new Cell(itemBarang.Kbli.Data);
                                    branganng.Cells[index_r301_barang, 11] = new Cell(itemBarang.Satuan.Data);
                                }
                            }

                            branganng.Cells[index_r301_barang, 12] = new Cell(item301.R301k4._Data);
                            branganng.Cells[index_r301_barang, 13] = new Cell(item301.R301k5._Data);
                            branganng.Cells[index_r301_barang, 14] = new Cell(item301.R301k6._Data);
                            branganng.Cells[index_r301_barang, 15] = new Cell(item301.R301k7._Data);
                            branganng.Cells[index_r301_barang, 16] = new Cell(item301.R301k8._Data);
                            branganng.Cells[index_r301_barang, 17] = new Cell(item301.R301k9._Data);
                            branganng.Cells[index_r301_barang, 18] = new Cell(item301.R301k10._Data);
                            branganng.Cells[index_r301_barang, 19] = new Cell(item301.R301catatan._Data);
                            branganng.Cells[index_r301_barang, 20] = new Cell("Triwulan " + itemDok.Blok_i.Triwulan._Data);
                            index_r301_barang = index_r301_barang + 1;
                        }
                    }
                    progres.Value = index;
                    index = index + 1;
                }
                workbook.Worksheets.Add(usaha);
                workbook.Worksheets.Add(branganng);
                workbook.Save(filepath.Text);
                System.Windows.Forms.MessageBox.Show("Berhasil Export Data !", "informasi"
                                    , MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch(Exception ex)
            {
                Console.WriteLine("Gagal Export");
                Console.WriteLine("Gagal Export : "+ex.Message);
                Console.WriteLine("Gagal Export : "+ex.StackTrace);
                System.Windows.Forms.MessageBox.Show("Gagal Export Data !", "informasi"
                              , MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            progres.Visibility = Visibility.Hidden;
        }

        private void cancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
