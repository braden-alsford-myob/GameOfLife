using System.Collections.Generic;
using System.Linq;
using GameOfLife.Business.CellObjects;
using GameOfLife.Business.GridObjects;
using NUnit.Framework;

namespace GameOfLifeTests.Business
{
    public class GridCreationTests
    {
        [TestCaseSource(nameof(GridData))]
        public void It_Should_Initialise_A_New_Grid_Of_The_Correct_Size(int height, int width)
        {
            var grid = new Grid(height, width);
            Assert.AreEqual(height, grid.GetRows().Count);
            Assert.AreEqual(width, grid.GetRows()[0].Count);
        }

        [TestCaseSource(nameof(GridData))]
        public void It_Should_Set_All_Cells_To_Be_Dead_On_Initialisation(int height, int width)
        {
            var grid = new Grid(height, width);

            foreach (var cell in grid.GetRows().SelectMany(row => row))
            {
                Assert.AreEqual(CellState.Dead, cell.GetState());
            }
        }

        private static IEnumerable<TestCaseData> GridData
        {
            get
            {
                yield return new TestCaseData(1, 1);
                yield return new TestCaseData(10, 10);
                yield return new TestCaseData(30, 50);
                yield return new TestCaseData(100, 100);
                
            }
        }
        
    }
}