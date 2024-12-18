using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace stack
{
    class Stack
    {
        public const int MaxSize = 100;

        private int top;
        private int[] item = new int[MaxSize];

       public Stack()
        {
            top = -1;
        }
       public void push(int Element)
        {
            if (top >= MaxSize - 1)
            {
                Console.WriteLine("Stack full on push");

            }
            else
            {
                top++;
                item[top] = Element;
            }
        }
        public  bool isEmpy()
        {
            return top < 0;

        }
        public void pop()
        {
            if (isEmpy())
            {
                Console.WriteLine("Stack is empty in pop");
            }
            else
            {
                top--;
            }


        }
        public void pop(ref int Element)
        {
            if (isEmpy())
            {
                Console.WriteLine("Stack is empty in pop");
            }
            else
            {
                Element = item[top];
                top--;
            }


        }

        public void getTop(ref  int stackTop)
        {
            if (isEmpy())
            {
                Console.WriteLine("Stack is empty in getTop");
            }
            else
            {
                stackTop = item[top];
                Console.WriteLine(stackTop);
            }


        }

        public void Print()
        {
            Console.Write("[");
            for (int i = top; i  > 0; i--)
            {
                Console.Write(item[i]);
                Console.Write(" ");

            }
            Console.Write("]");
            Console.WriteLine();


        }


    }


    internal class Program
    {
        static void Main(string[] args)
        {

            Stack s1 = new Stack();
            s1.push(10);
            s1.push(4);
            s1.push(7);
            s1.push(0);
            s1.push(6);
            int x = 0;
            s1.pop(ref x);
            Console.WriteLine(x);
            s1.Print();

            int y = 0;
            s1.getTop(ref y);
            Console.WriteLine(y);
            Console.ReadKey();

                
          
        }
    }
}
