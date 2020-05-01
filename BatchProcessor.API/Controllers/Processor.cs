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

        [Route("GetProgress")]
        public MemoryData GetProgress()
        {
            return Processor.GetProgress();
        }
    }
}