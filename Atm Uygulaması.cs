using System;

class Program
{
    static void Main()
    {
        double balance = 1000.0;
        int choice;

        while (true)
        {
            Console.WriteLine("\nATM Menüsü:");
            Console.WriteLine("1. Para Çek");
            Console.WriteLine("2. Para Yatır");
            Console.WriteLine("3. Bakiye Görüntüle");
            Console.WriteLine("4. Çıkış");
            Console.Write("Bir seçenek girin (1-4): ");
            choice = Convert.ToInt32(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    Console.Write("Çekmek istediğiniz tutarı girin: ");
                    double withdrawAmount = Convert.ToDouble(Console.ReadLine());
                    if (withdrawAmount <= balance)
                    {
                        balance -= withdrawAmount;
                        Console.WriteLine($"Başarıyla {withdrawAmount} TL çektiniz. Kalan bakiyeniz: {balance} TL.");
                    }
                    else
                    {
                        Console.WriteLine("Yetersiz bakiye. Lütfen daha küçük bir tutar girin.");
                    }
                    break;

                case 2:
                    Console.Write("Yatırmak istediğiniz tutarı girin: ");
                    double depositAmount = Convert.ToDouble(Console.ReadLine());
                    balance += depositAmount;
                    Console.WriteLine($"Başarıyla {depositAmount} TL yatırdınız. Yeni bakiyeniz: {balance} TL.");
                    break;

                case 3:
                    Console.WriteLine($"Mevcut bakiyeniz: {balance} TL.");
                    break;

                case 4:
                    Console.WriteLine("ATM işleminden çıkıyorsunuz.");
                    return;

                default:
                    Console.WriteLine("Geçersiz seçenek. Lütfen geçerli bir seçenek girin.");
                    break;
            }

            if (balance <= 0)
            {
                Console.WriteLine("\nParanız bitti! ATM işleminiz sonlandırılacaktır.");
                break;
            }
        }
    }
}
