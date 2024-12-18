using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class DoublyList
{
    private class Node
    {
        public int item;  
        public Node prv;  
        public Node next; 
    }

    private Node first; 
    private Node last;  
    private int length; 

    
    public DoublyList()
    {
        first = last = null;
        length = 0;
    }

   
    public bool IsEmpty()
    {
        return length == 0;
    }

    
    public void InsertFirst(int element)
    {
        Node newNode = new Node();
        newNode.item = element;

        if (IsEmpty()) 
        {
            first = last = newNode;
            newNode.next = newNode.prv = null;
        }
        else
        {
            newNode.next = first;
            newNode.prv = null;
            first.prv = newNode;
            first = newNode;
        }

        length++;
    }

    
    public void InsertLast(int element)
    {
        Node newNode = new Node();
        newNode.item = element;

        if (IsEmpty())
        {
            first = last = newNode;
            newNode.next = newNode.prv = null;
        }
        else
        {
            newNode.next = null;
            newNode.prv = last;
            last.next = newNode;
            last = newNode;
        }

        length++;
    }

   
    public void InsertAtPos(int pos, int element)
    {
        if (pos < 0 || pos > length)
        {
            Console.WriteLine("Out of Range on InsertAtPos...!");
            return;
        }

        Node newNode = new Node();
        newNode.item = element;

        if (IsEmpty()) 
        {
            first = last = newNode;
            newNode.next = newNode.prv = null;
            length++;
        }
        else if (pos == 0)
            InsertFirst(element); 
        else if (pos == length)
            InsertLast(element); 
        else
        {
            Node cur = first;
            for (int i = 1; i < pos; i++)
                cur = cur.next;

            newNode.next = cur.next;
            newNode.prv = cur;
            cur.next = newNode;
            newNode.next.prv = newNode;
            length++;
        }
    }

    public void RemoveFirst()
    {
        if (IsEmpty())
        {
            Console.WriteLine("Can't Delete Empty List on RemoveFirst...!");
            return;
        }
        else if (length == 1)
        {
            first = last = null;
        }
        else
        {
            Node cur = first;
            first = first.next;
            first.prv = null;
            cur.next = null;
        }

        length--;
    }

    public void RemoveLast()
    {
        if (IsEmpty())
        {
            Console.WriteLine("Can't Delete Empty List on RemoveLast...!");
            return;
        }
        else if (length == 1)
        {
            first = last = null;
        }
        else
        {
            Node cur = last;
            last = last.prv;
            last.next = null;
            cur.prv = null;
        }

        length--;
    }

    public void Remove(int element)
    {
        if (IsEmpty())
        {
            Console.WriteLine("Can't Delete Empty List on Remove...!");
            return;
        }

        if (first.item == element)
        {
            RemoveFirst();
        }
        else
        {
            Node cur = first.next;

            while (cur != null && cur.item != element)
                cur = cur.next;

            if (cur == null)
            {
                Console.WriteLine("The Element is Not Found Here on Remove...!");
                return;
            }
            else if (cur.next == null)
            {
                RemoveLast();
            }
            else
            {
                cur.prv.next = cur.next;
                cur.next.prv = cur.prv;
                cur.next = cur.prv = null;
                length--;
            }
        }
    }

    public void Display()
    {
        Node cur = first;
        Console.Write("Doubly Linked List Elements are: [ ");
        while (cur != null)
        {
            Console.Write(cur.item + " ");
            cur = cur.next;
        }
        Console.WriteLine("]");
    }

    public void ReversedDisplay()
    {
        Node cur = last;
        Console.Write("Doubly Linked List Elements After Reversed are: [ ");
        while (cur != null)
        {
            Console.Write(cur.item + " ");
            cur = cur.prv;
        }
        Console.WriteLine("]");
    }
}

class Program
{
    static void Main(string[] args)
    {
        DoublyList d = new DoublyList();
        d.InsertFirst(0);
        d.InsertAtPos(1, 10);
        d.InsertAtPos(2, 20);
        d.InsertLast(30);
        d.InsertLast(40);
        d.InsertLast(50);

        d.Display();
        d.ReversedDisplay();

        d.RemoveFirst();   
        d.RemoveLast();    

        d.Display();     

        d.Remove(20);      
        d.Display();
        Console.ReadKey();
    }
}
