using GameOfLife.Business.GridObjects;

namespace GameOfLife.Business
{
    public class GenerationViewModel
    {
        public ReadOnlyGrid Grid { get; }
        public int Count { get; }

        public GenerationViewModel(ReadOnlyGrid grid, int count)
        {
            Grid = grid;
            Count = count;
        }
    }
}