using BLL;
using DAL;
using EntityFrameWork;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        UsersIBLL usersIBLL;
        LevelIBLL levelIBLL;
        public UsersController(UsersIBLL usersIBLL,LevelIBLL l)
        { 
            this.usersIBLL = usersIBLL;
            this.levelIBLL = l;
        }
        // GET: api/<UsersController>
        [HttpGet]
        public List<User> Get()
        {
            return usersIBLL.GetAllUsers();
        }

        // GET api/<UsersController>/5
        [HttpGet("{mail}")]
        public User Get(string mail)
        {
            return usersIBLL.GetUserByMail(mail);
        }

        // POST api/<UsersController>
        [HttpPost]
        public User Post([FromBody]User u)
        {
            try
            {
                int levelID = levelIBLL.getCode(u.Level);
                u.Level= levelID;
                return usersIBLL.AddUser(u);
            }
            catch
            {
                return null;
            }

        }

        // PUT api/<UsersController>/5
        [HttpPut("{id}")]
        public bool Put(int id, User u)
        {
            try
            {
                usersIBLL.UpdateUSer(id,u);
                return true;
            }
            catch
            {
                return false;
            }
        }

        // DELETE api/<UsersController>/5
        [HttpDelete("{id}")]
        public bool Delete(int id)
        {
            try
            {
                usersIBLL.DeleteUser(id);
                return true;

            }
            catch
            {
                return false;
            }
        }
    }
}
