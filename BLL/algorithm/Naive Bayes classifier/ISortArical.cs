using EntityFrameWork;

namespace BLL.algorithm.Naive_Bayes_classifier
{
    public interface ISortArical
    {
        public List<string> getVocabulary(Level l, List<wordInArticale> cleanArt, Dictionary<string, Frequency> frequency, WordLevel userLevel, int userID, string title, string link);
    }
}
