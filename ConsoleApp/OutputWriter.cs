using System;

namespace ConsoleApp
{
    public class OutputWriter : IOutputWriter
    {
        public void Write(string message)
        {
            Console.WriteLine(message);
        }
    }
}