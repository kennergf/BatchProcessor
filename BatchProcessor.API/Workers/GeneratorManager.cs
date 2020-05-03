using System;
using BatchProcessor.API.Models;

namespace BatchProcessor.API.Workers
{
    public class GeneratorManager
    {
        public void Run(object oInput)
        {
            var input = (Input)oInput;
            var random = new Random();
            var execution = long.Parse(DateTime.Now.ToString("yyyyMMddHHmmss"));
            for(int i=0; i < input.XBatches; i++)
            {
                for(int j=0; j < input.YNumbers; j++)
                {
                    //Delay
                    System.Threading.Thread.Sleep(1000 * random.Next(5, 10));
                    // Generate Event
                    NumberGeneratedEventArgs args = new NumberGeneratedEventArgs();
                    args.Execution = execution;
                    args.BatchSequence = i;
                    args.Number = random.Next(1, 100);
                    OnNumberGenerated(args);
                }
            }
        }

        protected virtual void OnNumberGenerated(NumberGeneratedEventArgs e)
        {
            EventHandler<NumberGeneratedEventArgs> handler = NumberGenerated;
            if(handler != null)
            {
                handler(this, e);
            }
        }
        public event EventHandler<NumberGeneratedEventArgs> NumberGenerated;
    }

    public class NumberGeneratedEventArgs : EventArgs
    {
        public long Execution { get; set; }
        public int BatchSequence { get; set; }
        public int Number { get; set; }
    }
}