using System.Collections;
using System.Linq;
using BatchProcessor.Data.Data;
using BatchProcessor.Data.Data.Entities;

namespace BatchProcessor.Data.Services
{
    public class DataBase : IDataBase
    {
        private BPContext _db;

        public DataBase(BPContext db)
        {
            _db = db;
        }

        public void Add(Number number)
        {
            _db.Add(number);
        }

        public IEnumerable GetByGroup(int groupId)
        {
            return _db.BatchGroups.Where(bg => bg.Id == groupId);
        }

        public int Commit()
        {
            return _db.SaveChanges();
        }
    }
}