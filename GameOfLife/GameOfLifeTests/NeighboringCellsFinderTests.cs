using System.Collections.Generic;
using System.Linq;
using GameOfLife;
using GameOfLife.Business;
using NUnit.Framework;

namespace GameOfLifeTests
{
    public class NeighboringCellsFinderTests
    {
        private List<List<Cell>> _grid;
        
        [SetUp]
        public void Setup()
        {
            _grid = new List<List<Cell>>
            {
                new List<Cell>{new Cell(), new Cell(), new Cell()},
                new List<Cell>{new Cell(), new Cell(), new Cell()},
                new List<Cell>{new Cell(), new Cell(), new Cell()}
            };
        }

        [Test]
        public void It_Should_Return_Eight_Given_A_Cell_Surrounded_By_Active_Cells()
        {
            foreach (var cell in _grid.SelectMany(row => row))
            {
                cell.Revive();
            }
            
            var neighbourFinder = new EdgeWrappingActiveNeighbourFinder(_grid);
            var activeNeighbourCount = neighbourFinder.GetActiveNeighbourCount(new CellPosition(1, 1));
            
            Assert.AreEqual(8, activeNeighbourCount);
        }
        
        [Test]
        public void It_Should_Return_Zero_Given_A_Cell_Surrounded_By_Dead_Cells()
        {
            foreach (var cell in _grid.SelectMany(row => row))
            {
                cell.Kill();
            }

            var neighbourFinder = new EdgeWrappingActiveNeighbourFinder(_grid);
            var activeNeighbourCount = neighbourFinder.GetActiveNeighbourCount(new CellPosition(1, 1));
            
            Assert.AreEqual(0, activeNeighbourCount);
        }
        
        [Test]
        public void It_Should_Return_Four_Given_A_Cell_Surrounded_By_Alive_Cells_On_Every_Corner()
        {
            var count = 0;
            foreach (var cell in _grid.SelectMany(row => row))
            {
                if (count % 2 == 0)
                {
                    cell.Revive();
                }
                else
                {
                    cell.Kill();
                }

                count++;
            }

            var neighbourFinder = new EdgeWrappingActiveNeighbourFinder(_grid);
            var activeNeighbourCount = neighbourFinder.GetActiveNeighbourCount(new CellPosition(1, 1));
            
            Assert.AreEqual(4, activeNeighbourCount);
        }
        
        [Test]
        public void It_Should_Return_Four_Given_A_Cell_Surrounded_By_Alive_Cells_On_Every_Edge()
        {
            var count = 0;
            foreach (var cell in _grid.SelectMany(row => row))
            {
                if (count % 2 == 0)
                {
                    cell.Kill();
                }
                else
                {
                    cell.Revive();
                }

                count++;
            }

            var neighbourFinder = new EdgeWrappingActiveNeighbourFinder(_grid);
            var activeNeighbourCount = neighbourFinder.GetActiveNeighbourCount(new CellPosition(1, 1));
            
            Assert.AreEqual(4, activeNeighbourCount);
        }
        
        [Test]
        public void It_Should_Return_Eight_Given_A_Top_Left_Corner_Cell_Surrounded_By_Alive_Cells()
        {
            foreach (var cell in _grid.SelectMany(row => row))
            {
                cell.Revive();
            }

            var neighbourFinder = new EdgeWrappingActiveNeighbourFinder(_grid);
            var activeNeighbourCount = neighbourFinder.GetActiveNeighbourCount(new CellPosition(0, 0));
            
            Assert.AreEqual(8, activeNeighbourCount);
        }
        
        [Test]
        public void It_Should_Return_Eight_Given_A_Top_Right_Corner_Cell_Surrounded_By_Alive_Cells()
        {
            foreach (var cell in _grid.SelectMany(row => row))
            {
                cell.Revive();
            }

            var neighbourFinder = new EdgeWrappingActiveNeighbourFinder(_grid);
            var activeNeighbourCount = neighbourFinder.GetActiveNeighbourCount(new CellPosition(0, 2));
            
            Assert.AreEqual(8, activeNeighbourCount);
        }
        
        [Test]
        public void It_Should_Return_Eight_Given_A_Bottom_Left_Corner_Cell_Surrounded_By_Alive_Cells()
        {
            foreach (var cell in _grid.SelectMany(row => row))
            {
                cell.Revive();
            }

            var neighbourFinder = new EdgeWrappingActiveNeighbourFinder(_grid);
            var activeNeighbourCount = neighbourFinder.GetActiveNeighbourCount(new CellPosition(2, 0));
            
            Assert.AreEqual(8, activeNeighbourCount);
        }
        
        [Test]
        public void It_Should_Return_Eight_Given_A_Bottom_Right_Corner_Cell_Surrounded_By_Alive_Cells()
        {
            foreach (var cell in _grid.SelectMany(row => row))
            {
                cell.Revive();
            }

            var neighbourFinder = new EdgeWrappingActiveNeighbourFinder(_grid);
            var activeNeighbourCount = neighbourFinder.GetActiveNeighbourCount(new CellPosition(2, 2));
            
            Assert.AreEqual(8, activeNeighbourCount);
        }
    }
}