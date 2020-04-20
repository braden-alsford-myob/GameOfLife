namespace GameOfLife.Presentation
{
    public interface IWriter
    {
        public void WriteLine(string content);
        public void Clear();
    }
}