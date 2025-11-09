using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
    public class RoleBL
    {
        private RoleDA roleDA = new RoleDA();

        public List<Role> GetAll()
        {
            return roleDA.GetAll();
        }

        public List<RoleAccount> GetAccountRoles(string accountName)
        {
            return roleDA.GetAccountRoles(accountName);
        }

        public int UpdateAccountRoles(string accountName, int roleID, bool isAssigned)
        {
            return roleDA.UpdateAccountRoles(accountName, roleID, isAssigned);
        }

        public void UpdateAllAccountRoles(string accountName, List<RoleAccount> roles)
        {
            foreach (var role in roles)
            {
                roleDA.UpdateAccountRoles(accountName, role.RoleID, role.Actived);
            }
        }

        public List<Role> GetAvailableRoles()
        {
            return GetAll().Where(r => r.ID != 1).ToList(); // Loại trừ Admin nếu cần
        }

        public bool HasRole(string accountName, int roleID)
        {
            var accountRoles = GetAccountRoles(accountName);
            return accountRoles.Any(ar => ar.RoleID == roleID && ar.Actived);
        }

        public string GetRoleNames(string accountName)
        {
            var accountRoles = GetAccountRoles(accountName);
            var allRoles = GetAll();

            var roleNames = accountRoles
                .Where(ar => ar.Actived)
                .Join(allRoles,
                    ar => ar.RoleID,
                    r => r.ID,
                    (ar, r) => r.RoleName);

            return string.Join(", ", roleNames);
        }
    }
}