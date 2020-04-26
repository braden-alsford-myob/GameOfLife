using GameOfLife.Business.Cell;
using GameOfLife.Business.Grid;

namespace GameOfLife.Business.NeighbourFinderPieces
{
    public interface IIndexFinder
    {
        IndexSet GetIndexSet(ReadOnlyGrid grid, CellPosition cellPosition);
    }
}