using System.Threading;
using GameOfLife.Business.NeighbourFinder;
using GameOfLife.DataAccess;
using GameOfLife.Presentation;

namespace GameOfLife.Business
{
    public class Simulation
    {
        private int _generationCount;
        private readonly SimulationConfiguration _config;
        private readonly IPresenter _presenter;

        private readonly Board _board;

        public Simulation(SimulationConfiguration config, IPresenter presenter)
        {
            _generationCount = 0;
            _config = config;
            _presenter = presenter;
            
            var gridFactory = new GridFactory();
            var grid = gridFactory.Create(config.GridType);
            
            var ruleSetFactory = new RuleSetFactory();
            var ruleset = ruleSetFactory.Create(config.RuleSetType);
            
            _board = new Board(ruleset, NeighbourFinderType.EdgeWrapping, grid);
        }

        public void Execute()
        {
            while (_generationCount < _config.MaximumGenerations)
            {
                _presenter.Display(_board.GetGrid());
                Thread.Sleep(_config.AnimationDelay);
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