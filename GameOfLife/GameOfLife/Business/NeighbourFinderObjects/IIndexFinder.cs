using GameOfLife.Business.CellObjects;
using GameOfLife.Business.GridObjects;

namespace GameOfLife.Business.NeighbourFinderObjects
{
    public interface IIndexFinder
    {
        IndexSet GetIndexSet(ReadOnlyGrid grid, CellPosition cellPosition);
    }
}