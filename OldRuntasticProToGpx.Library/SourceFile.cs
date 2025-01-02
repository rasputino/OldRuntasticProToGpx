using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OldRuntasticProToGpx.Library
{
    internal class SourceFile
    {

        private string _dbPath;

        internal SourceFile(string fileName)
        {
            _dbPath = fileName;
            if (string.IsNullOrWhiteSpace(fileName) || !File.Exists(fileName))
            {
                throw new UserMessageException("Source file doesn't exist");
            }
        }

        internal List<OldRuntasticData> GetGpsData()
        {
            using (var connection = new SQLiteConnection($"Data Source={_dbPath};Version=3;"))
            {
                connection.Open();
                string query = "SELECT _ID, gpsTrace, avgPulse, maxPulse, note, hrTrace FROM session WHERE gpsTrace IS NOT NULL";

                var data = new List<OldRuntasticData>();
                using (var command = new SQLiteCommand(query, connection))
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var sessionData = new OldRuntasticData();
                        sessionData.SessionId = reader.GetInt32(0);
                        byte[] gpsTrace = (byte[])reader["gpsTrace"];
                        byte[]? heartRateData = reader["hrTrace"] != DBNull.Value ? (byte[])reader["hrTrace"] : null;
                        sessionData.AvgPulse = reader.IsDBNull(2) ? -1 : reader.GetInt32(2);
                        sessionData.MaxPulse = reader.IsDBNull(3) ? -1 : reader.GetInt32(3);
                        sessionData.Note = reader.IsDBNull(4) ? string.Empty : reader.GetString(4);

                        sessionData.GpsPoints = DecodeGpsData(gpsTrace);
                        sessionData.HeartRateDataRecords = DecodeHeartRateData(heartRateData);
                        if (sessionData.GpsPoints.Count > 0)
                        {
                            data.Add(sessionData);
                        }
                    }
                }

                return data;
            }
        }

        private static byte[] ReadBigEndian(BinaryReader reader, int count)
        {
            byte[] bytes = reader.ReadBytes(count);
            Array.Reverse(bytes); // Cambiar a big-endian
            return bytes;
        }

        static List<GpsPoint> DecodeGpsData(byte[] rawData)
        {
            var gpsDataList = new List<GpsPoint>();

            try
            {
                using (var stream = new MemoryStream(rawData))
                using (var reader = new BinaryReader(stream))
                {
                    // Leer el número total de puntos (primeros 4 bytes en big-endian)
                    int totalPoints = BitConverter.ToInt32(ReadBigEndian(reader, 4), 0);

                    for (int i = 0; i < totalPoints; i++)
                    {
                        try
                        {
                            // Leer los campos según el formato de GpsDataNew
                            long systemTimestamp = BitConverter.ToInt64(ReadBigEndian(reader, 8), 0); // 8 bytes
                            float longitude = BitConverter.ToSingle(ReadBigEndian(reader, 4), 0);     // 4 bytes
                            float latitude = BitConverter.ToSingle(ReadBigEndian(reader, 4), 0);      // 4 bytes
                            float altitude = BitConverter.ToSingle(ReadBigEndian(reader, 4), 0);      // 4 bytes
                            short accuracy = BitConverter.ToInt16(ReadBigEndian(reader, 2), 0);       // 2 bytes
                            float speed = BitConverter.ToSingle(ReadBigEndian(reader, 4), 0);         // 4 bytes
                            int runtime = BitConverter.ToInt32(ReadBigEndian(reader, 4), 0);          // 4 bytes
                            int distance = BitConverter.ToInt32(ReadBigEndian(reader, 4), 0);         // 4 bytes
                            short elevationGain = BitConverter.ToInt16(ReadBigEndian(reader, 2), 0);  // 2 bytes
                            short elevationLoss = BitConverter.ToInt16(ReadBigEndian(reader, 2), 0);  // 2 bytes

                            gpsDataList.Add(new GpsPoint
                            {
                                SystemTimestamp = systemTimestamp,
                                Longitude = longitude,
                                Latitude = latitude,
                                Altitude = altitude,
                                Accuracy = accuracy,
                                Speed = speed,
                                Runtime = runtime,
                                Distance = distance,
                                ElevationGain = elevationGain,
                                ElevationLoss = elevationLoss
                            });
                        }
                        catch
                        {
                            break; // Detener la lectura si hay errores graves
                        }
                    }
                }
            }
            catch
            {
                Console.WriteLine("Error al procesar los datos GPS.");
            }

            return gpsDataList;
        }


        public static List<HeartRateData> DecodeHeartRateData(byte[]? data)
        {
            var heartRateDataList = new List<HeartRateData>();

            if (data == null || data.Length == 0)
            {
                return heartRateDataList; // Devuelve una lista vacía si no hay datos
            }

            try
            {
                using (var stream = new MemoryStream(data))
                using (var reader = new BinaryReader(stream))
                {
                    int recordCount = BitConverter.ToInt32(ReadBigEndian(reader, 4), 0); // Número de registros


                    //18 bytes por paso
                    for (int i = 0; i < recordCount; i++)
                    {
                        var record = new HeartRateData
                        {
                            Timestamp = BitConverter.ToInt64(ReadBigEndian(reader, 8), 0),          // Timestamp
                            HeartRate = reader.ReadByte()           // Frecuencia cardíaca
                        };
                        int cander = reader.ReadByte(); // Ignora el espacio reservado
                        record.Duration = BitConverter.ToInt32(ReadBigEndian(reader, 4), 0);        // Duración
                        record.Distance = BitConverter.ToInt32(ReadBigEndian(reader, 4), 0);        // Distancia

                        heartRateDataList.Add(record);
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Error decoding heart rate data: " + e.Message);
            }

            return heartRateDataList;
        }
    }

}
