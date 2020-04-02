using System;
using System.Collections.Generic;
using GameOfLife.Business.NeighbourFinder;

namespace GameOfLife.Business
{
    public class Board
    {
        private readonly RuleSet _ruleset;
        private readonly NeighbourFinderType _neighbourFinderType;
        private readonly List<List<Cell.Cell>> _grid;

        public Board(RuleSet ruleset, NeighbourFinderType neighbourFinderType, List<List<Cell.Cell>> grid)
        {
            _ruleset = ruleset;
            _neighbourFinderType = neighbourFinderType;
            _grid = grid;
        }

        public void UpdateToNextGeneration()
        {
            var neighbourFinder = CreateNeighbourFinder();
            
            for (var i = 0; i < _grid.Count; i++)
            {
                for (var j = 0; j < _grid[i].Count; j++)
                {
                    UpdateCellState(new CellPosition(i, j), neighbourFinder);
                }
            }
        }

        public ReadOnlyGrid GetGrid()
        {
            return new ReadOnlyGrid(_grid);
        }

        private INeighbourFinder CreateNeighbourFinder()
        {
            return _neighbourFinderType switch
            {
                NeighbourFinderType.EdgeWrapping => new EdgeWrappingNeighbourFinder(GetGrid()),
                _ => throw new ArgumentOutOfRangeException()
            };
        }

        private void UpdateCellState(CellPosition position, INeighbourFinder finder)
        {
            var neighbours = finder.GetThreeByThreeGridAroundCell(position);
            var newState = _ruleset.GetNextCellState(neighbours);

            if (newState == CellState.Alive) _grid[position.Row][position.Column].Revive();
            else _grid[position.Row][position.Column].Kill();
        }
    }
}