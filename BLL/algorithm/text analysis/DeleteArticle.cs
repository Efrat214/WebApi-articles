using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using BLL;
using BLL.algorithm.Naive_Bayes_classifier;
using opennlp.tools.stemmer;
using EntityFrameWork;

namespace BLL.algorithm.text_analysis
{
    public class DeleteArticle:IDeleteArticle
    {
        CategoriesIBLL categoriesIBLL;
        WordsToCategoriesIBLL wordsToCategoriesIBLL;
        ArticelsIBLL articelsIBLL;
        VocabularyToAriacleIBLL vocabularyToAriacleIBLL;
        ArticaleToUserIBLL articaleToUserIBLL;
        public DeleteArticle(CategoriesIBLL categoriesIBLL, WordsToCategoriesIBLL wordsToCategoriesIBLL, ArticelsIBLL articelsIBLL, VocabularyToAriacleIBLL vocabularyToAriacleIBLL, ArticaleToUserIBLL articaleToUserIBLL)
        {
            this.categoriesIBLL = categoriesIBLL;
            this.wordsToCategoriesIBLL = wordsToCategoriesIBLL;
            this.articelsIBLL = articelsIBLL;
            this.vocabularyToAriacleIBLL = vocabularyToAriacleIBLL;
            this.articaleToUserIBLL = articaleToUserIBLL;
        }
        public bool delete(Article a)
        {
            IronOcr ironOcr = new IronOcr(a.Link);
            string content = ironOcr.ReadPdf();
            Preprocessing p = new Preprocessing(content);
            List<wordInArticale> filterArticale = p.parseToWords();
            foreach (var val in filterArticale)
            {
                wordsToCategoriesIBLL.DeleteWordToCategory(val.Word,(int)a.Category);                
            }
            articaleToUserIBLL.DeleteArticaleToUser(a.Id);
            vocabularyToAriacleIBLL.DeleteVocabularyToAriacle(a.Id);
            articelsIBLL.DeleteArticel(a.Id);
            categoriesIBLL.DecNumArticels((int)a.Category);
            return true;
        }
    }
}
