using GameOfLife;
using GameOfLife.Business;
using NUnit.Framework;

namespace GameOfLifeTests
{
    public class CellTests
    {
        [Test]
        public void It_Should_Change_State_To_Dead_Given_Kill()
        {
            var cell = new Cell();
            cell.Kill();
            Assert.AreEqual(CellState.Dead, cell.GetState());
        }
        
        [Test]
        public void It_Should_Change_State_To_Alive_Given_Revive()
        {
            var cell = new Cell();
            cell.Revive();
            Assert.AreEqual(CellState.Alive, cell.GetState());
        }
    }
}