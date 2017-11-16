using System;

namespace CameraBazaar.Data.Enums
{
    [Flags]
    public enum LightMeter
    {
        Spot = 1,
        CenterWeighted = 2,
        Evaluative = 4,
    }
}
