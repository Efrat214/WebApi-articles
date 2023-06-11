using EntityFrameWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class CategoriesDAL : CategoriesIDAL
    {
        public FinalArticelsDbContext db = new FinalArticelsDbContext();

        public int getLengthOfData()
        {
            return db.Categories.Count();
        }
        public int AddCategory(Category c)
        {
            Category c1=db.Categories.FirstOrDefault(x => x.Name.Equals(c.Name));  
            if (c1==null)
            {
                db.Categories.Add(c);
                db.SaveChanges();
                return c.Id;
            }
            else
            {
                c1.NumArticals++;
                db.SaveChanges();
                return c1.Id;
            }
        }
        public void Deleteategory(int Id)
        {
            db.Categories.Remove(db.Categories.FirstOrDefault(x => x.Id == Id));
            db.SaveChanges();
        }

        public List<Category> GetAllCategoriess()
        {
            return db.Categories.ToList();
        }
        public Category GetCategoryById(int Id)
        {
            return db.Categories.FirstOrDefault(x => x.Id == Id);
        }
        public void Updateategory(int Id, Category c)
        {
            var category = db.Categories.FirstOrDefault(x => x.Id == Id);
            if (category != null)
            {
                category.Name = c.Name;
                category.NumArticals = c.NumArticals;
                db.SaveChanges();
            }
        }
         public int[] getNumArticales()
         {
            int numCategory = db.Categories.Count();     
            int[] numArticales = new int[numCategory];
            int i = 0;
            foreach (var item in db.Categories)
            {
                numArticales[i++] = (int)item.NumArticals;
            }
            return numArticales;
         }
        public int[] getCodeCategory()
        {
            int numCategory = db.Categories.Count();
            int[] codeCategory = new int[numCategory];
            int i = 0;
            foreach (var item in db.Categories)
            {
                codeCategory[i++] = item.Id;
            }
            return codeCategory;
        }
        public void incNumArticels(int catID)
        {
            Category c1 = db.Categories.FirstOrDefault(x => x.Id==catID);
            if(c1!= null)
            {
                c1.NumArticals++;
                db.SaveChanges();
            }
        }
        public int getCodeCategory(int index)
        {
            return db.Categories.ToList()[index].Id;
        }
        public void DecNumArticels(int id)
        {
            Category c=db.Categories.FirstOrDefault(x=>x.Id==id);
            c.NumArticals--;
            db.SaveChanges();
        }
        public string getNameByCode(int code)
        {
            return db.Categories.FirstOrDefault(x => x.Id == code).Name;
        }
    }
}
