
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BatchProcessor.Data.Data.Entities
{
    public class BatchGroup
    {
        [Key]
        public int Id { get; set; }

        public List<Batch> Batches { get; set; }
    }
}