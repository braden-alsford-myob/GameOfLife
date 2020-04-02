using GameOfLife.Business;
using GameOfLife.Business.Cell;
using NUnit.Framework;

namespace GameOfLifeTests
{
    public class CellTests
    {
        [Test]
        public void It_Should_Change_State_To_Dead_Given_Kill()
        {
            var cell = new Cell(CellState.Alive);
            cell.Kill();
            Assert.AreEqual(CellState.Dead, cell.GetState());
        }
        
        [Test]
        public void It_Should_Change_State_To_Alive_Given_Revive()
        {
            var cell = new Cell(CellState.Dead);
            cell.Revive();
            Assert.AreEqual(CellState.Alive, cell.GetState());
        }
    }
}