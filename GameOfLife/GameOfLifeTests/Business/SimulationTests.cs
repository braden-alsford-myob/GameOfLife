using GameOfLife.Business;
using GameOfLife.DataAccess.Grids;
using GameOfLife.DataAccess.RuleSets;
using GameOfLife.Presentation;
using Moq;
using NUnit.Framework;

namespace GameOfLifeTests
{
    public class SimulationTests
    {
        private Mock<IPresenter> _spyPresenter;
        
        [SetUp]
        public void Setup()
        {
            const int maxGenerations = 10;
            const int animationDelay = 1;
            const GridType gridType = GridType.Glider;
            const RuleSetType ruleSetType = RuleSetType.Basic;

            var simulationConfig = new SimulationConfiguration(maxGenerations, animationDelay, gridType, ruleSetType);
            _spyPresenter = new Mock<IPresenter>();

            var simulation = new Simulation(simulationConfig, _spyPresenter.Object);
            simulation.Execute();
        }

        [Test]
        public void Display_Should_Get_Called_Ten_Times_Given_A_MaxGenerations_Of_Ten()
        {
            _spyPresenter.Verify(p => p.Display(It.IsAny<ReadOnlyGrid>()), Times.Exactly(10));
        }
    }
}