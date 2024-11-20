using System;

class Ogrenci
{
    public string Ad { get; set; }
    public string[] Dersler { get; set; }
    public int DersSayisi { get; set; }
}

class Ogretmen
{
    public string Ad { get; set; }
    public string[] VerdigiDersler { get; set; }
    public int DersSayisi { get; set; }
}

class Sinif
{
    public string SinifAdi { get; set; }
    public string[] Dersler { get; set; }
    public int DersSayisi { get; set; }
}

class Program
{
    static void OgrenciDersProgrami(Ogrenci ogr)
    {
        Console.WriteLine($"\nÖğrenci {ogr.Ad}'nin ders programı ({ogr.DersSayisi} ders):");
        string[] gunler = { "Pazartesi", "Çarşamba", "Perşembe" };
        for (int i = 0; i < ogr.DersSayisi; i++)
        {
            Console.WriteLine($"- {gunler[i]}: {ogr.Dersler[i]}");
        }
    }

    static void OgretmenDersProgrami(Ogretmen ogrt)
    {
        Console.WriteLine($"\nÖğretmen {ogrt.Ad}'nin verdiği dersler ({ogrt.DersSayisi} ders):");
        string[] gunler = { "Pazartesi", "Çarşamba", "Perşembe" };
        for (int i = 0; i < ogrt.DersSayisi; i++)
        {
            Console.WriteLine($"- {gunler[i]}: {ogrt.VerdigiDersler[i]}");
        }
    }

    static void SinifDersProgrami(Sinif sinif)
    {
        Console.WriteLine($"\n{sinif.SinifAdi} sınıfının ders programı ({sinif.DersSayisi} ders):");
        string[] gunler = { "Pazartesi", "Çarşamba", "Perşembe" };
        for (int i = 0; i < sinif.DersSayisi; i++)
        {
            Console.WriteLine($"- {gunler[i]}: {sinif.Dersler[i]}");
        }
    }

    static void Main(string[] args)
    {
        Console.WriteLine("Hoş geldiniz! Lütfen bir seçim yapınız:");
        Console.WriteLine("1. Öğretmen");
        Console.WriteLine("2. Öğrenci");
        Console.WriteLine("3. Sınıf Ders Programı");
        Console.Write("Seçiminiz: ");
        int secim = Convert.ToInt32(Console.ReadLine());

        Ogrenci ogrenci = new Ogrenci { Ad = "Mustafa", Dersler = new string[] { "Algoritma", "İş Güvenliği", "Kodlama Mimarisi" }, DersSayisi = 3 };
        Ogretmen ogretmen = new Ogretmen { Ad = "Caner", VerdigiDersler = new string[] { "Algoritma", "İş Güvenliği", "Kodlama Mimarisi" }, DersSayisi = 3 };
        Sinif sinif = new Sinif { SinifAdi = "Bilgisayar Programcılığı 1. Sınıf", Dersler = new string[] { "Algoritma", "Yazılım", "Tasarım" }, DersSayisi = 3 };

        if (secim == 1)
        {
            OgretmenDersProgrami(ogretmen);
        }
        else if (secim == 2)
        {
            OgrenciDersProgrami(ogrenci);
        }
        else if (secim == 3)
        {
            SinifDersProgrami(sinif);
        }
        else
        {
            Console.WriteLine("Geçersiz seçim");
        }
    }
}