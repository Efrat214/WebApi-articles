using Microsoft.AspNetCore.Mvc;
using BLL;
using EntityFrameWork;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WordsToCategorieisController : ControllerBase
    {
        WordsToCategoriesIBLL wordsToCategoriesIBLL;
        public WordsToCategorieisController(WordsToCategoriesIBLL wordsToCategoriesIBLL)
        {
            this.wordsToCategoriesIBLL = wordsToCategoriesIBLL;
        }

        // GET: api/<WordsToCategorieisController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<WordsToCategorieisController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<WordsToCategorieisController>
        [HttpPost]
        public void Post(WordToCategory wtc)
        {
             wordsToCategoriesIBLL.AddWordToCategory(wtc);
        }

        // PUT api/<WordsToCategorieisController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<WordsToCategorieisController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
