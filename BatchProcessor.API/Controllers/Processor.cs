using BatchProcessor.API.Workers;
using Microsoft.AspNetCore.Mvc;
using BatchProcessor.API.ViewModels;
using BatchProcessor.API.Models;

namespace BatchProcessor.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProcessorController : ControllerBase
    {
        public void Execute(int XBatches, int YNumbers)
        {
            Input input;
            try
            {
                input = new Input(XBatches, YNumbers);
                Processor.Start(input);
            }
            catch (System.Exception)
            {
                throw;
            }
        }

        [Route("GetProgress")]
        public BatchProgressViewModel GetProgress()
        {
            return Processor.GetProgress();
        }
    }
}