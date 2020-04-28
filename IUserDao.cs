using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Users.Entities;
namespace Users.DAL
{
    public  interface IUserDao
    {
        IEnumerable<User> GetUsers();
        IEnumerable<User> GetNeedUsers(int index);
        void AddUser(User user);
        void RemoveUser(int index);
    }
}
