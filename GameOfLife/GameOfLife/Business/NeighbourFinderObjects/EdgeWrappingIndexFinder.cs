using GameOfLife.Business.CellObjects;
using GameOfLife.Business.GridObjects;

namespace GameOfLife.Business.NeighbourFinderObjects
{
    public class EdgeWrappingIndexFinder : IIndexFinder
    {
        public IndexSet GetIndexSet(ReadOnlyGrid grid, CellPosition cellPosition)
        {
            return new IndexSet(
                GetAboveRowIndex(grid, cellPosition.Row),
                cellPosition.Row,
                GetBelowRowIndex(grid, cellPosition.Row),
                GetLeftColumnIndex(grid, cellPosition),
                cellPosition.Column,
                GetRightColumnIndex(grid, cellPosition)
                );
        }
        
        private static int GetAboveRowIndex(ReadOnlyGrid grid, int cellRowIndex)
        {
            if (cellRowIndex - 1 < 0) return grid.Rows.Count - 1;
            return cellRowIndex - 1;
        }
        
        private static int GetBelowRowIndex(ReadOnlyGrid grid, int cellRowIndex)
        {
            if (cellRowIndex + 1 > grid.Rows.Count - 1) return 0;
            return cellRowIndex + 1;
        }
        
        private static int GetLeftColumnIndex(ReadOnlyGrid grid, CellPosition cellPosition)
        {
            if (cellPosition.Column - 1 < 0) return grid.Rows[cellPosition.Row].Count - 1;
            return cellPosition.Column - 1;
        }
        
        private static int GetRightColumnIndex(ReadOnlyGrid grid, CellPosition cellPosition)
        {
            if (cellPosition.Column + 1 > grid.Rows[cellPosition.Row].Count - 1) return 0;
            return cellPosition.Column + 1;
        }
    }
}