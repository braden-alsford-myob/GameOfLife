using System.Collections.Generic;
using System.Collections.ObjectModel;
using GameOfLife.Business.Cell;
using GameOfLife.Business.Grid;

namespace GameOfLife.Business.NeighbourFinder
{
    public class EdgeWrappingNeighbourFinder : INeighbourFinder
    {
        private readonly ReadOnlyCollection<ReadOnlyCollection<ReadOnlyCell>> _rows;
        
        private int _aboveRowIndex;
        private int _currentRowIndex;
        private int _belowRowIndex;
        private int _leftColumnIndex;
        private int _currentColumnIndex;
        private int _rightColumnIndex;
        
        public EdgeWrappingNeighbourFinder(ReadOnlyGrid readOnlyGrid)
        {
            _rows = readOnlyGrid.Rows;
        }

        public ReadOnlyGrid GetThreeByThreeGridAroundCell(CellPosition cellPosition)
        {
            SetIndexValues(cellPosition);

            var rows = new List<ReadOnlyCollection<ReadOnlyCell>>
            {
                new ReadOnlyCollection<ReadOnlyCell>(GetAboveRow()),
                new ReadOnlyCollection<ReadOnlyCell>(GetMiddleRow()),
                new ReadOnlyCollection<ReadOnlyCell>(GetBelowRow())
            };

            return new ReadOnlyGrid(new ReadOnlyCollection<ReadOnlyCollection<ReadOnlyCell>>(rows));
            
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
                _rows[_aboveRowIndex][_leftColumnIndex],
                _rows[_aboveRowIndex][_currentColumnIndex],
                _rows[_aboveRowIndex][_rightColumnIndex]
            };
        }
        
        private List<ReadOnlyCell> GetMiddleRow()
        {
            return new List<ReadOnlyCell>
            {
                _rows[_currentRowIndex][_leftColumnIndex],
                _rows[_currentRowIndex][_currentColumnIndex],
                _rows[_currentRowIndex][_rightColumnIndex]
            };
        }
        
        private List<ReadOnlyCell> GetBelowRow()
        {
            return new List<ReadOnlyCell>
            {
                _rows[_belowRowIndex][_leftColumnIndex],
                _rows[_belowRowIndex][_currentColumnIndex],
                _rows[_belowRowIndex][_rightColumnIndex]
            };
        }
        
        private int _getAboveRowIndex(int cellRowIndex)
        {
            if (cellRowIndex - 1 < 0) return _rows.Count - 1;
            return cellRowIndex - 1;
        }
        
        private int _getBelowRowIndex(int cellRowIndex)
        {
            if (cellRowIndex + 1 > _rows.Count - 1) return 0;
            return cellRowIndex + 1;
        }
        
        private int _getLeftColumnIndex(CellPosition cellPosition)
        {
            if (cellPosition.Column - 1 < 0) return _rows[cellPosition.Row].Count - 1;
            return cellPosition.Column - 1;
        }
        
        private int _getRightColumnIndex(CellPosition cellPosition)
        {
            if (cellPosition.Column + 1 > _rows[cellPosition.Row].Count - 1) return 0;
            return cellPosition.Column + 1;
        }
    }
}