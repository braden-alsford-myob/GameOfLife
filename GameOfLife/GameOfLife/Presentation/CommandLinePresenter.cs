using System;
using System.Collections.ObjectModel;
using GameOfLife.Business;
using GameOfLife.Business.Cell;

namespace GameOfLife.Presentation
{
    public class CommandLinePresenter : IPresenter
    {
        private const string AliveRepresentation = "🧻 ";
        private const string DeadRepresentation = "   ";

        public void Display(ReadOnlyGrid grid)
        {
            Clear();

            foreach (var row in grid.Grid)
            {
                PrintRow(row);
            }
        }

        private static void PrintRow(ReadOnlyCollection<ReadOnlyCell> row)
        {
            Write("|");
            foreach (var cell in row)
            {
                PrintCell(cell);
            }
            
            Write("|\n");
        }

        private static void PrintCell(ICell cell)
        {
            Write(cell.GetState() == CellState.Alive ? AliveRepresentation : DeadRepresentation);
        }

        private static void Write(string content)
        {
            Console.Write(content);
        }
        
        private static void Clear()
        {
            Console.Clear();
        }
    }
}