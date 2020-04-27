using System;
using System.Collections.Generic;

namespace BatchProcessor.API.Workers
{
    public class GeneratorManager
    {
        internal IEnumerable<int> Run(int YNumbers)
        {
            var random = new Random();
            for(int i=0; i < YNumbers; i++)
            {
                yield return random.Next(1, 100);
            }
        }
    }
}