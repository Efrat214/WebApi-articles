using EntityFrameWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public interface ArticalsIDAL
    {
        List<Article> GetAllArticals();
        List<Article> GetArticaleByCategory(Category c);

        int AddArticale(Article a);
        void UpdatArticale(int Id, Article a);
        void DeleteArticale(int Id);
        Article GetArticleById(int Id);
        public bool isExist(Article a);
        Article GetArticleByTitle(string title);

    }
}
