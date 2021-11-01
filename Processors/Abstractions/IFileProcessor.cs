using System.Collections.Generic;
using System.Threading.Tasks;

namespace Module3HW8.Processors.Abstractions
{
    public interface IFileProcessor
    {
        public Task<List<string>> ReadAsync(string path);
        public void WriteAsync<T>(string path, T data);
    }
}
