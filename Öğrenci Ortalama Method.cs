using System;

class Program
{
    static void Main()
    {
        Console.Write("Öğrencinin adı: ");
        string ad = Console.ReadLine();
        
        Console.Write("Öğrencinin soyadı: ");
        string soyad = Console.ReadLine();
        
        Console.Write("1. sınav notunu girin: ");
        double not1 = double.Parse(Console.ReadLine());
        
        Console.Write("2. sınav notunu girin: ");
        double not2 = double.Parse(Console.ReadLine());
        
        double ortalama = OrtalamaHesapla(not1, not2);

        Console.WriteLine($"{ad} {soyad} adlı öğrencinin sınav ortalaması: {ortalama:F2}");
    }

    static double OrtalamaHesapla(double not1, double not2)
    {
        return (not1 + not2) / 2;
    }
}
