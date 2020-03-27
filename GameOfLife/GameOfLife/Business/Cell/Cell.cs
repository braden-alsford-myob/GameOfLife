namespace GameOfLife.Business.Cell
{
    public class Cell : ICell
    {
        private CellState _state;

        public Cell()
        {
            _state = CellState.Dead;
        }

        public void Kill()
        {
            _state = CellState.Dead;
        }

        public void Revive()
        {
            _state = CellState.Alive;
        }

        public CellState GetState()
        {
            return _state;
        }

        public ReadOnlyCell GetReadOnlyVersion()
        {
            return new ReadOnlyCell(_state);
        }
    }
}