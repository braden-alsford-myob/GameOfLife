using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Drawing;
using System.Linq;
using GameOfLife.Business.Cell;

namespace GameOfLife.Business
{
    public class EdgeWrappingNeighbourFinder
    {
        private readonly ReadOnlyCollection<ReadOnlyCollection<ReadOnlyCell>> _grid;
        
        private int _aboveRowIndex;
        private int _currentRowIndex;
        private int _belowRowIndex;
        private int _leftColumnIndex;
        private int _currentColumnIndex;
        private int _rightColumnIndex;
        
        public EdgeWrappingNeighbourFinder(ReadOnlyCollection<ReadOnlyCollection<ReadOnlyCell>> grid)
        {
            _grid = grid;
        }

        public ReadOnlyCollection<ReadOnlyCollection<ReadOnlyCell>> GetThreeByThreeGridAroundCell(CellPosition cellPosition)
        {
            SetIndexValues(cellPosition);

            var rows = new List<ReadOnlyCollection<ReadOnlyCell>>
            {
                new ReadOnlyCollection<ReadOnlyCell>(GetAboveRow()),
                new ReadOnlyCollection<ReadOnlyCell>(GetMiddleRow()),
                new ReadOnlyCollection<ReadOnlyCell>(GetBelowRow())
            };

            return new ReadOnlyCollection<ReadOnlyCollection<ReadOnlyCell>>(rows);
            
        }

        private void SetIndexValues(CellPosition cellPosition)
        {
            _aboveRowIndex = _getAboveRowIndex(cellPosition.Row);
            _currentRowIndex = cellPosition.Row;
            _belowRowIndex = _getBelowRowIndex(cellPosition.Row);
            
            _leftColumnIndex = _getLeftColumnIndex(cellPosition);
            _currentColumnIndex = cellPosition.Column;
            _rightColumnIndex = _getRightColumnIndex(cellPosition);
        }
        
        private List<ReadOnlyCell> GetAboveRow()
        {
            return new List<ReadOnlyCell>
            {
                _grid[_aboveRowIndex][_leftColumnIndex],
                _grid[_aboveRowIndex][_currentColumnIndex],
                _grid[_aboveRowIndex][_rightColumnIndex]
            };
        }
        
        private List<ReadOnlyCell> GetMiddleRow()
        {
            return new List<ReadOnlyCell>
            {
                _grid[_currentRowIndex][_leftColumnIndex],
                _grid[_currentRowIndex][_currentColumnIndex],
                _grid[_currentRowIndex][_rightColumnIndex]
            };
        }
        
        private List<ReadOnlyCell> GetBelowRow()
        {
            return new List<ReadOnlyCell>
            {
                _grid[_belowRowIndex][_leftColumnIndex],
                _grid[_belowRowIndex][_currentColumnIndex],
                _grid[_belowRowIndex][_rightColumnIndex]
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
    }
}