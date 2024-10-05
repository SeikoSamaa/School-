using System;

class Program
{
    static void Main()
    {
        // Kullanıcıdan 2 sayı istiyorum.
        Console.Write("Birinci sayiyi girin: ");
        double sayi1 = Convert.ToDouble(Console.ReadLine());

        Console.Write("İkinci sayiyi girin: ");
        double sayi2 = Convert.ToDouble(Console.ReadLine());

        // Kullanıcıdan aldğımız 2 sayının geometrik ortalamasını hesaplıyorum.
        double geometrikOrtalama = Math.Sqrt(sayi1 * sayi2);

        // Geometrik hesaplamasını yaptığımız sayıların sonucu ekrana yazdırıyorum.
        Console.WriteLine("Geometrik Ortalama: " + geometrikOrtalama);
    }
}