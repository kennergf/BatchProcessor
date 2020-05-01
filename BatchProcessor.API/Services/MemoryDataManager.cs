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

        public MemoryData GetProgress()
        {
            return _MemoryData;
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

        public void SetProgress(int progress)
        {
            _MemoryData.Progress = progress;
        }
    }
}