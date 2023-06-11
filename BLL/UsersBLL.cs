using EntityFrameWork;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class UsersBLL : UsersIBLL
    {
        UsersIDAL usersIDAL;
        public UsersBLL(UsersIDAL usersIDAL)
        {
            this.usersIDAL = usersIDAL;
        }
        public User AddUser(User u)
        {
           
            return usersIDAL.AddUser(u);
        }

        public void DeleteUser(int Id)
        {
            usersIDAL.DeleteUser(Id);
        }

        public List<User> GetAllUsers()
        {
            return usersIDAL.GetAllUsers();
        }

        public User GetUserByMail(string mail)
        {
            return usersIDAL.GetUserByMail(mail);
        }

        public void UpdateUSer(int Id, User u)
        {
            usersIDAL.UpdateUSer(Id, u);
        }
        public User GetUserById(int id)
        {
            return usersIDAL.GetUserById(id);
        }

    }
}
