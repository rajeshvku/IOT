using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Iot.Infrastructure
{
    public class Cities
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int RegionId { get; set; }
        public string Name { get; set; }
        public Region Region { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
    }
}
