using GameOfLife.Business;

namespace GameOfLife.DataAccess
{
    public interface IConfigurationLoader
    {
        public SimulationConfiguration Load();
    }
}