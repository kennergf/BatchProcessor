using System.ComponentModel.DataAnnotations;

namespace BatchProcessor.API.Models
{
    public class Input
    {
        public Input(){}

        public Input(int xBatches, int yNumbers)
        {
            XBatches = xBatches;
            YNumbers = yNumbers;
        }
        [Range(1, 10)]
        public int XBatches { get; set; }
        [Range(1, 10)]
        public int YNumbers { get; set; }
        // public string xBatches { get; set; }
        // public string yNumbers { get; set; }
    }
}