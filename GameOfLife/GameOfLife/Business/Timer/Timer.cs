using System.Threading;

namespace GameOfLife.Business.Timer
{
    public class Timer : ITimer
    {
        public void Sleep(int time)
        {
            Thread.Sleep(time);
        }
    }
}