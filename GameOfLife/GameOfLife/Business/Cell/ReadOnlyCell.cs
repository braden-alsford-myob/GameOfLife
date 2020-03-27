namespace GameOfLife.Business.Cell
{
    public class ReadOnlyCell : ICell
    {
        private readonly CellState _state;
        
        public ReadOnlyCell(CellState state)
        {
            _state = state;
        }
        
        public CellState GetState()
        {
            return _state;
        }
    }
}