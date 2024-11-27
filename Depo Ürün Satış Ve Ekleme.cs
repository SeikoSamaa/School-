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
        double kullaniciParasi = 25000; //Valla iyi para hocam 

        while (true)
        {
            Console.WriteLine("\nAna Menü:");
            Console.WriteLine("1 - Ürün Menüsü");
            Console.WriteLine("2 - Diğer İşlemler");
            Console.WriteLine("0 - Çıkış");
            Console.Write("Seçiminiz: ");

            if (!int.TryParse(Console.ReadLine(), out int secim))
            {
                YazdirMesaj("Geçersiz seçim. Lütfen tekrar deneyin.", ConsoleColor.Red);
                continue;
            }

            switch (secim)
            {
                case 1:
                    UrunMenusu(depo, ref kullaniciParasi);
                    break;
                case 2:
                    DigerIslemler(depo, ref kullaniciParasi);
                    break;
                case 0:
                    return;
                default:
                    break;
            }
        }
    }

    static void UrunMenusu(List<Urun> depo, ref double kullaniciParasi)
    {
        while (true)
        {
            Console.WriteLine("\nÜrün Menüsü:");
            Console.WriteLine("1 - Ürün Ekle");
            Console.WriteLine("2 - Ürün Satış");
            Console.WriteLine("0 - Ana Menüye Dön");
            Console.Write("Seçiminiz: ");

            if (!int.TryParse(Console.ReadLine(), out int secim))
            {
                YazdirMesaj("Geçersiz seçim. Lütfen tekrar deneyin.", ConsoleColor.Red);
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
                case 0:
                    return;
                default:
                    break;
            }
        }
    }

    static void DigerIslemler(List<Urun> depo, ref double kullaniciParasi)
    {
        while (true)
        {
            Console.WriteLine("\nDiğer İşlemler:");
            Console.WriteLine("1 - Depodaki Ürünleri Görüntüle");
            Console.WriteLine("2 - Bakiye Görüntüle");
            Console.WriteLine("0 - Ana Menüye Dön");
            Console.Write("Seçiminiz: ");

            if (!int.TryParse(Console.ReadLine(), out int secim))
            {
                YazdirMesaj("Geçersiz seçim. Lütfen tekrar deneyin.", ConsoleColor.Red);
                continue;
            }

            switch (secim)
            {
                case 1:
                    DepoyuGoruntule(depo);
                    break;
                case 2:
                    Console.WriteLine($"Mevcut bakiye: {kullaniciParasi} TL");
                    break;
                case 0:
                    return;
                default:
                    break;
            }
        }
    }

    static void UrunEkle(List<Urun> depo)
    {
        Console.Write("Ürün adı: ");
        string adi = Console.ReadLine();
        if (string.IsNullOrWhiteSpace(adi))
        {
            YazdirMesaj("Ürün adı boş olamaz!", ConsoleColor.Red);
            return;
        }

        Console.Write("Birim fiyatı: ");
        if (!double.TryParse(Console.ReadLine(), out double birimFiyat) || birimFiyat <= 0)
        {
            YazdirMesaj("Geçersiz fiyat!", ConsoleColor.Red);
            return;
        }

        Console.Write("Adet: ");
        if (!int.TryParse(Console.ReadLine(), out int adet) || adet <= 0)
        {
            YazdirMesaj("Geçersiz adet!", ConsoleColor.Red);
            return;
        }

        depo.Add(new Urun { Adi = adi, BirimFiyat = birimFiyat, Adet = adet });
        YazdirMesaj($"{adi} adlı ürün başarıyla eklendi.", ConsoleColor.Green);
    }

    static void UrunSatis(List<Urun> depo, ref double kullaniciParasi)
    {
        if (depo.Count == 0)
        {
            YazdirMesaj("Depo boş, satış yapılamaz!", ConsoleColor.Red);
            return;
        }

        Console.Write("Satış yapmak istediğiniz ürünün adı: ");
        string urunAdi = Console.ReadLine();
        var secilenUrun = depo.Find(u => u.Adi.Equals(urunAdi, StringComparison.OrdinalIgnoreCase));

        if (secilenUrun == null || secilenUrun.Adet <= 0)
        {
            YazdirMesaj("Bu ürün depoda bulunamadı veya stoğu kalmadı.", ConsoleColor.Red);
            return;
        }

        Console.Write("Kaç adet satmak istiyorsunuz? ");
        if (!int.TryParse(Console.ReadLine(), out int adet) || adet <= 0)
        {
            YazdirMesaj("Geçersiz adet!", ConsoleColor.Red);
            return;
        }

        if (adet > secilenUrun.Adet)
        {
            YazdirMesaj("Depoda bu kadar ürün yok!", ConsoleColor.Red);
            return;
        }

        double toplamTutar = secilenUrun.BirimFiyat * adet;
        if (toplamTutar > kullaniciParasi)
        {
            YazdirMesaj("Yetersiz bakiye.", ConsoleColor.Red);
            return;
        }

        secilenUrun.Adet -= adet;
        kullaniciParasi -= toplamTutar;
        YazdirMesaj($"{adet} adet {urunAdi} başarıyla satıldı. Kalan bakiye: {kullaniciParasi} TL.", ConsoleColor.Green);
    }

    static void DepoyuGoruntule(List<Urun> depo)
    {
        if (depo.Count == 0)
        {
            YazdirMesaj("Depo boş!", ConsoleColor.Red);
            return;
        }

        foreach (var urun in depo)
        {
            Console.WriteLine($"- {urun.Adi}: {urun.Adet} adet, {urun.BirimFiyat} TL/birim");
        }
    }

    static void YazdirMesaj(string mesaj, ConsoleColor renk)
    {
        Console.ForegroundColor = renk;
        Console.WriteLine(mesaj);
        Console.ResetColor();
    }
}
