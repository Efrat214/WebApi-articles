using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using opennlp.tools.stemmer;

namespace BLL.algorithm.text_analysis
{
    public class ReadCsv
    {
        string filePath;
        public ReadCsv(string filePath)
        {
            this.filePath = filePath;
        }
        public Dictionary<string,Frequency> readCsvv()
        {
            //PorterStemmer יצירת מופע של ה
            var stemmer = new PorterStemmer();
            //יצירת מילון לאחסון התוצאה
            Dictionary<string, Frequency> result = new Dictionary<string, Frequency>();
            //StreamReader קרא את הקובץ באמצעות 
            using (var reader = new StreamReader(filePath))
            {
                //חזור על כל שורה בקובץ
                while (!reader.EndOfStream)
                {
                    //קרא את השורה הנוכחית
                    var line = reader.ReadLine();
                    //חלקו את השורה בפסיק כדי לקבל ערכים
                    var values = line.Split(',');
                    //אחזר את המילה מהערך הראשון
                    string word = values[0];
                    //stemming בצע 
                    word = stemmer.stem(word);
                    //אחזר ערכי תדירות מהערכים הנותרים
                    long value1;
                    int value2;
                    //בדיקה האם אפשר להמיר את הערכים כשורה
                    if (long.TryParse(values[1], out value1) && int.TryParse(values[2], out value2))
                    {
                        //הוספת המילה למילון בתנאי שהיא לא קיימת כבר
                        if (!result.ContainsKey(word))
                        {
                            result.Add(word, new Frequency { frequency = value1, frequency_count = value2 });
                        }

                    }
                }
            }
            //החזרת מילון התוצאה
            return result;
        }
    }
}
public class Frequency
{
    public long frequency { get; set; }
    public int frequency_count { get; set;}
}