using System.ServiceModel;
using BatchProcessor.API.ViewModels;
using BatchProcessor.Data.Data.Entities;

namespace BatchProcessor.API.Services
{
    [ServiceContract]
    public interface IMemoryData
    {
        [OperationContract]
        public BatchProgressViewModel GetProgress();

        [OperationContract]
        public void AddNumber(Number number);
    }
}