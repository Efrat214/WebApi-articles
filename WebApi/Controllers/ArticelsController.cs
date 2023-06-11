using BLL;
using BLL.algorithm.text_analysis;
using EntityFrameWork;
using Microsoft.AspNetCore.Mvc;
using System.Net;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArticelsController : ControllerBase
    {
        ArticelsIBLL articelsIBLL;
        ItraningModel itraning;
        public ArticelsController(ArticelsIBLL articelsIBLL, ItraningModel itraning)
        {
            this.articelsIBLL = articelsIBLL;
            this.itraning = itraning;
        }
        // GET: api/<ArticelsController>
        [HttpGet]
        public List<Article> Get()
        {
            return articelsIBLL.GetAllArticels();
        }
        
        // GET api/<ArticelsController>/5
        [HttpGet("category/{category}")]
        public IActionResult GetArticlesByCategory([FromQuery] Category category)
        {
            var articles = articelsIBLL.GetArticleByCategory(category);
            return Ok(articles);
        }
       
        [HttpPost]
        public void Post([FromForm] ArticleUploadModel model)
        {
            List<IFormFile> files = model.Files;
            List<string> pathes = new List<string>();
            string category = model.Category;
            foreach (var item in files)
            {
                if (item != null)
                {
                    var filePath = Path.Combine(Directory.GetCurrentDirectory(), "uploads", item.FileName);

                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        item.CopyTo(stream);
                    }
                    pathes.Add(filePath);
                }
            }
            itraning.readData(pathes, category);
        }


        // PUT api/<ArticelsController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ArticelsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
public class ArticleUploadModel
{
    public List<IFormFile> Files { get; set; }
    public string Category { get; set; }
}
public class PathCatgory
{
    public List<string> pathes { get; set; }
    public string Category { get; set; }
}
