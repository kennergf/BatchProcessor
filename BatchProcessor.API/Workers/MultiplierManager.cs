using System;
using BatchProcessor.Data.Entities;

namespace BatchProcessor.API.Workers
{
    public class MultiplierManager : WorkerConstants
    {
        internal void Run(object oNumber)
        {
            var random = new Random();
            var number = (Number)oNumber;
            
            //Delay
            System.Threading.Thread.Sleep(1000 * random.Next(MinDelay, MaxDelay));
            // Generate Event
            NumberMultipliedEventArgs args = new NumberMultipliedEventArgs();
            args.Execution = number.Execution;
            args.BatchSequence = number.BatchSequence;
            args.Number = number.Value;
            args.Total = random.Next(MinMultiplier, MaxMultiplier) * number.Value;
            OnNumberMultiplied(args);
        }

        protected virtual void OnNumberMultiplied(NumberMultipliedEventArgs e)
        {
            EventHandler<NumberMultipliedEventArgs> handler = NumberMultiplied;
            if(handler != null)
            {
                handler(this, e);
            }
        }

        public event EventHandler<NumberMultipliedEventArgs> NumberMultiplied;
    }

    public class NumberMultipliedEventArgs : EventArgs
    {
        public long Execution { get; set; }
        public int BatchSequence { get; set; }
        public int Number { get; set; }
        public int Total { get; set; }
    }
}