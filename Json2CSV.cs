using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fusion2CSV
{
    public class Fusion2CSV
    {
        public void ResponseToFile(string response, string file)
        {
            var csvText = ResponseFormatter(response);
            WriteToCSV(csvText, file);
        }

        private string ResponseFormatter(string response)
        {
            var newResponse = response.Replace(@"\\n", "");
            newResponse = response.Replace(@"\r", "");
            newResponse = newResponse.Replace(@"\n", "\n");
            //newResponse = newResponse.Replace(",", ", ");
            newResponse = newResponse.Replace("\"", "");
            var finalText = new StringBuilder();
            using (StringReader reader = new StringReader(newResponse))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    line = $"\"{line}\"";
                    line = line.Replace(@"\t", "\"\\t\"");
                    line = line.Replace(@"\t", ",");
                    finalText.AppendLine(line);
                }
            }
            //newResponse = newResponse.Replace(@"\t", "\t");

            return finalText.ToString();
        }

        private void WriteToCSV(string response, string file)
        {
            System.IO.File.WriteAllText(file, response);
        }
    }
}
