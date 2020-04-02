using System.Collections.Generic;
using System.Linq;
using GameOfLife.Business.Requirements;

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

        public CellState GetNextCellState(ReadOnlyGrid concernedCells, CellState initialState)
        {
            return _requirements.All(requirement => requirement.HasMet(concernedCells)) ? _resultantState : initialState;
        }
    }
}