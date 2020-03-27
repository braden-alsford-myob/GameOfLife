using System.Collections.Generic;
using GameOfLife.Business;
using GameOfLife.Business.Exceptions;
using NUnit.Framework;
using Rule = GameOfLife.Business.Rule;

namespace GameOfLifeTests
{
    public class RuleTests
    {

        private Rule _overcrowdingRule;
        
        [SetUp]
        public void Setup()
        {
            _overcrowdingRule = new Rule(
                new HashSet<CellState>{CellState.Alive},
                new HashSet<int> {4, 5, 6, 7, 8}, CellState.Dead);
        }

        [Test]
        public void 
            It_Should_Throw_A_RuleInvalidException_When_Trying_To_Create_A_Rule_With_An_Empty_RequiredInitialStates()
        {
            void CheckFunction()
            {
                var invalidRule = new Rule(
                    new HashSet<CellState>(),
                    new HashSet<int> {1, 2, 3, 4, 5, 6, 7, 8}, CellState.Dead);
            }
            
            Assert.Throws(typeof(RuleInvalidException), CheckFunction);
        }

        [Test]
        public void 
            It_Should_Throw_A_RuleInvalidException_When_Trying_To_Create_A_Rule_With_An_ActiveNeighbourCount_Less_Than_0()
        {
            void CheckFunction()
            {
                var invalidRule = new Rule(
                    new HashSet<CellState>{CellState.Alive},
                    new HashSet<int> {-9}, CellState.Dead);
            }
            
            Assert.Throws(typeof(RuleInvalidException), CheckFunction);
        }

        [Test]
        public void 
            It_Should_Throw_A_RuleInvalidException_When_Trying_To_Create_A_Rule_With_An_ActiveNeighbourCount_Greater_Than_8()
        {
            void CheckFunction()
            {
                var invalidRule = new Rule(
                    new HashSet<CellState>{CellState.Alive},
                    new HashSet<int> {9}, CellState.Dead);
            }
            
            Assert.Throws(typeof(RuleInvalidException), CheckFunction);
        }

        [Test]
        public void It_Should_Return_Dead_Given_OvercrowdingRule_With_Alive_Overcrowded_Cell()
        {
            Assert.AreEqual(CellState.Dead, _overcrowdingRule.GetNextCellState(7, CellState.Alive));
        }
        
        [Test]
        public void It_Should_Return_Dead_Given_OvercrowdingRule_With_Dead_Overcrowded_Cell()
        {
            Assert.AreEqual(CellState.Dead, _overcrowdingRule.GetNextCellState(7, CellState.Dead));
        }
        
        [Test]
        public void It_Should_Return_Dead_Given_OvercrowdingRule_With_Dead_Undercrowded_Cell()
        {
            Assert.AreEqual(CellState.Dead, _overcrowdingRule.GetNextCellState(2, CellState.Dead));
        }
        
        [Test]
        public void It_Should_Return_Alive_Given_OvercrowdingRule_With_Alive_Undercrowded_Cell()
        {
            Assert.AreEqual(CellState.Alive, _overcrowdingRule.GetNextCellState(2, CellState.Alive));
        }
    }
}