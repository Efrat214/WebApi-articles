using EntityFrameWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public interface ArticaleToUserIBLL
    {
        List<Article> GetAllArticaleToUser(int userID);
        ArticaleToUser GetArticaleToUserById(int Id);

        void AddArticaleToUser(ArticaleToUser w);
        void UpdateArticaleToUser(int Id, ArticaleToUser w);
        void DeleteArticaleToUser(int Id);
    }
}
