using System;

namespace GameOfLife.Presentation
{
    public class Writer : IWriter
    {
        public void WriteLine(string content)
        {
            Console.WriteLine(content);
        }
        
        public void Clear()
        {
            Console.Clear();
        }
    }
}