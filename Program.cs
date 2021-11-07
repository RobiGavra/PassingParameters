using System;

namespace PassingParameters
{
    public class Program
    {
        static void Main(string[] args)
        {
            int n = 3;

            PassVal(n);
            MessageAfter(n);

            PassValAsRef(ref n);
            MessageAfter(n);

            int[] arr = { 1, 4, 5 };
            Change(arr);
            MessageAfter(arr[0]);

            Test test = new Test();
            test.number = 3;
            InOBj(in test);
            MessageAfter(test.number);

            MessageOut(out int a);
            Console.WriteLine(a);
            //Test test = new Test();
            test.number = 7;
            test.name = "7";

            InPar(11);

            Console.ReadKey();
        }

        public static void PassVal(int n)
        {
            Console.WriteLine("Here we passed an argument as value");
            MessageBefore(n);
            n *= n;
            MessageInside(n);
        }

        public static void PassValAsRef(ref int n)
        {
            //ref requires that the variable be initialized before it is passed
            Console.WriteLine("Here we passed an argument as reference by using ref");
            MessageBefore(n);
            n *= n;
            MessageInside(n);
        }

        static void Change(int[] array)//if we will use ref, both of the changes will affect the original value
        {
            Console.WriteLine("Here we changed the value of the first element of the array and after that we initialized the array as a new one");
            Console.WriteLine("Before calling the method, the first element is: {0}", array[0]);
            array[0] = 7;  // This change affects the original element.
            array = new int[5] { -3, -1, -2, -3, -4 };   // This change is local.
            Console.WriteLine("Inside the method, the first element is: {0}", array[0]);
        }

        static void InOBj(in Test test)
        { 
            test = new Test();
            MessageBefore(test.number);
            test.number = 4;
            MessageInside(test.number);
        }

        static void InPar(in int number)
        {
            MessageBefore(number);
            if(number == 4)
                MessageInside(number);
            
          //  number=4; not posible because number is readonly
        }

        public static void MessageBefore(int v)
        {
            Console.WriteLine("The value before calling the method: {0}", v);
        }

        public static void MessageInside(int v)
        {
            Console.WriteLine("The value inside the method: {0}", v);
        }

        public static void MessageAfter(int v)
        {
            Console.WriteLine("The value after calling the method: {0}", v);
            Console.WriteLine();
        }

        public static void MessageOut(out int x)
        {
            x = 10;
        }
    }

    public class Test
    {
        public int number;

        public string name;
    }
}
