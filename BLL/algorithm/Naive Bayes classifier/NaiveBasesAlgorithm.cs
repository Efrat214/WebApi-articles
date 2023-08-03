using BLL.algorithm.Naive_Bayes_classifier;
using BLL.algorithm.text_analysis;
using DAL;
using EntityFrameWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace BLL.algorithm
{
    public class NaiveBasesAlgorithm:INaiveBasesAlgorithm
    {
        CategoriesIDAL categoriesIDAL;
        WordsToCategoriesIDAL wordsToCategoriesIDAL;
        ArticalsIDAL ArticalsIDAL;
        VocabularyToAriacleIDAL vocabularyToAriacleIDAL;
        ArticaleToUserIDAL articaleToUserIDAL;
        LevelIDAL levelIDAL;
        public NaiveBasesAlgorithm(WordsToCategoriesIDAL wocrdsToCategoriesIDAL,CategoriesIDAL categoriesIDAL, ArticalsIDAL articalsIDAL, VocabularyToAriacleIDAL vocabularyToAriacleIDAL, ArticaleToUserIDAL articaleToUserIDAL, LevelIDAL levelIDAL)
        {
            this.wordsToCategoriesIDAL = wocrdsToCategoriesIDAL;
            this.categoriesIDAL = categoriesIDAL;
            this.ArticalsIDAL = articalsIDAL;
            this.vocabularyToAriacleIDAL = vocabularyToAriacleIDAL;
            this.articaleToUserIDAL = articaleToUserIDAL;
            this.levelIDAL = levelIDAL;
        }
        public WordLevel getUserLevel(Level level)
        {
            List<Level> levels = levelIDAL.GetLevels();
            int index = levels.IndexOf(level);
            WordLevel userLevel=new WordLevel();
            switch (index)
            {
                case 0:
                    userLevel = WordLevel.Easy;
                    break;
                case 1:
                    userLevel = WordLevel.Medium;
                    break;
                case 2:
                    userLevel = WordLevel.Hard;
                    break;
                case 3:
                    userLevel = WordLevel.ReallyHard;
                    break;
            }
            return userLevel;
        }
        public List<string> process(string pathToArticale, string title, Level level, int userid)
        {
            //שליחה לפונקצייה שאחראית על קריאת תוכן המאמר
            IronOcr ironOcr = new IronOcr(pathToArticale);
            string content = ironOcr.ReadPdf();
            //שליחה לפונקצייה לניקוי טקסט
            Preprocessing p = new Preprocessing(content);
            List<wordInArticale> cleanArt = p.parseToWords();
            //קריאת מערך הנתונים של התדירות
            ReadCsv r = new ReadCsv(@"C:\Users\unigram_freq.csv");
            Dictionary<string, Frequency> frequency = r.readCsvv();
            //קבלת רמת המאמר
            LevelAnalysis levelAnalysis=new LevelAnalysis();
            WordLevel wordLevel= levelAnalysis.GetPercentageByLevel(cleanArt, frequency);
            //קבלת רמת המשתמש בהתאם לenum
            WordLevel userLevel = getUserLevel(level);
            //בדיקה האם רמת המאמר מותאמת לרמת המשתמש
            if (userLevel >= wordLevel)
            {
                SortArical s = new SortArical(categoriesIDAL,wordsToCategoriesIDAL, ArticalsIDAL,vocabularyToAriacleIDAL,articaleToUserIDAL);
                return s.getVocabulary(level,cleanArt,frequency,userLevel, userid, title,pathToArticale);
            }
            else
                return new List<string>();
        }

    }
}
