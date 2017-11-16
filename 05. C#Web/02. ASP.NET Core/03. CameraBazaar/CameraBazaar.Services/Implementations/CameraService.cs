using CameraBazaar.Data;
using CameraBazaar.Data.Enums;
using CameraBazaar.Data.Models;
using CameraBazaar.Services.Generics;
using System.Collections.Generic;
using System.Linq;

namespace CameraBazaar.Services.Implementations
{
    public class CameraService : ICameraService
    {
        private readonly AppDbContext db;

        public CameraService(AppDbContext db)
        {
            this.db = db;
        }

        public void Create(CameraMake make, string model, decimal price, int quantity, int minShutterSpeed, int maxShutterSpeed, MinISO minISO, int maxIso, bool isFullFrame, string videoResolution, IEnumerable<LightMeter> lightMeterings, string description, string imageUrl, string userId)
        {
            var camera = new Camera
            {
                Make = make,
                Model = model,
                Price = price,
                Quantity = quantity,
                MinShutterSpeed = minShutterSpeed,
                MaxShutterSpeed = maxShutterSpeed,
                MinISO = minISO,
                MaxISO = maxIso,
                IsFullFrame = isFullFrame,
                VideoResolution = videoResolution,
                LightMetering = (LightMeter)lightMeterings.Cast<int>().Sum(),
                Description = description,
                ImageUrl = imageUrl,
                UserId = userId
            };

            this.db.Add(camera);
            this.db.SaveChanges();
        }
    }
}
