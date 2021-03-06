using System.Collections.Generic;
using System.Linq;
using GameOfLife.Business.CellObjects;
using GameOfLife.Business.Exceptions;
using GameOfLife.Business.GridObjects;

namespace GameOfLife.Business.Requirements
{
    public class ActiveNeighbourRequirement : IRequirement
    {
        private readonly HashSet<int> _activeNeighbourCounts;
        private const int CenterOfGrid = 1;

        public ActiveNeighbourRequirement(HashSet<int> activeNeighbourCounts)
        {
            ValidateActiveNeighbourCounts(activeNeighbourCounts);
            _activeNeighbourCounts = activeNeighbourCounts;
        }

        public bool HasMet(ReadOnlyGrid concernedCells)
        {
            var activeNeighbourCount = CalculateActiveNeighbours(concernedCells);
            return _activeNeighbourCounts.Contains(activeNeighbourCount);
        }

        private static int CalculateActiveNeighbours(ReadOnlyGrid concernedCells)
        {
            var neighbouringCellStates = GetNeighbouringCellStates(concernedCells);
            return neighbouringCellStates.Count(state => state == CellState.Alive);
        }

        private static List<CellState> GetNeighbouringCellStates(ReadOnlyGrid concernedCells)
        {
            var neighbouringCells = new List<CellState>();

            for (var rowIndex = 0; rowIndex < 3; rowIndex++)
            {
                for (var columnIndex = 0; columnIndex < 3; columnIndex++)
                {
                    if (!IsCenterCell(rowIndex, columnIndex))
                    {
                        var cellPosition = new CellPosition(rowIndex, columnIndex);
                        neighbouringCells.Add(concernedCells.GetCellState(cellPosition));
                    }
                }
            }

            return neighbouringCells;
        }

        private static bool IsCenterCell(int rowIndex, int columnIndex)
        {
            return rowIndex == CenterOfGrid && columnIndex == CenterOfGrid;
        }

        private static void ValidateActiveNeighbourCounts(HashSet<int> activeNeighbourCounts)
        {
            if (activeNeighbourCounts.Any(activeNeighbourCount => activeNeighbourCount > 8 || activeNeighbourCount < 0))
            {
                throw new RequirementInvalidException("Cannot have an active neighbour count outside of range 0 - 8.", activeNeighbourCounts);
            }
        }
    }
}