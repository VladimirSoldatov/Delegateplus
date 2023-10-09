using System;

using static System.Console;
namespace SimpleProject
{
    public delegate double AnonimDelegateDouble(double x,
    double y);

    public delegate void AnonimDelegateInt(int n);
    public delegate void AnonimDelegateVoid();
    class Dispacher
    {
        public event AnonimDelegateDouble eventDouble;
        public event AnonimDelegateInt eventVoid;
        public double OnEventDouble(double x, double y)
        {
            if (eventDouble != null)
            {
                return eventDouble(x, y);
            }
            throw new NullReferenceException();
        }
        public void OnEventVoid(int n = 0)
        {
            if (eventVoid != null)
            {
                eventVoid(n);
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            WriteLine("\tThe use of events");
            Dispacher dispacher = new Dispacher();
            // анонимный метод
            dispacher.eventDouble +=
            delegate (double a, double b)
            {
                if (b != 0)
                {
                    return a / b;
                }
                throw new DivideByZeroException();
            };
            double n1 = 5.7, n2 = 3.2;
            WriteLine($"{n1} / {n2} =     {dispacher.OnEventDouble(n1, n2)}"); // вызов
            WriteLine(" Using a local variable");
            int number = 5;
            dispacher.eventVoid += delegate (int n)// анонимный
            {
                WriteLine($"{number} + {n} = {number + n}");
            };
            dispacher.OnEventVoid(); // вызов
            dispacher.OnEventVoid(6);
            WriteLine("\tThe use of a delegate");
            AnonimDelegateVoid voidDel =
            new AnonimDelegateVoid(delegate
            { WriteLine("Ok!"); });
            // анонимный метод
            voidDel += delegate { WriteLine("Bye!"); };
            voidDel(); // вызов
        }
    }
}