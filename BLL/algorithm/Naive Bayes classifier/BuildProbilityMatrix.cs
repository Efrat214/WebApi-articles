using DAL;
using EntityFrameWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;


namespace BLL.algorithm.Naive_Bayes_classifier
{
    public class BuildProbilityMatrix:IBuildProbilityMatrix
    {
        public int numOfCategory { get; set; }
        CategoriesIDAL categoriesIDAL { get; set; }
        WordsToCategoriesIDAL wordsToCategoriesIDAL { get; set; }
        public List<Category> allCategories;
        public List<WordToCategory> allWordsToCategory;
        public Dictionary<string, Dictionary<int, double>> probilityTable{ get; set; }
        public int[] numArticalsToCategory { get; set; }
        public int[] codeCategory { get; set; }
   
        Dictionary<string, int> codePerWord;
        public BuildProbilityMatrix(WordsToCategoriesIDAL wordsToCategoriesIDAL, CategoriesIDAL categoriesIDAL)
        {
            this.categoriesIDAL = categoriesIDAL;
            this.allCategories = categoriesIDAL.GetAllCategoriess();
            //איתחול מספר הקטגוריות
            this.numOfCategory = this.allCategories.Count();
            this.wordsToCategoriesIDAL = wordsToCategoriesIDAL;
            //שמירת מספר מאמרים לכל קטגוריה
            this.numArticalsToCategory = categoriesIDAL.getNumArticales();
            //שמירת קודי קטגוריות
            this.codeCategory = categoriesIDAL.getCodeCategory();

        }
        public void buildMat()
        {
            //קבלת מילון שהמפתח שלו המילה והערך מילון המכיל קטגוריה
            //ומספר המופעים של המילה בקטגוריה זו  
            Dictionary<string, Dictionary<int, int>> wordsByCategory=wordsToCategoriesIDAL.getWordCategoryNumAppearance();
            probilityTable = new Dictionary<string, Dictionary<int, double>>();
            foreach (var item in wordsByCategory)
            {
                probilityTable.Add(item.Key, new Dictionary<int, double>());
                for (int i = 0; i < numOfCategory; i++)
                {
                    probilityTable[item.Key].Add(codeCategory[i], 0);
                    //חישוב ההסתברות הנוכחית תהיה מס' מופעים של מילה זו
                    //בקטגוריה זו/מס' המאמרים בקטוגריה זו
                    probilityTable[item.Key][codeCategory[i]] = (double)item.Value[codeCategory[i]] / (double)numArticalsToCategory[i];
                }
                //בדיקת ההפרשים אם ההסתברות זהה אז ההסתברות תהיה 1
                if (item.Value.Count() == numOfCategory && (probilityTable[item.Key].Max(x => x.Value) -
                probilityTable[item.Key].Min(x => x.Value)) < probilityTable[item.Key].Min(x => x.Value))
                {
                    for (int j = 0; j < numOfCategory; j++)
                    {
                        probilityTable[item.Key][codeCategory[j]] = 1;
                    }
                }
            }
        }
    }
}
