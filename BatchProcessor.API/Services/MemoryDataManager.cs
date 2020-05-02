using System.Collections.Generic;
using System.Linq;
using BatchProcessor.API.Models;
using BatchProcessor.API.ViewModels;
using BatchProcessor.Data.Data.Entities;

namespace BatchProcessor.API.Services
{
    public class MemoryDataManager
    {
        private MemoryData _MemoryData;

        public MemoryDataManager()
        {
            _MemoryData = new MemoryData();
            _MemoryData.Numbers = new List<Number>();
            _MemoryData.State = State.Waiting;
        }

        public BatchLotViewModel GetProgress()
        {
            var batchLotViewModel = new BatchLotViewModel();
            batchLotViewModel.GrandTotal = _MemoryData.GrandTotal;
            batchLotViewModel.RemainingNumbers = _MemoryData.RemainingNumbers;
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

        public void UpdateGrandTotal(int grandTotal)
        {
            _MemoryData.GrandTotal = grandTotal;
            _MemoryData.RemainingNumbers = grandTotal;
        }
    }
}