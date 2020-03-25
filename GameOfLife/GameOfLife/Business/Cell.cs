using GameOfLife.Business;

namespace GameOfLife
{
    public class Cell
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
    }
}