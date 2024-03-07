using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using WheelyRev.Models;

namespace WheelyRev
{
    public class MyRole : RoleProvider
    {
        public override string ApplicationName
        {
            get
            {
                throw new NotImplementedException();
            }

            set
            {
                throw new NotImplementedException();
            }
        }

        public override void AddUsersToRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override void CreateRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override bool DeleteRole(string roleName, bool throwOnPopulatedRole)
        {
            throw new NotImplementedException();
        }

        public override string[] FindUsersInRole(string roleName, string usernameToMatch)
        {
            throw new NotImplementedException();
        }

        public override string[] GetAllRoles()
        {
            using (var db = new WheelyRevEntities())
            {
                //Same as
                //SELECT roleName FROM vw_UserRole
                return db.vw_UserRoles.Select(m => m.roleName).ToArray();
            }
        }

        public override string[] GetRolesForUser(string username)
        {
            using (var db = new WheelyRevEntities())
            {
                //Same as
                //SELECT roleName WHERE username == username
                return db.vw_UserRoles.Where(m => m.username == username).Select(m => m.roleName).ToArray();
            }
        }

        public override string[] GetUsersInRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override bool IsUserInRole(string username, string roleName)
        {
            throw new NotImplementedException();
        }

        public override void RemoveUsersFromRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override bool RoleExists(string roleName)
        {
            throw new NotImplementedException();
        }
    }
}