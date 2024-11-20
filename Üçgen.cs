using System;

class Program
{
    static void Main()
    {
        
        Console.Write("a değerini yazın: ");
        int a = Convert.ToInt32(Console.ReadLine());

        Console.Write("b değerini yazın: ");
        int b = Convert.ToInt32(Console.ReadLine());

        Console.Write("c değerini yazın: ");
        int c = Convert.ToInt32(Console.ReadLine());

       
        int toplam = a + b + c;

       
        if (toplam < 180)
        {
            Console.WriteLine("Üçgen değil");
        }
        else if (toplam > 180)
        {
            Console.WriteLine("Üçgen değil");
        }
        else
        {
            Console.WriteLine("Üçgen");
        }

        
        Console.WriteLine("Program sonlandı.");
    }
}