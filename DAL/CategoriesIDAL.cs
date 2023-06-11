using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityFrameWork;
namespace DAL
{
    public interface CategoriesIDAL
    {
        //קבלת רשימת קטגוריות
        public List<Category> GetAllCategoriess();
        public Category GetCategoryById(int Id);

        public int AddCategory(Category c);
        public void Updateategory(int Id, Category c);
        public void Deleteategory(int Id);
        public int getLengthOfData();
        public int[] getCodeCategory();
        public int[] getNumArticales();
        public void incNumArticels(int catID);    
        public int getCodeCategory(int index);
        public void DecNumArticels(int id);
        public string getNameByCode(int code);


    }
}
