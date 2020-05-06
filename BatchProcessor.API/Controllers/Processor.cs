using BatchProcessor.API.Workers;
using Microsoft.AspNetCore.Mvc;
using BatchProcessor.API.Models;
using BatchProcessor.API.ViewModels;
using BatchProcessor.Data.Services;
using System.Collections.Generic;
using BatchProcessor.API.Profile;
using System;
using BatchProcessor.API.Services;

namespace BatchProcessor.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProcessorController : ControllerBase
    {
        private Processor _Processor;
        private IDataBase _db;

        public ProcessorController(IDataBase db, IMemoryDataManager mdm)
        {
            _db = db;
            _Processor = new Processor(db, mdm);
        }

        public string Test(int XBatches, int YNumbers)
        {
            return Execute(new Input(XBatches, YNumbers));
        }

        [HttpPost]
        [Route("Execute")]
        public string Execute(Input input)
        {
            try
            {
                if(input.Validate())
                {
                    return _Processor.Start(input);
                }

                return "Invalid Input!";
            }
            catch (System.Exception)
            {
                return "[  { \"Message\": \"Error\"  } ]";
            }
        }

        [HttpGet]
        [Route("GetProgress")]
        public BatchLotViewModel GetProgress()
        {
            _Processor.PersistIfFinished();
            return _Processor.GetProgress();
        }

        [Route("GetCurrentProcessingState")]
        public State GetCurrentProcessingState()
        {
            return _Processor.GetCurrentProcessingState();
        }

        [Route("GetExecutions")]
        public List<long> GetExecutions()
        {
            return _db.GetExecutions();
        }

        [Route("GetBatchesByExecution")]
        public List<List<BatchViewModel>> GetBatchesByExecution(long Id)
        {
            try
            {
                var numbers = _db.GetByExecution(Id);
                return BatchProfile.ConvertNumbersToBatches(numbers);
            }
            catch(Exception)
            {
                return new List<List<BatchViewModel>>();
            }
        }
    }
}