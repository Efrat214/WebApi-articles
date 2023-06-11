using EntityFrameWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.algorithm.Naive_Bayes_classifier
{
    public interface INaiveBasesAlgorithm
    {
        public List<string> process(string pathToArticale,string title,Level level,int userid);

    }
}
