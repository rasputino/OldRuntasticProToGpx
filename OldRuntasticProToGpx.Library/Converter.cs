namespace OldRuntasticProToGpx.Library
{
    public static class Converter
    {
        public static void Convert(string sourceFilePath, string outputFolder)
        {
            var sourceFile = new SourceFile(sourceFilePath);
            var oldRuntasticData = sourceFile.GetGpsData();
            GpxFile.BatchCreateGpxFileWithGarminExtensions(outputFolder, oldRuntasticData);
        }
    }
}
