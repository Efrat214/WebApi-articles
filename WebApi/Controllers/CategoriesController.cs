using Microsoft.AspNetCore.Mvc;
using BLL;
using EntityFrameWork;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        CategoriesIBLL categoriesIBLL;
        public CategoriesController(CategoriesIBLL categoriesIBLL)
        {
            this.categoriesIBLL = categoriesIBLL;
        }    
        // GET: api/<Categories>
        [HttpGet]
        public List<Category> Get()
        {
            return categoriesIBLL.GetAllCategoriess();
        }

        // GET api/<Categories>/5
        [HttpGet("{id}")]
        public Category Get(int id)
        {
            return categoriesIBLL.GetCategoryById(id);
        }


        // POST api/<Categories>
        [HttpPost]
        public bool Post(Category c)
        {
            try
            {
                categoriesIBLL.AddCategory(c);
                return true;
            }
            catch
            {
                return false;
            }

        }


        // PUT api/<Categories>/5
        [HttpPut("{id}")]
        public bool Put(int id, Category c)
        {
            try
            {
                categoriesIBLL.Updateategory(id, c);
                return true;
            }
            catch
            {
                return false;
            }
        }

        // DELETE api/<Categories>/5
        [HttpDelete("{id}")]
        public bool Delete(int id)
        {
            try
            {
                categoriesIBLL.Deleteategory(id);
                return true;

            }
            catch
            {
                return false;
            }
        }
    }
}
