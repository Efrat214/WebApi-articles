using Google.Cloud.Language.V1;
using opennlp.tools.stemmer;
//using LemmaSharp;
using System.Text.RegularExpressions;

namespace BLL.algorithm
{
    public class Preprocessing
    {
        string articale;
        public Preprocessing(string articale)
        {
            this.articale = articale;
        }
        public List<wordInArticale> parseToWords()
        {
            int index = 0;
            //להסרה stop words טעינת רשימת
            var stopWords = new HashSet<string>(File.ReadAllLines(@"C:\Users\NaiveBasesAlgo\stop_words.txt"));
            //לצורך ניתוח ישויות והסרת שמות ושמות מקומות google nlp api שליחה ל 
            //List<EntitySentiment> res = GoogleNlpEntity(articale);
            //הגדרת תווי רווח לפיצול המאמר למילים
            char[] whiteSpace = new char[] { ' ', '\t', '\n', '\r' };
            List<string> words = articale.Split(whiteSpace).ToList();
            foreach (var item in res)
            {
                //הסרת מילים שהישות שלהם היא אדם/מקום בוצעה בדיקה האם המילה מתחילה באות גדולה  
                // מכיוון שעל המילה שדה לדוג' נקבל את הישות מקום
                if ((item.Type.Equals("Location") || item.Type.Equals("Person")) && char.IsUpper(item.Name, 0))
                {
                    if (item.Name.Contains(' '))
                    {
                        //אם שם הישות מכיל רווחים, נפצל אותו ונסיר כל חלק
                        List<string> spl = item.Name.Split(whiteSpace).ToList();
                        foreach (var val in spl)
                        {
                            words.Remove(val);
                        }
                    }
                    words.Remove(item.Name);
                }
            }
            //סנן מילות עצירה מרשימת המילים
            var filteredTokens = words.Where(token => !stopWords.Contains(token.ToLower())).ToArray();
            List<wordInArticale> result = new List<wordInArticale>();
            //אשר מכילים מילה ומיקום wordInArticale ויצירת רשימה של אובייקטים מסוג token מעבר על כל 
            foreach (var item in filteredTokens)
            {
                //הסר כתובות דוא"ל וספרות מהטוקנים
                var word = Regex.Replace(item, @"\S+@\S+", "");
                word = Regex.Replace(word, @"[\d-]", string.Empty);
                //הסרת סימני פיסוק
                new List<string> { "@", "+", "-", ",", ".", "'", "*", "=", "(", ")", "\"", "!", "?", "/", ":" }.ForEach(m => word = word.Replace(m, ""));
                if (word.Length > 1)
                {
                    //יצירת  אובייקט  עבור המילה המעובדת והוספה לרשימת התוצאות
                    var wordInArticale = new wordInArticale
                    {
                        Word = word.ToLower(),
                        Index = ++index
                    };
                    result.Add(wordInArticale);
                }
            }
            return result;
        }
        public static List<EntitySentiment> GoogleNlpEntity(string s)
        {
            // Set up Google Cloud NLP client
            Environment.SetEnvironmentVariable("GOOGLE_APPLICATION_CREDENTIALS", @"C:\Users\1\Desktop\תכנות\תכנות יד\פרויקט גמר\finalProjecr\finalProjecr\google_nlp.json");
            var client = LanguageServiceClient.Create();

            // Call Google Cloud NLP API and extract entity sentiment information
            var response = client.AnalyzeEntitySentiment(Document.FromPlainText(s));
            var entitySentiments = new List<EntitySentiment>();
            foreach (var entity in response.Entities)
            {
                var entitySentiment = new EntitySentiment()
                {
                    Name = entity.Name,
                    Type = entity.Type.ToString(),
                    Score = entity.Sentiment.Score,
                    Magnitude = entity.Sentiment.Magnitude
                };
                entitySentiments.Add(entitySentiment);
            }


            // Return list of EntitySentiment objects
            return entitySentiments;
        }

    }
}
public class wordInArticale
{
    public string Word { get; set; }
    public int Index { get; set; }

}
public class WordWithStatistic
{
    public int Index { get; set; }
    public double Percent { get; set; }
    public WordLevel wordLevel { get; set; }
}
public class EntitySentiment
{
    public string Name { get; set; }
    public string Type { get; set; }
    public float Score { get; set; }
    public float Magnitude { get; set; }
}
