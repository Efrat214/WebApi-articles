using DAL;
using EntityFrameWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class VocabularyToAriacleBLL : VocabularyToAriacleIBLL
    {
        VocabularyToAriacleIDAL VocabularyToAriacleIDAL;
        public VocabularyToAriacleBLL(VocabularyToAriacleIDAL vocabularyToAriacleIDAL)
        {
            VocabularyToAriacleIDAL = vocabularyToAriacleIDAL;
        }

        public void AddVocabularyToAriacle(VocabularyToAriacle w)
        {
            VocabularyToAriacleIDAL.AddVocabularyToAriacle(w);
        }

        public void DeleteVocabularyToAriacle(int Id)
        {
            VocabularyToAriacleIDAL.DeleteVocabularyToAriacle(Id);
        }

        public List<string> GetAllVocabularyToAriacle(int id,int level)
        {
            return VocabularyToAriacleIDAL.GetAllVocabularyToAriacle(id,level);
        }

        public VocabularyToAriacle GetVocabularyToAriacleById(int Id)
        {
            throw new NotImplementedException();
        }

        public void UpdateVocabularyToAriacle(int Id, VocabularyToAriacle w)
        {
            throw new NotImplementedException();
        }
    }
}
