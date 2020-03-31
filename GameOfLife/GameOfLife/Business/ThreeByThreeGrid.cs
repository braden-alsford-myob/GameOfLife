using System.Collections.ObjectModel;
using GameOfLife.Business.Cell;

namespace GameOfLife.Business
{
    public class ThreeByThreeGrid
    {
        private readonly ReadOnlyCollection<ReadOnlyCollection<ReadOnlyCell>> _grid;

        public ThreeByThreeGrid(ReadOnlyCollection<ReadOnlyCollection<ReadOnlyCell>> grid)
        {
            _grid = grid;
        }

        public CellState GetCellState(int row, int column)
        {
            return _grid[row][column].GetState();
        }
    }
}