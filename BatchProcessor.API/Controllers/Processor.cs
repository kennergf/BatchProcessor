using BatchProcessor.API.Workers;
using Microsoft.AspNetCore.Mvc;
using BatchProcessor.API.Models;
using BatchProcessor.API.ViewModels;
using BatchProcessor.Data.Services;
using System.Threading.Tasks;
using System.Collections.Generic;
using BatchProcessor.API.Profile;
using System;

namespace BatchProcessor.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProcessorController : ControllerBase
    {
        private Processor _Processor;
        private IDataBase _db;

        public ProcessorController(IDataBase db)
        {
            _db = db;
            _Processor = new Processor(db);
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
                    _Processor.Start(input);
                    return "OK";
                }

                return "Invalid Input!";
            }
            catch (System.Exception)
            {
                return "Error";
            }
        }

        [HttpGet]
        [Route("GetProgress")]
        public BatchLotViewModel GetProgress()
        {
            _Processor.HasFinished();
            return _Processor.GetProgress();
        }

        [Route("GetExecutions")]
        public List<long> GetExecutions()
        {
            return _db.GetExecutions();
        }

        [Route("GetBatchesByExecution")]
        public List<List<BatchViewModel>> GetBatchesByExecution(long execution)
        {
            try
            {
                var numbers = _db.GetByExecution(execution);
                return BatchProfile.ConvertNumbersToBatches(numbers);
            }
            catch(Exception)
            {
                return new List<List<BatchViewModel>>();
            }
        }
    }
}