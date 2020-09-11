using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Iot.Infrastructure
{
    public class Building
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int SitesId { get; set; }
        public string Name { get; set; }
        public string Area { get; set; }
        public string Temperature { get; set; }
        public Sites Sites { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
    }
}
