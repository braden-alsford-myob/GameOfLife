namespace GameOfLife.Business.Requirements
{
    public interface IRequirement
    {
        public bool HasMet(ReadOnlyGrid concernedCells);
    }
}