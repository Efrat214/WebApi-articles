using EntityFrameWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public interface VocabularyToAriacleIDAL
    {
        //קבלת רשימת מאמרים לת"ז
        public List<string> GetAllVocabularyToAriacle(int id,int level);
        public VocabularyToAriacle GetVocabularyToAriacleById(int Id);

        public void AddVocabularyToAriacle(VocabularyToAriacle w);
        public void UpdateVocabularyToAriacle(int Id, VocabularyToAriacle w);
        public void DeleteVocabularyToAriacle(int Id);
        public bool GetIsExist(int artId,Level l);
    }
}
