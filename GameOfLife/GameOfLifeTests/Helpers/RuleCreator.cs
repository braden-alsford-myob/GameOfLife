using System.Collections.Generic;
using GameOfLife.Business;
using GameOfLife.Business.CellObjects;
using GameOfLife.Business.Requirements;

namespace GameOfLifeTests.Helpers
{
    public static class RuleCreator
    {
        public static Rule GetOvercrowdingRule()
        {
            var cellAliveRequirement = new InitialStateRequirement(new HashSet<CellState>{CellState.Alive});
            var moreThanThreeNeighboursRequirement = new ActiveNeighbourRequirement(new HashSet<int>{4, 5, 6, 7, 8});
            var requirements = new List<IRequirement> {cellAliveRequirement, moreThanThreeNeighboursRequirement};
            
            return new Rule(requirements, CellState.Dead);
        }
    }
}