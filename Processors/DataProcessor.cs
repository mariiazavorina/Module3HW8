using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Module3HW8.Processors.Abstractions;
using Module3HW8.Models;

namespace Module3HW8.Processors
{
    public class DataProcessor : IDataProcessor
    {
        public List<User> GetUsers(List<string> usersFromFile)
        {
            var usersList = new List<User>();
            foreach (var user in usersFromFile)
            {
                string[] userData = user.Split(';');
                var newUser = new User()
                {
                    Id = Convert.ToInt32(userData[0]),
                    Name = userData[1],
                    Gender = userData[2],
                    Age = Convert.ToInt32(userData[3])
                };
                usersList.Add(newUser);
            }

            return usersList;
        }

        public List<Order> GetOrders(List<string> ordersFromFile)
        {
            var ordersList = new List<Order>();
            foreach (var order in ordersFromFile)
            {
                string[] orderInfo = order.Split(';');
                var newOrder = new Order()
                {
                    Id = Convert.ToInt32(orderInfo[0]),
                    User_Id = Convert.ToInt32(orderInfo[1]),
                    Order_Number = Convert.ToInt32(orderInfo[2]),
                    Order_Date = Convert.ToDateTime(orderInfo[3]),
                    Total = Convert.ToDecimal(orderInfo[4])
                };
                ordersList.Add(newOrder);
            }

            return ordersList;
        }

        public string GetResults(List<User> users, List<Order> orders)
        {
            var resultsString = new StringBuilder();
            var selectedOrders = from user in users
                                 from order in orders
                                 where user.Id == order.User_Id
                                 where user.Age > 18 && user.Age < 65
                                 where order.Order_Date >= DateTime.Now.AddDays(-7)
                                 orderby order.Order_Date descending
                                 select new
                                 {
                                     Order_Number = order.Order_Number,
                                     Order_Date = order.Order_Date.ToString("yyyy-MM-dd"),
                                     User_Name = user.Name,
                                     Total = order.Total
                                 };
            foreach (var selected in selectedOrders)
            {
                resultsString.AppendLine($"{selected.Order_Number};{selected.Order_Date};{selected.User_Name};{selected.Total};");
            }

            return resultsString.ToString();
        }
    }
}
