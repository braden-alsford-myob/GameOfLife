using System.Collections.Generic;
using System.Linq;
using GameOfLife.Business.Cell;
using GameOfLife.Business.Exceptions;
using GameOfLife.Business.Requirement;

namespace GameOfLife.Business
{
    public class ActiveNeighbourRequirement : IRequirement
    {
        private readonly HashSet<int> _activeNeighbourCounts;

        public ActiveNeighbourRequirement(HashSet<int> activeNeighbourCounts)
        {
            ValidateActiveNeighbourCounts(activeNeighbourCounts);
            _activeNeighbourCounts = activeNeighbourCounts;
        }

        public bool HasMet(IReadOnlyList<IReadOnlyList<ICell>> concernedCells)
        {
            var neighbouringCells = GetNeighbouringCells(concernedCells);
            var activeNeighbourCount = CalculateActiveNeighbours(neighbouringCells);
            return _activeNeighbourCounts.Contains(activeNeighbourCount);
        }
        
        private static IEnumerable<ICell> GetNeighbouringCells(IReadOnlyList<IReadOnlyList<ICell>> concernedCells)
        {
            var neighbouringCells = new List<ICell>();
            neighbouringCells.AddRange(concernedCells[0]);   // Top Row
            neighbouringCells.Add(concernedCells[1][0]);     // Middle Left
            neighbouringCells.Add(concernedCells[1][2]);     // Middle Right
            neighbouringCells.AddRange(concernedCells[2]);   // Bottom Row
            
            return neighbouringCells;
        }

        private static int CalculateActiveNeighbours(IEnumerable<ICell> neighbouringCells)
        {
            return neighbouringCells.Count(cell => cell.GetState() == CellState.Alive);
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