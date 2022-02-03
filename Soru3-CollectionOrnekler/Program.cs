using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Soru3_CollectionOrnekler
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Bir sayı listesi tanımlayınız ve içine rastgele 6 dayı ekleyip ekrana yan yana yazdırınız.
            Random rand = new Random();

            List<int> list1 = new List<int>();

            for (int i = 0; i < 6; i++)
            {
                list1.Add(rand.Next(100));
            }
            ListeYazdir(list1);

            //Listenin elemanlarını küçükten büyüğe sıralayıp ekrana yazdırınız.

            list1.Sort();
            ListeYazdir(list1);

            //Listenin elemanlarını küçükten büyüğe sıralayınız.

            list1.Reverse();
            ListeYazdir(list1);

            //İçerisinde  Ankara,Istanbul,Izmir,Bursa,Malatya,Niğde,Kocaeli,Antalya,Manisa şehirlerinin barındıran bir liste tanımlayınız.Kullanıcıdan aldığı şehir adını isteyip eğer listede bulunuyorsa aradığınız listede bulunmaktadır,bulunmuyorsa bulunmadığı mesajını kullanıcıya veriniz.

            List<string> list2 = new List<string>() { "ankara", "istanbul", "izmir", "bursa", "malatya", "niğde", "kocaeli", "antalya", "manisa" };
            Console.WriteLine();
            ListeYazdir(list2);
            //foreach (string s in list2)
            //    Console.WriteLine(s);

            Console.WriteLine();

            Console.Write("Hangi şehir ismini arıyorsunuz?:");

            string arananSehir = Console.ReadLine();
            arananSehir = arananSehir.ToLower().Trim();

            if (list2.Contains(arananSehir))

                Console.WriteLine($"Aradığınız {arananSehir} kelimesi, liste içerisinde {list2.IndexOf(arananSehir)}. indeksinde bulunmaktadır.");
            else
                Console.WriteLine($"Aradığınız {arananSehir} kelimesi, liste içerisinde bulunmamaktadır.");

            list2.Sort();
            ListeYazdir(list2);

            list2.Add("izmir");
            ListeYazdir(list2);

            Console.WriteLine(list2.IndexOf("izmir")); //ilk izmir indeksi 
            Console.WriteLine(list2.LastIndexOf("izmir")); //soon izmir indeksi 

            //List<int> sayiListesi = new List<int> { 100, 200, 333, 444, 555 };

            Console.ReadKey();
        }
        private static void ListeYazdir<T>(List<T> sayilar) //Generic Method
        {
            Console.WriteLine("****************");
            foreach (T item in sayilar)
            {
                Console.WriteLine(item);
            }
        }
    }
}
