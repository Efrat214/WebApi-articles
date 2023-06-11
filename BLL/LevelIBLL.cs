using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityFrameWork;

namespace BLL
{
    public interface LevelIBLL
    {
  
        public Level getLevelById(int? levelID);
        public List<Level> GetLevels();

        int AddLevel(Level l);
        void UpdateLevel(int Id, Level l);
        void DeleteLevel(int Id);
        public int getCode(int? num);

    }
}
