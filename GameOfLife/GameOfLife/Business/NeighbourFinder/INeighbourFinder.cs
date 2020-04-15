using GameOfLife.Business.Cell;

namespace GameOfLife.Business.NeighbourFinder
{
    public interface INeighbourFinder
    {
        public ReadOnlyGrid GetThreeByThreeGridAroundCell(CellPosition cellPosition);
    }
}