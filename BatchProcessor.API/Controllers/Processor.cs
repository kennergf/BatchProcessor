using BatchProcessor.API.Workers;
using Microsoft.AspNetCore.Mvc;
using BatchProcessor.API.Models;
using BatchProcessor.API.ViewModels;
using BatchProcessor.Data.Services;
using System.Threading.Tasks;

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
                _Processor.Start(input);
                return "OK";
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
    }
}