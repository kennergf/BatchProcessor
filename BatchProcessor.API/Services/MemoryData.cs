using System.Collections.Generic;
using System.Runtime.Serialization;
using BatchProcessor.API.Models;
using BatchProcessor.Data.Data.Entities;

namespace BatchProcessor.API.ViewModels
{
    [DataContract]
    public class MemoryData
    {
        [DataMember]
        public List<Number> Numbers { get; set; }
        [DataMember]
        public int Progress { get; set; }
        [DataMember]
        public State State { get; set; }
    }
}