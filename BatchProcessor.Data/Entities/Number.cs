using System.ComponentModel.DataAnnotations;

namespace BatchProcessor.Data.Entities
{
    public class Number
    {
        public Number(long execution, int batchSequence, int value)
        {
            Execution = execution;
            BatchSequence = batchSequence;
            Value = value;
        }

        public Number(long execution, int batchSequence, int value, int total)
        {
            Execution = execution;
            BatchSequence = batchSequence;
            Value = value;
            Total = total;
        }

        [Key]
        public int Id { get; set; }

        [Required]
        public long Execution { get; set; }

        [Required, MaxLength(10)]
        public int BatchSequence { get; set; }

        [Range(1, 100), Required]
        public int Value { get; set; }

        public int Total { get; set; }
    }
}