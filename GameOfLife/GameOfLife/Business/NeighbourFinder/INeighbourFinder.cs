using GameOfLife.Business.Cell;
using GameOfLife.Business.Grid;

namespace GameOfLife.Business.NeighbourFinder
{
    public interface INeighbourFinder
    {
        public ReadOnlyGrid GetThreeByThreeGridAroundCell(CellPosition cellPosition);
    }
}