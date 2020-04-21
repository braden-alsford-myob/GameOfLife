using System.Collections.Generic;
using GameOfLife.Business;
using GameOfLife.Business.Grid;
using GameOfLife.Presentation;
using GameOfLifeTests.Helpers;
using Moq;
using NUnit.Framework;

namespace GameOfLifeTests.Presentation
{
    public class CommandLinePresenterTests
    {
        private Mock<IWriter> _spyWriter;

        private IPresenter _presenter;
        private GenerationViewModel _testGenerationViewModel;
        
        [SetUp]
        public void Setup()
        {
            _spyWriter = new Mock<IWriter>();
            _presenter = new CommandLinePresenter(_spyWriter.Object);
            
            _testGenerationViewModel = new GenerationViewModel(GridCreator.GetOnlyAliveCenterGrid(), 0);
        }
        
        [Test]
        public void Display_Should_Call_Clear_Once()
        {
            _presenter.Display(_testGenerationViewModel);
            
            _spyWriter.Verify(w => w.Clear(), Times.Once());
        }

        [Test]
        public void Display_Should_Call_Clear_Before_WriteLine()
        {
            var callOrder = 0;
            
            _spyWriter.Setup(x => x.Clear()).Callback(() => Assert.That(callOrder++, Is.EqualTo(0)));
            _spyWriter.Setup(x => x.WriteLine(It.IsAny<string>())).Callback(() => Assert.That(callOrder++, Is.EqualTo(1)));
            
            _presenter.Display(_testGenerationViewModel);
        }
        
        [Test, TestCaseSource(nameof(GenerationViewModels))]
        public void WriteLine_Should_Get_Called_With_Correct_Output(GenerationViewModel generation, string expected)
        {
            _presenter.Display(generation);
            
            _spyWriter.Verify(w => w.WriteLine(expected), Times.Once);
        }
        
        
        private static IEnumerable<TestCaseData> GenerationViewModels
        {
            get
            {
                yield return new TestCaseData(
                    new GenerationViewModel(GridCreator.GetOnlyAliveCenterGrid(), 10),
                    OutputConstants.RowEdge +
                    OutputConstants.DeadRepresentation +
                    OutputConstants.DeadRepresentation +
                    OutputConstants.DeadRepresentation +
                    OutputConstants.RowEdge +
                    OutputConstants.NewLine +
                    OutputConstants.RowEdge +
                    OutputConstants.DeadRepresentation +
                    OutputConstants.AliveRepresentation +
                    OutputConstants.DeadRepresentation +
                    OutputConstants.RowEdge +
                    OutputConstants.NewLine +
                    OutputConstants.RowEdge +
                    OutputConstants.DeadRepresentation +
                    OutputConstants.DeadRepresentation +
                    OutputConstants.DeadRepresentation +
                    OutputConstants.RowEdge +
                    OutputConstants.NewLine +
                    OutputConstants.NewLine +
                    OutputConstants.GenerationCount +
                    "10");
                
                yield return new TestCaseData(
                    new GenerationViewModel(GridCreator.GetAllAliveGrid(), 98765),
                    OutputConstants.RowEdge +
                    OutputConstants.AliveRepresentation +
                    OutputConstants.AliveRepresentation +
                    OutputConstants.AliveRepresentation +
                    OutputConstants.RowEdge +
                    OutputConstants.NewLine +
                    OutputConstants.RowEdge +
                    OutputConstants.AliveRepresentation +
                    OutputConstants.AliveRepresentation +
                    OutputConstants.AliveRepresentation +
                    OutputConstants.RowEdge +
                    OutputConstants.NewLine +
                    OutputConstants.RowEdge +
                    OutputConstants.AliveRepresentation +
                    OutputConstants.AliveRepresentation +
                    OutputConstants.AliveRepresentation +
                    OutputConstants.RowEdge +
                    OutputConstants.NewLine +
                    OutputConstants.NewLine +
                    OutputConstants.GenerationCount +
                    "98765");
                
            }
        }
    }
}