using System.Collections.Generic;
using GameOfLife.Business;
using GameOfLife.Business.Grid;
using GameOfLife.Business.RuleSet;
using GameOfLife.Business.Timer;
using GameOfLife.Presentation;
using Moq;
using NUnit.Framework;

namespace GameOfLifeTests
{
    public class SimulationTests
    {
        private Mock<IWriter> _spyWriter;
        private IPresenter _presenter;
        private Mock<ITimer> _spyTimer;

        private List<string> _generationsWritten;
        
        
        [SetUp]
        public void Setup()
        {
            _spyWriter = new Mock<IWriter>();

            _generationsWritten = new List<string>();
            _spyWriter.Setup(s => s.WriteLine(It.IsAny<string>()))
                .Callback<string>(s => _generationsWritten.Add(s));
            
            _presenter = new CommandLinePresenter(_spyWriter.Object);

            _spyTimer = new Mock<ITimer>();
            _spyTimer.Setup(timer => timer.Sleep(It.IsAny<int>())).Verifiable();
        }
        
        
        [Test, TestCaseSource(nameof(ConfigurationsWithInfiniteLoops))]
        public void Simulation_Should_Write_The_Correct_Number_Of_Generations(SimulationConfiguration config)
        {
            var simulation = new Simulation(config, _presenter, _spyTimer.Object);
            simulation.Execute();

            var expectedWrites = config.MaximumGenerations + 1;
            
            _spyWriter.Verify(p => p.WriteLine(It.IsAny<string>()), Times.Exactly(expectedWrites));
        }
        

        [Test, TestCaseSource(nameof(ConfigurationsWithInfiniteLoops))]
        public void Simulation_Should_Wait_For_Expected_Time_Between_Generations(SimulationConfiguration config)
        {
            var simulation = new Simulation(config, _presenter, _spyTimer.Object);
            simulation.Execute();
        
            var expectedAnimationDelay = config.AnimationDelay;
            var expectedTimesCalled = config.MaximumGenerations + 1;
            
            _spyTimer.Verify(t => t.Sleep(expectedAnimationDelay), Times.Exactly(expectedTimesCalled));
        }
        
        
        [Test, TestCaseSource(nameof(ConfigurationsWithInfiniteLoops))]
        public void Simulation_Grid_Should_Change_Frame_To_Frame_Given_Grid_With_Infinite_Loop(SimulationConfiguration config)
        {
            var simulation = new Simulation(config, _presenter, _spyTimer.Object);
            simulation.Execute();
                
            for (var i = 0; i < _generationsWritten.Count - 1; i += 2)
            {
                var generationI = _generationsWritten[i];
                var generationIPlusOne = _generationsWritten[i + 1];
                
                Assert.False(generationI.Equals(generationIPlusOne));
            }
        }
        
        
        private static IEnumerable<TestCaseData> ConfigurationsWithInfiniteLoops
        {
            get
            {
                yield return new TestCaseData(
                    new SimulationConfiguration(10, 3000, GridType.Glider, RuleSetType.Basic, 5, 5));
                
                yield return new TestCaseData(
                    new SimulationConfiguration(100, 300, GridType.Glider, RuleSetType.Basic, 5, 5));
                
                yield return new TestCaseData(
                    new SimulationConfiguration(1000, 30, GridType.Tumbler, RuleSetType.Basic, 5, 5));
            }
        }
    }
}