namespace GameOfLife.Presentation
{
    public interface IWriter
    {
        void WriteLine(string content);
        void Clear();
    }
}