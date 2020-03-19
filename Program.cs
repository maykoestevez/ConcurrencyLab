using System;

namespace ConcurrencyLab
{
    class Program
    {
        static void Main(string[] args)
        {
            //Test Delay
            var delayTask = new Delay<string>();
            Console.WriteLine(delayTask.DelayTask("Hola After 5 seconds", TimeSpan.FromSeconds(5)).Result);
        }
    }
}
