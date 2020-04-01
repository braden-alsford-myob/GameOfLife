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

        public CellState GetCellState(int row, int column)
        {
            return Grid[row][column].GetState();
        }

        public bool Equals(ReadOnlyGrid otherGrid)
        {

            if (!SameSize(Grid, otherGrid.Grid)) return false;
            for (var i = 0; i < Grid.Count; i++)
            {
                if (!SameRowStates(Grid[i], otherGrid.Grid[i])) return false;
            }

            return true;
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

        private static bool SameRowStates(IEnumerable<ReadOnlyCell> row, IReadOnlyList<ReadOnlyCell> otherRow)
        {
            return !row.Where((cell, i) => cell.GetState() != otherRow[i].GetState()).Any();
        }
    }
}