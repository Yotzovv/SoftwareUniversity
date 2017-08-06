using _09.Traffic_Lights.Enums;
using System;

namespace _09.Traffic_Lights
{
    public class TrafficLight
    {
        public TrafficLight(string light)
        {
            this.Light = (TrafficLights) Enum.Parse(typeof(TrafficLights), light);
        }

        public TrafficLights Light { get; private set; }

        public void Cycle()
        {
            this.Light += 1;

            if((int)this.Light > 2)
            {
                this.Light = 0;
            }
        }

        public override string ToString()
        {
            return $"{this.Light}";
        }
    }
}
