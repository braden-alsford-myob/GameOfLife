using System.Threading;

namespace GameOfLife.Business.TimerObjects
{
    public class Timer : ITimer
    {
        public void Sleep(int time)
        {
            Thread.Sleep(time);
        }
    }
}