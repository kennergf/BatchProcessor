using System.Collections;
using System.Collections.Generic;
using BatchProcessor.Data.Entities;

namespace BatchProcessor.Data.Services
{
    public interface IDataBase
    {
        /// <summary>
        /// Add a number to the DataBase
        /// </summary>
        /// <param name="number"></param>
        void Add(Number number);

        /// <summary>
        /// Get the total of numbers ever generated
        /// </summary>
        /// <returns></returns>
        long GetGrandTotal();

        /// <summary>
        /// Return a List of Number by Execution
        /// </summary>
        /// <param name="execution"></param>
        /// <returns></returns>
        List<Number> GetByExecution(int execution);

        /// <summary>
        /// Commit the alteration to the DataBase
        /// </summary>
        /// <returns></returns>
        int Commit();
    }
}