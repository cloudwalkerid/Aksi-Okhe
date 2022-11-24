using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Akhi_Okhee._1._Common
{
    public class Satuan
    {
        private string simbol;
        private string nama;
        private string nama_lengkap;
        private double konversi;

        public string Simbol { get => simbol;  }
        public string Nama { get => nama;}
        public string Nama_lengkap { get => nama_lengkap; }
        public double Konversi { get => konversi;  }

        public Satuan(string _simbol, string _nama, double _konversi)
        {
            simbol = _simbol;
            nama = _nama;
            konversi = _konversi;
            nama_lengkap = _nama + " (" + _simbol + ")";
        }    
    }
}
