using System.Collections;
using BatchProcessor.Data.Data.Entities;

namespace BatchProcessor.Data.Services
{
    public interface IDataBase
    {
        void Add(Number number);

        IEnumerable GetByGroup(int groupId);

        int Commit();
    }
}