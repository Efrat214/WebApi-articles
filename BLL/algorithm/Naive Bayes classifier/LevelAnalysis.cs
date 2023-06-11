using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
public enum WordLevel
{
    Easy,
    Medium,
    Hard,
    ReallyHard
}
namespace BLL.algorithm.Naive_Bayes_classifier
{
    public class LevelAnalysis
    {
        public WordLevel GetWordLevel(string word, Dictionary<string, Frequency> wordFrequencies)
        {
            int frequency = wordFrequencies.ContainsKey(word) ? wordFrequencies[word].frequency_count : 0;

            return frequency < 3000 ? WordLevel.Easy
                : frequency < 10000 ? WordLevel.Medium
                : frequency < 20000 ? WordLevel.Hard
                : WordLevel.ReallyHard;
        }
        public Dictionary<WordLevel, int> CountWordsByLevel(List<wordInArticale> words, Dictionary<string, Frequency> frequencyDictionary)
        {
            var countByLevel = new Dictionary<WordLevel, int>();
            foreach (wordInArticale word in words)
            {
                WordLevel level = GetWordLevel(word.Word, frequencyDictionary);
                if (countByLevel.ContainsKey(level))
                {
                    countByLevel[level]++;
                }
                else
                {
                    countByLevel[level] = 1;
                }
            }
            return countByLevel;
        }
        public WordLevel GetPercentageByLevel(List<wordInArticale> words, Dictionary<string, Frequency> frequencyDictionary)
        {
            //שמירה לכל רמה מספר מילים
            Dictionary<WordLevel,int> countByLevel = CountWordsByLevel(words, frequencyDictionary);
            //סה"כ מספר מילים
            int totalCount = countByLevel.Values.Sum();
            //יצירת מילון כדי לאחסן את אחוז המילים לפי רמה
            var percentageByLevel = new Dictionary<WordLevel, double>();
            //הגדרת מערך משקל לכל רמה
            int[]weighted=new int[4] { 1,2,3,4};
            //חישוב האחוז עבור כל רמה
            foreach (var kvp in countByLevel)
            {
                var level = kvp.Key;
                var count = kvp.Value;
                //הכפלת מס' מילים במשקל עבור הרמה המתאימה
                var percentage = count*weighted[(int)level];
                percentageByLevel[level] = percentage;
            }
            //חישוב האחוז המשוקלל הכולל
            double totalWeightedPercentage = percentageByLevel.Sum(x => x.Value) / totalCount;
            //חישוב הייצוג השלם של האחוז המשוקלל (עיגול כלפי מעלה
            int level1 = (int)Math.Ceiling(totalWeightedPercentage);
            //קבל את ערך הרמה המתאים לרמת המספרים השלמים
            WordLevel[] levels = (WordLevel[])Enum.GetValues(typeof(WordLevel));
            WordLevel levelEnum = levels[level1 - 1];
            return levelEnum;
        }
    }
}
