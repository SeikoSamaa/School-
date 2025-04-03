using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Xml;

namespace Proje5
{
    class Tablo
    {
        int size;
        public Node[] dizi;

        public Tablo(int size)
        {
            this.size = size;
            dizi = new Node[size];
            for (int i = 0; i < size; i++)
            {
                dizi[i] = new Node();
            }


        }
        public int indexUret(int key)
        {
            return key % size;
        }
        public void ekle(int key, string isim)
        {
            int indis = indexUret(key);
            Node eleman = new Node(key, isim);
            Node temp = dizi[indis];
            if (temp.next == null)
            {
                temp.next = eleman;
                Console.WriteLine("sütunun ilk elemanı eklendi");
            }
            else
            {
               
               eleman.next=dizi[indis].next;//ekleme yapıyoruz
               dizi[indis].next=eleman;//güncelleme

                
                Console.WriteLine(key + "eklendi");
            }
        }
        public void sil(int key)
        {
            bool sonuc = false;
            int indis = indexUret(key);
            Node temp = dizi[indis];
            if (temp.next == null)
            {
                Console.WriteLine(key + "numaralı kayıt yok ! ");
                sonuc = true;
            }
            else if (temp.next.next == null && temp.next.key == key)
            {
                temp.next = null;
                Console.WriteLine(key + "numaralı kişi silindi.");
                sonuc = true;
            }
            else
            {
                Node temp2 = temp;
                while (temp.next != null)
                {
                    temp2 = temp;
                    temp = temp.next;
                    if (temp.key == key)
                    {
                        temp2.next = temp.next;
                        Console.WriteLine(key + "numaralı kişi silindi.");
                        sonuc = true;
                    }
                }
                if (!sonuc)
                {
                    Console.WriteLine(key + "numaralı kişi bulunamadı");
                }
            }

        }
        public void yazdır()
        {

            for (int i = 0; i < size; i++)
            {
                Node temp = dizi[i];
                Console.Write("Dizi [{0}] ->  " + i);
                while (temp.next != null)
                {
                    temp = temp.next;
                    Console.Write(temp.key + " " + temp.isim + " -> ");

                }
            }
        }
        public void adetBul()
        {
            int sayac=0;
            for (int i = 0; i < size; i++)
            {
                Node temp = dizi[i];
                Console.WriteLine();
                while (temp.next != null)
                {
                    temp = temp.next;
                   sayac++;

                }
                Console.WriteLine();
            }
            if (sayac==0)
            {
                Console.WriteLine("tabloda kayıtlı veri yok");
            }
            else
            {
                Console.WriteLine("tabloda kayıtlı kişi sayısı : " + sayac);
            }
        }
        public void kişibul(int key)
        {
            bool sonuc =false;
             for (int i = 0; i < size; i++)
            {
                Node temp = dizi[i];
                while (temp.next != null)
                {
                    temp = temp.next;
                    if (key == temp.key)
                    {
                        Console.Write(temp.key + "numaralı kişi bilgileri :  " + temp.isim + " -> "); 
                        sonuc=true;
                    }
                   

                }
                 Console.WriteLine();
            }
            if (!sonuc)
            {
                Console.WriteLine(key + "numaralı kişi bulunamadı ! ");
            }
           
        }
    }
}