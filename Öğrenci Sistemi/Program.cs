using System;
using System.ComponentModel.Design;
using System.Security.Cryptography;
using System.Security.Principal;
namespace Proje4
{
    class Program
    {
        static void Main(string[] args)
        {
            Liste ogrenciler = new Liste();
            int numara;
            string ad, soyad, dersAdi;
            float vize, final, ortalama;
            int secim = menu();
            while (secim != 0)
            {
                switch (secim)
                {
                    case 1:
                        Console.Write("numara : "); numara = int.Parse(Console.ReadLine());
                        Console.Write("İsim : "); ad = Console.ReadLine();
                        Console.Write("Soyisim : "); soyad = Console.ReadLine();
                        Console.Write("Ders Adı : "); dersAdi = Console.ReadLine();
                        Console.Write("Vize : "); vize = int.Parse(Console.ReadLine());
                        Console.Write("Final : "); final = int.Parse(Console.ReadLine());
                        ogrenciler.ekle(numara, ad, soyad, dersAdi, vize, final);
                        break;

                    case 2:
                        Console.Write("numara : "); numara = int.Parse(Console.ReadLine());
                        ogrenciler.sil(numara);
                        break;

                    case 3: ogrenciler.yazdır(); break;
                    case 4:ogrenciler.enBaşarılıÖğrenci();
                    break;

                    case 0:break;

                    default:
                    Console.WriteLine("Hatalı seçim yaptınız !");
                        break;
                }
                secim=menu();
            }
            Console.WriteLine("Program kapatılıyor...");
        }
        private static int menu()
        {
            int secim;
            Console.WriteLine("\n1-Öğrenci ekle");
            Console.WriteLine("2-Öğrenci sil");
            Console.WriteLine("3-Öğrencileri yazdır");
            Console.WriteLine("4-En başarılı öğrenciyi göster");
            Console.WriteLine("0-Programı kapat");
            Console.WriteLine("Seçiminiz : ");
            secim = int.Parse(Console.ReadLine());
            return secim;
        }
    }
    class Ögrenci //Node
    {
        public int numara;
        public string ad, soyad, dersAdi;
        public float vize, final, ortalama;
        public string durum;

        public Ögrenci next;

        public Ögrenci(int n, string a, string s, string d, float v, float f)
        {
            this.numara = n;
            this.ad = a;
            this.soyad = s;
            this.dersAdi = d;
            this.vize = v;
            this.final = f;

            this.ortalama = this.vize * 40 / 100 + this.final * 60 / 100;
            this.durum = this.ortalama < 50 ? "Kaldı" : "Geçti";
            this.next = null;
        }
    }
    class Liste
    {
        Ögrenci head;
        public Liste()
        {
            head = null;
        }
        public void ekle(int n, string a, string s, string d, float v, float f)
        {
            Ögrenci ogr = new Ögrenci(n, a, s, d, v, f);
            if (head == null)
            {
                head = ogr;
                Console.WriteLine(n + "numaralı öğrenci listeye eklendi.");
            }
            else
            {
                ogr.next = head;
                head = ogr;
                Console.WriteLine(n + "numaralı öğrenci eklendi.");
            }
        }
        public void sil(int numara)
        {
            bool sonuc = false;
            if (head == null)
            {
                sonuc = true;
                Console.WriteLine("Listede kayıtlı öğrenci yok !");
            }
            else if (head.next == null && head.numara == numara)
            {
                sonuc = true;
                head = head.next;
                Console.WriteLine(numara + "numaralı öğrenci silindi , listede hiç öğrenci kalmadı.");
            }
            else if (head.next != null && head.numara == numara)
            {
                sonuc = true;
                head = null;
                Console.WriteLine(numara + "numaralı öğrenci silindi , listede hiç öğrenci kalmadı.");
            }
            else
            {
                Ögrenci temp = head;
                Ögrenci temp2 = temp;

                while (temp.next != null)
                {
                    if (numara == temp.numara)
                    {
                        sonuc = true;
                        temp2.next = temp.next;
                        Console.WriteLine(numara + "numaralı öğrenci silindi.");

                    }
                    temp2 = temp;
                    temp = temp.next;
                }
                if (numara == temp.numara)
                {
                    sonuc = true;
                    temp2.next = null;
                    Console.WriteLine(numara + "numaralı öğrenci silindi.");
                }

            }
            if (sonuc == false)
            {
                Console.WriteLine(numara + "numaralı öğrenciye ait kayıt bulunamamdı.");
            }
        }
        public void yazdır()
        {
            if (head == null)
            {
                Console.WriteLine("Listede kayıtlı öğrenci yok.");
            }
            else
            {
                Ögrenci temp = head;
                Console.WriteLine("Numara\tAd\tSayad\tDersAdı\tOrtalama\tDurum ");

                while (temp.next != null)
                {
                    Console.WriteLine(temp.numara + "\t" + temp.ad + "\t" + temp.soyad + "\t" + temp.dersAdi + "\t" + temp.ortalama + "\t" + temp.durum + "\t");
                    temp = temp.next;
                }
                Console.WriteLine(temp.numara + "\t" + temp.ad + "\t" + temp.soyad + "\t" + temp.dersAdi + "\t" + temp.ortalama + "\t" + temp.durum + "\t");
            }
        }
        public void enBaşarılıÖğrenci()
        {
            if (head == null)
            {
                Console.WriteLine("Listede kayıtlı öğrenci yok.");
            }
            else
            {
                Ögrenci temp = head;
                Ögrenci yuksekOgr=head;
                float enYuksekOrtalama=head.ortalama;
               

                while (temp.next != null)
                {
                    if (enYuksekOrtalama<temp.ortalama)
                    {
                        enYuksekOrtalama=temp.ortalama;
                        yuksekOgr=temp;
                    }
                    temp = temp.next;
                }
                if (enYuksekOrtalama<temp.ortalama)
                    {
                        enYuksekOrtalama=temp.ortalama;
                        yuksekOgr=temp;
                    }
                Console.WriteLine("En yüksek ortalamalı öğrenci bilgileri : ");
                Console.WriteLine("Numara\tAd\tSayad\tDersAdı\tOrtalama\tDurum ");
                Console.WriteLine(yuksekOgr.numara + "\t" + yuksekOgr.ad + "\t" + yuksekOgr.soyad + "\t" + yuksekOgr.dersAdi + "\t" + yuksekOgr.ortalama + "\t" + yuksekOgr.durum + "\t");
            }
        }

    }
}