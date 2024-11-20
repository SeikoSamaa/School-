using System;
using System.ComponentModel;
class Sınav
{
    static void Main()
    {
        int sayac =0;
        int adet =0;
        Console.WriteLine("1. Sayi Degerini Giriniz");
        int sayi1 = int.Parse (Console.ReadLine());
        
        Console.WriteLine("2. Sayi Degerini Giriniz");
        int sayi2 = int.Parse(Console.ReadLine());
        
        for (int i = sayi1; i < sayi2; i++)
         if (i%2==0)
         {
            Console.WriteLine(i);
            sayac=i;
            adet=i;
         }
         Console.WriteLine(sayac);
         Console.WriteLine("Toplam adet: "+adet/2);

    }
}   

 