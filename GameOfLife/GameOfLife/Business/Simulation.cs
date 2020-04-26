using GameOfLife.Business.Grid;
using GameOfLife.Business.RuleSet;
using GameOfLife.Business.Timer;
using GameOfLife.Presentation;

namespace GameOfLife.Business
{
    public class Simulation
    {
        private int _generationCount;
        private readonly SimulationConfiguration _config;
        private readonly IPresenter _presenter;
        private readonly ITimer _timer;

        private readonly Board _board;

        public Simulation(SimulationConfiguration config, IPresenter presenter, ITimer timer)
        {
            _generationCount = 0;
            _config = config;
            _presenter = presenter;
            _timer = timer;

            var gridFactory = new GridFactory();
            var grid = gridFactory.Create(config.GridType, config.Height, config.Width);
            
            var ruleSetFactory = new RuleSetFactory();
            var ruleset = ruleSetFactory.Create(config.RuleSetType);
            
            _board = new Board(ruleset, grid);
        }

        public void Execute()
        {
            while (_generationCount <= _config.MaximumGenerations)
            {
                var generationViewModel = new GenerationViewModel(_board.GetGrid(), _generationCount);
                
                _presenter.Display(generationViewModel);
                _timer.Sleep(_config.AnimationDelay);
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