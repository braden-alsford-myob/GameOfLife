namespace GameOfLife.Business.Cell
{
    public class Cell : ICell
    {
        private CellState _state;

        //Obsolete i think... TODO
        public Cell()
        {
            _state = CellState.Dead;
        }        
        
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