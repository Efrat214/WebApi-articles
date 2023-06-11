using EntityFrameWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class ArticasDAL : ArticalsIDAL
    {
       FinalArticelsDbContext db=new FinalArticelsDbContext();
        
        public bool isExist(Article a)
        {
            Article a1 = db.Articles.FirstOrDefault(x => x.Title.Equals(a.Title));
            return a1 != null;

        }
        public int AddArticale(Article a)
        {
            Article a1=db.Articles.FirstOrDefault(x=>x.Title.Equals(a.Title));
            if (a1 == null)
            {
                db.Articles.Add(a);
                db.SaveChanges();
                return a.Id;
            }
            return a1.Id;
            
        }

        public void DeleteArticale(int Id)
        {
            db.Articles.Remove(db.Articles.FirstOrDefault(x => x.Id == Id));
            db.SaveChanges();
        }

        public List<Article> GetAllArticals()
        {
            return db.Articles.ToList();
        }

        public List<Article> GetArticaleByCategory(Category c)
        {
            List<Article> a = new List<Article>();
            foreach (var item in db.Articles.ToList())
            {
                if (item.Category == c.Id)
                    a.Add(item);
            }
            return a;
        }

        public void UpdatArticale(int Id, Article a)
        {
            throw new NotImplementedException();
        }
        public Article GetArticleById(int Id)
        {
            return db.Articles.FirstOrDefault(x => x.Id == Id);
        }
       public Article GetArticleByTitle(string title)
        {
            return db.Articles.FirstOrDefault(x => x.Title.Equals(title));

        }

    }
}
