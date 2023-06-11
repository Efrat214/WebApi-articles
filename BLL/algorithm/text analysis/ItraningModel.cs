using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.algorithm.text_analysis
{
    public interface ItraningModel
    {
        public void readData(List<string> pathes,string category);
    }
}
