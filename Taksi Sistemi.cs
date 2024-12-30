using System;
using System.Collections.Generic;

public enum AraçTipi //sabit değer olduğu için enum veri tipini kullanıyorum
{
    Ekonomik,
    VIP
}

public class Taksi
{
    public string TaksiId { get; set; } // Taksiye özgü plaka.
    public string ŞoförAdı { get; set; } // Taksi şoförünün adı.
    public bool UygunMu { get; set; } // Taksi uygunluk durumu (müsait mi?).
    public AraçTipi AraçTipi { get; set; } // Taksi tipini belirten enum (Ekonomik veya VIP).
    public double Ücret { get; set; } // Yolculuk ücreti.
    public double BeklemeSüresi { get; set; } // Bekleme süresini dakika cinsinden saklar.
    public double EkstraBagajÜcreti { get; set; } // Ekstra bagaj ücretini saklar.

    public Taksi(string taksiId, string şoförAdı, bool uygunMu, AraçTipi araçTipi)
    {
        TaksiId = taksiId;
        ŞoförAdı = şoförAdı;
        UygunMu = uygunMu;
        AraçTipi = araçTipi;
        Ücret = 0;
        BeklemeSüresi = 0;
        EkstraBagajÜcreti = 100;
    }

    public void YolculukBaşlat(double mesafe, double beklemeSüresi, bool ekstraBagaj)
    {
        BeklemeSüresi = beklemeSüresi; // Bekleme süresi bilgisi alınıyor.
        EkstraBagajÜcreti = ekstraBagaj ? 100 : 0; // Ekstra bagaj var mı kontrol edilerek ücret belirleniyor.
        double indirimsizFiyat = ÜcretHesapla(mesafe, beklemeSüresi); // Yolculuk ücreti hesaplanıyor.
        double indirimliFiyat = indirimsizFiyat - (indirimsizFiyat * ZamanBazlıÜcretHesapla(beklemeSüresi)); // Zaman bazlı indirim uygulanıyor.
        Ücret = indirimliFiyat + EkstraBagajÜcreti; // Toplam ücret hesaplanıyor.

        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine($"{ŞoförAdı} yolculuğu başlatıyor. Mesafe: {mesafe} km, Bekleme Süresi: {beklemeSüresi} dakika, Ekstra Bagaj Ücreti: {EkstraBagajÜcreti} TL.");
        Console.WriteLine($"İndirimsiz Fiyat: {indirimsizFiyat} TL");
        Console.WriteLine($"İndirimli Fiyat: {indirimliFiyat} TL");
        Console.ResetColor();

        UygunMu = false; // Yolculuk sırasında,taksi uygun değil.
    }

    public void YolculukSonlandır()
    {
        UygunMu = true; // Yolculuk bittiğinde taksi yeniden uygun hale gelir.
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine($"{ŞoförAdı} yolculuğu tamamladı. Toplam ücret: {Ücret} TL.");
        Console.ResetColor();
    }

    private double ÜcretHesapla(double mesafe, double beklemeSüresi)
    {
        double temelÜcret = 25; // Her kilometre için alınan temel ücret.
        double zamanBazlıÜcret = ZamanBazlıÜcretHesapla(beklemeSüresi); // Bekleme süresine bağlı olarak indirim hesaplanır.
        double mesafeÜcreti = mesafe * temelÜcret; // Mesafe üzerinden ücret hesaplanır.

        if (AraçTipi == AraçTipi.VIP)
        {
            mesafeÜcreti *= 1.25; // VIP araçlar için %25 ek ücret.
        }

        if (mesafe <= 2)
        {
            mesafeÜcreti = 100; // 2 km ve daha kısa mesafelerde sabit ücret uygulanır.
        }

        return mesafeÜcreti + zamanBazlıÜcret; // Toplam ücret döndürülür.
    }

    private double ZamanBazlıÜcretHesapla(double beklemeSüresi)
    {
        double indirimOranı = 0; // Başlangıçta indirim oranı yok.
        if (beklemeSüresi <= 10)
        {
            indirimOranı = 0.05; // 10 dakika veya daha az bekleme için %5 indirim.
        }
        else if (beklemeSüresi <= 20)
        {
            indirimOranı = 0.075; // 20 dakika veya daha az bekleme için %7.5 indirim.
        }
        else if (beklemeSüresi <= 30)
        {
            indirimOranı = 0.1; // 30 dakika veya daha az bekleme için %10 indirim.
        }
        return indirimOranı; // Hesaplanan indirim oranı döndürülür.
    }
}

public class TaksiServisi
{
    private List<Taksi> taksiler = new List<Taksi>(); // Servise ait taksi listesini tutar.

    public void TaksiEkle(Taksi taksi)
    {
        taksiler.Add(taksi); // Yeni taksi listeye eklenir.
    }

    public Taksi UygunTaksiGetir()
    {
        foreach (var taksi in taksiler)
        {
            if (taksi.UygunMu)
            {
                return taksi; // Uygun bir taksi döndürülür.
            }
        }
        return null; // Uygun taksi bulunamazsa null döndürülür.
    }

    public List<Taksi> TaksileriListele()
    {
        return taksiler; // Taksilerin listesini döndürür.
    }

    public void TaksileriGöster()
    {
        foreach (var taksi in taksiler)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"Taksi ID: {taksi.TaksiId}, Şoför: {taksi.ŞoförAdı}, Araç Tipi: {taksi.AraçTipi}, Uygun Mu: {taksi.UygunMu}");
            Console.ResetColor();
        }
    }
}

class Program
{
    static void Main()
    {
        TaksiServisi taksiServisi = new TaksiServisi(); // Yeni bir taksi servisi oluşturulur.
        Taksi sabitTaksi = new Taksi("06 Tax 26", "Emre", true, AraçTipi.VIP); // Örnek bir VIP taksi oluşturulur.
        taksiServisi.TaksiEkle(sabitTaksi); // Bu taksi servise eklenir.

        Console.WriteLine("Taksici eklemek ister misiniz? (evet/hayır): ");
        if (EvetVeyaHayırSor()) // Kullanıcı yeni taksiler eklemek isteyip istemediğini belirtir.
        {
            Console.WriteLine("Eklemek istediğiniz taksi sayısını girin:");
            int taksiSayısı;
            while (!int.TryParse(Console.ReadLine(), out taksiSayısı) || taksiSayısı <= 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Geçersiz giriş. Lütfen geçerli bir sayı girin.");
                Console.ResetColor();
            }

            for (int i = 0; i < taksiSayısı; i++)
            {
                Console.WriteLine($"Taksi {i + 1} için bilgileri girin:");

                Console.Write("Taksi ID: ");
                string taksiId = Console.ReadLine(); // Kullanıcıdan taksi plaka bilgisi alınır.

                Console.Write("Şoför Adı: ");
                string şoförAdı = Console.ReadLine(); // Kullanıcıdan şoför adı bilgisi alınır.

                bool uygunMu = EvetVeyaHayırSor("Taksi uygun mu? (evet/hayır): "); // Uygunluk bilgisi alınır.

                AraçTipi araçTipi;
                do
                {
                    Console.Write("Araç tipi girin (1: Ekonomik, 2: VIP): ");
                    string girdi = Console.ReadLine();
                    if (girdi == "1")
                    {
                        araçTipi = AraçTipi.Ekonomik;
                        break;
                    }
                    else if (girdi == "2")
                    {
                        araçTipi = AraçTipi.VIP;
                        break;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Yanlış giriş yaptınız. Lütfen '1' (Ekonomik) veya '2' (VIP) girin.");
                        Console.ResetColor();
                    }
                } while (true);

                taksiServisi.TaksiEkle(new Taksi(taksiId, şoförAdı, uygunMu, araçTipi)); // Yeni taksi oluşturulup listeye eklenir.
            }
        }

        while (true)
        {
            Console.WriteLine("\nSistemdeki Taksiler:");
            taksiServisi.TaksileriGöster(); // Sistemde kayıtlı taksiler gösterilir.

            Console.WriteLine("\nLütfen rezervasyon yapmak istediğiniz taksiyi seçin:");
            List<Taksi> taksiler = taksiServisi.TaksileriListele(); // Taksiler listelenir.
            for (int i = 0; i < taksiler.Count; i++)
            {
                string araçTipi = taksiler[i].AraçTipi == AraçTipi.Ekonomik ? "Ekonomik" : "VIP";
                Console.WriteLine($"{i + 1}. {taksiler[i].TaksiId} - Şoför: {taksiler[i].ŞoförAdı} - Araç Tipi: {araçTipi}");
            }

            int secim;
            while (!int.TryParse(Console.ReadLine(), out secim) || secim <= 0 || secim > taksiler.Count)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Geçersiz seçim. Lütfen geçerli bir seçenek girin.");
                Console.ResetColor();
            }

            Taksi uygunTaksi = taksiler[secim - 1]; // Taksi seçimi yapılır.

            if (uygunTaksi != null && uygunTaksi.UygunMu)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"\nTaksi rezerve ediliyor: {uygunTaksi.TaksiId} - Şoför: {uygunTaksi.ŞoförAdı}");
                Console.ResetColor();

                Console.WriteLine("Mesafeyi kilometre cinsinden girin:");
                double mesafe;
                while (!double.TryParse(Console.ReadLine(), out mesafe) || mesafe <= 0)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Geçersiz giriş. Lütfen geçerli bir mesafe girin.");
                    Console.ResetColor();
                }

                bool ekstraBagaj = EvetVeyaHayırSor("Ekstra bagaj var mı? (evet/hayır): "); // Ekstra bagaj bilgisi alınır.

                Console.WriteLine("Bekleme süresini dakika cinsinden girin:");
                double beklemeSüresi;
                while (!double.TryParse(Console.ReadLine(), out beklemeSüresi) || beklemeSüresi < 0)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Geçersiz giriş. Lütfen geçerli bir bekleme süresi girin.");
                    Console.ResetColor();
                }

                uygunTaksi.YolculukBaşlat(mesafe, beklemeSüresi, ekstraBagaj); // Yolculuk başlatılır.
                uygunTaksi.YolculukSonlandır(); // Yolculuk sonlandırılır.

                Console.WriteLine("Yolculuğunuzu 10 üzerinden puanlayın:");
                int puan;
                while (!int.TryParse(Console.ReadLine(), out puan) || puan < 1 || puan > 10)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Geçersiz giriş. Lütfen 1 ile 10 arasında bir puan girin.");
                    Console.ResetColor();
                }

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"Teşekkürler! Yolculuğunuzu {puan} puanla değerlendirdiniz.");
                Console.ResetColor();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Seçilen taksi uygun değil veya bulunamadı.");
                Console.ResetColor();
            }

            Console.WriteLine("Başka bir rezervasyon yapmak ister misiniz? (evet/hayır): ");
            if (!EvetVeyaHayırSor())
            {
                Console.WriteLine("Program sonlandırılıyor. İyi günler dileriz.");
                break; // Kullanıcı başka rezervasyon istemezse kod sonlanır.
            }
        }
    }

    static bool EvetVeyaHayırSor(string soru = "")
    {
        string kullanıcıGirişi;
        do
        {
            if (!string.IsNullOrEmpty(soru))
            {
                Console.Write(soru); // Soruyu ekrana yazdırır.
            }
            kullanıcıGirişi = Console.ReadLine().ToLower();

            if (kullanıcıGirişi == "evet")
            {
                return true; 
            }
            else if (kullanıcıGirişi == "hayır")
            {
                return false; 
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Geçersiz giriş. Lütfen 'evet' veya 'hayır' girin.");
                Console.ResetColor();
            }
        } while (true);
    }
}
