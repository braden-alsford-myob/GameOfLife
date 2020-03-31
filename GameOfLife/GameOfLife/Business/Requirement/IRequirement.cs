namespace GameOfLife.Business.Requirement
{
    public interface IRequirement
    {
        public bool HasMet(ThreeByThreeGrid concernedCells);
    }
}