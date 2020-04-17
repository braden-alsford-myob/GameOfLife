using GameOfLife.Business.Grid;

namespace GameOfLife.Presentation
{
    public interface IPresenter
    {
        public void Display(ReadOnlyGrid grid);
    }
}