using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExtensionMethods
{
    public static class BenimKutuphanem
    {
        public static bool CiftMi(this int sayi)
        {
            return sayi % 2 == 0;
        }
        public static int YasHesapla(this DateTime dogumTarihi)
        {
            TimeSpan ts = DateTime.Now - dogumTarihi;
            return (int)ts.TotalDays / 365;
        }

        public static int BuyuguGetir(this int sayi1, int sayi2)
        {
            return sayi1 >= sayi2 ? sayi1 : sayi2;
        }

        public static int UsAlma(this int taban, int us)
        {
            if (us == 0)
                return 1;
            return UsAlma(taban, --us) * taban;
        }


    }
}
