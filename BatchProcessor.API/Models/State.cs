using System.Runtime.Serialization;

namespace BatchProcessor.API.Models
{
    [DataContract(Name = "State")]
    public enum State
    {
        [EnumMember]
        Waiting,
        [EnumMember]
        Processing,
        [EnumMember]
        Finished,
        [EnumMember]
        Error
    }
}