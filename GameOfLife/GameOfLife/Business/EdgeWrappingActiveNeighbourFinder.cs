using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace GameOfLife.Business
{
    public class EdgeWrappingActiveNeighbourFinder
    {
        private List<List<Cell>> _grid;

        public EdgeWrappingActiveNeighbourFinder(List<List<Cell>> grid)
        {
            _grid = grid;
        }
        
        public int GetActiveNeighbourCount(CellPosition cellPosition)
        {
            var neighbourCellLocations = _getNeighbourLocations(cellPosition);
            return neighbourCellLocations.Count(_cellIsActive);
        }

        private List<CellPosition> _getNeighbourLocations(CellPosition cellPosition)
        {
            var aboveRowIndex = _getAboveRowIndex(cellPosition.Row);
            var currentRowIndex = cellPosition.Row;
            var belowRowIndex = _getBelowRowIndex(cellPosition.Row);
            
            var leftColumnIndex = _getLeftColumnIndex(cellPosition);
            var currentColumnIndex = cellPosition.Column;
            var rightColumnIndex = _getRightColumnIndex(cellPosition);
            
            return new List<CellPosition>
            {
                new CellPosition(aboveRowIndex, leftColumnIndex),
                new CellPosition(aboveRowIndex, currentColumnIndex),
                new CellPosition(aboveRowIndex, rightColumnIndex),
                
                new CellPosition(currentRowIndex, leftColumnIndex),
                new CellPosition(currentRowIndex, rightColumnIndex),
                
                new CellPosition(belowRowIndex, leftColumnIndex),
                new CellPosition(belowRowIndex, currentColumnIndex),
                new CellPosition(belowRowIndex, rightColumnIndex)
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