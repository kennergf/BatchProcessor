using System.Collections.Generic;

namespace BatchProcessor.API.ViewModels
{
    public class BatchLotViewModel
    {
        public BatchLotViewModel()
        {
            Numbers = new List<List<BatchViewModel>>();
        }

        public List<List<BatchViewModel>> Numbers { get; set; }
        public int RemainingNumbers { get; set; }
        public int GrandTotal { get; set; }
    }
}