using System.Collections.Generic;
using GameOfLife.Business;
using GameOfLife.Business.Cell;
using GameOfLife.Business.NeighbourFinder;
using GameOfLife.Business.Requirements;

namespace GameOfLife.DataAccess
{
    public static class DemoBoardCreator
    {
        public static Board Create()
        {
            var basicRuleSet = GetBasicRuleSet();
            var wrapper = NeighbourFinderType.EdgeWrapping;
            var gliderGrid = GetFirstGliderGridFrame();
            return new Board(basicRuleSet, wrapper, gliderGrid);
        }

        private static List<List<Cell>> GetFirstGliderGridFrame()
        {
            var rowOne = new List<Cell>
            {
                new Cell(CellState.Dead),
                new Cell(CellState.Dead),
                new Cell(CellState.Dead),
                new Cell(CellState.Dead),
                new Cell(CellState.Dead),
                new Cell(CellState.Dead),
                new Cell(CellState.Dead),
                new Cell(CellState.Dead)
            };
            
            var rowTwo = new List<Cell>
            {
                new Cell(CellState.Dead),
                new Cell(CellState.Dead),
                new Cell(CellState.Alive),
                new Cell(CellState.Dead),
                new Cell(CellState.Dead),
                new Cell(CellState.Dead),
                new Cell(CellState.Dead),
                new Cell(CellState.Dead)
            };
            
            var rowThree = new List<Cell>
            {
                new Cell(CellState.Dead),
                new Cell(CellState.Dead),
                new Cell(CellState.Dead),
                new Cell(CellState.Alive),
                new Cell(CellState.Dead),
                new Cell(CellState.Dead),
                new Cell(CellState.Dead),
                new Cell(CellState.Dead)
            };

            var rowFour = new List<Cell>
            {
                new Cell(CellState.Dead),
                new Cell(CellState.Alive),
                new Cell(CellState.Alive),
                new Cell(CellState.Alive),
                new Cell(CellState.Dead),
                new Cell(CellState.Dead),
                new Cell(CellState.Dead),
                new Cell(CellState.Dead)
            };

            var rowFive = new List<Cell>
            {
                new Cell(CellState.Dead),
                new Cell(CellState.Dead),
                new Cell(CellState.Dead),
                new Cell(CellState.Dead),
                new Cell(CellState.Dead),
                new Cell(CellState.Dead),
                new Cell(CellState.Dead),
                new Cell(CellState.Dead)
            };

            var rowSix = new List<Cell>
            {
                new Cell(CellState.Dead),
                new Cell(CellState.Dead),
                new Cell(CellState.Dead),
                new Cell(CellState.Dead),
                new Cell(CellState.Dead),
                new Cell(CellState.Dead),
                new Cell(CellState.Dead),
                new Cell(CellState.Dead)
            };

            var rowSeven = new List<Cell>
            {
                new Cell(CellState.Dead),
                new Cell(CellState.Dead),
                new Cell(CellState.Dead),
                new Cell(CellState.Dead),
                new Cell(CellState.Dead),
                new Cell(CellState.Dead),
                new Cell(CellState.Dead),
                new Cell(CellState.Dead)
            };

            var rowEight = new List<Cell>
            {
                new Cell(CellState.Dead),
                new Cell(CellState.Dead),
                new Cell(CellState.Dead),
                new Cell(CellState.Dead),
                new Cell(CellState.Dead),
                new Cell(CellState.Dead),
                new Cell(CellState.Dead),
                new Cell(CellState.Dead)
            };
            
            return new List<List<Cell>>
            {
                rowOne,
                rowTwo,
                rowThree,
                rowFour,
                rowFive,
                rowSix,
                rowSeven,
                rowEight
            };
        }

        private static RuleSet GetBasicRuleSet()
        {
            var basicRules = new Dictionary<int, Rule>
            {
                {1, GetReproductionRule()},
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
            var cellAliveRequirement = new InitialStateRequirement(new HashSet<CellState>{CellState.Dead});
            var threeNeighbourRequirements = new ActiveNeighbourRequirement(new HashSet<int>{3});
            var requirements = new List<IRequirement> {cellAliveRequirement, threeNeighbourRequirements};
            
            return new Rule(requirements, CellState.Alive);
        }
        
        
    }
}