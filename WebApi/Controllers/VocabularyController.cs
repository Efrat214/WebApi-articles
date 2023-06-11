using BLL;
using BLL.algorithm;
using BLL.algorithm.Naive_Bayes_classifier;
using com.sun.research.ws.wadl;
using DAL;
using EntityFrameWork;
using javax.swing.border;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class VocabularyController : ControllerBase
    {
        //  private readonly SortArical sortArical;
        INaiveBasesAlgorithm naiveBasesAlgorithm;
        VocabularyToAriacleIBLL vocabularyToAriacle;
        LevelIBLL levelBLL;
        ArticelsIBLL ArticelsIBLL;
        UsersIBLL usersIBLL;
        public VocabularyController(INaiveBasesAlgorithm myService,VocabularyToAriacleIBLL vocabularyToAriacleIBLL, LevelIBLL levelBLL,ArticelsIBLL a,UsersIBLL u)
        {
            naiveBasesAlgorithm = myService; // inject an instance of the service class
            this.vocabularyToAriacle = vocabularyToAriacleIBLL;
            this.levelBLL = levelBLL;
            this.ArticelsIBLL = a;
            this.usersIBLL = u;
        }

        // GET: api/<VocabularyController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<VocabularyController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<VocabularyController>
        [HttpPost]
        public List<string> Post(int artId,int userId)
        {
            Article a = ArticelsIBLL.GetArticleById(artId);
            User u=usersIBLL.GetUserById(userId);
            Level l = levelBLL.getLevelById(u.Level);
            //string link = $@"{linkToArticale}";
            string link =a.Link;
            List<string> words = vocabularyToAriacle.GetAllVocabularyToAriacle(a.Id,l.Id);
            if(words.Count > 0)
            {
                return words;
            }
            return naiveBasesAlgorithm.process(a.Link,a.Title, l,userId); // call the public method in the service class
            //return result; // return the result as an HTTP response
        }


        // PUT api/<VocabularyController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<VocabularyController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
