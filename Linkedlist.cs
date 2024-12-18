using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace Linkedlist
{
    internal class LinkedList
    {
        public class Node
        {
            public int Item;
            public Node Next;

        }

        public Node Head;
        public LinkedList()
        {
            Head = null;

        }
        public bool IsEmpty()
        {
            return Head == null;
        }


        public void InsertFirst(int NewItem)
        {
            Node NewNode = new Node();
            NewNode.Item = NewItem;
            if (IsEmpty())
            {
                NewNode.Next = null;
                Head = NewNode;

            }
            else
            {
                NewNode.Next = Head;
                Head = NewNode;
            }

        }
        public void InsertLast(int NewItem)
        {
            
            if (IsEmpty())
            {
                InsertFirst(NewItem);
            }
            else
            {
                Node temp = Head;
                while (temp.Next!=null)
                {
                    temp = temp.Next;
                }

                Node NewNode = new Node();
                NewNode.Item = NewItem;
                temp.Next = NewNode;
                NewNode.Next = null;

            }

        }

        public void InsertBefore(int Item , int NewValue)
        {
            Node NewNode = new Node();
            NewNode.Item = NewValue;
            Node temp = Head;
            if (IsEmpty())
                InsertFirst(NewValue);

            if (IsFound(Item))
            {
                while (temp != null && temp.Item != Item)
                {
                    temp = temp.Next;

                }
                NewNode.Next = temp.Next;
                temp.Next = NewNode;
            }
           
            else
            {
                Console.WriteLine( "Item is not found , please try again");
            }



        }

        public void Reverse()
        {
            Node Prevptr = new Node();
            Node Currptr = new Node();
            Node Nextvptr = new Node();

            Prevptr = null;
            Currptr = Head;
            Nextvptr = Currptr.Next;

            while (Nextvptr != null)
            {
                Nextvptr = Currptr.Next;
                Currptr.Next = Prevptr;
                Prevptr = Currptr;
                Currptr = Nextvptr;

            }
            Head = Prevptr;

        }

        public void Delete(int Item)
        {
            if (IsEmpty())
            {
                Console.WriteLine("List is empty");
            }
            if (Head.Item == Item)
            {
                Head = Head.Next;
            }
            else
            {
                Node Delptr = Head;
                Node Prevptr = null;
                while (Delptr.Item != Item)
                {
                    Prevptr = Delptr;
                    Delptr = Delptr.Next;

                }

                Prevptr = Delptr.Next;
            } 

        }

        public void Display()
        {
            Node temp = new Node();
            temp = Head;
            while (temp != null)
            {
                Console.WriteLine(temp.Item);
                temp = temp.Next;
            }


        }

        public int Count()
        {
            int Counter = 0;
            Node temp = new Node();
            temp = Head;
            while (temp != null)
            {
                Counter++;
                temp = temp.Next;
               
            }
            return Counter;

        }

        public bool IsFound(int Key)
        {
            bool Found = false;
            Node temp = new Node();
            temp = Head;
            while (temp != null)
            {
                if (temp.Item == Key)
                    Found = true;

                temp = temp.Next;
            }
            return Found;
        }
    }
    internal class Program
    {


        static void Main(string[] args)
        {
            LinkedList L1 = new LinkedList();
            L1.InsertFirst(1);
            L1.InsertFirst(2);
            Console.WriteLine(L1.Count()); 
            Console.WriteLine(L1.IsFound(5)); 
            
            L1.Display();
            L1.InsertBefore(2,5);
            L1.Display();
            L1.InsertLast(15);
            L1.Display();

            L1.Delete(5);
            Console.WriteLine("after delete");
            L1.Display();
            L1.Reverse();
            L1.Display();

            Console.ReadKey();
        }
    }
}
