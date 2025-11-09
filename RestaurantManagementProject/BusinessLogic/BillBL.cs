using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BusinessLogic
{
    public class BillBL
    {
        private BillDA billDA = new BillDA();

        public List<Bill> GetAll()
        {
            return billDA.GetAll();
        }

        public List<BillDetail> GetBillDetails(int billID)
        {
            return billDA.GetBillDetails(billID);
        }

        public int CreateBill(int tableID, List<OrderItem> orderItems, string accountName)
        {
            if (orderItems == null || orderItems.Count == 0)
                throw new Exception("Hóa đơn phải có ít nhất một món");

            // Guard against null items inside list
            if (orderItems.Any(oi => oi == null))
                throw new Exception("Danh sách món không hợp lệ.");

            Bill bill = new Bill();
            bill.Name = "Hóa đơn bàn " + tableID;
            bill.TableID = tableID;

            // Safe sum (in case any TotalPrice is unexpected)
            decimal total = orderItems.Sum(oi => oi?.TotalPrice ?? 0m);
            bill.Amount = Convert.ToInt32(total);
            bill.Discount = 0;
            bill.Tax = 0;
            bill.Status = false;

            // Allow null accountName but set to empty string to avoid null usage later
            bill.Account = accountName ?? string.Empty;

            var billDetails = orderItems.Select(oi => new BillDetail
            {
                FoodID = oi.FoodID,
                Quantity = oi.Quantity,
                Price = oi.UnitPrice,
                TotalPrice = oi.TotalPrice
            }).ToList();

            return billDA.CreateBill(bill, billDetails);
        }

        public decimal CalculateTotalAmount(int billID)
        {
            var details = GetBillDetails(billID);
            return details.Sum(d => d.TotalPrice);
        }

        public List<Bill> Find(string keyword)
        {
            var allBills = GetAll();
            if (string.IsNullOrEmpty(keyword))
                return allBills;

            return allBills.Where(b =>
                (b.Name ?? string.Empty).ToLower().Contains(keyword.ToLower()) ||
                b.ID.ToString().Contains(keyword) ||
                (b.TableName ?? string.Empty).ToLower().Contains(keyword.ToLower()) ||
                (b.Account ?? string.Empty).ToLower().Contains(keyword.ToLower()) ||
                b.Amount.ToString().Contains(keyword)
            ).ToList();
        }
    }

    public class OrderItem
    {
        public int FoodID { get; set; }
        public string FoodName { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal TotalPrice { get; set; }
    }
}