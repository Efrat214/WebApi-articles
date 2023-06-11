using EntityFrameWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class LevelDAL:LevelIDAL
    {
        FinalArticelsDbContext db=new FinalArticelsDbContext();

        public int AddLevel(Level l)
        {
            throw new NotImplementedException();
        }

        public void DeleteLevel(int Id)
        {
            throw new NotImplementedException();
        }

        public Level getLevelById(int? levelID)
        {
            return db.Levels.FirstOrDefault(x => x.Id == levelID);
        }

        public List<Level> GetLevels()
        {
            return db.Levels.ToList();
        }

        public void UpdateLevel(int Id, Level l)
        {
            throw new NotImplementedException();
        }
        public int getCode(int? num)
        {
            List<Level> l = db.Levels.ToList();
            return l[num.Value].Id;
        }
    }
}
