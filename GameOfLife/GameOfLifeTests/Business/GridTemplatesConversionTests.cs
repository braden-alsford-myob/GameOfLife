using System.Collections.Generic;
using GameOfLife.Business.CellObjects;
using GameOfLife.Business.GridObjects;
using GameOfLifeTests.Helpers;
using NUnit.Framework;

namespace GameOfLifeTests.Business
{
    public class GridTemplatesConversionTests
    {
        [TestCaseSource(nameof(Templates))]
        public void Templates_Should_Be_Converted(string stringRepresentation, Grid expected)
        {
            var grid = StringTemplateToGridConverter.Convert(stringRepresentation);
            
            var readOnlyGrid = new ReadOnlyGrid(grid);
            var readOnlyExpected = new ReadOnlyGrid(expected);

            Assert.True(readOnlyGrid.Equals(readOnlyExpected));
        }
        
        private static IEnumerable<TestCaseData> Templates
        {
            get
            {
                yield return new TestCaseData(
                    GridTemplates.Glider,
                    BasicGliderFrameCreator.GetFrame(1));
                                
                yield return new TestCaseData(
                    "000\n" +
                    "111",
                    new Grid(new List<List<Cell>>
                    {
                        new List<Cell>
                        {
                            new Cell(CellState.Dead),
                            new Cell(CellState.Dead),
                            new Cell(CellState.Dead)
                        },
                        new List<Cell>
                        {
                            new Cell(CellState.Alive),
                            new Cell(CellState.Alive),
                            new Cell(CellState.Alive)
                        }
                    }));
            }
        }
    }
}