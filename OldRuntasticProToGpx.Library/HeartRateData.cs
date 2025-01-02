using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OldRuntasticProToGpx.Library
{
    internal class HeartRateData
    {
        /// <summary>
        /// milliseconds
        /// </summary>
        public long Timestamp { get; set; }
        /// <summary>
        /// BPM
        /// </summary>
        public int HeartRate { get; set; }

        /// <summary>
        /// seconds
        /// </summary>
        public int Duration { get; set; }

        /// <summary>
        /// meters
        /// </summary>
        public int Distance { get; set; }

        public override string ToString()
        {
            return $"HeartRateData [Timestamp={Timestamp}, HeartRate={HeartRate}, Duration={Duration}, Distance={Distance}]";
        }
    }
}
