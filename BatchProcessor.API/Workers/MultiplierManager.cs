using System;
using BatchProcessor.Data.Entities;

namespace BatchProcessor.API.Workers
{
    internal class MultiplierManager : WorkerConstants
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

        internal event EventHandler<NumberMultipliedEventArgs> NumberMultiplied;
    }

    internal class NumberMultipliedEventArgs : EventArgs
    {
        internal long Execution { get; set; }
        internal int BatchSequence { get; set; }
        internal int Number { get; set; }
        internal int Total { get; set; }
    }
}