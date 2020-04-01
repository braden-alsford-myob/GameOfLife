using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace GameOfLife.Business
{
    public class Board
    {
        private RuleSet _ruleset;
        private List<List<Cell.Cell>> _grid;

        public Board(RuleSet ruleset, List<List<Cell.Cell>> grid)
        {
            _ruleset = ruleset;
            _grid = grid;
        }

        public void UpdateToNextGeneration()
        {
            throw new NotImplementedException();
        }

        public ReadOnlyGrid GetGrid()
        {
            throw new NotImplementedException();
        }
    }
}