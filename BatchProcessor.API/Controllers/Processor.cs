using BatchProcessor.API.Workers;
using Microsoft.AspNetCore.Mvc;
using BatchProcessor.API.Models;
using BatchProcessor.API.ViewModels;

namespace BatchProcessor.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProcessorController : ControllerBase
    {
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
                Processor.Start(input);
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
            return Processor.GetProgress();
        }
    }
}