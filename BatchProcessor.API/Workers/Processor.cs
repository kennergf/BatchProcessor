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
        private Number number;
        private Thread tGeneratorManager;
        private Thread tMultiplierManager;
        private IDataBase _db;
        private IMemoryDataManager _memoryDataManager;

        internal Processor(IDataBase db, IMemoryDataManager mdm)
        {
            _db = db;
            _memoryDataManager = mdm;
        }

        internal string Start(Input input)
        {
            try
            {
                if (_memoryDataManager.GetCurrentProcessingState() == State.Waiting ||
                    _memoryDataManager.GetCurrentProcessingState() == State.Error)
                {
                    _memoryDataManager = new MemoryDataManager();
                    _memoryDataManager.UpdateState(State.Processing);
                    _memoryDataManager.SetCurrentTotal(input.XBatches * input.YNumbers);
                    CallGenerator(input);
                    return "[  { \"Message\": \"Started\"  } ]";
                }
                else
                {
                    return "[  { \"Message\": \"Already Processing\"  } ]";
                }
            }
            catch (System.Exception)
            {
                _memoryDataManager.UpdateState(State.Error);
                return "[  { \"Message\": \"Error\"  } ]";
            }
        }

        private void CallGenerator(Input input)
        {
            var generator = new GeneratorManager();
            generator.NumberGenerated += generator_NumberGenerated;

            // Create one thread for Batch
            for (int i = 0; i < input.XBatches; i++)
            {
                tGeneratorManager = new Thread(generator.Run);
                // Create a new GeneratorInput for Thread to avoid update value of previous thread
                tGeneratorManager.Start(new GeneratorInput(input.YNumbers, i));
            }
        }

        private void CallMultiplier(Number number)
        {
            var multiplier = new MultiplierManager();
            multiplier.NumberMultiplied += multiplier_NumberMultiplied;

            tMultiplierManager = new Thread(multiplier.Run);
            tMultiplierManager.Start(number);
        }

        internal BatchLotViewModel GetProgress()
        {
            return _memoryDataManager.GetProgress(_db);
        }

        internal State GetCurrentProcessingState()
        {
            return _memoryDataManager.GetCurrentProcessingState();
        }

        internal void PersistIfFinished()
        {
            _memoryDataManager.PersistIfFinished(_db);
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