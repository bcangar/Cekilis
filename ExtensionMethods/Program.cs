using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExtensionMethods
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //extension method örnekleri
            string sayi = 10.ToString();
            string buyukHarf = "adadasdasd".ToUpper();
            bool sonuc = CiftMi(2); //Aşağıda tanımlanan Method
            bool sonuc2 = BenimKutuphanem.CiftMi(2); //Static Method
            bool sonuc3 = 2.CiftMi(); //Extension Method
            int yasim = new DateTime(1998, 7, 27).YasHesapla();
            int buyuk = 10.BuyuguGetir(15);
            int sonuc4 = 2.UsAlma(4);
            Console.WriteLine(sonuc3);
            Console.WriteLine(yasim);
            Console.WriteLine(buyuk);
            Console.WriteLine(sonuc4);

            Console.ReadKey();
        }
        static int UsAlma(int taban, int us)
        {
            if (us == 0)
                return 1;
            return UsAlma(taban, --us) * taban;
        }
        static int BuyuguGetir(int sayi1, int sayi2)
        {
            return sayi1 >= sayi2 ? sayi1 : sayi2;
        }
        static bool CiftMi(int sayi)
        {
            return sayi % 2 == 0;
        }
        static int YasHesapla(DateTime dateTime)
        {
            TimeSpan ts = DateTime.Now - dateTime;
            return (int)ts.TotalDays / 365;



        }
    }
}
