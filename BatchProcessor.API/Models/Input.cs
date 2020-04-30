using System.ComponentModel.DataAnnotations;

namespace BatchProcessor.API.Models
{
    public class Input
    {
        public Input(int xBatches, int yNumbers)
        {
            XBatches = xBatches;
            YNumbers = yNumbers;
        }
        [Range(1, 10)]
        internal int XBatches { get; set; }
        [Range(1, 10)]
        internal int YNumbers { get; set; }
    }
}