using BLL;
using EntityFrameWork;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArticelsToUsersController : ControllerBase
    {
        ArticaleToUserIBLL articaleToUserIBLL;
        public ArticelsToUsersController(ArticaleToUserIBLL articaleToUserIBLL)
        {
            this.articaleToUserIBLL = articaleToUserIBLL;
        }
        // GET: api/<ArticelsToUsersController>
        [HttpGet]
        public List<ArticaleToUser> Get()
        {
            throw new NotImplementedException();
        }

        // GET api/<ArticelsToUsersController>/5
        [HttpGet("{userID}")]
        public List<Article> Get(int userID)
        {
            return articaleToUserIBLL.GetAllArticaleToUser(userID);
        }
        // POST api/<ArticelsToUsersController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<ArticelsToUsersController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ArticelsToUsersController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
