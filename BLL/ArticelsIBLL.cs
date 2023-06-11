using EntityFrameWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public interface ArticelsIBLL
    {
        List<Article> GetAllArticels();
        List<Article> GetArticleByCategory(Category c);

        int AddArticel(Article a);
        void UpdateArticel(int Id, Category c);
        void DeleteArticel(int Id);
        Article GetArticleById(int Id);
        Article GetArticleByTitle(string title);
    }
}
