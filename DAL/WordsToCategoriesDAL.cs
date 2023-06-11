using EntityFrameWork;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class WordsToCategoriesDAL : WordsToCategoriesIDAL
    {
        public FinalArticelsDbContext db= new FinalArticelsDbContext();
 
        public void AddWordToCategory(WordToCategory w)
        {
            WordToCategory wc = db.WordToCategories.FirstOrDefault(x => x.Word == w.Word && x.Category == w.Category);
            if (wc!=null) 
            { 
                wc.Count++;
                db.WordToCategories.Update(wc);
                //UpdateWordToCategory(wc.Id,wc);   
            }
            else
            {
                db.WordToCategories.Add(w);
               
            }
            db.SaveChanges();

        }

        public void DeleteWordToCategory(string word,int catId)
        {
            WordToCategory wc = db.WordToCategories.FirstOrDefault(x => x.Category == catId && x.Word.Equals(word));
            if(wc.Count==0)
            {
                db.WordToCategories.Remove(wc);
            }
            else
            {
                wc.Count--;
                db.SaveChanges();
            }
        }

        public List<WordToCategory> GetAllWordsToCategories()
        {
            return db.WordToCategories.ToList();
        }

        public WordToCategory GetWordToCategoryById(int Id)
        {
            return db.WordToCategories.FirstOrDefault(x => x.Id == Id);
        }

        public void UpdateWordToCategory(int Id, WordToCategory w)
        {
            var word1 = db.WordToCategories.FirstOrDefault(x => x.Id == Id);
            if (word1 != null)
            {
                word1.Word = w.Word;
                word1.Category = w.Category;
                word1.Count= w.Count;
                db.SaveChanges();
            }
        }
        public Dictionary<string,Dictionary<int,int>> getWordCategoryNumAppearance()
        {
           Dictionary<string, Dictionary<int, int>> wordsByCategory = new Dictionary<string, Dictionary<int, int>>();
            List<Category> categories = db.Categories.ToList();
            int numCategory = categories.Count;
            int[] codeCategory = new int[numCategory];
            for (int i = 0; i < numCategory; i++)
            {
                Category c = categories.ElementAt(i);
                codeCategory[i] = c.Id;
            }
            //int[] codeCategory=categoriesDAL.getCodeCategory();
            foreach (var item in db.WordToCategories)
            {
                if (!wordsByCategory.ContainsKey(item.Word))
                {
                    wordsByCategory.Add(item.Word, new Dictionary<int, int>());
                    for (int i = 0; i < numCategory; i++)
                    {
                        wordsByCategory[item.Word].Add(codeCategory[i], 0);
                        if (item.Category == codeCategory[i])
                            wordsByCategory[item.Word][codeCategory[i]] = (int)item.Count;
                    }
                }
                wordsByCategory[item.Word][(int)item.Category] = (int)item.Count;


            }
            return wordsByCategory;
        }

        public Dictionary<int, Dictionary<int, List<string>>> getWordsByCategoryAndLevel()
        {
            Dictionary<int, Dictionary<int, List<string>>> dic = new Dictionary<int, Dictionary<int, List<string>>>();
            int numLevels = 4;
            //מעבר על טבלת מילים לקטגוריות
            foreach (var item in db.WordToCategories)
            {
                //בדיקה האם המילון מכיל כבר את קטגוריה זו
                if (!dic.ContainsKey((int)item.Category))
                {
                    //הוספת הקטגוריה ויצירת ערך שהוא מילון המכיל רמה ורשימה של מילים
                    dic.Add((int)item.Category, new Dictionary<int, List<string>>());
                    for (int i = 0; i < numLevels; i++)
                    {
                        dic[(int)item.Category].Add(i, new List<string>() { });
                    }
                    dic[(int)item.Category][item.Frequency].Add(item.Word);

                }
                else
                    dic[(int)item.Category][item.Frequency].Add(item.Word);

            }
            return dic;
        }
    }
}
