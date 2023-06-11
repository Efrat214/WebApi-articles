using DAL;
using EntityFrameWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    [color: black()]
    public class ArticelsBLL : ArticelsIBLL
    {
        ArticalsIDAL articalsIDAL;
        public ArticelsBLL(ArticalsIDAL articalsIDAL)
        {
            this.articalsIDAL = articalsIDAL;
        }
        public int AddArticel(Article a)
        {
            return articalsIDAL.AddArticale(a); ;
        }

        public void DeleteArticel(int Id)
        {
            articalsIDAL.DeleteArticale(Id);
        }

        public List<Article> GetAllArticels()
        {
            return articalsIDAL.GetAllArticals();
        }

        public List<Article> GetArticleByCategory(Category c)
        {
            return articalsIDAL.GetArticaleByCategory(c);
        }

        public void UpdateArticel(int Id, Category c)
        {
            throw new NotImplementedException();
        }
        public Article GetArticleById(int Id)
        {
            return articalsIDAL.GetArticleById(Id);
        }
        public Article GetArticleByTitle(string title)
        {
            return articalsIDAL.GetArticleByTitle(title);

        }
    }
}
