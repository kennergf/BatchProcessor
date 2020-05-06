using BatchProcessor.API.Models;
using BatchProcessor.API.ViewModels;
using BatchProcessor.Data.Entities;
using BatchProcessor.Data.Services;

namespace BatchProcessor.API.Services
{
    public interface IMemoryDataManager
    {
        /// <summary>
        /// Return the current data of the job in progress to the front-end
        /// </summary>
        /// <param name="db">Necessary to retrieve the grand total from da previous execution</param>
        /// <returns></returns>
        BatchLotViewModel GetProgress(IDataBase db);

        /// <summary>
        /// Return the current State of the processing
        /// </summary>
        /// <returns></returns>
        State GetCurrentProcessingState();

        /// <summary>
        /// Add a number to the list of numbers stored in memory
        /// </summary>
        /// <param name="number">Number to be stored</param>
        void AddNumber(Number number);

        /// <summary>
        /// Update a number on memory storage
        /// </summary>
        /// <param name="number">Number to be updated</param>
        void UpdateNumber(Number number);

        /// <summary>
        /// Update the State of processing
        /// </summary>
        /// <param name="state">New State</param>
        void UpdateState(State state);

        /// <summary>
        /// Decrement the current amount of numbers to be processed
        /// </summary>
        void DecrementRemainingNumbers();

        /// <summary>
        /// Set the currentTotal and RemainingNumbers with the passed value
        /// </summary>
        /// <param name="currentTotal"></param>
        void SetCurrentTotal(int currentTotal);

        /// <summary>
        /// Store in the DB if the processing has finished
        /// </summary>
        /// <param name="db"></param>
        void PersistIfFinished(IDataBase db);
    }
}