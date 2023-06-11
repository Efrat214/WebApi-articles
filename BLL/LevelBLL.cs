using DAL;
using EntityFrameWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class LevelBLL : LevelIBLL
    {
        LevelIDAL levelDAL;
        public LevelBLL(LevelIDAL levelDAL)
        {
            this.levelDAL = levelDAL;
        }

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
            return levelDAL.getLevelById(levelID);
        }

        public List<Level> GetLevels()
        {
            throw new NotImplementedException();
        }

        public void UpdateLevel(int Id, Level l)
        {
            throw new NotImplementedException();
        }
        public int getCode(int? num)
        {
            return levelDAL.getCode(num);
        }

    }
}
