using System.Collections.Generic;
using System.Linq;
using BatchProcessor.API.Models;
using BatchProcessor.API.ViewModels;
using BatchProcessor.Data.Data.Entities;

namespace BatchProcessor.API.Services
{
    public class MemoryData
    {
        private BatchProgressViewModel batchProgress;

        public MemoryData()
        {
            batchProgress = new BatchProgressViewModel();
            batchProgress.Numbers = new List<Number>();
            batchProgress.State = State.Waiting;
        }

        public BatchProgressViewModel GetProgress()
        {
            return batchProgress;
        }

        public void AddNumber(Number number)
        {
            batchProgress.Numbers.Add(number);
        }

        public void UpdateNumber(Number number)
        {
            var n = batchProgress.Numbers.Find(n => n.Execution == number.Execution
                        && n.BatchSequence == number.BatchSequence
                        && n.Value == number.Value);
            batchProgress.Numbers.Remove(n);
            batchProgress.Numbers.Add(number);
        }

        public void UpdateState(State state)
        {
            batchProgress.State = state;
        }

        public void SetProgress(int progress)
        {
            batchProgress.Progress = progress;
        }
    }
}