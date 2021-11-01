using Module3HW8.Processors.Abstractions;

namespace Module3HW8
{
    public class Starter
    {
        private readonly IFileProcessor _fileProcessor;
        private readonly IDataProcessor _dataProcessor;

        public Starter(IFileProcessor fileProcessor, IDataProcessor dataProcessor)
        {
            _fileProcessor = fileProcessor;
            _dataProcessor = dataProcessor;
        }

        public void Run()
        {
            var usersFromFile = _fileProcessor.ReadAsync("users.txt").Result;
            var ordersFromFile = _fileProcessor.ReadAsync("orders.txt").Result;
            var listOfUserModels = _dataProcessor.GetUsers(usersFromFile);
            var listOfOrderModels = _dataProcessor.GetOrders(ordersFromFile);

            var resultsList = _dataProcessor.GetResults(listOfUserModels, listOfOrderModels);
            _fileProcessor.WriteAsync<string>("results.txt", resultsList);
        }
    }
}
