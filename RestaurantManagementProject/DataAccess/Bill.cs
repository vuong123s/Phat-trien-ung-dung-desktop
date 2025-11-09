using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class Bill
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int TableID { get; set; }
        public string TableName { get; set; }
        public int Amount { get; set; }
        public double Discount { get; set; }
        public double Tax { get; set; }
        public bool Status { get; set; }
        public string StatusText { get; set; }
        public DateTime? CheckoutDate { get; set; }
        public string Account { get; set; }
        public decimal ActualAmount { get; set; }
    }

    public class BillDetail
    {
        public int ID { get; set; }
        public int InvoiceID { get; set; }
        public int FoodID { get; set; }
        public string FoodName { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public decimal TotalPrice { get; set; }
        public string Unit { get; set; }
        public string CategoryName { get; set; }
    }
}