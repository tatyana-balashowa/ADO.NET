using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Users.DAL;
using Users.Entities;
namespace Users.BLL
{
    public class UserLogic : IUserLogic
    {
        private IUserDao userDao;
        public UserLogic()
        {
            userDao = new UserDaoDB();
        }
        public void AddUser(User user)
        {
            userDao.AddUser(user);
        }
        public IEnumerable <User> GetUsers()
        {
            return userDao.GetUsers();
        }
        public IEnumerable<User> GetNeedUsers(int index)
        {
            return userDao.GetNeedUsers(index);
        }
        public void RemoveUser (int index)
        {
            userDao.RemoveUser(index);
        }

    }
}
