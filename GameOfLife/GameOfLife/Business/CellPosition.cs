namespace GameOfLife.Business
{
    public class CellPosition
    {
        public int Row { get; private set; }
        public int Column { get; private set; }

        public CellPosition(int row, int column)
        {
            Row = row;
            Column = column;
        }
    }
}