
using System;
using System.Collections.Generic;

namespace BatchProcessor.API.Workers
{
    public class MultiplierManager
    {
        internal int Run(int number)
        {
            var random = new Random();
            return random.Next(2, 4) * number;
        }
    }
}