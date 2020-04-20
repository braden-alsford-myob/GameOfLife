using GameOfLife.Business;

namespace GameOfLife.Presentation
{
    public interface IPresenter
    {
        public void Display(GenerationViewModel generation);
    }
}