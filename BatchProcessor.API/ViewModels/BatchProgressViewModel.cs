using System.Collections.Generic;
using System.Runtime.Serialization;
using BatchProcessor.Data.Data.Entities;

namespace BatchProcessor.API.ViewModels
{
    [DataContract]
    public class BatchProgressViewModel
    {
        [DataMember]
        public List<Number> Numbers { get; set; }
        [DataMember]
        public int Progress { get; set; }
    }
}