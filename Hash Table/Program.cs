using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Text;
using System.Xml;

namespace Proje5
{
    class TProgram
    {
        static void Main(string[] args)
        {
            int size;
            Console.WriteLine("Hash tablo boyu : "); size = int.Parse(Console.ReadLine());
            Tablo htablo = new Tablo(size);
            int numara;
            string isim;
            int secim = menu();
            while (secim != 0)
            {
                switch (secim)
                {
                    case 1:
                        Console.WriteLine("numara : "); numara = int.Parse(Console.ReadLine());
                        Console.WriteLine("isim : "); isim = Console.ReadLine();
                        htablo.ekle(numara, isim);
                        break;
                    case 2:
                        Console.WriteLine("silinecek kişinin numarası : "); numara = int.Parse(Console.ReadLine());
                        htablo.sil(numara);
                        break;

                    case 3: htablo.yazdır(); break;
                    case 4: htablo.adetBul();break;
                    case 5: Console.WriteLine("aranan kişinin numarası : "); numara = int.Parse(Console.ReadLine());
                    htablo.kişibul(numara);
                    break;
                    case 0: break;
                    default:
                        Console.WriteLine("Hatalı seçim !");
                        break;
                }
                secim = menu();

            }
            Console.WriteLine("Çıkış yapılıyor...");
        }
        private static int menu()
        {
            int secim;
            Console.WriteLine("1-Ekle");
            Console.WriteLine("2-Sil");
            Console.WriteLine("3-Yazdır");
            Console.WriteLine("4-Kişi sayısı");
            Console.WriteLine("5-Kişi bul");
            Console.WriteLine("0-Çıkış");
            Console.WriteLine("Seçiminiz : "); secim = int.Parse(Console.ReadLine());
            return secim;

        }
    }
}
