namespace ConsoleApp_lab8
{
    public delegate void DisplayMessage(string message);
    public delegate int MyDelegate(int a, int b);
    public delegate bool Predicate(int num);
    class Program
    {
        static void Main()
        {
            //1
            Console.WriteLine("Standart  ");
            DisplayMessage displayMessage = ShowMessage;
            displayMessage("Hello, world!");

            Console.WriteLine("Upper  ");
            displayMessage = ShowUpperCaseMessage;
            displayMessage("Hello, world!");

            Console.WriteLine("Lower  ");
            displayMessage = ShowLowerCaseMessage;
            displayMessage("Hello, world!");

            //2

            MyDelegate myDelegate = null;
            Console.WriteLine("Enter 2 number : ");
            int num1 = int.Parse(Console.ReadLine());
            int num2 = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter '1' = +; '2' = -; '3' = *; '4' = /; ");
            int s = int.Parse(Console.ReadLine());

            switch (s)
            {
                case 1:
                    myDelegate = Add;

                    break;
                case 2:
                    myDelegate = Substract;

                    break;
                case 3:
                    myDelegate = Multiplication;

                    break;
                case 4:
                    myDelegate = Division;

                    break;
                default:
                    Console.WriteLine("Error!");
                    break;
            }

            int res = myDelegate(num1, num2);
            Console.WriteLine($"  res  {res}");

            //3
            Console.WriteLine("Enter your number");
            int num = int.Parse(Console.ReadLine());
            Console.WriteLine($"number {num} ");
            Predicate<int> isEven = x => x % 2 == 0;
            Predicate<int> isOdd = x => x % 2 != 0;
            Predicate<int> isPrime = IsPrime;
            Predicate<int> isFibonacci = IsFibonacci;

            Console.WriteLine("{0} is even: {1}", num, isEven(num));
            Console.WriteLine("{0} is odd: {1}", num, isOdd(num));
            Console.WriteLine("{0} is prime: {1}", num, isPrime(num));
            Console.WriteLine("{0} is Fibonacci: {1}", num, isFibonacci(num));





        }


        static bool IsPrime(int num)
        {
            if (num <= 1)
            {
                return false;
            }

            for (int i = 2; i <= Math.Sqrt(num); i++)
            {
                if (num % i == 0)
                {
                    return false;
                }
            }

            return true;
        }

        static bool IsFibonacci(int num)
        {
            if (num == 0 || num == 1)
            {
                return true;
            }

            int prev = 0;
            int curr = 1;

            while (curr < num)
            {
                int next = prev + curr;
                prev = curr;
                curr = next;
            }

            return curr == num;
        }
        public static int Add(int a, int b)
        {
            return a + b;
        }

        public static int Substract(int a, int b)
        {
            return a - b;
        }

        public static int Multiplication(int a, int b)
        {
            return a * b;
        }

        public static int Division(int a, int b)
        {
            return a / b;
        }
        public static void ShowMessage(string message)
        {
            Console.WriteLine(message);
        }

        public static void ShowUpperCaseMessage(string message)
        {
            Console.WriteLine(message.ToUpper());
        }

        public static void ShowLowerCaseMessage(string message)
        {
            Console.WriteLine(message.ToLower());
        }
    }
}