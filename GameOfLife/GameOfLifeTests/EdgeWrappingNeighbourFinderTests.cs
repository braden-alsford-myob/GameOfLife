// namespace GameOfLifeTests
// {
//     public class EdgeWrappingNeighbourFinderTests
//     {
//         
//         [Test]
//         public void It_Should_Return_Eight_Given_A_Top_Left_Corner_Cell_Surrounded_By_Alive_Cells()
//         {
//             foreach (var cell in _grid.SelectMany(row => row))
//             {
//                 cell.Revive();
//             }
//
//             var neighbourFinder = new EdgeWrappingNeighbourFinder(_grid);
//             var activeNeighbourCount = neighbourFinder.GetNeighbors(new CellPosition(0, 0));
//             
//             Assert.AreEqual(8, activeNeighbourCount);
//         }
//         
//         [Test]
//         public void It_Should_Return_Eight_Given_A_Top_Right_Corner_Cell_Surrounded_By_Alive_Cells()
//         {
//             foreach (var cell in _grid.SelectMany(row => row))
//             {
//                 cell.Revive();
//             }
//
//             var neighbourFinder = new EdgeWrappingNeighbourFinder(_grid);
//             var activeNeighbourCount = neighbourFinder.GetNeighbors(new CellPosition(0, 2));
//             
//             Assert.AreEqual(8, activeNeighbourCount);
//         }
//         
//         [Test]
//         public void It_Should_Return_Eight_Given_A_Bottom_Left_Corner_Cell_Surrounded_By_Alive_Cells()
//         {
//             foreach (var cell in _grid.SelectMany(row => row))
//             {
//                 cell.Revive();
//             }
//
//             var neighbourFinder = new EdgeWrappingNeighbourFinder(_grid);
//             var activeNeighbourCount = neighbourFinder.GetNeighbors(new CellPosition(2, 0));
//             
//             Assert.AreEqual(8, activeNeighbourCount);
//         }
//         
//         [Test]
//         public void It_Should_Return_Eight_Given_A_Bottom_Right_Corner_Cell_Surrounded_By_Alive_Cells()
//         {
//             foreach (var cell in _grid.SelectMany(row => row))
//             {
//                 cell.Revive();
//             }
//
//             var neighbourFinder = new EdgeWrappingNeighbourFinder(_grid);
//             var activeNeighbourCount = neighbourFinder.GetNeighbors(new CellPosition(2, 2));
//             
//             Assert.AreEqual(8, activeNeighbourCount);
//         }
//     }
// }