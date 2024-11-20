using System;

class Program
{
    static void Main()
    {
        Console.WriteLine("Üçgenin çevresini hesaplamak için:");
        Console.Write("1. kenar uzunluğunu girin: ");
        double kenar1 = double.Parse(Console.ReadLine());
        
        Console.Write("2. kenar uzunluğunu girin: ");
        double kenar2 = double.Parse(Console.ReadLine());
        
        Console.Write("3. kenar uzunluğunu girin: ");
        double kenar3 = double.Parse(Console.ReadLine());
        
        double ucgenCevre = UcgenCevresi(kenar1, kenar2, kenar3);
        Console.WriteLine($"Üçgenin çevresi: {ucgenCevre}");

        Console.WriteLine("\nKarenin alanını hesaplamak için:");
        Console.Write("Karenin bir kenar uzunluğunu girin: ");
        double kenar = double.Parse(Console.ReadLine());
        
        double kareAlan = KareninAlani(kenar);
        Console.WriteLine($"Karenin alanı: {kareAlan}");
    }

    static double UcgenCevresi(double kenar1, double kenar2, double kenar3)
    {
        return kenar1 + kenar2 + kenar3;
    }

    static double KareninAlani(double kenar)
    {
        return kenar * kenar;
    }
}
