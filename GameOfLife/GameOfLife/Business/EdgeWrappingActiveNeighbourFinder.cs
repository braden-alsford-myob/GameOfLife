using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using GameOfLife.Business.Cell;

namespace GameOfLife.Business
{
    public class EdgeWrappingActiveNeighbourFinder
    {
        private IReadOnlyList<IReadOnlyList<ICell>> _grid;
        
        public EdgeWrappingActiveNeighbourFinder(IReadOnlyList<IReadOnlyList<ICell>> grid)
        {
            _grid = grid;
        }
        
        public int GetActiveNeighbourCount(CellPosition cellPosition)
        {
            var neighbourCellLocations = _getNeighbouringCellPositions(cellPosition);
            return neighbourCellLocations.Count(_cellIsActive);
        }

        private List<CellPosition> _getNeighbouringCellPositions(CellPosition cellPosition)
        {
            var aboveRow = _getAboveRowIndex(cellPosition.Row);
            var currentRow = cellPosition.Row;
            var belowRow = _getBelowRowIndex(cellPosition.Row);
            
            var leftColumn = _getLeftColumnIndex(cellPosition);
            var currentColumn = cellPosition.Column;
            var rightColumn = _getRightColumnIndex(cellPosition);
            
            return new List<CellPosition>
            {
                new CellPosition(aboveRow, leftColumn),
                new CellPosition(aboveRow, currentColumn),
                new CellPosition(aboveRow, rightColumn),
                
                new CellPosition(currentRow, leftColumn),
                new CellPosition(currentRow, rightColumn),
                
                new CellPosition(belowRow, leftColumn),
                new CellPosition(belowRow, currentColumn),
                new CellPosition(belowRow, rightColumn)
            };
        }

        private int _getAboveRowIndex(int cellRowIndex)
        {
            if (cellRowIndex - 1 < 0) return _grid.Count - 1;
            return cellRowIndex - 1;
        }
        
        private int _getBelowRowIndex(int cellRowIndex)
        {
            if (cellRowIndex + 1 > _grid.Count - 1) return 0;
            return cellRowIndex + 1;
        }
        
        private int _getLeftColumnIndex(CellPosition cellPosition)
        {
            if (cellPosition.Column - 1 < 0) return _grid[cellPosition.Row].Count - 1;
            return cellPosition.Column - 1;
        }
        
        private int _getRightColumnIndex(CellPosition cellPosition)
        {
            if (cellPosition.Column + 1 > _grid[cellPosition.Row].Count - 1) return 0;
            return cellPosition.Column + 1;
        }
        
        private bool _cellIsActive(CellPosition cellPositions)
        {
            return _grid[cellPositions.Row][cellPositions.Column].GetState() == CellState.Alive;
        }
    }
}