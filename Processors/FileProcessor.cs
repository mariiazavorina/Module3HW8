using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.IO;
using Module3HW8.Processors.Abstractions;

namespace Module3HW8.Processors
{
    public class FileProcessor : IFileProcessor
    {
        public async Task<List<string>> ReadAsync(string path)
        {
            var dataList = new List<string>();
            using (StreamReader sr = new StreamReader(path, System.Text.Encoding.Default))
            {
                string line;
                while ((line = await sr.ReadLineAsync()) != null)
                {
                    dataList.Add(line);
                }
            }

            Console.WriteLine("Reading completed.");
            return dataList;
        }

        public async void WriteAsync<T>(string path, T data)
        {
            using (StreamWriter streamWriter = new StreamWriter(path, false, System.Text.Encoding.Default))
            {
                await streamWriter.WriteAsync(Convert.ToString(data));
            }

            Console.WriteLine("Writing completed.");
        }
    }
}
