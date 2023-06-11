using EntityFrameWork;

namespace DAL
{
    public class VocabularyToAriacleDAL : VocabularyToAriacleIDAL
    {
        FinalArticelsDbContext db = new FinalArticelsDbContext();
        public void AddVocabularyToAriacle(VocabularyToAriacle w)
        {
            db.VocabularyToAriacles.Add(w);
            db.SaveChanges();
        }

        public void DeleteVocabularyToAriacle(int Id)
        {
            foreach (var item in db.VocabularyToAriacles)
            {
                if(item.Articale==Id)
                {
                    db.VocabularyToAriacles.Remove(item);
                }
            }            
            db.SaveChanges();
        }

        public List<string> GetAllVocabularyToAriacle(int id,int level)
        {
            List<string> a = new List<string>();
            foreach (var item in db.VocabularyToAriacles.ToList())
            {
                if (item.Articale == id&&item.Level==level)
                    a.Add(item.Word);
            }
            return a;
        }

        public VocabularyToAriacle GetVocabularyToAriacleById(int Id)
        {
            throw new NotImplementedException();
        }

        public void UpdateVocabularyToAriacle(int Id, VocabularyToAriacle w)
        {
            throw new NotImplementedException();
        }
        public bool GetIsExist(int artId, Level l)
        {

            VocabularyToAriacle voc = db.VocabularyToAriacles.FirstOrDefault(x => x.Articale == artId && x.Level == l.Id);
            return voc != null;
        }

    }
}
