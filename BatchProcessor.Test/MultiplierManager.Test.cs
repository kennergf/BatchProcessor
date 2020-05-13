using System;
using System.Threading;
using BatchProcessor.API.Workers;
using BatchProcessor.Data.Entities;
using Xunit;

namespace BatchProcessor.Test
{
    public class MultiplierManager_Test
    {
        [Theory]
        [InlineData(11)]
        [InlineData(2)]
        [InlineData(99)]
        public void CallMultiplier(int value)
        {
            var number = new Number(
                long.Parse(DateTime.Now.ToString("yyyyMMddHHmmss")),
                0,
                value);
            var multiplier = new MultiplierManager();
            multiplier.NumberMultiplied += multiplier_NumberMultiplied;

            var tMultiplierManager = new Thread(multiplier.Run);
            tMultiplierManager.Start(number);
        }

        void multiplier_NumberMultiplied(object sender, NumberMultipliedEventArgs e)
        {
            var number = new Number(e.Execution, e.BatchSequence, e.Number, e.Total);
            Assert.InRange(number.Total / number.Value, 2, 4);
        }
    }
}