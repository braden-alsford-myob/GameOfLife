using System.Collections.Generic;
using System.Collections.ObjectModel;
using GameOfLife.Business.Cell;
using GameOfLife.Business.Grid;

namespace GameOfLife.Business.NeighbourFinderPieces
{
    public class NeighbourFinder
    {
        private readonly IIndexFinder _indexFinder;
        private readonly ReadOnlyGrid _grid;
        
        public NeighbourFinder(ReadOnlyGrid grid, IIndexFinder indexFinder)
        {
            _indexFinder = indexFinder;
            _grid = grid;
        }

        public ReadOnlyGrid GetThreeByThreeGridAroundCell(CellPosition cellPosition)
        {
            var indexSet = _indexFinder.GetIndexSet(_grid, cellPosition);
            
            var rows = new List<ReadOnlyCollection<ReadOnlyCell>>
            {
                new ReadOnlyCollection<ReadOnlyCell>(GetAboveRow(indexSet)),
                new ReadOnlyCollection<ReadOnlyCell>(GetMiddleRow(indexSet)),
                new ReadOnlyCollection<ReadOnlyCell>(GetBelowRow(indexSet))
            };

            return new ReadOnlyGrid(new ReadOnlyCollection<ReadOnlyCollection<ReadOnlyCell>>(rows));
        }
        
        private List<ReadOnlyCell> GetAboveRow(IndexSet indexSet)
        {
            return new List<ReadOnlyCell>
            {
                _grid.Rows[indexSet.AboveRowIndex][indexSet.LeftColumnIndex],
                _grid.Rows[indexSet.AboveRowIndex][indexSet.CurrentColumnIndex],
                _grid.Rows[indexSet.AboveRowIndex][indexSet.RightColumnIndex]
            };
        }
        
        private List<ReadOnlyCell> GetMiddleRow(IndexSet indexSet)
        {
            return new List<ReadOnlyCell>
            {
                _grid.Rows[indexSet.CurrentRowIndex][indexSet.LeftColumnIndex],
                _grid.Rows[indexSet.CurrentRowIndex][indexSet.CurrentColumnIndex],
                _grid.Rows[indexSet.CurrentRowIndex][indexSet.RightColumnIndex]
            };
        }
        
        private List<ReadOnlyCell> GetBelowRow(IndexSet indexSet)
        {
            return new List<ReadOnlyCell>
            {
                _grid.Rows[indexSet.BelowRowIndex][indexSet.LeftColumnIndex],
                _grid.Rows[indexSet.BelowRowIndex][indexSet.CurrentColumnIndex],
                _grid.Rows[indexSet.BelowRowIndex][indexSet.RightColumnIndex]
            };
        }
    }
}