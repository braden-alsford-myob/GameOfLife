using System.Collections.ObjectModel;
using GameOfLife.Business;
using GameOfLife.Business.CellObjects;

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

            var printableGeneration = "";
            
            foreach (var row in generation.Grid.Rows)
            {
                printableGeneration += GetPrintableRow(row);
            }

            printableGeneration += GetPrintableGenerationCount(generation.Count);
            
            _writer.WriteLine(printableGeneration);
        }

        private string GetPrintableRow(ReadOnlyCollection<ReadOnlyCell> cellsRow)
        {
            var row = OutputConstants.RowEdge;
            
            foreach (var cell in cellsRow)
            {
                row += GetCellRepresentation(cell);
            }
            
            row += OutputConstants.RowEdge;
            row += OutputConstants.NewLine;

            return row;
        }

        private string GetCellRepresentation(ReadOnlyCell cell)
        {
            return cell.GetState() == CellState.Alive
                ? OutputConstants.AliveRepresentation
                : OutputConstants.DeadRepresentation;
        }
        
        private string GetPrintableGenerationCount(int generationCount)
        {
            return string.Concat(
                OutputConstants.NewLine, 
                OutputConstants.GenerationCount, 
                generationCount);
        }
    }
}