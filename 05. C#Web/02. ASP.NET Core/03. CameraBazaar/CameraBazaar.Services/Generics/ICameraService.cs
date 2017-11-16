using CameraBazaar.Data.Enums;
using System.Collections.Generic;

namespace CameraBazaar.Services.Generics
{
    public interface ICameraService
    {
        void Create(CameraMake make, string model, decimal price, int quantity,
                    int minShutterSpeed, int maxShutterSpeed, MinISO minISO,
                    int maxIso, bool isFullFrame, string videoResolution, 
                    IEnumerable<LightMeter> lightMeterings, string description, 
                    string imageUrl, string userId);
    }
}
