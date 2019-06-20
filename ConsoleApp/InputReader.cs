using System;

namespace ConsoleApp
{
    public class InputReader : IInputReader
    {
        public string Read()
        {
            return Console.ReadLine();
        }
    }
}