using System.Globalization;
using CsvHelper;
using CsvHelper.Configuration;

namespace Mandatory_I
{
    internal class CollectionToCSVProcessor<T>
    {

        public void ProcessCSV(string directoryName, string CSVFileName, List<T> collection)
        {
            CsvConfiguration config = new(CultureInfo.InvariantCulture);

            StreamWriter streamWriter = new(@"test/" + "/" + directoryName + "/" + CSVFileName);
            CsvWriter csvWriter = new (streamWriter, config);
            {
                csvWriter.WriteRecords(collection);
                csvWriter.Flush();
                streamWriter.Close();
            }
        }
    }
}
