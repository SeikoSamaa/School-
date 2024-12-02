using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static List<Book> library = new List<Book>();
    static List<Rental> rentals = new List<Rental>();

    static void Main()
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("=== Kütüphane Yönetim Sistemi ===");
            Console.WriteLine("1. Kitap Ekle");
            Console.WriteLine("2. Kitap Kirala");
            Console.WriteLine("3. Kitap İade");
            Console.WriteLine("4. Kitap Ara");
            Console.WriteLine("5. Raporlama");
            Console.WriteLine("0. Çıkış");
            Console.Write("Seçiminiz: ");

            string input = Console.ReadLine();
            switch (input)
            {
                case "1": AddBook(); break;
                case "2": RentBook(); break;
                case "3": ReturnBook(); break;
                case "4": SearchBook(); break;
                case "5": GenerateReports(); break;
                case "0": return;
                default: 
                    Console.WriteLine("Geçerli bir değer giriniz. Devam etmek için bir tuşa basın.");
                    Console.ReadKey(); 
                    break;
            }
        }
    }

    static void AddBook()
    {
        Console.Clear();
        Console.Write("Kitap Adı: ");
        string name = Console.ReadLine();
        Console.Write("Yazar Adı: ");
        string author = Console.ReadLine();
        Console.Write("Yayın Yılı: ");
        if (!int.TryParse(Console.ReadLine(), out int year))
        {
            Console.WriteLine("Geçerli bir yıl giriniz.");
            Console.ReadKey();
            return;
        }
        Console.Write("Stok Adedi: ");
        if (!int.TryParse(Console.ReadLine(), out int stock))
        {
            Console.WriteLine("Geçerli bir stok adedi giriniz.");
            Console.ReadKey();
            return;
        }

        var existingBook = library.FirstOrDefault(b => b.Name == name && b.Author == author);
        if (existingBook != null)
        {
            existingBook.Stock += stock;
            Console.WriteLine($"Stok güncellendi. Yeni stok: {existingBook.Stock}");
        }
        else
        {
            library.Add(new Book { Name = name, Author = author, Year = year, Stock = stock });
            Console.WriteLine("Kitap başarıyla eklendi.");
        }
        Console.ReadKey();
    }

    static void RentBook()
    {
        Console.Clear();
        if (library.Count == 0)
        {
            Console.WriteLine("Kütüphanede kitap bulunmuyor.");
            Console.ReadKey();
            return;
        }

        Console.WriteLine("Mevcut Kitaplar:");
        for (int i = 0; i < library.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {library[i].Name} - {library[i].Author} (Stok: {library[i].Stock})");
        }
        Console.Write("Kiralamak istediğiniz kitabın numarasını seçin: ");
        if (!int.TryParse(Console.ReadLine(), out int choice) || choice < 1 || choice > library.Count)
        {
            Console.WriteLine("Geçerli bir seçim yapınız.");
            Console.ReadKey();
            return;
        }

        var book = library[choice - 1];
        if (book.Stock <= 0)
        {
            Console.WriteLine("Seçilen kitap stokta yok.");
            Console.ReadKey();
            return;
        }

        Console.Write("Kaç gün kiralamak istiyorsunuz? ");
        if (!int.TryParse(Console.ReadLine(), out int days) || days <= 0)
        {
            Console.WriteLine("Geçerli bir gün sayısı giriniz.");
            Console.ReadKey();
            return;
        }

        int cost = days * 5;
        Console.Write($"Kiralama bedeli {cost} TL. Bütçenizi girin: ");
        if (!int.TryParse(Console.ReadLine(), out int budget) || budget < cost)
        {
            Console.WriteLine("Bütçeniz yetersiz veya geçerli bir tutar girmediniz.");
            Console.ReadKey();
            return;
        }

        Console.Write("Adınız: ");
        string userName = Console.ReadLine();

        book.Stock--;
        rentals.Add(new Rental
        {
            UserName = userName,
            BookName = book.Name,
            DueDate = DateTime.Now.AddDays(days),
            RentalDuration = days
        });
        Console.WriteLine("Kiralama işlemi başarılı.");
        Console.ReadKey();
    }

    static void ReturnBook()
    {
        Console.Clear();
        if (rentals.Count == 0)
        {
            Console.WriteLine("İade edilebilecek kiralanmış kitap bulunmuyor.");
            Console.ReadKey();
            return;
        }

        Console.WriteLine("İade Edilebilecek Kitaplar:");
        for (int i = 0; i < rentals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {rentals[i].BookName} - {rentals[i].UserName} (İade Tarihi: {rentals[i].DueDate})");
        }

        Console.Write("İade etmek istediğiniz kitabın numarasını seçin: ");
        if (!int.TryParse(Console.ReadLine(), out int choice) || choice < 1 || choice > rentals.Count)
        {
            Console.WriteLine("Geçerli bir seçim yapınız.");
            Console.ReadKey();
            return;
        }

        var selectedRental = rentals[choice - 1];
        var book = library.FirstOrDefault(b => b.Name == selectedRental.BookName);

        if (book != null)
        {
            book.Stock++;
        }

        DateTime today = DateTime.Now;
        int usedDays = (today - selectedRental.DueDate.AddDays(-selectedRental.RentalDuration)).Days;
        usedDays = usedDays > 0 ? usedDays : 0;

        int actualRentalCost = usedDays * 5;
        int originalRentalCost = selectedRental.RentalDuration * 5;

        if (usedDays < selectedRental.RentalDuration)
        {
            int refund = originalRentalCost - actualRentalCost;
            Console.WriteLine($"Kitap erken iade edildi. Para iadesi: {refund} TL.");
        }
        else if (usedDays > selectedRental.RentalDuration)
        {
            Console.WriteLine("Kitap geç iade edildi. Ekstra ücret uygulanabilir.");
        }

        rentals.Remove(selectedRental);
        Console.WriteLine($"\"{selectedRental.BookName}\" kitabı başarıyla iade edildi.");
        Console.ReadKey();
    }

    static void SearchBook()
    {
        Console.Clear();
        Console.WriteLine("1. Kitap adına göre ara");
        Console.WriteLine("2. Yazar adına göre ara");
        Console.Write("Seçiminiz: ");
        string choice = Console.ReadLine();

        Console.Write("Arama terimi: ");
        string term = Console.ReadLine().ToLower();

        var results = choice == "1"
            ? library.Where(b => b.Name.ToLower().Contains(term)).ToList()
            : library.Where(b => b.Author.ToLower().Contains(term)).ToList();

        if (results.Count == 0)
        {
            Console.WriteLine("Aramanızla eşleşen kitap bulunamadı.");
        }
        else
        {
            foreach (var book in results)
            {
                Console.WriteLine($"{book.Name} - {book.Author} ({book.Year}) - Stok: {book.Stock}");
            }
        }
        Console.ReadKey();
    }

    static void GenerateReports()
    {
        Console.Clear();
        Console.WriteLine("1. Tüm kitapları listele");
        Console.WriteLine("2. Belirli bir yazara ait kitapları listele");
        Console.WriteLine("3. Belirli bir yıla ait kitapları listele");
        Console.WriteLine("4. Kiralanan kitapları listele");
        Console.Write("Seçiminiz: ");
        string choice = Console.ReadLine();

        switch (choice)
        {
            case "1":
                foreach (var book in library)
                {
                    Console.WriteLine($"{book.Name} - {book.Author} ({book.Year}) - Stok: {book.Stock}");
                }
                break;
            case "2":
                Console.Write("Yazar adı: ");
                string author = Console.ReadLine();
                foreach (var book in library.Where(b => b.Author == author))
                {
                    Console.WriteLine($"{book.Name} ({book.Year}) - Stok: {book.Stock}");
                }
                break;
            case "3":
                Console.Write("Yayın yılı: ");
                if (!int.TryParse(Console.ReadLine(), out int year))
                {
                    Console.WriteLine("Geçerli bir yıl giriniz.");
                    Console.ReadKey();
                    return;
                }
                foreach (var book in library.Where(b => b.Year == year))
                {
                    Console.WriteLine($"{book.Name} - {book.Author} - Stok: {book.Stock}");
                }
                break;
            case "4":
                foreach (var rental in rentals)
                {
                    Console.WriteLine($"{rental.BookName} - {rental.UserName} (İade Tarihi: {rental.DueDate})");
                }
                break;
            default:
                Console.WriteLine("Geçerli bir seçim yapınız.");
                break;
        }
        Console.ReadKey();
    }
}

class Book
{
    public string Name { get; set; }
    public string Author { get; set; }
    public int Year { get; set; }
    public int Stock { get; set; }
}

class Rental
{
    public string UserName { get; set; }
    public string BookName { get; set; }
    public DateTime DueDate { get; set; }
    public int RentalDuration { get; set; }
}
