using System;
class Program
{
 static void Main()
 {
 Console.WriteLine("Sayı Değerinizi Giriniz:");
 int sayi = int.Parse(Console.ReadLine());
 if (MükemmelSayiMi(sayi))
 {
 Console.WriteLine($"{sayi} Bir Mükemmel Sayıdır.");
 }
 else
 {
 Console.WriteLine($"{sayi} Bir Mükemmel Sayı Değildir");
 }
 }
 static bool MükemmelSayiMi(int sayi)
 {
 if (sayi <= 1) return false;
 int toplam = 0;
 for (int i = 1; i < sayi; i++)
 {
 if (sayi % i == 0)
 {
 toplam += i;
 }
 }
 return toplam == sayi;
 }
}