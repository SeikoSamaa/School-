using System;
using System.ComponentModel.Design;
namespace Proje1
{
    class Program
    {
        static void Main(string[] args)
        {
            Liste cydaListe = new Liste(); // Liste nesnesi oluşturuluyor
            int sayi, indis;
            int secim = menu(); // Kullanıcıdan seçim alınıyor
            while (secim != 0)
            {
                switch (secim)
                {
                    case 1:
                        Console.Write("Sayı : "); sayi = int.Parse(Console.ReadLine());
                        cydaListe.basaEkle(sayi); // Başa eleman ekleme
                        cydaListe.yazdır();
                        break;
                    case 2:
                        Console.Write("Sayı : "); sayi = int.Parse(Console.ReadLine());
                        cydaListe.sonaEkle(sayi); // Sona eleman ekleme
                        cydaListe.yazdır();
                        break;
                    case 3:
                        Console.Write("indis : "); indis = int.Parse(Console.ReadLine()); 
                        cydaListe.aradanSil(indis); cydaListe.yazdır(); // Belirtilen indeksten eleman silme
                        break;
                    case 0:
                        break;
                    default:
                        Console.WriteLine("Hatalı seçim yaptınız");
                        break;
                }
                secim = menu();
            }
            Console.WriteLine("Program kapatılıyor...");
        }
        private static int menu()
        {
            int secim;
            Console.WriteLine("\n\n1-Başa ekle");
            Console.WriteLine("2-Sona ekle");
            Console.WriteLine("3-Aradan sil");
            Console.WriteLine("0-Programı kapat");
            Console.Write("seçiminiz : ");
            secim = int.Parse(Console.ReadLine());
            return secim;
        }
    }
    
    class Node
    {
        public int data;
        public Node next;
        public Node prev;

        public Node(int data)
        {
            this.data = data;
            this.next = null;
            this.prev = null;
        }
    }
    
    class Liste
    {
        Node head;
        Node tail;

        public Liste()
        {
            this.head = null;
            this.tail = null;
        }
        
        public void basaEkle(int data)
        {
            Node eleman = new Node(data);
            if (head == null)
            {
                head = tail = eleman;
                tail.next = head;
                tail.prev = head;
                head.next = tail;
                head.prev = tail;
                Console.WriteLine("Liste yapısı oluşturuldu, ilk eleman eklendi.");
            }
            else
            {
                eleman.next = head;
                head.prev = eleman;
                head = eleman;
                head.prev = tail;
                tail.next = head;
                Console.WriteLine("Başa eleman eklendi");
            }
        }
        
        public void sonaEkle(int data)
        {
            Node eleman = new Node(data);
            if (head == null)
            {
                head = tail = eleman;
                tail.next = head;
                tail.prev = head;
                head.next = tail;
                head.prev = tail;
                Console.WriteLine("Liste yapısı oluşturuldu, ilk eleman eklendi.");
            }
            else
            {
                tail.next = eleman;
                eleman.prev = tail;
                tail = eleman;
                tail.next = head;
                head.prev = tail;
                Console.WriteLine("Sona eleman eklendi");
            }
        }
        
        public void yazdır()
        {
            if (head == null)
                Console.WriteLine("Liste boş");
            else
            {
                Node temp = head;
                Console.Write("Baş -> ");
                while (temp != tail)
                {
                    Console.Write(temp.data + " -> ");
                    temp = temp.next;
                }
                Console.Write(temp.data + " son.");
            }
        }
        
        public void aradanSil(int indis)
        {
            if (head == null)
            {
                Console.WriteLine("Liste boş");
            }
            else
            {
                Node temp = head;
                Node temp2 = null;
                int i = 0;

                while (temp != tail && i < indis)
                {
                    temp2 = temp;
                    temp = temp.next;
                    i++;
                }

                if (i == indis)
                {
                    if (temp == head)
                    {
                        head = head.next;
                        head.prev = tail;
                        tail.next = head;
                    }
                    else if (temp == tail)
                    {
                        tail = tail.prev;
                        tail.next = head;
                        head.prev = tail;
                    }
                    else
                    {
                        temp2.next = temp.next;
                        temp.next.prev = temp2;
                    }
                    Console.WriteLine("Aradan eleman silindi.");
                }
                else
                {
                    Console.WriteLine("Geçersiz indis");
                }
            }
        }
    }
}
