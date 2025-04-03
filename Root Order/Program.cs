using System;
using System.Runtime.CompilerServices;

namespace Proje3
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Ağaç veri yapısı.");

            // İkili arama ağacı oluşturuluyor
            Tree bst = new Tree();

            // Ağaca elemanlar ekleniyor
            bst.root = bst.insert(bst.root, 10);
            bst.root = bst.insert(bst.root, 5);
            bst.root = bst.insert(bst.root, 15);
            bst.root = bst.insert(bst.root, 20);
            bst.root = bst.insert(bst.root, 3);
            bst.root = bst.insert(bst.root, 12);
            bst.root = bst.insert(bst.root, 9);

            // Farklı ağaç dolaşım sıralamaları
            Console.Write("preOrder : ");
            bst.preOrder(bst.root); 

            Console.Write("inOrder : ");
            bst.inOrder(bst.root);

            Console.Write("postOrder : ");
            bst.postOrder(bst.root);
        }
    }

    // Düğüm (Node) sınıfı
    class Node
    {
        public int data; // Düğüm verisi
        public Node left; 
        public Node rigth; 

        public Node(int data)
        {
            this.data = data;
            left = null;
            rigth = null;
        }
    }

    // Ağaç (Tree) sınıfı
    class Tree
    {
        public Node root; // Kök düğüm
        
        public Tree()
        {
            root = null;
        }
        
        // Yeni düğüm oluşturur
        public Node newNode(int data)
        {
            root = new Node(data);
            return root;
        }
        
        // Ağaca eleman ekleme
        public Node insert(Node root, int data)
        {
            Node eleman = new Node(data);
            if (root != null)
            {
                if (data < root.data)
                {
                    root.left = insert(root.left, data);
                }
                else
                {
                    root.rigth = insert(root.rigth, data);
                }
            }
            else
                root = newNode(data);
            return root;
        }
        
        // Preorder (Öncelikli) dolaşım: Kök -> Sol -> Sağ
        public void preOrder(Node root)
        {
            if (root !=null)
            {
                Console.Write(root.data + "  ");
                preOrder(root.left);
                preOrder(root.rigth);
            }
        }
        
        // Inorder (Sıralı) dolaşım: Sol -> Kök -> Sağ
        public void inOrder(Node root)
        {
            if (root !=null)
            {
                inOrder(root.left);
                Console.Write(root.data + "  ");
                inOrder(root.rigth);
            }
        }
        
        // Postorder (Sonralı) dolaşım: Sol -> Sağ -> Kök
        public void postOrder(Node root)
        {
            if (root !=null)
            {
                postOrder(root.left);
                postOrder(root.rigth); 
                Console.Write(root.data + "  ");
            }
        }
    }
}
