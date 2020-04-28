
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BatchProcessor.Data.Data.Entities
{
    public class Batch
    {
        [Key]
        public int Id { get; set; }

        public List<Number> Numbers { get; set; }
    }
}