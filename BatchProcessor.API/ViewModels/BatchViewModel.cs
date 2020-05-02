namespace BatchProcessor.API.ViewModels
{
    public class BatchViewModel
    {
        public BatchViewModel(int number, int total)
        {
            Number = number;
            Total = total;
        }
        public int Number { get; set; }
        public int Total { get; set; }
    }
}