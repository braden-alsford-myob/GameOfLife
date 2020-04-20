using System.Collections.Generic;
using GameOfLife.Business;
using GameOfLife.Business.Grid;
using GameOfLife.Business.RuleSet;
using GameOfLife.Business.Timer;
using GameOfLife.Presentation;
using Moq;
using NUnit.Framework;

namespace GameOfLifeTests.Business
{
    public class SimulationTests
    {
        private Mock<IPresenter> _spyPresenter;
        private Mock<ITimer> _spyTimer;

        private List<GenerationViewModel> _generationsDisplayed;
        
        
        [SetUp]
        public void Setup()
        {
            _spyPresenter = new Mock<IPresenter>();
            
            _generationsDisplayed = new List<GenerationViewModel>();
            _spyPresenter.Setup(s => s.Display(It.IsAny<GenerationViewModel>()))
                .Callback<GenerationViewModel>(g => _generationsDisplayed.Add(g));
            
            _spyTimer = new Mock<ITimer>();
            _spyTimer.Setup(timer => timer.Sleep(It.IsAny<int>())).Verifiable();
        }
        
        
        [Test, TestCaseSource(nameof(Configurations))]
        public void Simulation_Should_Present_The_Correct_Number_Of_Generations(SimulationConfiguration config)
        {
            var simulation = new Simulation(config, _spyPresenter.Object, _spyTimer.Object);
            simulation.Execute();

            var expectedGenerations = config.MaximumGenerations + 1;
            
            _spyPresenter.Verify(p => p.Display(It.IsAny<GenerationViewModel>()), Times.Exactly(expectedGenerations));
        }
        

        [Test, TestCaseSource(nameof(Configurations))]
        public void Simulation_Should_Wait_For_Expected_Time_Between_Generations(SimulationConfiguration config)
        {
            var simulation = new Simulation(config, _spyPresenter.Object, _spyTimer.Object);
            simulation.Execute();

            var expectedAnimationDelay = config.AnimationDelay;
            var expectedTimesCalled = config.MaximumGenerations + 1;
            
            _spyTimer.Verify(t => t.Sleep(expectedAnimationDelay), Times.Exactly(expectedTimesCalled));
        }

        
        [Test, TestCaseSource(nameof(Configurations))]
        public void Simulation_Grid_Should_Change_Frame_To_Frame(SimulationConfiguration config)
        {
            if (!IsInfiniteGrid(config.GridType)) return;
            
            var simulation = new Simulation(config, _spyPresenter.Object, _spyTimer.Object);
            simulation.Execute();
                
            for (var i = 0; i < _generationsDisplayed.Count - 1; i += 2)
            {
                var generationI = _generationsDisplayed[i];
                var generationIPlusOne = _generationsDisplayed[i + 1];
                
                Assert.False(generationI.Grid.Equals(generationIPlusOne.Grid));
            }
        }


        [Test, TestCaseSource(nameof(Configurations))]
        public void Simulation_Generation_Count_Should_Increment(SimulationConfiguration config)
        {
            var simulation = new Simulation(config, _spyPresenter.Object, _spyTimer.Object);
            
            simulation.Execute();
            
            for (var i = 1; i < _generationsDisplayed.Count; i++)
            {
                Assert.AreEqual(i, _generationsDisplayed[i].Count);
            }
        }
        

        private static IEnumerable<TestCaseData> Configurations
        {
            get
            {
                yield return new TestCaseData(
                    new SimulationConfiguration(10, 3000, GridType.Glider, RuleSetType.Basic));
                
                yield return new TestCaseData(
                    new SimulationConfiguration(100, 300, GridType.Glider, RuleSetType.Basic));
                
                yield return new TestCaseData(
                    new SimulationConfiguration(1000, 30, GridType.Tumbler, RuleSetType.Basic));
            }
        }

        private bool IsInfiniteGrid(GridType grid)
        {
            var verifiedInfiniteGrids = new List<GridType>{GridType.Glider, GridType.Tumbler};
            return verifiedInfiniteGrids.Contains(grid);
        }
        
    }
}