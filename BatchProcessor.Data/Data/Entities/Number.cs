
using System.ComponentModel.DataAnnotations;

namespace BatchProcessor.Data.Data.Entities
{
    public class Number
    {
        [Key]
        public int Id { get; set; }

        [Range(1, 100), Required]
        public int Value { get; set; }
    }
}