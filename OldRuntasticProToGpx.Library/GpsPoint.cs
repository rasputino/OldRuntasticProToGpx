using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OldRuntasticProToGpx.Library
{
    internal class GpsPoint
    {
        public long SystemTimestamp { get; set; }
        public float Longitude { get; set; }
        public float Latitude { get; set; }
        public float Altitude { get; set; }
        public short Accuracy { get; set; }
        public float Speed { get; set; }
        public int Runtime { get; set; }
        public int Distance { get; set; }
        public short ElevationGain { get; set; }
        public short ElevationLoss { get; set; }
    }
}
