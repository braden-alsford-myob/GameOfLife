using GameOfLife.Business;
using GameOfLife.DataAccess;
using GameOfLife.Presentation;

namespace GameOfLife
{
    class Program
    {
        static void Main(string[] args)
        {
            var simulationConfig = ConfigurationLoader.LoadSimulationConfiguration("appsettings.json");
            var simulation = new Simulation(simulationConfig, new CommandLinePresenter());
            simulation.Excecute();
        }
    }
}