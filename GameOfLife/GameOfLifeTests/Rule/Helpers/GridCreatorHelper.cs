using System.Collections.Generic;
using System.Collections.ObjectModel;
using GameOfLife.Business;
using GameOfLife.Business.Cell;

namespace GameOfLifeTests.Rule.Helpers
{
    public static class GridCreatorHelper
    {
        private static readonly List<ReadOnlyCell> AllDeadRow = new List<ReadOnlyCell>
        {
            new ReadOnlyCell(CellState.Dead),
            new ReadOnlyCell(CellState.Dead),
            new ReadOnlyCell(CellState.Dead)
        };
        
        private static readonly List<ReadOnlyCell> AllAliveRow = new List<ReadOnlyCell>
        {
            new ReadOnlyCell(CellState.Alive),
            new ReadOnlyCell(CellState.Alive),
            new ReadOnlyCell(CellState.Alive)
        };
        
        public static ThreeByThreeGrid GetAllDeadGrid()
        {
            var allDeadGrid = new List<ReadOnlyCollection<ReadOnlyCell>>
            {
                new ReadOnlyCollection<ReadOnlyCell>(AllDeadRow),
                new ReadOnlyCollection<ReadOnlyCell>(AllDeadRow),
                new ReadOnlyCollection<ReadOnlyCell>(AllDeadRow)
            };
            
            var allDeadReadOnlyGrid = new ReadOnlyCollection<ReadOnlyCollection<ReadOnlyCell>>(allDeadGrid);
            
            return new ThreeByThreeGrid(allDeadReadOnlyGrid);
        }

        public static ThreeByThreeGrid GetAllAliveGrid()
        {
            var allActiveRows = new List<ReadOnlyCollection<ReadOnlyCell>>
            {
                new ReadOnlyCollection<ReadOnlyCell>(AllAliveRow),
                new ReadOnlyCollection<ReadOnlyCell>(AllAliveRow),
                new ReadOnlyCollection<ReadOnlyCell>(AllAliveRow)
            };
            
            var allAliveReadOnlyGrid = new ReadOnlyCollection<ReadOnlyCollection<ReadOnlyCell>>(allActiveRows);
            
            return new ThreeByThreeGrid(allAliveReadOnlyGrid);
        }

        public static ThreeByThreeGrid GetOnlyAliveCenterGrid()
        {
            var aliveCenterRow = new List<ReadOnlyCell>
            {
                new ReadOnlyCell(CellState.Dead),
                new ReadOnlyCell(CellState.Alive),
                new ReadOnlyCell(CellState.Dead)
            };

            var allActiveRows = new List<ReadOnlyCollection<ReadOnlyCell>>
            {
                new ReadOnlyCollection<ReadOnlyCell>(AllDeadRow),
                new ReadOnlyCollection<ReadOnlyCell>(aliveCenterRow),
                new ReadOnlyCollection<ReadOnlyCell>(AllDeadRow)
            };
            
            var aliveCenterReadOnlyGrid = new ReadOnlyCollection<ReadOnlyCollection<ReadOnlyCell>>(allActiveRows);
            
            return new ThreeByThreeGrid(aliveCenterReadOnlyGrid);
        }

        public static ThreeByThreeGrid GetOnlyDeadCenterGrid()
        {
            var deadCenterRow = new List<ReadOnlyCell>
            {
                new ReadOnlyCell(CellState.Alive),
                new ReadOnlyCell(CellState.Dead),
                new ReadOnlyCell(CellState.Alive)
            };
            
            var deadCenterGrid = new List<ReadOnlyCollection<ReadOnlyCell>>
            {
                new ReadOnlyCollection<ReadOnlyCell>(AllAliveRow),
                new ReadOnlyCollection<ReadOnlyCell>(deadCenterRow),
                new ReadOnlyCollection<ReadOnlyCell>(AllAliveRow)
            };
            
            var deadCenterReadOnlyGrid = new ReadOnlyCollection<ReadOnlyCollection<ReadOnlyCell>>(deadCenterGrid);
            
            return new ThreeByThreeGrid(deadCenterReadOnlyGrid);
        }

        public static ThreeByThreeGrid GetAliveCenterWithFourAliveNeighboursGrid()
        {
            var onlyLeftDeadRow = new List<ReadOnlyCell>
            {
                new ReadOnlyCell(CellState.Dead),
                new ReadOnlyCell(CellState.Alive),
                new ReadOnlyCell(CellState.Alive)
            };
            
            var aliveCenterWithFourAliveNeighbours = new List<ReadOnlyCollection<ReadOnlyCell>>
            {
                new ReadOnlyCollection<ReadOnlyCell>(AllDeadRow),
                new ReadOnlyCollection<ReadOnlyCell>(onlyLeftDeadRow),
                new ReadOnlyCollection<ReadOnlyCell>(AllAliveRow)
            };
            
            var aliveCenterWithFourAliveNeighboursReadOnlyGrid = 
                new ReadOnlyCollection<ReadOnlyCollection<ReadOnlyCell>>(aliveCenterWithFourAliveNeighbours);
            
            return new ThreeByThreeGrid(aliveCenterWithFourAliveNeighboursReadOnlyGrid);
        }
    }
}