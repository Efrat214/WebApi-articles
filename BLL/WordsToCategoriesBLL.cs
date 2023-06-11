using DAL;
using EntityFrameWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class WordsToCategoriesBLL : WordsToCategoriesIBLL
    {
        WordsToCategoriesIDAL wordsToCategoriesIDAL;
        public WordsToCategoriesBLL(WordsToCategoriesIDAL wordsToCategoriesIDAL) 
        {
            this.wordsToCategoriesIDAL = wordsToCategoriesIDAL;
        }
        public void AddWordToCategory(WordToCategory w)
        {
            wordsToCategoriesIDAL.AddWordToCategory(w);
        }

        public void DeleteWordToCategory(string word, int Id)
        {
            wordsToCategoriesIDAL.DeleteWordToCategory(word,Id);
        }

        public List<WordToCategory> GetAllWordsToCategories()
        {
            return wordsToCategoriesIDAL.GetAllWordsToCategories();
        }

        public WordToCategory GetWordToCategoryById(int Id)
        {
            return wordsToCategoriesIDAL.GetWordToCategoryById((int)Id);
        }

        public void UpdateWordToCategory(int Id, WordToCategory w)
        {
            wordsToCategoriesIDAL.UpdateWordToCategory(Id, w);  
        }
    }
}
