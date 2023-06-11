using EntityFrameWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.algorithm.text_analysis
{
    public interface IDeleteArticle
    {
        public bool delete(Article a);
    }
}
