﻿using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Globalization;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TransactionLog
{
    static class Conversiones
    {
        public static String DarleVuelta(string Hex)
        {
            String converted = "";
            for (int i=Hex.Length-1;i>=0;i-=2)
            {
                converted = converted+Hex.Substring(i-1, 1);
                converted = converted + Hex.Substring(i, 1);
            }
            return converted;
        }
        public static byte[] FromHex(string hex)
        {
            byte[] raw = new byte[hex.Length / 2];
            for (int i = 0; i < raw.Length; i++)
            {
                raw[i] = Convert.ToByte(hex.Substring(i * 2, 2), 16);
            }
            return raw;
        }

        public static int Conversion_a_Int(String Hex)
        {
            int converted = 0;
            converted=int.Parse(DarleVuelta(Hex), System.Globalization.NumberStyles.HexNumber);
            return converted;
        }

        
        public static string Conversion_a_DateTime(String Hex)
        {
            byte[] data=FromHex(DarleVuelta(Hex));
            if (data.Length != 4) throw new ArgumentException();
            return new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc).AddSeconds(
                      BitConverter.ToUInt32(data, 0)).ToString();
        }


        public static Char Conversion_a_Char(String Hex)
        {
            int value = Convert.ToInt32(DarleVuelta(Hex), 16);
            return (Char) value;
        }

        public static String Conversion_a_TinyInt(String Hex)
        {
            byte[] data = FromHex(DarleVuelta(Hex));
            return ((int)data[0]).ToString(CultureInfo.CurrentCulture);
        }

        public static string Conversion_a_Double(String Hex)
        {
            long parsed = long.Parse(DarleVuelta(Hex), NumberStyles.AllowHexSpecifier);
            double d = BitConverter.Int64BitsToDouble(parsed);

            return  d.ToString();
        }

        public static BigInteger Conversion_a_BigInt(String Hex)
        {
            return BigInteger.Parse(DarleVuelta(Hex), NumberStyles.HexNumber);
        }

        
        public static String Conversion_a_String_Varchar(String Hex)
        {
            String value = "";
            String hexvalue = DarleVuelta(Hex);
            while (hexvalue.Length>0)
            {
                value += System.Convert.ToChar(System.Convert.ToUInt32(hexvalue.Substring(0, 2), 16)).ToString();
                hexvalue = hexvalue.Substring(2, hexvalue.Length - 2);
            }
            return value;
        }

        private static Double Conversion_a_Decimal(String Hex)
        {
            String hexNumber = DarleVuelta(Hex).Substring(0,14);
            hexNumber = hexNumber.Replace("x", string.Empty);
            long result = 0;
            long.TryParse(hexNumber, System.Globalization.NumberStyles.HexNumber, null, out result);
            return result;
        }

        public static string Conversion_a_SmallDateTime(byte[] data)
        {
            DateTime returnDate = new DateTime(1900, 1, 1);

            int datePart;
            int timePart;

            timePart = BitConverter.ToUInt16(data, 0);
            datePart = BitConverter.ToUInt16(data, 2);

            returnDate = returnDate.AddDays(datePart).AddMinutes(timePart);

            return returnDate.ToString();
        }

        public static float Conversion_del_Real(String hex)
        {
            byte[] raw = new byte[hex.Length / 2];
            for (int i = 0; i < raw.Length; i++)
            {
                //raw[raw.Length - i - 1] = Convert.ToByte(hex.Substring(i * 2, 2), 16);
                raw[i] = Convert.ToByte(hex.Substring(i * 2, 2), 16);
            }
            float f = BitConverter.ToSingle(raw, 0);
            return f;
        }

        public static List<string> Recorrer(string rowlog,List<Campos> campos)
        {
            List<String> columnas=new List<string>();
            int recorrer = 10;

            

            for (int i = 0; i < campos.Count ;i++ )
            {
                switch (campos.ElementAt(i).Type)
                {
                    case "int":
                        columnas.Add(Conversion_a_Int(rowlog.Substring(recorrer,campos.ElementAt(i).Tamaño)).ToString());
                        recorrer += campos.ElementAt(i).Tamaño;
                        break;
                    case "nchar":
                        columnas.Add(Conversion_a_Char(rowlog.Substring(recorrer,4)).ToString());
                        recorrer += 4;
                        break;
                    case "float":
                        columnas.Add(Conversion_a_Double(rowlog.Substring(recorrer, campos.ElementAt(i).Tamaño)).ToString());
                        recorrer += campos.ElementAt(i).Tamaño;
                        break;
                    case "bigint":
                        columnas.Add(Conversion_a_BigInt(rowlog.Substring(recorrer, campos.ElementAt(i).Tamaño)).ToString());
                        recorrer += campos.ElementAt(i).Tamaño;
                        break;
                    case "money":
                        columnas.Add(Conversion_a_Decimal(rowlog.Substring(recorrer, campos.ElementAt(i).Tamaño)).ToString());
                        recorrer += campos.ElementAt(i).Tamaño;
                        break;
                    case "decimal":
                        columnas.Add(Conversion_a_Decimal(rowlog.Substring(recorrer, campos.ElementAt(i).Tamaño)).ToString());
                        recorrer += campos.ElementAt(i).Tamaño;
                        break;
                    case "real":
                        columnas.Add(Conversion_del_Real(rowlog.Substring(recorrer, campos.ElementAt(i).Tamaño)).ToString());
                        recorrer += campos.ElementAt(i).Tamaño;
                        break;
                    case "tinyint":
                        columnas.Add(Conversion_a_TinyInt(rowlog.Substring(recorrer, campos.ElementAt(i).Tamaño)).ToString());
                        recorrer += campos.ElementAt(i).Tamaño;
                        break;
                }
            }

            recorrer += 6;
            return columnas;
        }
    }

  
}