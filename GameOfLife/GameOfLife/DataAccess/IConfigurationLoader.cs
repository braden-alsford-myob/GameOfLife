using GameOfLife.Business;

namespace GameOfLife.DataAccess
{
    public interface IConfigurationLoader
    {
        SimulationConfiguration Load();
    }
}