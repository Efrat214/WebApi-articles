using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.algorithm.Naive_Bayes_classifier
{
    public interface Itest
    {
        public List<Question> createTest();
        public List<Words> randomWordss(Dictionary<int, Dictionary<int, List<string>>> allWords);
    }
}
