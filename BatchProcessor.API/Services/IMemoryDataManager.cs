using BatchProcessor.API.Models;
using BatchProcessor.API.ViewModels;
using BatchProcessor.Data.Entities;
using BatchProcessor.Data.Services;

namespace BatchProcessor.API.Services
{
    public interface IMemoryDataManager
    {
        BatchLotViewModel GetProgress(IDataBase db);

        State GetCurrentProcessingState();

        void AddNumber(Number number);

        void UpdateNumber(Number number);

        void UpdateState(State state);

        void DecrementRemainingNumbers();

        void SetCurrentTotal(int currentTotal);

        void HasFinished(IDataBase db);
    }
}