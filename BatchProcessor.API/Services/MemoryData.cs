using System.Collections.Generic;
using System.Runtime.Serialization;
using BatchProcessor.API.Models;
using BatchProcessor.Data.Entities;

namespace BatchProcessor.API.Services
{
    [DataContract]
    internal class MemoryData
    {
        internal MemoryData()
        {
            Numbers = new List<Number>();
            State = State.Waiting;
        }
        [DataMember]
        internal List<Number> Numbers { get; set; }
        [DataMember]
        internal State State { get; set; }
        [DataMember]
        internal int RemainingNumbers { get; set; }
        [DataMember]
        internal int CurrentTotal { get; set; }
        [DataMember]
        internal long GrandTotal { get; set; }
    }
}