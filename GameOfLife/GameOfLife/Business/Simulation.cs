using System.Threading;
using GameOfLife.Business.NeighbourFinder;
using GameOfLife.DataAccess;
using GameOfLife.Presentation;

namespace GameOfLife.Business
{
    public class Simulation
    {
        private int _generationCount;
        private readonly int _maximumGenerations;
        private readonly int _animationDelay;
        private readonly IPresenter _presenter;

        private readonly Board _board;

        public Simulation(SimulationConfiguration config, IPresenter presenter)
        {
            _generationCount = 0;
            _maximumGenerations = config.MaximumGenerations;
            _animationDelay = config.AnimationDelay;
            _presenter = presenter;
            
            var gridFactory = new GridFactory();
            var grid = gridFactory.Create(config.GridType);
            
            var ruleSetFactory = new RuleSetFactory();
            var ruleset = ruleSetFactory.Create(config.RuleSetType);
            
            _board = new Board(ruleset, NeighbourFinderType.EdgeWrapping, grid);
        }

        public void Execute()
        {
            while (_generationCount < _maximumGenerations)
            {
                _presenter.Display(_board.GetGrid());
                Thread.Sleep(_animationDelay);
                _board.UpdateToNextGeneration();
                Tick();
            }
        }

        private void Tick()
        {
            _generationCount++;
        }
    }
}