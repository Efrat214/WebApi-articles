using EntityFrameWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public interface WordsToCategoriesIBLL
    {
        List<WordToCategory> GetAllWordsToCategories();
        WordToCategory GetWordToCategoryById(int Id);

        void AddWordToCategory(WordToCategory w);
        void UpdateWordToCategory(int Id, WordToCategory w);
        void DeleteWordToCategory(string word, int Id);

    }
}
