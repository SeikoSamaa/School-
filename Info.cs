using System;

class Program2
{
    static void Main(string[] args)
    {       //Console.write komutu ve string komutlarını kullanarak kullanıcıların verilerini kaydettim.
        Console.Write("Ad Girin: "); 
        string ad = Console.ReadLine();

        Console.Write("Soyad Girin: ");
        string soyad = Console.ReadLine();

        Console.Write("Ogrenci No Girin: ");  
        string ogrenciNo = Console.ReadLine();

        Console.Write("Cep Telefon No Girin: ");
        string cepTelefonNo = Console.ReadLine();

        Console.Write("Mail Adresinizi Girin: ");
        string mailAdresi = Console.ReadLine();

        Console.Write("Yasinizi Girin: ");
        string yas = Console.ReadLine();
        //Readline Komutunu Kullanarak Kullanıcıdan Aldığım Verileri Kaydettim
        
        //Kullanıcıdan Aldığım Bilgileri Ekrana Yazdırmak İçin $ string modelini kullandım Kaynak:https://stackoverflow.com/questions/32878549/whats-does-the-dollar-sign-string-do

        Console.WriteLine("\nAlınan Bilgiler:");
        Console.WriteLine($"Ad: {ad}");
        Console.WriteLine($"Soyad: {soyad}");
        Console.WriteLine($"Öğrenci No: {ogrenciNo}");
        Console.WriteLine($"Cep Telefon No: {cepTelefonNo}");
        Console.WriteLine($"Mail Adresi: {mailAdresi}");
        Console.WriteLine($"Yaş: {yas}");
    }
}
