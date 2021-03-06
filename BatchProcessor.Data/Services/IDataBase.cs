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
        /// Add a list of numbers to the DataBase
        /// </summary>
        /// <param name="numbers"></param>
        void Add(List<Number> numbers);

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
        List<Number> GetByExecution(long execution);

        /// <summary>
        /// Get a list of distinct Executions
        /// </summary>
        /// <returns></returns>
        List<long> GetExecutions();

        /// <summary>
        /// Commit the alteration to the DataBase
        /// </summary>
        /// <returns></returns>
        int Commit();
    }
}