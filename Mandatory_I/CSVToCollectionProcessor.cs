using System.Globalization;
using CsvHelper;
using CsvHelper.Configuration;

namespace Mandatory_I
{
    internal class CSVToCollectionProcessor<T>
    {

        public void ProcessCSV(string directoryName, string CSVFileName, List<T> collection)
        {
            CsvConfiguration config = new(CultureInfo.InvariantCulture);

            StreamReader streamReader = new(@"test/" + "/" + directoryName + "/" + CSVFileName);
            CsvReader csvReader = new(streamReader, config);
            {
                while (csvReader.Read())
                {
                    var record = csvReader.GetRecord<T>();
                    if (record != null)
                    {
                        collection.Add(record);
                    }
                    
                }
                csvReader.Dispose();
                streamReader.Close();
            }
        }
    }
}
