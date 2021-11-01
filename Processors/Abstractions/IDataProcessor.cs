using System.Collections.Generic;
using Module3HW8.Models;

namespace Module3HW8.Processors.Abstractions
{
    public interface IDataProcessor
    {
        public List<User> GetUsers(List<string> usersFromFile);
        public List<Order> GetOrders(List<string> usersFromFile);
        public string GetResults(List<User> users, List<Order> orders);
    }
}
