using System.Collections.Generic;
using GameOfLife.Business;
using GameOfLife.Business.Cell;
using GameOfLife.Business.Requirements;

namespace GameOfLife.DataAccess.RuleSets
{
    public class PopulationGrowthRuleSet : IRuleSet
    {
        public RuleSetType GetName()
        {
            return RuleSetType.Basic;
        }

        public RuleSet GetRuleSet()
        {
            var basicRules = new Dictionary<int, Rule>
            {
                {1, GetReproductionRule()},
                {2, GetOvercrowdingRule()}
            };
            
            return new RuleSet(basicRules);
        }

        private static Rule GetReproductionRule()
        {
            var cellAliveRequirement = new InitialStateRequirement(new HashSet<CellState>{CellState.Dead});
            var threeNeighbourRequirements = new ActiveNeighbourRequirement(new HashSet<int>{1, 2, 3, 4, 5, 6, 7});
            var requirements = new List<IRequirement> {cellAliveRequirement, threeNeighbourRequirements};
            
            return new Rule(requirements, CellState.Alive);
        }
        
        private static Rule GetOvercrowdingRule()
        {
            var cellAliveRequirement = new InitialStateRequirement(new HashSet<CellState>{CellState.Alive});
            var moreThanThreeNeighboursRequirement = new ActiveNeighbourRequirement(new HashSet<int>{8});
            var requirements = new List<IRequirement> {cellAliveRequirement, moreThanThreeNeighboursRequirement};
            
            return new Rule(requirements, CellState.Dead);
        }
    }
}