using System.Threading;
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
            
            // DEFINITELY FIX THIS TODO
            _board = DemoBoardCreator.Create();
        }

        public void Excecute()
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