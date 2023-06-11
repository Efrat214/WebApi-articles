using EntityFrameWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;


namespace BLL
{
    public class CategoriesBLL : CategoriesIBLL
    {
        CategoriesIDAL categoriesIDAL;
        public CategoriesBLL(CategoriesIDAL categoriesIDAL)
        {
            this.categoriesIDAL = categoriesIDAL;
        }
        public int AddCategory(Category c)
        {
            return categoriesIDAL.AddCategory(c);
        }

        public void Deleteategory(int Id)
        {
            categoriesIDAL.Deleteategory(Id);
        }

        public List<Category> GetAllCategoriess()
        {
            return categoriesIDAL.GetAllCategoriess();
        }

        public Category GetCategoryById(int Id)
        {
            return categoriesIDAL.GetCategoryById(Id);
        }

        public void Updateategory(int Id, Category c)
        {
            categoriesIDAL.Updateategory(Id, c);
        }
        public void DecNumArticels(int id)
        {
            categoriesIDAL.DecNumArticels(id);
        }
        public string getNameByCode(int code)
        {
            return categoriesIDAL.getNameByCode(code);
        }

    }
}
