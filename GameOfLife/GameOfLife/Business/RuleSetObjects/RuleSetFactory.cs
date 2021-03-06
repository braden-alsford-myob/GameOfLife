using System;
using System.Collections.Generic;
using GameOfLife.Business.CellObjects;
using GameOfLife.Business.Requirements;

namespace GameOfLife.Business.RuleSetObjects
{
    public class RuleSetFactory
    {
        public RuleSet Create(RuleSetType type)
        {
            return type switch
            {
                RuleSetType.Standard => GetStandardRuleSet(),
                RuleSetType.EasyReproduction => GetEasyReproductionRuleSet(),
                _ => throw new Exception()
            };
        }
        
        private static RuleSet GetStandardRuleSet()
        {
            var basicRules = new Dictionary<int, Rule>
            {
                {1, GetReproductionRule()},
                {2, GetOvercrowdingRule()},
                {3, GetUnderpopulationRule()}
            };
            
            return new RuleSet(basicRules);
        }
        
        private static RuleSet GetEasyReproductionRuleSet()
        {
            var basicRules = new Dictionary<int, Rule>
            {
                {1, GetEasyReproductionRule()},
                {2, GetOvercrowdingRule()},
                {3, GetUnderpopulationRule()}
            };
            
            return new RuleSet(basicRules);
        }

        private static Rule GetOvercrowdingRule()
        {
            var cellAliveRequirement = new InitialStateRequirement(new HashSet<CellState>{CellState.Alive});
            var moreThanThreeNeighboursRequirement = new ActiveNeighbourRequirement(new HashSet<int>{4, 5, 6, 7, 8});
            var requirements = new List<IRequirement> {cellAliveRequirement, moreThanThreeNeighboursRequirement};
            
            return new Rule(requirements, CellState.Dead);
        }

        private static Rule GetUnderpopulationRule()
        {
            var cellAliveRequirement = new InitialStateRequirement(new HashSet<CellState>{CellState.Alive});
            var lessThanTwoNeighbourRequirement = new ActiveNeighbourRequirement(new HashSet<int>{0, 1});
            var requirements = new List<IRequirement> {cellAliveRequirement, lessThanTwoNeighbourRequirement};
            
            return new Rule(requirements, CellState.Dead);
        }

        private static Rule GetReproductionRule()
        {
            var cellDeadRequirement = new InitialStateRequirement(new HashSet<CellState>{CellState.Dead});
            var threeNeighbourRequirements = new ActiveNeighbourRequirement(new HashSet<int>{3});
            var requirements = new List<IRequirement> {cellDeadRequirement, threeNeighbourRequirements};
            
            return new Rule(requirements, CellState.Alive);
        }

        private static Rule GetEasyReproductionRule()
        {
            var cellDeadRequirement = new InitialStateRequirement(new HashSet<CellState>{CellState.Dead});
            var threeNeighbourRequirements = new ActiveNeighbourRequirement(new HashSet<int>{2, 3});
            var requirements = new List<IRequirement> {cellDeadRequirement, threeNeighbourRequirements};
            
            return new Rule(requirements, CellState.Alive);
        }

    }
}