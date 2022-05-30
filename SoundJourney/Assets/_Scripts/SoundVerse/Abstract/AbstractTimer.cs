using System.Collections;
using System.Collections.Generic;

namespace SoundVerse
{
    public abstract class AbstractTimer
    {
        public bool On = false;
        public abstract void UpdateTime(float cTime);
        public abstract float StartTime();
        public abstract float CurrentTime();
        public void OnOff()
        {
            On = !On;
        }
    }
}
