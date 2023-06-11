using DAL;
using EntityFrameWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class ArticaleToUserBLL : ArticaleToUserIBLL
    {
        ArticaleToUserIDAL articaleToUserIDAL;
        public ArticaleToUserBLL(ArticaleToUserIDAL articaleToUserIDAL)
        {
            this.articaleToUserIDAL = articaleToUserIDAL;
        }
    
        public void AddArticaleToUser(ArticaleToUser w)
        {
            articaleToUserIDAL.AddArticaleToUser(w);
        }

        public void DeleteArticaleToUser(int Id)
        {
            articaleToUserIDAL.DeleteArticaleToUser(Id);
        }

        public List<Article> GetAllArticaleToUser(int userID)
        {
            return articaleToUserIDAL.GetAllArticaleToUser(userID);
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
