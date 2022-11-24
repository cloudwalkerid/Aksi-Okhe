using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Akhi_Okhee._1._Common
{
    public class variable<T> : INotifyPropertyChanged
    {
        private string nama;
        private int? panjang; //panjang string
        private Boolean _null;
        private T data;
        private string _data;
        private double? min = null; //min int dan datetime
        private double? max = null; //min int dan datetime
        private barang barang;
        private List<string> err_metadata;
        private List<string> err_konsistensi;
        private Boolean is_error_metadata = false;
        private Boolean is_error_konsistensi = false;
        private blok _blok;

        public string Nama { get => nama; set => nama = value.ToUpper(); }
        public int? Panjang { get => panjang; set => panjang = value; }
        public bool Null { get => _null; set => _null = value; }
        public T Data { get => data; 
            set {
                data = value;
                /*Console.WriteLine("Set Variabel " + Nama );*/
                if (EqualityComparer<T>.Default.Equals(value, default(T)))
                {
                    _data = "";
                }
                else
                {
                    _data = value.ToString();
                    /*Console.WriteLine("Set Variabel " + Nama + " = " + value.ToString());*/
                }
                if (Blok != null)
                {
                    Blok.changeValue(this);
                }
                RaisePropertyChanged(Nama);
            } 
        }
        public string _Data { get => _data;
            set
            {
                //Console.WriteLine("Perubahan " + Nama + " = " + value);
                _data = value;
                if (value.ToString().Equals(""))
                {
                    Data = default(T);
                }
                else if (value == null){
                    Data = default(T);
                }
                else
                {
                    Data = (T)convertValueFromString(value);
                   
                }
                RaisePropertyChanged(Nama);
            }
        }
        public double? Min { get => min; set => min = value; }
        public double? Max { get => max; set => max = value; }
        public barang Barang { get => barang; set => barang = value; }
        public List<string> Err_metadata { get => err_metadata; set => err_metadata = value; }
        public List<string> Err_konsistensi { get => err_konsistensi; set => err_konsistensi = value; }
        public blok Blok { get => _blok; set => _blok = value; }
        public bool Is_error_metadata { get => is_error_metadata; set => is_error_metadata = value; }
        public bool Is_error_konsistensi { get => is_error_konsistensi; set => is_error_konsistensi = value; }

        public variable(string nama, Boolean is_null, int? panjang=null, long? min=null, long? max=null)
        { //string tapi ada min maxnya juga
            Nama = nama;
            Null = is_null;
            Panjang = panjang;
            Min = min;
            Max = max;
            Blok = _blok;
            Data = default(T);
            err_konsistensi = new List<string>();
            err_metadata = new List<string>();
        }
      
       
        public override string ToString()
        {
            return nama;
        }
        public Type getType()
        {
            if (typeof(T) == typeof(string) && (min != null || max != null))
            {
                return typeof(int);
            }
            return typeof(T);
        }
        public List<string> getErrorMetadata()
        {
            List<string> returnValue = new List<string>();
            if (typeof(T) == typeof(string))
            {
                if (!Null)
                {
                    if (Data == null || Data.ToString().Length == 0)
                    {
                        Console.WriteLine("1.........");
                        returnValue.Add("Isian " + nama + " tidak boleh kosong");
                    }
                }
                if (!EqualityComparer<T>.Default.Equals(Data, default(T)))
                {
                    if (Panjang!=null && Data.ToString().Length > Panjang)
                    {
                        returnValue.Add("Isian " + nama + " terlalu panjang dari format yang disediakan");
                    }
                    try
                    {
                        if (min != null && max != null)
                        {
                            if (Convert.ToInt32(Data) < min || Convert.ToInt32(Data) > max)
                            {
                                returnValue.Add("Isian " + nama + " tidak didalam range yang ditentukan");
                            }
                        }
                        else if (min != null && max == null)
                        {
                            if (Convert.ToInt32(Data) < min)
                            {
                                returnValue.Add("Isian " + nama + " tidak didalam range yang ditentukan");
                            }
                        }
                        else if (min == null && max != null)
                        {
                            if (Convert.ToInt32(Data) > max)
                            {
                                returnValue.Add("Isian " + nama + " tidak didalam range yang ditentukan");
                            }
                        }
                    }
                    catch(Exception ex)
                    {
                        returnValue.Add("Isian " + nama + " bukan berisi angka");
                    }
                }
            }
            else if (typeof(T) == typeof(long?))
            {
                if (!Null)
                {
                    if (Data == null)
                    {
                        returnValue.Add("Isian " + nama + " tidak boleh kosong");
                    }

                }
                if (Data != null)
                {
                    if (min != null && max != null)
                    {
                        if (Convert.ToInt64(Data) < min || Convert.ToInt64(Data) > max)
                        {
                            returnValue.Add("Isian " + nama + " tidak didalam range yang ditentukan");
                        }
                    }
                    else if (min != null && max == null)
                    {
                        if (Convert.ToInt64(Data) < min)
                        {
                            returnValue.Add("Isian " + nama + " tidak didalam range yang ditentukan");
                        }
                    }
                    else if (min == null && max != null)
                    {
                        if (Convert.ToInt64(Data) > max)
                        {
                            returnValue.Add("Isian " + nama + " tidak didalam range yang ditentukan");
                        }
                    }
                }
            }
            else if (typeof(T) == typeof(double?))
            {
                if (!Null)
                {
                    if (Data == null)
                    {
                        returnValue.Add("Isian " + nama + " tidak boleh kosong");
                    }

                }
                if (Data != null)
                {
                    if (min != null && max != null)
                    {
                        if (Convert.ToDouble(Data) < min || Convert.ToDouble(Data) > max)
                        {
                            returnValue.Add("Isian " + nama + " tidak didalam range yang ditentukan");
                        }
                    }
                    else if (min != null && max == null)
                    {
                        if (Convert.ToDouble(Data) < min)
                        {
                            returnValue.Add("Isian " + nama + " tidak didalam range yang ditentukan");
                        }
                    }
                    else if (min == null && max != null)
                    {
                        if (Convert.ToDouble(Data) > max)
                        {
                            returnValue.Add("Isian " + nama + " tidak didalam range yang ditentukan");
                        }
                    }
                }
            }
            else if (typeof(T) == typeof(DateTime?))
            {
                if (!Null)
                {
                    if (Data == null)
                    {
                        returnValue.Add("Isian " + nama + " tidak boleh kosong");
                    }
                }
                if (Data!= null)
                {
                    if (min != null && max != null)
                    {
                        if (Convert.ToDateTime(Data).Month < min || Convert.ToDateTime(Data).Month > max)
                        {
                            returnValue.Add("Isian tanggal " + nama + " tidak didalam range yang ditentukan");
                        }
                    }
                    else if (min != null && max == null)
                    {
                        if (Convert.ToDateTime(Data).Month < min)
                        {
                            returnValue.Add("Isian tanggal " + nama + " tidak didalam range yang ditentukan");
                        }
                    }
                    else if (min == null && max != null)
                    {
                        if (Convert.ToDateTime(Data).Month > max)
                        {
                            returnValue.Add("Isian tanggal " + nama + " tidak didalam range yang ditentukan");
                        }
                    }
                }
            }
            Err_metadata = returnValue;
            if (returnValue.Count > 0)
            {
                Is_error_metadata = true;
            }
            else
            {
                Is_error_metadata = false;
            }
            return returnValue;
        }   

        public Boolean isError()
        {
            getErrorMetadata();
            Is_error_konsistensi = false;

            if (err_konsistensi.Count > 0)
            {
                Is_error_konsistensi = true;
            }
            Console.WriteLine("Error metdad "+Nama+": " + err_metadata.Count+"|"+err_konsistensi.Count);
            return Is_error_konsistensi || Is_error_metadata;
        }

        public List<String> getAllError()
        {
            
            List<String> returnValue = new List<string>();
            returnValue.AddRange(getErrorMetadata());
            if (Err_konsistensi != null)
            {
                returnValue.AddRange(Err_konsistensi);
            }
            return returnValue;
        }
       
        private object convertValueFromString(string value)
        {
            if (typeof(T) == typeof(string)) 
            { 
                return value;
            }
            else if (typeof(T) == typeof(long?))
            {
                return long.Parse(value);
            }else if (typeof(T) == typeof(double?))
            {
                return double.Parse(value);
            } 
            else
            {
                return Convert.ChangeType(value, typeof(T));
            }
        }
        void RaisePropertyChanged(string prop)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
        public event PropertyChangedEventHandler PropertyChanged;
    }
}
