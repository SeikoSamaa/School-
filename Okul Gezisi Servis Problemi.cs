using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        List<string> ogrenciListe = new List<string> { "Baki", "Muhammet" };

        Console.WriteLine("Geziye katılacak öğrencilerin listesini yönetmek için:");
        Console.WriteLine("1 - Yeni öğrenci girişi");
        Console.WriteLine("2 - Toplam eklenen öğrenci sayısını göster");
        Console.WriteLine("3 - Aracı kontrol et");
        Console.WriteLine("0 - Programdan çık");

        while (true)
        {
            Console.WriteLine("\nBir işlem seçin:");
            if (!int.TryParse(Console.ReadLine(), out int karar))
            {
                Console.WriteLine("Geçersiz giriş. Lütfen bir sayı girin.");
                continue;
            }

            switch (karar)
            {
                case 1:
                    Console.WriteLine("Eklemek istediğiniz öğrencinin adını yazın:");
                    string yeniOgrenci = Console.ReadLine();
                    ogrenciListe.Add(yeniOgrenci);
                    Console.WriteLine($"{yeniOgrenci} listeye eklendi.");
                    break;

                case 2:
                    Console.WriteLine($"Toplam eklenen öğrenci sayısı: {ogrenciListe.Count}");
                    Console.WriteLine("Öğrenciler:");
                    foreach (var ogrenci in ogrenciListe)
                    {
                        Console.WriteLine("- " + ogrenci);
                    }
                    break;

                case 3:
                    Console.WriteLine("Araç kapasitesini girin:");
                    if (!int.TryParse(Console.ReadLine(), out int kapasite))
                    {
                        Console.WriteLine("Geçersiz giriş. Lütfen bir sayı girin.");
                        continue;
                    }

                    if (ogrenciListe.Count <= kapasite)
                    {
                        Console.WriteLine("Aracın kapasitesi yeterli.");
                    }
                    else
                    {
                        Console.WriteLine($"Aracın kapasitesi yetersiz! {ogrenciListe.Count - kapasite} kişi dışarıda kalacak.");
                    }
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
}
