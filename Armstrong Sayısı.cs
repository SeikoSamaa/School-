using System;

class Program
{
    static void Main()
    {
        Console.Write("Bir sayı girin: ");
        int sayi = int.Parse(Console.ReadLine());

        int basamakSayisi = sayi.ToString().Length;

        int toplam = 0;
        int geçiciSayi = sayi;

        while (geçiciSayi > 0)
        {
            int basamak = geçiciSayi % 10;
            toplam += (int)Math.Pow(basamak, basamakSayisi);
            geçiciSayi /= 10;
        }

        if (toplam == sayi)
        {
            Console.WriteLine($"{sayi} bir Armstrong sayısıdır");
        }
        else
        {
            Console.WriteLine($"{sayi} bir Armstrong sayısı değildir");
        }
    }
}
