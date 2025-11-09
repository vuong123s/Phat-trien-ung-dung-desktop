using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
    public class AccountBL
    {
        private AccountDA accountDA = new AccountDA();

        public List<Account> GetAll()
        {
            return accountDA.GetAll();
        }

        public int Insert(Account account)
        {
            ValidateAccount(account);
            return accountDA.Insert(account);
        }

        public int Update(Account account)
        {
            ValidateAccount(account);
            return accountDA.Update(account);
        }

        public int ResetPassword(string accountName, string newPassword)
        {
            if (string.IsNullOrEmpty(accountName) || string.IsNullOrEmpty(newPassword))
                throw new Exception("Tên tài khoản và mật khẩu không được để trống");

            if (newPassword.Length < 6)
                throw new Exception("Mật khẩu phải có ít nhất 6 ký tự");

            return accountDA.ResetPassword(accountName, newPassword);
        }

        private void ValidateAccount(Account account)
        {
            if (string.IsNullOrEmpty(account.AccountName))
                throw new Exception("Tên tài khoản không được để trống");

            if (string.IsNullOrEmpty(account.FullName))
                throw new Exception("Họ tên không được để trống");

            if (account.AccountName.Length > 100)
                throw new Exception("Tên tài khoản không được vượt quá 100 ký tự");
        }

        public List<Account> Find(string keyword)
        {
            var allAccounts = GetAll();
            if (string.IsNullOrEmpty(keyword))
                return allAccounts;

            return allAccounts.Where(a =>
                a.AccountName.ToLower().Contains(keyword.ToLower()) ||
                a.FullName.ToLower().Contains(keyword.ToLower()) ||
                a.Email.ToLower().Contains(keyword.ToLower()) ||
                a.Tell.Contains(keyword)
            ).ToList();
        }

        public Account Login(string accountName, string password)
        {
            return accountDA.Login(accountName, password);
        }

        
    }
}