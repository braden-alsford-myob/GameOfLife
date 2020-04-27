using GameOfLife.Business.CellObjects;
using GameOfLife.Business.GridObjects;
using GameOfLife.Business.NeighbourFinderObjects;
using GameOfLife.Business.RuleSetObjects;

namespace GameOfLife.Business
{
    public class Board
    {
        private readonly RuleSet _ruleset;
        private readonly Grid _grid;

        public Board(RuleSet ruleset, Grid grid)
        {
            _ruleset = ruleset;
            _grid = grid;
        }
        
        public ReadOnlyGrid GetGrid()
        {
            return new ReadOnlyGrid(_grid);
        }

        public void UpdateToNextGeneration()
        {
            var indexFinder = new EdgeWrappingIndexFinder();
            var neighbourFinder = new NeighbourFinder(GetGrid(), indexFinder);
            
            for (var i = 0; i < _grid.GetRows().Count; i++)
            {
                for (var j = 0; j < _grid.GetRows()[i].Count; j++)
                {
                    UpdateCellState(new CellPosition(i, j), neighbourFinder);
                }
            }
        }

        private void UpdateCellState(CellPosition position, NeighbourFinder finder)
        {
            var neighbours = finder.GetThreeByThreeGridAroundCell(position);
            var newState = _ruleset.GetNextCellState(neighbours);
            
            
            if (newState == CellState.Alive) _grid.GetRows()[position.Row][position.Column].Revive();
            else _grid.GetRows()[position.Row][position.Column].Kill();
        }
    }
}