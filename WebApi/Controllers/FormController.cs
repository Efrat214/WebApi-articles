using Microsoft.AspNetCore.Mvc;
using BLL.algorithm.Naive_Bayes_classifier;
using System.IO;
using BLL.algorithm;
using EntityFrameWork;
using BLL;
using BLL.algorithm.text_analysis;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FormController : ControllerBase
    {
        // GET: api/<FormController>
        INaiveBasesAlgorithm naiveBasesAlgorithm;
        LevelIBLL levelBLL;
        UsersIBLL usersBLL;
        IDeleteArticle deleteArticle;
        ArticelsIBLL articelsIBLL;
        public FormController(LevelIBLL levelBLL,INaiveBasesAlgorithm naiveBasesAlgorithm,UsersIBLL usersIBLL,IDeleteArticle deleteArticle,ArticelsIBLL articelsIBLL)
        {
           this.levelBLL = levelBLL; 
            this.naiveBasesAlgorithm = naiveBasesAlgorithm;
            this.usersBLL = usersIBLL;
            this.deleteArticle = deleteArticle;
            this.articelsIBLL = articelsIBLL;
        }

        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<FormController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        [HttpPost]
        public List<string> UploadFile([FromForm]UploadFileData data)
        {
            if (data.File == null || data.File.Length == 0)
            {
                return new List<string>();
            }

            var filePath = Path.Combine(Directory.GetCurrentDirectory(), "uploads", data.File.FileName);

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                data.File.CopyTo(stream);
            }
            User u = usersBLL.GetUserById(data.User);
            Level l = levelBLL.getLevelById(u.Level);
            return naiveBasesAlgorithm.process(filePath, data.File.FileName, l, u.Id); // call the public method in the service class
        }

     

        // PUT api/<FormController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<FormController>/5
        [HttpDelete("{title}")]
        public bool Delete(string title)
        {
            Article a=articelsIBLL.GetArticleByTitle(title);
            return deleteArticle.delete(a);
        }
    }
}
public class UploadFileData
{
    public IFormFile File { get; set; }
    public int User { get; set; }
}
