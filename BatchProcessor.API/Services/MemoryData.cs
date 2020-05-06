using System.Collections.Generic;
using System.Runtime.Serialization;
using BatchProcessor.API.Models;
using BatchProcessor.Data.Entities;

namespace BatchProcessor.API.Services
{
    [DataContract]
    public class MemoryData
    {
        public MemoryData()
        {
            Numbers = new List<Number>();
            State = State.Waiting;
        }
        [DataMember]
        public List<Number> Numbers { get; set; }
        [DataMember]
        public State State { get; set; }
        [DataMember]
        public int RemainingNumbers { get; set; }
        [DataMember]
        public int CurrentTotal { get; set; }
        [DataMember]
        public long GrandTotal { get; set; }
    }
}