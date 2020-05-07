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

        public void Add(List<Number> numbers)
        {
            numbers.ForEach(n => Add(n));
        }

        public long GetGrandTotal()
        {
            return _db.Numbers.LongCount();
        }

        public List<Number> GetByExecution(long execution)
        {
            return _db.Numbers.Where(n => n.Execution == execution).ToList();
        }

        public List<long> GetExecutions()
        {
            return _db.Numbers.Select(n => n.Execution).Distinct().ToList();
        }

        public int Commit()
        {
            return _db.SaveChanges();
        }
    }
}