using System.Collections.Generic;
using System.Linq;
using BatchProcessor.API.ViewModels;
using BatchProcessor.Data.Entities;

namespace BatchProcessor.API.Profile
{
    internal static class BatchProfile
    {
        internal static List<List<BatchViewModel>> ConvertNumbersToBatches(List<Number> numbers)
        {
            var listBatchViewModel = new List<List<BatchViewModel>>();
            var listGroupNumber = numbers.GroupBy(n => n.BatchSequence).ToList();
            foreach(var groupNumber in listGroupNumber)
            {
                var listNumber = groupNumber.ToList();
                var listBatchVM = new List<BatchViewModel>();
                foreach(var n in listNumber)
                {
                    listBatchVM.Add(new BatchViewModel(n.Value, n.Total));
                }
                listBatchViewModel.Add(listBatchVM);
            }

            return listBatchViewModel;
        }
    }
}