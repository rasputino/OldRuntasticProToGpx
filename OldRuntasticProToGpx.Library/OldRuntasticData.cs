using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OldRuntasticProToGpx.Library
{
    internal class OldRuntasticData
    {
        internal int SessionId { get; set; }
        internal string? Note { get; set; }
        internal int MaxPulse { get; set; }
        internal int AvgPulse { get; set; }
        internal List<GpsPoint>? GpsPoints { get; set; }
        internal List<HeartRateData>? HeartRateDataRecords { get; set; }

    }
}
