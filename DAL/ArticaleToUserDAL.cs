using EntityFrameWork;

namespace DAL
{
    public class ArticaleToUserDAL : ArticaleToUserIDAL
    {
        FinalArticelsDbContext db = new FinalArticelsDbContext();
        public void AddArticaleToUser(ArticaleToUser w)
        {
            ArticaleToUser a1=db.ArticaleToUsers.FirstOrDefault(x=> x.UserId == w.UserId&&x.Articale==w.Articale);  
            if (a1 == null)
            {
                db.ArticaleToUsers.Add(w);
                db.SaveChanges();
            }
        }

        public void DeleteArticaleToUser(int artID)
        {
            db.ArticaleToUsers.Remove(db.ArticaleToUsers.FirstOrDefault(x => x.Articale == artID));
            db.SaveChanges(); ;
        }

        public List<Article> GetAllArticaleToUser(int userID)
        {
            var innerJoinQuery = from articaleToUser in db.ArticaleToUsers
                                 join article in db.Articles on articaleToUser.Articale equals article.Id
                                 where articaleToUser.UserId == userID
                                 select new Article
                                 {
                                     Category = article.Category,
                                     Link = article.Link,
                                     Title = article.Title,
                                     Id = article.Id
                                 };

            return innerJoinQuery.ToList();
        }

        public ArticaleToUser GetArticaleToUserById(int Id)
        {
            throw new NotImplementedException();
        }

        public void UpdateArticaleToUser(int Id, ArticaleToUser w)
        {
            throw new NotImplementedException();
        }
    }
}
