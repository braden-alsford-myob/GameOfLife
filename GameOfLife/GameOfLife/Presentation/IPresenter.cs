using GameOfLife.Business;

namespace GameOfLife.Presentation
{
    public interface IPresenter
    {
        void Display(GenerationViewModel generation);
    }
}