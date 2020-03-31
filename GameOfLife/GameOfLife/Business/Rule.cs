using System.Collections.Generic;
using System.Linq;
using GameOfLife.Business.Requirement;

namespace GameOfLife.Business
{
    public class Rule
    {        
        private readonly List<IRequirement> _requirements;
        private readonly CellState _resultantState;

        public Rule(List<IRequirement> requirements, CellState resultantState)
        {
            _requirements = requirements;
            _resultantState = resultantState;
        }

        public CellState GetNextCellState(ThreeByThreeGrid concernedCells)
        {
            return _requirements.All(requirement => requirement.HasMet(concernedCells)) ? _resultantState : CellState.NoChange;
        }
    }
}