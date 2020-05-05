using System.Threading;
using BatchProcessor.API.Models;
using BatchProcessor.API.Services;
using BatchProcessor.Data.Entities;
using BatchProcessor.API.ViewModels;
using BatchProcessor.Data.Services;

namespace BatchProcessor.API.Workers
{
    internal class Processor
    {
        private static MemoryDataManager _memoryDataManager = new MemoryDataManager();
        private Number number;
        private Thread tGeneratorManager;
        private Thread tMultiplierManager;
        private IDataBase _db;

        public Processor(IDataBase db)
        {
            _db = db;
        }

        internal void Start(Input input)
        {
            try
            {
                if(tGeneratorManager == null || (tGeneratorManager.ThreadState == ThreadState.Stopped
                        || tMultiplierManager.ThreadState == ThreadState.Stopped))
                {
                    _memoryDataManager = new MemoryDataManager();
                    _memoryDataManager.UpdateState(State.Processing);
                    _memoryDataManager.SetCurrentTotal(input.XBatches * input.YNumbers);
                    CallGenerator(input);
                }
                else if(tGeneratorManager.ThreadState == ThreadState.Running
                        || tMultiplierManager.ThreadState == ThreadState.Running)
                {
                    // TODO return message
                }
                else
                {
                    
                }
            }
            catch (System.Exception)
            {
                _memoryDataManager.UpdateState(State.Error);
                throw;
            }
        }

        private void CallGenerator(Input input)
        {
            var generator = new GeneratorManager();
            generator.NumberGenerated += generator_NumberGenerated;

            tGeneratorManager = new Thread(generator.Run);
            tGeneratorManager.Start(input);
        }

        private void CallMultiplier(Number number)
        {
            var multiplier = new MultiplierManager();
            multiplier.NumberMultiplied += multiplier_NumberMultiplied;

            tMultiplierManager = new Thread(multiplier.Run);
            tMultiplierManager.Start(number);
        }

        public BatchLotViewModel GetProgress()
        {
            return _memoryDataManager.GetProgress(_db);
        }

        public State GetCurrentProcessingState()
        {
            return _memoryDataManager.GetCurrentProcessingState();
        }
        
        public void HasFinished()
        {
            _memoryDataManager.HasFinished(_db);
        }

        void generator_NumberGenerated(object sender, NumberGeneratedEventArgs e)
        {
            number = new Number(e.Execution, e.BatchSequence, e.Number);
            _memoryDataManager.AddNumber(number);
            CallMultiplier(number);
        }

        void multiplier_NumberMultiplied(object sender, NumberMultipliedEventArgs e)
        {
            number = new Number(e.Execution, e.BatchSequence, e.Number, e.Total);
            _memoryDataManager.UpdateNumber(number);
            _memoryDataManager.DecrementRemainingNumbers();
        }
    }
}