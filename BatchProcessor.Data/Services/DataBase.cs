using System.Collections;
using System.Collections.Generic;
using System.Linq;
using BatchProcessor.Data.Data;
using BatchProcessor.Data.Entities;

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

        public long GetGrandTotal()
        {
            return _db.Numbers.LongCount();
        }

        public List<Number> GetByExecution(int execution)
        {
            return _db.Numbers.Where(n => n.Execution == execution).ToList();
        }

        public int Commit()
        {
            return _db.SaveChanges();
        }
    }
}