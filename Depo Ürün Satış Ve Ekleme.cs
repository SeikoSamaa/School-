using System;
using System.Collections.Generic;

class Program
{
    class Urun
    {
        public string Adi { get; set; } = string.Empty;
        public double BirimFiyat { get; set; }
        public int Adet { get; set; }
    }

    static void Main()
    {
        List<Urun> depo = new List<Urun>();
        double kullaniciParasi = 5000;

        while (true)
        {
            Console.WriteLine("\nDepo Sistemi Menüsü:");
            Console.WriteLine("1 - Ürün Ekle");
            Console.WriteLine("2 - Ürün Satış");
            Console.WriteLine("3 - Depodaki Ürünleri Görüntüle");
            Console.WriteLine("0 - Çıkış");
            Console.Write("Seçiminiz: ");

            if (!int.TryParse(Console.ReadLine(), out int secim))
            {
                Console.WriteLine("Geçersiz giriş! Lütfen bir sayı girin.");
                continue;
            }

            switch (secim)
            {
                case 1:
                    UrunEkle(depo);
                    break;
                case 2:
                    UrunSatis(depo, ref kullaniciParasi);
                    break;
                case 3:
                    DepoyuGoruntule(depo);
                    break;
                case 0:
                    Console.WriteLine("Programdan çıkılıyor.");
                    return;
                default:
                    Console.WriteLine("Geçersiz seçim. Lütfen tekrar deneyin.");
                    break;
            }
        }
    }

    static void UrunEkle(List<Urun> depo)
    {
        Console.Write("Ürün adı: ");
        string? adi = Console.ReadLine();
        if (string.IsNullOrWhiteSpace(adi))
        {
            Console.WriteLine("Ürün adı boş olamaz.");
            return;
        }

        Console.Write("Birim fiyatı: ");
        if (!double.TryParse(Console.ReadLine(), out double birimFiyat) || birimFiyat <= 0)
        {
            Console.WriteLine("Geçersiz fiyat.");
            return;
        }

        Console.Write("Adet: ");
        if (!int.TryParse(Console.ReadLine(), out int adet) || adet <= 0)
        {
            Console.WriteLine("Geçersiz adet.");
            return;
        }

        depo.Add(new Urun { Adi = adi, BirimFiyat = birimFiyat, Adet = adet });
        Console.WriteLine($"{adi} adlı ürün başarıyla eklendi.");
    }

    static void UrunSatis(List<Urun> depo, ref double kullaniciParasi)
    {
        if (depo.Count == 0)
        {
            Console.WriteLine("Depo boş! Satış yapılamaz.");
            return;
        }

        Console.Write("Satış yapmak istediğiniz ürünün adı: ");
        string? urunAdi = Console.ReadLine();
        if (string.IsNullOrWhiteSpace(urunAdi))
        {
            Console.WriteLine("Geçersiz ürün adı.");
            return;
        }

        var secilenUrun = depo.Find(u => u.Adi.Equals(urunAdi, StringComparison.OrdinalIgnoreCase));
        if (secilenUrun == null || secilenUrun.Adet <= 0)
        {
            Console.WriteLine("Bu ürün depoda bulunamadı veya stoğu kalmadı.");
            return;
        }

        Console.Write("Kaç adet satmak istiyorsunuz? ");
        if (!int.TryParse(Console.ReadLine(), out int adet) || adet <= 0)
        {
            Console.WriteLine("Geçersiz adet.");
            return;
        }

        double toplamTutar = secilenUrun.BirimFiyat * adet;
        if (adet > secilenUrun.Adet)
        {
            Console.WriteLine("Depoda bu kadar ürün yok!");
        }
        else if (toplamTutar > kullaniciParasi)
        {
            Console.WriteLine("Yetersiz bakiye.");
        }
        else
        {
            secilenUrun.Adet -= adet;
            kullaniciParasi -= toplamTutar;
            Console.WriteLine($"{adet} adet {urunAdi} satıldı. Kalan paranız: {kullaniciParasi} TL.");
        }
    }

    static void DepoyuGoruntule(List<Urun> depo)
    {
        if (depo.Count == 0)
        {
            Console.WriteLine("Depo boş!");
        }
        else
        {
            foreach (var urun in depo)
            {
                Console.WriteLine($"- {urun.Adi}: {urun.Adet} adet, {urun.BirimFiyat} TL/birim");
            }
        }
    }
}
