using System.Collections;
using BatchProcessor.Data.Data.Entities;

namespace BatchProcessor.Data.Services
{
    public interface IDataBase
    {
        void Add(Number number);

        /// <summary>
        /// Add a BatchGroup to the DataBase
        /// </summary>
        /// <param name="batchGroup"></param>
        void Add(BatchGroup batchGroup);

        IEnumerable GetByGroup(int groupId);

        int Commit();
    }
}