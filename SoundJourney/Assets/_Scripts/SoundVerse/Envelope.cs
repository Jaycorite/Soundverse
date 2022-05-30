using System.Collections;
using System.Collections.Generic;
using System;

namespace SoundVerse
{
    
    public class Envelope : AmpManipulator
    {
        Timer timer;
        int currentTimer = 0;
        public Envelope(List<(float, float)> timePointArray, ref Timer timer)
        {
            ID = System.Guid.NewGuid().ToString();
            AmpTimePoints = timePointArray;
            this.timer = timer;
        }
        public override double SignalValue(float cTime)
        {
            double cAmp = 0;
            
            if (timer.On)
            {
                timer.UpdateTime(cTime);
                double timeOn = timer.CurrentTime() - timer.StartTime();
                if (AmpTimePoints[currentTimer].Item1 < 0)
                {
                    if(cTime % AmpTimePoints[currentTimer].Item1 > AmpTimePoints[currentTimer].Item1 / 2)
                    {
                        float ampModifier = (cTime % Math.Abs(AmpTimePoints[currentTimer].Item1)) * AmpTimePoints[currentTimer].Item2;
                        cAmp = AmpTimePoints[currentTimer - 1].Item1 + ampModifier- AmpTimePoints[currentTimer].Item2/2;
                    }
                    else if(cTime % AmpTimePoints[currentTimer].Item1 < AmpTimePoints[currentTimer].Item1 / 2)
                    {
                        float ampModifier = -((cTime % Math.Abs(AmpTimePoints[currentTimer].Item1)) * AmpTimePoints[currentTimer].Item2);
                        cAmp = AmpTimePoints[currentTimer - 1].Item1 + ampModifier - AmpTimePoints[currentTimer].Item2 / 2;
                    }
                }
                else if(timeOn > AmpTimePoints[currentTimer].Item1)
                {
                    if(currentTimer < AmpTimePoints.Count-1)
                        currentTimer++;
                }
                cAmp = (timeOn / AmpTimePoints[currentTimer].Item1) * AmpTimePoints[currentTimer].Item2;
            }
            else if (!timer.On || currentTimer == AmpTimePoints.Count-1)
            {
                if (!timer.On)
                    currentTimer = AmpTimePoints.Count - 1;
                double timeOff = timer.CurrentTime() - cTime;
                if (timeOff < AmpTimePoints[currentTimer].Item1 && currentTimer == AmpTimePoints.Count - 1)
                    cAmp = (timeOff / AmpTimePoints[currentTimer].Item1) * AmpTimePoints[currentTimer].Item2;
                else if (timeOff > AmpTimePoints[currentTimer].Item1)
                {
                    currentTimer++;
                }
            }
            if (currentTimer >= AmpTimePoints.Count)
                cAmp = 0;

            return cAmp;
        }
    }
}
