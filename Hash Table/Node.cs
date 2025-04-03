using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace Proje5
{
    class Node
    {
       public  int key;
       public string isim;
       public Node next;
        public Node()
        {
            this.next=null;

        }
        public Node(int key,string isim)
        {
            this.key=key;
            this.isim=isim;
            this.next=null;

        }
    }
}