using EntityFrameWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public interface UsersIDAL
    {
        List<User> GetAllUsers();
        User GetUserByMail(string mail);

        User AddUser(User u);
        void UpdateUSer(int Id, User u);
        void DeleteUser(int Id);
        User GetUserById(int id);

    }
}
