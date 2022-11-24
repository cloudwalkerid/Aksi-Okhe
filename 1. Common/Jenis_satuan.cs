using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Akhi_Okhee._1._Common
{
    public class Jenis_satuan
    {
        private string kode;
        private string nama;
        private string kode_standar;
        private Dictionary<string,Satuan> satuans;

        public string Kode { get => kode; set => kode = value; }
        public string Nama { get => nama; set => nama = value; }
        public Dictionary<string, Satuan> Satuans { get => satuans; set => satuans = value; }
        public string Kode_standar { get => kode_standar; set => kode_standar = value; }

        public Jenis_satuan(string _kode, string _nama)
        {
            kode = _kode;
            nama = _nama;
            satuans = new Dictionary<string, Satuan>();
        }

        public static Dictionary<string, Jenis_satuan> getAllSatuanStandar()
        {
            Dictionary<string, Jenis_satuan> returnValue = new Dictionary<string, Jenis_satuan>();
            //1: berat, 2:luas, 3:Panjang, 4: Lainnya
            Jenis_satuan berat_satuan = new Jenis_satuan("01", "Berat");
            berat_satuan.Satuans.Add("ton", new Satuan("ton", "Ton", 1000000));
            berat_satuan.Satuans.Add("kw", new Satuan("kw", "Kwintal", 100000));
            berat_satuan.Satuans.Add("kg", new Satuan("kg", "Kilogram", 1000));
            berat_satuan.Satuans.Add("hg", new Satuan("hg", "Hektogram", 100));
            berat_satuan.Satuans.Add("dag", new Satuan("dag", "Dekagram", 10));
            berat_satuan.Satuans.Add("g", new Satuan("g", "Gram", 1));
            berat_satuan.Satuans.Add("dg", new Satuan("dg", "Desigram", 0.1));
            berat_satuan.Satuans.Add("cg", new Satuan("cg", "Miligram", 0.01));
            berat_satuan.Satuans.Add("mg", new Satuan("mg", "Miligram", 0.001));
            berat_satuan.Satuans.Add("ons", new Satuan("ons", "Ons", 100));
            berat_satuan.Satuans.Add("pon", new Satuan("pon", "Pon", 500));
            returnValue.Add("01", berat_satuan);

            Jenis_satuan luas_satuan = new Jenis_satuan("02", "Luas");
            luas_satuan.Satuans.Add("km2", new Satuan("km2", "Kilometer Persegi", 1000000));
            luas_satuan.Satuans.Add("hm2", new Satuan("hm2", "Hektometer Persegi", 10000));
            luas_satuan.Satuans.Add("dam2", new Satuan("dam2", "Dekameter Persegi", 100));
            luas_satuan.Satuans.Add("m2", new Satuan("m2", "Meter Persegi", 1));
            luas_satuan.Satuans.Add("dm2", new Satuan("dm2", "Desimeter Persegi", 1/100));
            luas_satuan.Satuans.Add("cm2", new Satuan("cm2", "Milimeter Persegi", 1/10000));
            luas_satuan.Satuans.Add("mm2", new Satuan("mm2", "Milimeter Persegi", 1/1000000));
            luas_satuan.Satuans.Add("ha", new Satuan("ha2", "Hektar Persegi", 10000));
            returnValue.Add("02", luas_satuan);

            Jenis_satuan panjang_satuan = new Jenis_satuan("03", "Panjang");
            panjang_satuan.Satuans.Add("km", new Satuan("km", "Kilometer", 1000));
            panjang_satuan.Satuans.Add("hm", new Satuan("hm", "Hektometer", 100));
            panjang_satuan.Satuans.Add("dam", new Satuan("dam", "Dekameter", 10));
            panjang_satuan.Satuans.Add("m", new Satuan("m", "Meter", 1));
            panjang_satuan.Satuans.Add("dm", new Satuan("dm", "Desimeter", 0.1));
            panjang_satuan.Satuans.Add("cm", new Satuan("cm", "Milimeter", 0.01));
            panjang_satuan.Satuans.Add("mm", new Satuan("mm", "Milimeter", 0.001));
            returnValue.Add("03", panjang_satuan);
            return returnValue;
        }
    }
}
