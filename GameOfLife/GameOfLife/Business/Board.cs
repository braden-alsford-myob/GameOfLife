using System;
using System.Collections.Generic;

namespace GameOfLife.Business
{
    public class Board
    {
        private RuleSet _ruleset;
        private readonly List<List<Cell.Cell>> _grid;

        public Board(RuleSet ruleset, List<List<Cell.Cell>> grid)
        {
            _ruleset = ruleset;
            _grid = grid;
        }

        public void UpdateToNextGeneration()
        {
            foreach (var row in _grid)
            {
                foreach (var cell in row)
                {
                    
                }
            }
        }

        public ReadOnlyGrid GetGrid()
        {
            return new ReadOnlyGrid(_grid);
        }
    }
}