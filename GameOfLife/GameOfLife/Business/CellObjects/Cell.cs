namespace GameOfLife.Business.CellObjects
{
    public class Cell : ICell
    {
        private CellState _state;

        public Cell(CellState state)
        {
            _state = state;
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
    }
}