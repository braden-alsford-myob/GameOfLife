// using System.Collections.Generic;
// using System.Linq;
// using GameOfLife;
// using GameOfLife.Business;
// using GameOfLife.Business.Cell;
// using GameOfLife.Business.Exceptions;
// using GameOfLife.Business.Requirement;
// using NUnit.Framework;
// using Rule = GameOfLife.Business.Rule;
//
// namespace GameOfLifeTests
// {
//     public class RuleTests
//     {
//
//         private Rule _overcrowdingRule;
//         private List<List<Cell>> _grid = new List<List<Cell>>();
//         
//         [SetUp]
//         public void Setup()
//         {
//             var cellAliveRequirement = new InitialStateRequirement(new HashSet<CellState>{CellState.Alive});
//             var moreThanThreeNeighboursRequirement = new ActiveNeighbourRequirement(new HashSet<int>{4, 5, 6, 7, 8});
//             var requirements = new List<IRequirement> {cellAliveRequirement, moreThanThreeNeighboursRequirement};
//             
//             _overcrowdingRule = new Rule(requirements, CellState.Dead);
//
//             for (var i = 0; i < 3; i++)
//             {
//                 _grid.Add(new List<Cell> {new Cell(), new Cell(), new Cell()});
//             }
//             
//         }
//
//
//         [Test]
//         public void It_Should_Return_Dead_Given_OvercrowdingRule_With_Alive_Overcrowded_Cell()
//         {
//             foreach (var cell in _grid.SelectMany(row => row))
//             {
//                 cell.Revive();
//             }
//
//
//             Assert.AreEqual(CellState.Dead, _overcrowdingRule.GetNextCellState(_grid));
//         }
//         
//         [Test]
//         public void It_Should_Return_Dead_Given_OvercrowdingRule_With_Dead_Overcrowded_Cell()
//         {
//             foreach (var cell in _grid.SelectMany(row => row))
//             {
//                 cell.Revive();
//             }
//             _grid[1][1].Kill();
//             
//             Assert.AreEqual(CellState.Dead, _overcrowdingRule.GetNextCellState(_grid));
//         }
//         
//         [Test]
//         public void It_Should_Return_Dead_Given_OvercrowdingRule_With_Dead_Undercrowded_Cell()
//         {
//             foreach (var cell in _grid.SelectMany(row => row))
//             {
//                 cell.Kill();
//             }
//             _grid[0][0].Revive();
//             _grid[0][1].Revive();
//             
//             Assert.AreEqual(CellState.Dead, _overcrowdingRule.GetNextCellState(_grid));
//         }
//         
//         [Test]
//         public void It_Should_Return_Alive_Given_OvercrowdingRule_With_Alive_Undercrowded_Cell()
//         {
//             foreach (var cell in _grid.SelectMany(row => row))
//             {
//                 cell.Kill();
//             }
//             _grid[0][0].Revive();
//             _grid[0][1].Revive();
//             _grid[1][1].Revive();
//             
//             Assert.AreEqual(CellState.Alive, _overcrowdingRule.GetNextCellState(_grid));
//         }
//     }
// }