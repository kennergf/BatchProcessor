using System;
using System.Threading;
using BatchProcessor.API.Models;
using BatchProcessor.API.Workers;
using BatchProcessor.Data.Entities;
using Xunit;

namespace BatchProcessor.Test
{
    public class GeneratorManager_Test
    {
        [Theory]
        [InlineData(2, 2)]
        [InlineData(3, 5)]
        private void CallGenerator(int XBatches, int YNumbers)
        {
            var input = new Input(XBatches, YNumbers);
            var generator = new GeneratorManager();
            generator.NumberGenerated += generator_NumberGenerated;

            // Create one thread for Batch
            for (int i = 0; i < input.XBatches; i++)
            {
                var tGeneratorManager = new Thread(generator.Run);
                // Create a new GeneratorInput for Thread to avoid update value of previous thread
                tGeneratorManager.Start(new GeneratorInput(input.YNumbers, i));
            }
        }

        void generator_NumberGenerated(object sender, NumberGeneratedEventArgs e)
        {
            var number = new Number(e.Execution, e.BatchSequence, e.Number);
            Assert.True(number.Value > 0);
        }

    }
}