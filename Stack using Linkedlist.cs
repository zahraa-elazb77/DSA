using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;


namespace stack_using_linkedlist
{
    class Stack
    {
   
        public class Node
        {
            public int item;  
            public Node Next; 
        }
        
        Node top;

        public Stack()
        {
            top = null; 
        }

        
        public void Push(int NewItem)
        {
            
            Node NewItemPtr = new Node();
            NewItemPtr.item = NewItem; 

            if (IsEmpty())
            {
                top = NewItemPtr;  
            }
            else
            {
                NewItemPtr.Next = top;  
                top = NewItemPtr;  
            }
        }

        public void Pop()
        {
            if (IsEmpty())
            {
                Console.WriteLine("Stack is empty in pop");
            }
            else
            {
                Node Delptr = top;
                int value = top.item;
                top = top.Next;
                Console.WriteLine(value);
               
            }


        }



        public int Peek()
        {
            if (top == null) 
            {
               Console.WriteLine("Stack is empty");
            }

            return top.item; 
        }

        public bool IsEmpty()
        {
            return top == null;
        }

       public void display() 
       {
            Node temp = top;
            while (temp != null)
            {
                Console.WriteLine(temp.item);
                temp = temp.Next;
            }
        
        
       }
        public int Count()
        {
            int Counter = 0;
            Node temp = top;
            while (temp != null)
            {
                Counter++;
                temp = temp.Next;

            }
            return Counter;


        }

        public bool isFound(int item)
        {
            bool Found = false;
            Node temp = top;
            while (temp != null)
            {
                if (temp.item == item)
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
            
            Stack stack = new Stack();

            stack.Push(10);
            stack.Push(20);
            stack.Push(30);
            stack.Push(40);

            Console.WriteLine("Top item: " + stack.Peek());

            Console.Write("popped item : ");
            stack.Pop();
            Console.WriteLine();


            Console.WriteLine("Top item after pop: " + stack.Peek());  

            Console.WriteLine("Is stack empty? " + stack.IsEmpty());
            Console.WriteLine("Number of Nodes :" + stack.Count());
            stack.display();
           
        }
    }
}
