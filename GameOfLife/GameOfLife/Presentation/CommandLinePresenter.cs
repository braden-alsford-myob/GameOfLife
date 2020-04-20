using System.Collections.ObjectModel;
using System.Linq;
using GameOfLife.Business;
using GameOfLife.Business.Cell;

namespace GameOfLife.Presentation
{
    public class CommandLinePresenter : IPresenter
    {
        private readonly IWriter _writer;
        
        public CommandLinePresenter(IWriter writer)
        {
            _writer = writer;
        }
        
        public void Display(GenerationViewModel generation)
        {
            _writer.Clear();
            
            foreach (var row in generation.Grid.Rows)
            {
                PrintRow(row);
            }
            
            PrintGenerationCount(generation.Count);
        }

        private void PrintGenerationCount(int generationCount)
        {
            var generationCountOutput = string.Concat(
                    OutputConstants.NewLine, 
                    OutputConstants.GenerationCount, 
                    generationCount);
            
            _writer.WriteLine(generationCountOutput);
        }

        private void PrintRow(ReadOnlyCollection<ReadOnlyCell> cellsRow)
        {
            var row = OutputConstants.RowEdge;

            foreach (var cell in cellsRow)
            {
                row += GetCellRepresentation(cell);
            }

            row += OutputConstants.RowEdge;

            _writer.WriteLine(row);
        }

        private string GetCellRepresentation(ReadOnlyCell cell)
        {
            return cell.GetState() == CellState.Alive
                ? OutputConstants.AliveRepresentation
                : OutputConstants.DeadRepresentation;
        }
    }
}