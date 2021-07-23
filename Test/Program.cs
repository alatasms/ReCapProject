using System;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            Guid guid = Guid.NewGuid();
            Console.WriteLine("Guid {0}",guid);
        }
    }
}
