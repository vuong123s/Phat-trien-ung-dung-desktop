using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
    public class TableBL
    {
        private TableDA tableDA = new TableDA();

        public List<Table> GetAll()
        {
            return tableDA.GetAll();
        }

        public int Insert(Table table)
        {
            ValidateTable(table);
            return tableDA.Insert(table);
        }

        public int Update(Table table)
        {
            ValidateTable(table);
            return tableDA.Update(table);
        }

        public int Delete(int tableID)
        {
            return tableDA.Delete(tableID);
        }

        public int UpdateStatus(int tableID, int status)
        {
            return tableDA.UpdateStatus(tableID, status);
        }

        private void ValidateTable(Table table)
        {
            if (string.IsNullOrEmpty(table.Name))
                throw new Exception("Tên bàn không được để trống");

            if (table.Capacity <= 0)
                throw new Exception("Sức chứa phải lớn hơn 0");

            if (table.Status < 0 || table.Status > 2)
                throw new Exception("Trạng thái bàn không hợp lệ");
        }

        public List<Table> Find(string keyword)
        {
            var allTables = GetAll();
            if (string.IsNullOrEmpty(keyword))
                return allTables;

            return allTables.Where(t =>
                t.Name.ToLower().Contains(keyword.ToLower()) ||
                t.ID.ToString().Contains(keyword) ||
                t.Capacity.ToString().Contains(keyword) ||
                GetStatusText(t.Status).ToLower().Contains(keyword.ToLower())
            ).ToList();
        }

        public string GetStatusText(int status)
        {
            switch (status)
            {
                case 0: return "Trống";
                case 1: return "Đang dùng";
                case 2: return "Đã đặt";
                default: return "Không xác định";
            }
        }
    }
}