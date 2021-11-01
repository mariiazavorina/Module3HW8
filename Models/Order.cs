using System;

namespace Module3HW8.Models
{
    public class Order
    {
        public int Id { get; init; }
        public int User_Id { get; init; }
        public int Order_Number { get; init; }
        public DateTime Order_Date { get; init; }
        public decimal Total { get; init; }
    }
}
