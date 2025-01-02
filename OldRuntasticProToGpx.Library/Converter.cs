namespace OldRuntasticProToGpx.Library
{
    public static class Converter
    {
        public static void Convert(string sourceFilePath, string outputFolder, ILogger _logger)
        {
            var sourceFile = new SourceFile(sourceFilePath, _logger);
            var oldRuntasticData = sourceFile.GetGpsData();
            GpxFile.BatchCreateGpxFileWithGarminExtensions(outputFolder, oldRuntasticData, _logger);
            _logger.Log("All OK! Enjoy your old .gpx files");
        }
    }
}
