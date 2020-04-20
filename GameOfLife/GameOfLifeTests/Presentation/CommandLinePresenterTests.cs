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
        private ReadOnlyGrid _testGrid;
        private int _generationCount;
        
        [SetUp]
        public void Setup()
        {
            _spyWriter = new Mock<IWriter>();
            var presenter = new CommandLinePresenter(_spyWriter.Object);

            _testGrid = GridCreator.GetOnlyAliveCenterGrid();
            _generationCount = 10;

            var generationVm = new GenerationViewModel(_testGrid, _generationCount);
            
            presenter.Display(generationVm);
        }
        
        [Test]
        public void Display_Should_Call_Clear_Once()
        {
            _spyWriter.Verify(w => w.Clear(), Times.Once());
        }

        [Test, TestCaseSource(nameof(OutputStrings))]
        public void WriteLine_Should_Get_Called_With_Correct_Output(string output, int expectedTimes)
        {
            _spyWriter.Verify(w => w.WriteLine(output), Times.Exactly(expectedTimes));
        }
        
        private static IEnumerable<TestCaseData> OutputStrings
        {
            get
            {
                yield return new TestCaseData(
                    OutputConstants.RowEdge +
                    OutputConstants.DeadRepresentation +
                    OutputConstants.DeadRepresentation +
                    OutputConstants.DeadRepresentation +
                    OutputConstants.RowEdge,
                    2);                
                
                yield return new TestCaseData(
                    OutputConstants.RowEdge + 
                    OutputConstants.DeadRepresentation +
                    OutputConstants.AliveRepresentation +
                    OutputConstants.DeadRepresentation +
                    OutputConstants.RowEdge,
                    1);           
                
                yield return new TestCaseData(
                    OutputConstants.NewLine + 
                    OutputConstants.GenerationCount + 
                    10,
                    1);
            }
        }
    }
}