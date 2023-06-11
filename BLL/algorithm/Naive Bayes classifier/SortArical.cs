using DAL;
using EntityFrameWork;
//using MoreLinq;
//using MoreLinq.Extensions;
using opennlp.tools.stemmer;

namespace BLL.algorithm.Naive_Bayes_classifier
{
    public class SortArical : ISortArical
    {
        double[,] matPerArticale;
        CategoriesIDAL categoriesIDAL;
        WordsToCategoriesIDAL wordsToCategoriesIDAL;
        ArticalsIDAL ArticalsIDAL;
        VocabularyToAriacleIDAL vocabularyToAriacleIDAL;
        ArticaleToUserIDAL articaleToUserIDAL;
        public SortArical(CategoriesIDAL categoriesIDAL, WordsToCategoriesIDAL wordsToCategoriesIDAL, ArticalsIDAL articalsIDAL, VocabularyToAriacleIDAL vocabularyToAriacleIDAL, ArticaleToUserIDAL articaleToUserIDAL)
        {
            this.matPerArticale = matPerArticale;
            this.categoriesIDAL = categoriesIDAL;
            this.wordsToCategoriesIDAL = wordsToCategoriesIDAL;
            this.ArticalsIDAL = articalsIDAL;
            this.vocabularyToAriacleIDAL = vocabularyToAriacleIDAL;
            this.articaleToUserIDAL = articaleToUserIDAL;
        }

        public double checkSimilarWords(Dictionary<string, double> similarWords, Category category, BuildProbilityMatrix data)
        {
            double sum = 0, avg = 0;
            double c1;
            //מעבר על מילון מילים דומות
            foreach (var item in similarWords)
            {
                //חיושב הסכום של כל ערכי הדמיון
                sum += (double)item.Value;
                //בדיקה האם המילה נמצאת בטבלת ההסתברויות ואם כן האם ערכה בקטגוריה הנתונה חיובי       
                if (data.probilityTable.ContainsKey(item.Key) && data.probilityTable[item.Key][category.Id] > 0)
                {
                    //קבלת הסתברות המילה מתוך טבלת ההסתברויות
                    c1 = (double)data.probilityTable[item.Key][category.Id];
                    //נכפיל את הסתברות מילה זו*דמיון ונסכום את כל הציונים
                    avg += (double)item.Value * c1;
                }
                //חישוב ממוצע ממשוקל:סכום הציונים/סכום הדמיונות

            }
            return avg / sum;
        }
        public void InitializeMatPerArticale(double[,] matPerArticale, int sizeOfDate, int numOfCategory)
        {
            for (int i = 0; i < sizeOfDate; i++)
            {
                for (int j = 0; j < numOfCategory; j++)
                {
                    matPerArticale[i, j] = 0.0;
                }
            }
        }

        public Dictionary<int, double> newArticale(List<wordInArticale> artWords, BuildProbilityMatrix data, Dictionary<string, Frequency> frequency)
        {
            //שמירת מספר המילים במאמר 
            int sizeOfDate = artWords.Count;
            //איתחול מטריצה לשמירת ההסתברויות עבור המאמר הנוכחי
            matPerArticale = new double[sizeOfDate, data.numOfCategory];
            InitializeMatPerArticale(matPerArticale, sizeOfDate, data.numOfCategory);
            Dictionary<int, double> result = new Dictionary<int, double>();
            //מערך סטטיסטי לצורך הסיווג 
            double[] categories = new double[data.numOfCategory];
            //איתחול המערך עבור כל קטגוריה במספר המאמרים בקטגוריה
            for (int i = 0; i < data.numOfCategory; i++)
            {
                categories[i] = data.numArticalsToCategory[i];
            }
            SimilarWords s = new SimilarWords();
            //שליחה לפונקציה המחזירה מילון של מילונים לצורך שמירה עבור כל אחת ממילות המאמר מילים דומות
            Dictionary<string, Dictionary<string, double>> similarWords = s.getAllSimilarWords(artWords, data);
            //מעבר על כל מילה ממילות המאמר
            foreach (var word in artWords)
            {
                //מעבר על כל אחת מהקטגוריות
                for (int i = 0; i < data.numOfCategory; i++)
                {
                    bool flag = false;
                    double weight = 0;
                    double statistic = 0;
                    //אם טבלת ההסתברות מכילה את המילה וכן ההסתברות בקטגוריה זו חיובי ניקח את ההסתברות מתוך הטבלה
                    if (data.probilityTable.ContainsKey(word.Word))
                    {
                        if (data.probilityTable[word.Word][data.codeCategory[i]] > 0)
                        {
                            statistic = data.probilityTable[word.Word][data.codeCategory[i]];
                            flag = true;
                        }
                    }

                    if (!flag)
                    {
                        //אם המילה אינה נמצאת בטבלת ההסתברויות נמצא את מקלה ע"י שליחה לפונקצייה אשר מוצאת הסתברות מילה ע"י מילים דומות
                        weight = checkSimilarWords(similarWords[word.Word], categoriesIDAL.GetCategoryById(data.codeCategory[i]), data);
                    }
                    //השמה במטריצה עבור המאמר את ערך ההסתברות
                    if (statistic > 0)
                    {
                        categories[i] *= statistic;
                        matPerArticale[word.Index - 1, i] = statistic;
                    }

                    else if (weight > 0)
                    {
                        categories[i] *= weight;
                        matPerArticale[word.Index - 1, i] = weight;
                    }
                    else
                    {
                        categories[i] *= 0.001;
                        matPerArticale[word.Index - 1, i] = 0.001;
                    }
                }


            }
            // שמירת המערך הסטטיסטי במילון שהמפתח הוא אינדקס הקטגוריה עפי הסדר במאגר הנתונים והערך הוא הסתברות הקטגוריה 
            for (int i = 0; i < data.numOfCategory; i++)
            {
                result.Add(i, categories[i]);
            }
            //מיון המילון בסדר יורד עפ"י הסתברות הקטגוריה
            result = result.OrderByDescending(x => x.Value).ToDictionary(x => x.Key, x => x.Value);
            //החזרת מילון התוצאה
            return result;
        }

        public static WordWithStatistic[] GetNBy2MaxValues(WordWithStatistic[] arr, int n)
        {
            int k = n / 2;

            //הגדרת ערימה

            var maxHeap = new PriorityQueue<WordWithStatistic>(k, Comparer<WordWithStatistic>.Create((a, b) => b.Percent.CompareTo(a.Percent)));

            foreach (var num in arr)
            {
                if (maxHeap.Count < k || num.Percent > maxHeap.Peek().Percent)
                {
                    maxHeap.Enqueue(num);

                    if (maxHeap.Count > k)
                    {
                        maxHeap.Dequeue();
                    }
                }
            }

            return maxHeap.ToArray();
        }

        public void addDb(List<string> words, List<wordInArticale> artWords, Level l, int userId, int category, string link, string title, Dictionary<string, Frequency> frequency)
        {
            int catId = categoriesIDAL.getCodeCategory(category);
            var stemmer = new PorterStemmer();
            LevelAnalysis levelAnalysis = new LevelAnalysis();
            var a = new Article
            {
                Category = catId,
                Link = link,
                Title = title
            };
            bool isExist = ArticalsIDAL.isExist(a);
            if (!isExist)
            {
                categoriesIDAL.incNumArticels(catId);
                foreach (var item in artWords)
                {
                    WordLevel wordLevel = levelAnalysis.GetWordLevel(stemmer.stem(item.Word), frequency);
                    WordLevel[] levels = (WordLevel[])Enum.GetValues(typeof(WordLevel));
                    int levelIndex = Array.IndexOf(levels, wordLevel);
                    int fr = levelIndex;
                    var wordToCat = new WordToCategory
                    {
                        Category = catId,
                        Word = item.Word,
                        Frequency = fr,
                        Count = 1
                    };
                    wordsToCategoriesIDAL.AddWordToCategory(wordToCat);
                }
            }
            int artId = ArticalsIDAL.AddArticale(a);
            bool exist = vocabularyToAriacleIDAL.GetIsExist(artId, l);
            if (!exist)
            {
                foreach (var item in words)
                {
                    var word = new VocabularyToAriacle
                    {
                        Articale = artId,
                        Level = l.Id,
                        Word = item
                    };
                    vocabularyToAriacleIDAL.AddVocabularyToAriacle(word);
                }
            }
            var artToUser = new ArticaleToUser
            {
                Articale = artId,
                UserId = userId,
            };
            articaleToUserIDAL.AddArticaleToUser(artToUser);
        }

        public List<string> getVocabulary(Level l, List<wordInArticale> cleanArt, Dictionary<string, Frequency> frequency, WordLevel userLevel, int userID, string title, string link)
        {
            var stemmer = new PorterStemmer();
            int sizeOfData = cleanArt.Count;
            List<wordInArticale> cleanArt1 = cleanArt.ToList();
            //איתחול המתשנים העקיריים
            BuildProbilityMatrix b = new BuildProbilityMatrix(wordsToCategoriesIDAL, categoriesIDAL);
            //בניית הטבלה ההסתברותית
            b.buildMat();
            LevelAnalysis levelAnalysis = new LevelAnalysis();
            ///שליחה לפונ' המחזירה מערך בגודל מס' הקטגוריות שבו ההסתברות לכל קטגוריה
            Dictionary<int, double> classification = newArticale(cleanArt, b, frequency);
            //קבלת קטגוריית המאמר
            int category = classification.First().Key;
            ///יצירת רשימה של מילים המותאמת לרמת המשתמש הרשימה תחזור בצורה מיקום המילה ברשימת מילות המאמר וניקוד 
            Dictionary<int, double> bestProbility = new Dictionary<int, double>();
            List<string> vocabulary = new List<string>();
            ////חישוב איזה מילים לתת- החישוב נעשה כך מכל איזור תינתן מילה איך נקבע מי המילה? כל תחום בגודל הררוח נעביר למערך ואז במערך נמצא את הרווח/2 איברים גדולים ומתוכם נבחר את המילים מותאם לרמת המשתמש החישוב נעשה כמו שכתוב בהמשך.
            ///מציאת טווח כדי לקבל את המילים במורה מפוזרת על גבי הטקסט
            int space = sizeOfData / l.NumOfWords;
            List<int> maxHeap = new List<int>();
            //למנוע גלישה בשורה i+j<sizeOfDate לכן נגדיר flag
            bool flag = false;
            //אני צריכה לחלק את המטריצה לחלקים מכל חלק לקחת את ה3 מילים  הכי משמעותית-הסתברות הכי גבוהה לבשוק את התדירות ואז לבחור.
            for (int i = 0; i < sizeOfData && !flag; i += space)
            {
                WordWithStatistic[] columnArray = new WordWithStatistic[space];
                for (int j = 0; j < space; j++)
                {
                    columnArray[j] = new WordWithStatistic();
                    if (i + j >= sizeOfData - 1)
                    {
                        flag = true;
                    }
                    else
                    {
                        columnArray[j].Percent = matPerArticale[i + j, category];
                        columnArray[j].Index = i + j;
                    }
                }
                if (!flag)
                {
                    WordWithStatistic[] kbigelements = InitializeWordWithStatisticArray(space / 2);
                    kbigelements = GetNBy2MaxValues(columnArray, space);///רשימת מילים מותאת לרמה המילים נבחרות מתוך המילים עם ההסתברות הכי גבוהה.
                    WordWithStatistic maxInLevel = new WordWithStatistic() { Percent = double.MinValue }, maxNotInLevel = new WordWithStatistic() { Percent = double.MinValue };
                    List<WordWithStatistic> wordInLevels = new List<WordWithStatistic>();
                    List<WordWithStatistic> wordNotInLevels = new List<WordWithStatistic>();
                    foreach (var item in kbigelements)
                    {
                        //קבלת המילה ובדיקת הרמה שלה
                        string word = cleanArt[item.Index + 1].Word;
                        word = stemmer.stem(word);
                        WordLevel wordLevel = levelAnalysis.GetWordLevel(word, frequency);
                        item.wordLevel = wordLevel;
                        //שמירה של שתי רשימות של מילים ברמת המשתמש ומתחת ורשימה שנייה למילים ברמה יותר מרמתו
                        if (wordLevel <= userLevel)
                            wordInLevels.Add(item);
                        else
                            wordNotInLevels.Add(item);
                    }
                    if (wordInLevels.Count == 0)
                    {
                        WordWithStatistic maxi = new WordWithStatistic() { Percent = double.MinValue };
                        //אם אין מילים ברמת המשתמש או מתחת לה ניקח את המילה עם ההסתברות הגבוהה ברשימה של המילים שאינם ברמתו
                        foreach (var item in wordNotInLevels)
                        {
                            maxi.Percent = Math.Max(maxi.Percent, item.Percent);
                            if (maxi.Percent == item.Percent)
                            {
                                maxi.Index = item.Index;
                                maxi.wordLevel = item.wordLevel;
                            }
                        }
                        bestProbility.Add(maxi.Index, maxi.Percent);
                    }
                    else
                    {
                        //חלוקה לשתי רשימות
                        foreach (var item in wordInLevels)
                        {
                            if (item.wordLevel == userLevel)
                            {
                                maxInLevel.Percent = Math.Max(maxInLevel.Percent, item.Percent);
                                if (maxInLevel.Percent == item.Percent)
                                {
                                    maxInLevel.Index = item.Index;
                                    maxInLevel.wordLevel = item.wordLevel;
                                }
                            }
                            else
                            {
                                maxNotInLevel.Percent = Math.Max(maxNotInLevel.Percent, item.Percent);
                                if (maxNotInLevel.Percent == item.Percent)
                                {
                                    maxNotInLevel.Index = item.Index;
                                    maxNotInLevel.wordLevel = item.wordLevel;
                                }
                            }
                        }
                        //נעדיף לבחור את המילה ברמתו אך אם אין מילה כזו ניקח את המילה ברמה נמוכה יותר
                        WordWithStatistic chosenWord = maxInLevel.Percent > double.MinValue ? maxInLevel : maxNotInLevel;
                        int chosenIndex = chosenWord.Index;
                        string chosenWordValue = cleanArt.First(x => x.Index == (chosenIndex + 1)).Word;
                        //לצורך הורדת כפולים נקבע את הסתברות המילים הנותרות ברשימה שזהות למילה החדשה לערך נמוך וכך הן לא תבחרנה שוב
                        cleanArt.ForEach(val =>
                        {
                            if (val.Word.Equals(chosenWordValue))
                            {
                                matPerArticale[(val.Index) - 1, category] = -1.0;
                            }
                        });
                        bestProbility.Add(chosenIndex, chosenWord.Percent);
                    }
                }
            }
            foreach (var item in bestProbility)
            {
                vocabulary.Add(cleanArt.ElementAt(item.Key).Word);
            }
            addDb(vocabulary, cleanArt, l, userID, category, link, title, frequency);
            return vocabulary;
        }


        private WordWithStatistic[] InitializeWordWithStatisticArray(int size)
        {
            WordWithStatistic[] wordArray = new WordWithStatistic[size];

            for (int i = 0; i < size; i++)
            {
                wordArray[i] = new WordWithStatistic();
            }

            return wordArray;
        }

    }
}


