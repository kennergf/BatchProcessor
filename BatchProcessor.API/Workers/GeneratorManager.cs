using System;
using BatchProcessor.API.Models;

namespace BatchProcessor.API.Workers
{
    internal class GeneratorManager : WorkerConstants
    {
        internal void Run(object oInput)
        {
            var input = (Input)oInput;
            var random = new Random();
            var execution = long.Parse(DateTime.Now.ToString("yyyyMMddHHmmss"));
            for(int i=0; i < input.XBatches; i++)
            {
                for(int j=0; j < input.YNumbers; j++)
                {
                    //Delay
                    System.Threading.Thread.Sleep(1000 * random.Next(MinDelay, MaxDelay));
                    // Generate Event
                    NumberGeneratedEventArgs args = new NumberGeneratedEventArgs();
                    args.Execution = execution;
                    args.BatchSequence = i;
                    args.Number = random.Next(MinNumber, MaxNumber);
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
        internal event EventHandler<NumberGeneratedEventArgs> NumberGenerated;
    }

    internal class NumberGeneratedEventArgs : EventArgs
    {
        internal long Execution { get; set; }
        internal int BatchSequence { get; set; }
        internal int Number { get; set; }
    }
}