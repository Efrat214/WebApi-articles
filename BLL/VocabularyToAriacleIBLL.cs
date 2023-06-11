using EntityFrameWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public interface VocabularyToAriacleIBLL
    {
        List<string> GetAllVocabularyToAriacle(int id, int level);
        VocabularyToAriacle GetVocabularyToAriacleById(int Id);

        void AddVocabularyToAriacle(VocabularyToAriacle w);
        void UpdateVocabularyToAriacle(int Id, VocabularyToAriacle w);
        void DeleteVocabularyToAriacle(int Id);
    }
}
