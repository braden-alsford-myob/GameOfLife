using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using GameOfLife.Business.Cell;

namespace GameOfLife.Business
{
    public class ReadOnlyGrid
    {
        public readonly ReadOnlyCollection<ReadOnlyCollection<ReadOnlyCell>> Grid;

        public ReadOnlyGrid(ReadOnlyCollection<ReadOnlyCollection<ReadOnlyCell>> grid)
        {
            Grid = grid;
        }

        public ReadOnlyGrid(List<List<Cell.Cell>> grid)
        {
            Grid = CreateReadOnlyGrid(grid);
        }

        public CellState GetCellState(CellPosition position)
        {
            return Grid[position.Row][position.Column].GetState();
        }

        public bool Equals(ReadOnlyGrid otherGrid)
        {
            return SameSize(Grid, otherGrid.Grid) && SameStates(Grid, otherGrid.Grid);
        }

        private static ReadOnlyCollection<ReadOnlyCollection<ReadOnlyCell>> CreateReadOnlyGrid(List<List<Cell.Cell>> grid)
        {
            var readOnlyRows = new List<ReadOnlyCollection<ReadOnlyCell>>();
            
            foreach (var row in grid)
            {
                var readOnlyRow = row.Select(cell => new ReadOnlyCell(cell.GetState())).ToList();
                readOnlyRows.Add( new ReadOnlyCollection<ReadOnlyCell>(readOnlyRow));
            }
            
            return new ReadOnlyCollection<ReadOnlyCollection<ReadOnlyCell>>(readOnlyRows);
        }

        private static bool SameSize(IReadOnlyList<ReadOnlyCollection<ReadOnlyCell>> thisGrid, 
            IReadOnlyList<ReadOnlyCollection<ReadOnlyCell>> otherGrid)
        {
            if (thisGrid.Count != otherGrid.Count) return false;
            for (var i = 0; i < thisGrid.Count; i++)
            {
                if (thisGrid[i].Count != otherGrid[i].Count) return false;
            }

            return true;
        }

        private static bool SameStates(IReadOnlyList<ReadOnlyCollection<ReadOnlyCell>> thisGrid, 
            IReadOnlyList<ReadOnlyCollection<ReadOnlyCell>> otherGrid)
        {
            for (var i = 0; i < thisGrid.Count; i++)
            {
                if (!SameRowStates(thisGrid[i], otherGrid[i])) return false;
            }

            return true;
        }

        private static bool SameRowStates(IEnumerable<ReadOnlyCell> row, IReadOnlyList<ReadOnlyCell> otherRow)
        {
            return !row.Where((cell, i) => cell.GetState() != otherRow[i].GetState()).Any();
        }
    }
}