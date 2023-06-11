using BLL.algorithm.Naive_Bayes_classifier;
using BLL.algorithm.text_analysis;
using EntityFrameWork;
using opennlp.tools.stemmer;


namespace BLL.algorithm
{
    public class traningModel : ItraningModel
    {
        CategoriesIBLL categoriesIBLL;
        WordsToCategoriesIBLL WordsToCategoriesIBLL;
        ArticelsIBLL articelsIBLL;
        Frequency fr;
        public string json { get; set; }
        public traningModel(CategoriesIBLL categoriesIBLL, WordsToCategoriesIBLL WordsToCategoriesIBLL, ArticelsIBLL articelsIBLL)
        {
            this.categoriesIBLL = categoriesIBLL;
            this.WordsToCategoriesIBLL = WordsToCategoriesIBLL;
            this.articelsIBLL = articelsIBLL;
        }
        public void readData(List<string> pathes, string category)
        {
            var stemmer = new PorterStemmer();
            ReadCsv r = new ReadCsv(@"C:\Users\1\Desktop\תכנות\תכנות יד\פרויקט גמר גמור!!\WebApi\BLL\unigram_freq.csv");
            Dictionary<string, Frequency> frequency = r.readCsvv();
            LevelAnalysis levelAnalysis = new LevelAnalysis();
            var c = new Category
            {
                Name = category,
                NumArticals = 1,
            };
            int catId = categoriesIBLL.AddCategory(c);
            foreach (var file in pathes)
            {
                string fileNameWithoutExtension = Path.GetFileNameWithoutExtension(file);
                var a = new Article
                {
                    Title = fileNameWithoutExtension,
                    Link = file,
                    Category = catId,

                };
                articelsIBLL.AddArticel(a);
                IronOcr ironOcr = new IronOcr(file);
                string content = ironOcr.ReadPdf();
                Preprocessing p = new Preprocessing(content);
                List<wordInArticale> filterArticale = p.parseToWords();
                foreach (var val in filterArticale)
                {
                    WordLevel wordLevel = levelAnalysis.GetWordLevel(stemmer.stem(val.Word), frequency);
                    WordLevel[] levels = (WordLevel[])Enum.GetValues(typeof(WordLevel));
                    int levelIndex = Array.IndexOf(levels, wordLevel);
                    int fr = levelIndex;
                    var wordToCategory = new WordToCategory
                    {
                        Category = catId,
                        Word = val.Word,
                        Count = 1,
                        Frequency = fr,

                    };
                    WordsToCategoriesIBLL.AddWordToCategory(wordToCategory);
                }
            }
        }
    }
}