using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NewCategoryController : ControllerBase
    {
        // GET: api/<NewCategoryController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<NewCategoryController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<NewCategoryController>
        [HttpPost]
        public void Post(xyz [] arr)
        {
            //foreach (var item in arr)
            //{
            //    if(item.file.)
            //}
        }

        // PUT api/<NewCategoryController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<NewCategoryController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
public class xyz
{
    public string path { get; set; }
    public IFormFile file { get; set; }
}