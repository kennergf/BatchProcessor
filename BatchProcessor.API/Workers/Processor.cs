using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading;
using BatchProcessor.API.Models;
using BatchProcessor.API.Services;
using BatchProcessor.API.ViewModels;
using BatchProcessor.Data.Data.Entities;

namespace BatchProcessor.API.Workers
{
    internal static class Processor
    {
        private static MemoryData _memoryData = new MemoryData();
        private static Number number;
        private static Thread tGeneratorManager;
        private static Thread tMultiplierManager;

        internal static void Start(Input input)
        {
            try
            {
                if(tGeneratorManager == null || (tGeneratorManager.ThreadState == ThreadState.Stopped
                        || tMultiplierManager.ThreadState == ThreadState.Stopped))
                {
                    CallGenerator(input);
                }
                else if(tGeneratorManager.ThreadState == ThreadState.Running
                        || tMultiplierManager.ThreadState == ThreadState.Running)
                {

                }
                else
                {
                    
                }
            }
            catch (System.Exception)
            {
                
                throw;
            }
        }

        private static void CallGenerator(Input input)
        {
            _memoryData = new MemoryData();
            var generator = new GeneratorManager();
            generator.NumberGenerated += generator_NumberGenerated;

            tGeneratorManager = new Thread(generator.Run);
            tGeneratorManager.Start(input);
        }

        private static void CallMultiplier(Number number)
        {
            var multiplier = new MultiplierManager();
            multiplier.NumberMultiplied += multiplier_NumberMultiplied;

            tMultiplierManager = new Thread(multiplier.Run);
            tMultiplierManager.Start(number);
        }

        public static BatchProgressViewModel GetProgress()
        {
            return _memoryData.GetProgress();
        }

        static void generator_NumberGenerated(object sender, NumberGeneratedEventArgs e)
        {
            number = new Number(e.Execution, e.BatchSequence, e.Number);
            _memoryData.AddNumber(number);
            CallMultiplier(number);
        }

        static void multiplier_NumberMultiplied(object sender, NumberMultipliedEventArgs e)
        {
            number = new Number(e.Execution, e.BatchSequence, e.Number, e.Total);
            _memoryData.UpdateNumber(number);
        }
    }
}