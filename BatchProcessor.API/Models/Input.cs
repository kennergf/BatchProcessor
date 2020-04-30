namespace BatchProcessor.API.Models
{
    public class Input
    {
        public Input(int xBatches, int yNumbers)
        {
            XBatches = xBatches;
            YNumbers = yNumbers;
        }
        internal int XBatches { get; set; }
        internal int YNumbers { get; set; }
    }
}