using EntityFrameWork;

namespace DAL
{
    public class UsersDAL : UsersIDAL
    {
        FinalArticelsDbContext db = new FinalArticelsDbContext();
        public User AddUser(User u)
        {
            db.Users.Add(u);
            db.SaveChanges();
            return db.Users.FirstOrDefault(x=>x.Id==u.Id);
        }

        public void DeleteUser(int Id)
        {
            db.Users.Remove(db.Users.FirstOrDefault(x => x.Id == Id));
            db.SaveChanges();
        }

        public List<User> GetAllUsers()
        {
            return db.Users.ToList();
        }

        public User GetUserByMail(string mail)
        {
            //User u = db.Users.FirstOrDefault(x => x.Mail.Equals(userDetails[0]));
            //if (u != null)
            //{
            //    if (u.Password.Equals(userDetails[1]))
            //        return u;
            //    return null;

            //}
            //return null;
            return db.Users.FirstOrDefault(x => x.Mail.Equals(mail));
        }

        public void UpdateUSer(int Id, User u)
        {
            var user = db.Users.FirstOrDefault(x => x.Id == Id);
            if (user != null)
            {
                user.Level=u.Level;
                user.Password = u.Password;
                user.Name = u.Name;
                user.IsAdmin = u.IsAdmin;
                db.SaveChanges();
            }
        }
        public User GetUserById(int id)
        {
            return db.Users.FirstOrDefault(x => x.Id==id);

        }

    }
}
