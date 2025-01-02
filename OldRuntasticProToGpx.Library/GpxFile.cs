using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace OldRuntasticProToGpx.Library
{
    internal class GpxFile
    {

        internal static void BatchCreateGpxFileWithGarminExtensions(string outputFolder, List<OldRuntasticData> oldRuntasticData, ILogger _logger)
        {
            _logger.Log("Exporting gpx files...");
            foreach(var oldSession in oldRuntasticData)
            {
                var filePath = Path.Combine(outputFolder, $"{oldSession.SessionId}.gpx");
                CreateGpxFileWithGarminExtensions(filePath, oldSession);
                _logger.Log($"{filePath} created.");
            }
        }

        internal static void CreateGpxFileWithGarminExtensions(string filePath, OldRuntasticData runtasticData)
        {
            ArgumentNullException.ThrowIfNull(runtasticData.GpsPoints);

            XNamespace gpxNamespace = "http://www.topografix.com/GPX/1/1";
            XNamespace garminNamespace = "http://www.garmin.com/xmlschemas/TrackPointExtension/v1";

            var note = runtasticData.Note;

            var gpx = new XElement(gpxNamespace + "gpx",
                new XAttribute("version", "1.1"),
                new XAttribute("creator", "Garmin Exporter"),
                new XAttribute(XNamespace.Xmlns + "xsi", "http://www.w3.org/2001/XMLSchema-instance"),
                new XAttribute(XNamespace.Xmlns + "gpxtpx", garminNamespace.NamespaceName),

                // Metadata opcional
                string.IsNullOrWhiteSpace(note) ? null : new XElement(gpxNamespace + "metadata",
                    new XElement(gpxNamespace + "desc", note),
                    new XElement(gpxNamespace + "name", note),
                    new XElement(gpxNamespace + "author", "Pablo León"),
                    new XElement(gpxNamespace + "time", DateTimeOffset.FromUnixTimeMilliseconds(runtasticData.GpsPoints.First().SystemTimestamp).ToString("s"))
                ),

                // Información del track
                new XElement(gpxNamespace + "trk",
                    //new XElement(gpxNamespace + "name", $"Session {Path.GetFileNameWithoutExtension(filePath)}"),
                    new XElement(gpxNamespace + "name", note),
                    new XElement(gpxNamespace + "trkseg",
                        runtasticData.GpsPoints.ConvertAll(point =>
                        {
                            // Buscar el ritmo cardíaco más cercano
                            var nearestHeartRate = runtasticData.HeartRateDataRecords?
                                .Where(hr => hr.HeartRate > 0) // Filtrar valores mayores a 0
                                .OrderBy(hr => Math.Abs(hr.Timestamp - point.SystemTimestamp))
                                .FirstOrDefault();

                            return new XElement(gpxNamespace + "trkpt",
                                new XAttribute("lat", point.Latitude.ToString(CultureInfo.InvariantCulture)),
                                new XAttribute("lon", point.Longitude.ToString(CultureInfo.InvariantCulture)),
                                new XElement(gpxNamespace + "ele", point.Altitude.ToString(CultureInfo.InvariantCulture)),
                                new XElement(gpxNamespace + "time", DateTimeOffset.FromUnixTimeMilliseconds(point.SystemTimestamp).UtcDateTime.ToString("o")),

                                // Extensiones de Garmin (solo si hay un ritmo cardíaco válido)
                                nearestHeartRate != null ? new XElement(gpxNamespace + "extensions",
                                    new XElement(garminNamespace + "TrackPointExtension",
                                        new XElement(garminNamespace + "hr", nearestHeartRate.HeartRate)
                                    )
                                ) : null
                            );
                        })
                    )
                )
            );

            gpx.Save(filePath);
        }

    }
}
