using GameOfLife.Business.Cell;
using GameOfLife.Business.Grid;

namespace GameOfLife.Business.NeighbourFinder
{
    public interface IIndexFinder
    {
        public IndexSet GetIndexSet(ReadOnlyGrid grid, CellPosition cellPosition);
    }
}