using System.ComponentModel.DataAnnotations;

namespace BatchProcessor.API.Models
{
    public class Input
    {
        // CONSTANTS
        private const int Min = 1;
        private const int Max = 10;
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

        public bool Validate()
        {
            if(XBatches >= Min && XBatches <= Max 
                && YNumbers >= Min && YNumbers <= Max)
            {
                return true;
            }

            return false;
        }
    }
}