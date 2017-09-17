using System;

namespace hello
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("What's your name: ");
            var name = Console.ReadLine();
            var message = logic.HelloWorld.GetMessage(name);
            Console.WriteLine(message);
        }
    }
}
