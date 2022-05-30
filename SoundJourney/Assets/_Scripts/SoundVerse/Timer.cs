using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoundVerse
{
    public class Timer
    {
        double startTime;
        double currentTime;
        public bool On;

        public Timer(double sTime)
        {
            startTime = sTime;
            currentTime = startTime;
            On = false;
        }
        public double CurrentTime()
        {
            return currentTime;
        }
        public double StartTime()
        {
            return startTime;
        }
        public void UpdateTime(double cTime)
        {
            currentTime = cTime;
        }

        public void TurnOn(double cTime)
        {
            On = true;
            startTime = cTime;
        }
    }
}
