using DAL;
using EntityFrameWork;
using Google.Cloud.Translation.V2;


namespace BLL.algorithm.Naive_Bayes_classifier
{
    public class Test : Itest
    {
        WordsToCategoriesIDAL wordsToCategoriesIDAL;
        public Test(WordsToCategoriesIDAL wordsToCategoriesIDAL)
        {
            this.wordsToCategoriesIDAL = wordsToCategoriesIDAL;
        }
        Random random = new Random();
        int[] numbers = new int[15];
        public List<Question> createTest()
        {
            //הגדרת רשימת השאלות
            List<Question> questions = new List<Question>();
            List<WordToCategory> wordToCategories = new List<WordToCategory>();
            List<Task<Question>> tasks = new List<Task<Question>>();
            //קבלת המילון המכיל קטגוריה וכל קוגוריה מילון המכיל רמה ולכל רמה רשימת מילים
            Dictionary<int, Dictionary<int, List<string>>> dic = wordsToCategoriesIDAL.getWordsByCategoryAndLevel();
            //שליחה לפונקצייה שמרנדמת מילים 
            List<Words> randomWords = randomWordss(dic);
            Boolean flag = false;
            //הקפיצה היא ב4 מכיוון שאני יוצרת מבחן רב ברירה שיש בו 4 תשובות
            for (int i = 0; i < randomWords.Count; i += 4)
            {
                Question questions1 = translateQuestion(i, randomWords);
                questions.Add(questions1);

            }
            return questions;
        }
        public Question similarWordsQuestion(int i, List<Words> randomWords)
        {
            SimilarWords similarWords = new SimilarWords();
            Question question = new Question();
            int indexQuest = random.Next(i, i + 4);
            Dictionary<string, double> sim;
            question.Options = new List<string>();
            for (int j = 0; j < 4; j++)
            {
                if (i + j == indexQuest)
                {
                    question.QuestionText = "Which of the following words means " + randomWords.ElementAt(indexQuest);
                    sim = similarWords.getSimilarWordsPython(randomWords.ElementAt(indexQuest).Word);
                    question.Level = randomWords.ElementAt(indexQuest).Level;
                    question.Answer = (sim.First().Key);
                    question.Options.Add(question.Answer);
                }
                else
                {
                    sim = similarWords.getSimilarWordsPython(randomWords.ElementAt(i + j).Word);
                    question.Options.Add(sim.First().Key);
                }
            }
            return question;
        }
        public Question translateQuestion(int i, List<Words> randomWords)
        {
            string ret = "";
            //הגרלת אינדקס שהוא יהיה בשאלה 
            int indexQuest = random.Next(i, i + 4);
            string text = "";
            //חיבור לתרגום גוגל 
            string targetLanguage = "he";
            Environment.SetEnvironmentVariable("GOOGLE_APPLICATION_CREDENTIALS", @"C:\Users\google_nlp.json");
            var client = TranslationClient.Create();
            TranslationResult result;
            Question question = new Question();
            question.Options = new List<string>();
            for (int j = 0; j < 4; j++)
            {
                //בדיקה האם האינדקס הוא האינדקס הנבחר לשאלה
                if (i + j == indexQuest)
                {
                    //הגדרת משתני השאלה
                    text = randomWords.ElementAt(indexQuest).Word;
                    question.QuestionText = "what is the translation for " + text;
                    result = client.TranslateText(text, targetLanguage);
                    question.Level = randomWords.ElementAt(indexQuest).Level;
                    question.Answer = result.TranslatedText;
                    question.Options.Add(question.Answer);
                }
                else
                {
                    text = randomWords.ElementAt(i + j).Word;
                    result = client.TranslateText(text, targetLanguage);
                    question.Options.Add(result.TranslatedText);
                }
            }
            //לבסוף נחזיר את השאלה
            return question;

        }
        public List<Words> randomWordss(Dictionary<int, Dictionary<int, List<string>>> allWords)
        {
            Random rnd = new Random();
            List<Words> randomWords = new List<Words>();
            //מעבר על כל קטגוריה
            foreach (var category in allWords)
            {
                int categoryId = category.Key;
                //מעבר על כל רמה 
                foreach (var frequencyLevel in category.Value)
                {
                    double frequency = frequencyLevel.Key; // get the frequency level
                    List<string> words = frequencyLevel.Value;
                    int len = words.Count();
                    //הגרלה מתוך רשימת המילים
                    for (int i = 0; i < 4; i++)
                    {
                        //הגרלת אינדקס נתוך הרשימה
                        int r = rnd.Next(len);
                        //הוספת האיבר לרשימת המילים 
                        randomWords.Add(new Words() { Word = words.ElementAt(r), Level = frequency });
                        //דריסת המילה לצורך הגרלה ללא כפולים
                        words[r] = words.ElementAt(len - 1);
                        len--;
                    }
                }
            }
            return randomWords;
        }
        // Generate 4 random numbers between 0-3000
    }
}
public class Question
{
    public int Id { get; set; }
    public double Level { get; set; }
    public string QuestionText { get; set; }
    public List<string> Options { get; set; }
    public string Answer { get; set; }
}
public class Words
{
    public string Word { get; set; }
    public double Level { get; set; }
}
