using System.ComponentModel.DataAnnotations;

namespace BatchProcessor.API.Models
{
    public class GeneratorInput
    {
        public GeneratorInput(int YNumbers, int BatchSequence)
        {
            this.YNumbers = YNumbers;
            this.BatchSequence = BatchSequence;
        }
        
        [Range(1, 10)]
        public int YNumbers { get; set; }

        public int BatchSequence { get; set; }
    }
}