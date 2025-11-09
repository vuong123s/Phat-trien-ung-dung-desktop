using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace DataAccess
{
    public class Utilities
    {
        // Lấy chuỗi kết nối từ tập tin App.Config
        private static string StrName = "KetNoiDB";
        public static string ConnectionString = ConfigurationManager.ConnectionStrings[StrName]?.ConnectionString;

        // Các biến của bảng Food
        public static string Food_GetAll = "Food_GetAll";
        public static string Food_InsertUpdateDelete = "Food_InsertUpdateDelete";

        // Các biến của bảng Category
        public static string Category_GetAll = "Category_GetAll";
        public static string Category_InsertUpdateDelete = "Category_InsertUpdateDelete";
        public static string Category_Search = "Category_Search";

        // Store procedures cho Account/User
        public static string User_Login = "User_Login";
        public static string GetAllAccounts = "GetAllAccounts";
        public static string InsertAccount = "InsertAccount";
        public static string UpdateAccount = "UpdateAccount";
        public static string ResetPassword = "ResetPassword";
        public static string GetAccountRoles = "GetAccountRoles";
        public static string UpdateAccountRoles = "UpdateAccountRoles";

        // Store procedures cho Bill - ĐÃ SỬA THEO CẤU TRÚC THỰC TẾ
        public static string Bill_GetAll = "Bill_GetAll";
        public static string Bill_InsertUpdateDelete = "Bill_InsertUpdateDelete";
        public static string Bill_Search = "Bill_Search";
        public static string GetBillDetails = "GetBillDetails";
        public static string GetAccountActivity = "GetAccountActivity";
    }
}