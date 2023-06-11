using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityFrameWork;

namespace BLL
{
    public interface UsersIBLL
    {
        List<User> GetAllUsers();
        User GetUserByMail(string mail);
        User GetUserById(int id);
        User AddUser(User u);
        void UpdateUSer(int Id, User u);
        void DeleteUser(int Id);
    }
}
