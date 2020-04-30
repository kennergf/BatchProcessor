using System.Collections.Generic;
using BatchProcessor.API.Workers;
using Microsoft.AspNetCore.Mvc;
using BatchProcessor.Data.Data.Entities;
using BatchProcessor.API.ViewModels;
using BatchProcessor.API.Services;
using System.Threading;
using BatchProcessor.API.Models;

namespace BatchProcessor.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProcessorController : ControllerBase
    {
        public void Execute(int XBatches, int YNumbers)
        {
            var input = new Input(XBatches, YNumbers);
            Processor.Start(input);
        }

        [Route("GetProgress")]
        public BatchProgressViewModel GetProgress()
        {
            return Processor.GetProgress();
        }
    }
}