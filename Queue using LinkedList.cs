using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Queue_using_linkedlist
{
    class Queue
    {
       
        class Node
        {
          public int Item;
          public Node Next;
           public Node()
            {
                Item = 0;
                Next = null;
            }

        }

       Node Front;
       Node Rear;
       public Queue()
       {
         Front = null;
         Rear = null;

       }

        public bool IsEmpty()
        {
            return Front == null;
        }

        public void Enqueue(int NewItem)
        {
            Node NewNode = new Node();
            NewNode.Item = NewItem;

            if(IsEmpty())
            {
                Front = NewNode;
                Rear = NewNode;
            }
            else
            {
                Rear.Next = NewNode;
                Rear = NewNode;
            }

        }

        public void Dequeue()
        {
            
            if(IsEmpty())
            {
                Console.WriteLine("Queue is empty to dequeue");
            }
            else if ((Front == Rear) && (Front != null) )
            {
                int Delvalue = Front.Item;
                Front = Rear = null;
                Console.WriteLine(Delvalue);
            }
            else
            {
                //Node Delptr = Front;
                int Delvalue = Front.Item;
                Front = Front.Next;
                Console.WriteLine(Delvalue);

            }

        }

        public int GetFront()
        {
            return Front.Item;
        }

        public void Count()
        {
            int Counter = 0;
            Node Temp = Front;
            while (Temp != null)
            {
                Counter++; 
                Temp = Temp.Next;

            }
            Console.WriteLine("The count of nodes:" + Counter);
        }

        public void Clear()
        {

            while (!IsEmpty())
            {
                Dequeue();

            }
        }
        public void display()
        {
            Node Temp = Front;
           
            if (IsEmpty())
            {
                Console.WriteLine("Queue is empty to display");
            }
            else
            {
                while (Temp != null)
                {
                    Console.Write(Temp.Item);
                    Console.Write("\t");
                    Temp = Temp.Next;
                }
            }
            Console.WriteLine();
        }



    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Queue Q1 = new Queue();
            for (int i = 0; i <= 0; i++)
            {
                int Item;
                Console.WriteLine("Enter item to inqueue");
                Item = int.Parse(Console.ReadLine());
                Q1.Enqueue(Item);
            }
            Console.WriteLine("Queue before dequeue :");
            Q1.display();
            Console.Write("deleted item :");
            Q1.Dequeue();
            Console.WriteLine();
            Console.WriteLine("Queue after dequeue :");
            Q1.display();
            Console.WriteLine();

            Console.ReadKey();
        }
    }
}
