using System.Collections.Generic;
using System.Collections.ObjectModel;
using GameOfLife.Business;
using GameOfLife.Business.Cell;

namespace GameOfLifeTests.Helpers
{
    public static class GridCreator
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
        
        public static ReadOnlyGrid GetAllDeadGrid()
        {
            var allDeadGrid = new List<ReadOnlyCollection<ReadOnlyCell>>
            {
                new ReadOnlyCollection<ReadOnlyCell>(AllDeadRow),
                new ReadOnlyCollection<ReadOnlyCell>(AllDeadRow),
                new ReadOnlyCollection<ReadOnlyCell>(AllDeadRow)
            };
            
            var allDeadReadOnlyGrid = new ReadOnlyCollection<ReadOnlyCollection<ReadOnlyCell>>(allDeadGrid);
            
            return new ReadOnlyGrid(allDeadReadOnlyGrid);
        }

        public static ReadOnlyGrid GetAllAliveGrid()
        {
            var allActiveRows = new List<ReadOnlyCollection<ReadOnlyCell>>
            {
                new ReadOnlyCollection<ReadOnlyCell>(AllAliveRow),
                new ReadOnlyCollection<ReadOnlyCell>(AllAliveRow),
                new ReadOnlyCollection<ReadOnlyCell>(AllAliveRow)
            };
            
            var allAliveReadOnlyGrid = new ReadOnlyCollection<ReadOnlyCollection<ReadOnlyCell>>(allActiveRows);
            
            return new ReadOnlyGrid(allAliveReadOnlyGrid);
        }

        public static ReadOnlyGrid GetOnlyAliveCenterGrid()
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
            
            return new ReadOnlyGrid(aliveCenterReadOnlyGrid);
        }

        public static ReadOnlyGrid GetOnlyDeadCenterGrid()
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
            
            return new ReadOnlyGrid(deadCenterReadOnlyGrid);
        }

        public static ReadOnlyGrid GetAliveCenterWithFourAliveNeighboursGrid()
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
            
            return new ReadOnlyGrid(aliveCenterWithFourAliveNeighboursReadOnlyGrid);
        }

        public static ReadOnlyGrid GetTwoRowAllAliveGrid()
        {
            var twoRowAllAliveGrid = new List<ReadOnlyCollection<ReadOnlyCell>>
            {
                new ReadOnlyCollection<ReadOnlyCell>(AllAliveRow),
                new ReadOnlyCollection<ReadOnlyCell>(AllAliveRow),
            };
            
            var twoRowAllAliveReadOnlyGrid = 
                new ReadOnlyCollection<ReadOnlyCollection<ReadOnlyCell>>(twoRowAllAliveGrid);
            
            return new ReadOnlyGrid(twoRowAllAliveReadOnlyGrid);
        }
    }
}