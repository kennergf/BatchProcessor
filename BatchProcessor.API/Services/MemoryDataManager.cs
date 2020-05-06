using System.Collections.Generic;
using System.Linq;
using BatchProcessor.API.Models;
using BatchProcessor.API.ViewModels;
using BatchProcessor.Data.Entities;
using BatchProcessor.Data.Services;

namespace BatchProcessor.API.Services
{
    public class MemoryDataManager : IMemoryDataManager
    {
        private static MemoryData _MemoryData = new MemoryData();

        public MemoryDataManager()
        {
            _MemoryData.Numbers = new List<Number>();
        }

        public BatchLotViewModel GetProgress(IDataBase db)
        {
            var batchLotViewModel = new BatchLotViewModel();
            batchLotViewModel.CurrentTotal = _MemoryData.CurrentTotal;
            batchLotViewModel.RemainingNumbers = _MemoryData.RemainingNumbers;
            batchLotViewModel.GrandTotal = GetGrandTotal(db);
            // Convert list of numbers to list of batches
            var listGroupNumber = _MemoryData.Numbers.GroupBy(n => n.BatchSequence).ToList();
            foreach(var groupNumber in listGroupNumber)
            {
                var listNumber = groupNumber.ToList();
                var listBatchVM = new List<BatchViewModel>();
                foreach(var n in listNumber)
                {
                    listBatchVM.Add(new BatchViewModel(n.Value, n.Total));
                }
                batchLotViewModel.Numbers.Add(listBatchVM);
            }

            return batchLotViewModel;
        }

        public State GetCurrentProcessingState()
        {
            return _MemoryData.State;
        }

        public void AddNumber(Number number)
        {
            _MemoryData.Numbers.Add(number);
        }

        public void UpdateNumber(Number number)
        {
            var n = _MemoryData.Numbers.Find(n => n.Execution == number.Execution
                        && n.BatchSequence == number.BatchSequence
                        && n.Value == number.Value);
            _MemoryData.Numbers.Remove(n);
            _MemoryData.Numbers.Add(number);
        }

        public void UpdateState(State state)
        {
            _MemoryData.State = state;
        }

        public void DecrementRemainingNumbers()
        {
            _MemoryData.RemainingNumbers--;
        }

        public void SetCurrentTotal(int currentTotal)
        {
            _MemoryData.CurrentTotal = currentTotal;
            _MemoryData.RemainingNumbers = currentTotal;
        }

        public void PersistIfFinished(IDataBase db)
        {
            if(_MemoryData.State == State.Processing &&
                _MemoryData.RemainingNumbers == 0)
            {
                UpdateState(State.Finished);
                db.Add(_MemoryData.Numbers);
                db.Commit();
            }
        }

        private long GetGrandTotal(IDataBase db)
        {
            // If GrandTotal = 0, means first time here
            // If State = Finished, means processing just finished
            if(_MemoryData.GrandTotal == 0 || _MemoryData.State == State.Finished)
            {
                // Need to update GrandTotal from DB
                _MemoryData.GrandTotal = db.GetGrandTotal();
                if(_MemoryData.State == State.Finished)
                {
                    // Update state to Waiting so, a new processing can be performed
                    UpdateState(State.Waiting);
                }
            }

            // If processing, GrandTotal need to include currentTotal
            if(_MemoryData.State == State.Processing)
            {
                return _MemoryData.GrandTotal + _MemoryData.CurrentTotal;
            }
            else
            {
                return _MemoryData.GrandTotal;
            }
        }
    }
}