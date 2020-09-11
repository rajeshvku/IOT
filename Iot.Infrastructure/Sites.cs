using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Iot.Infrastructure
{
    public class Sites
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int CitiesId { get; set; }
        public string Name { get; set; }
        public Cities Cities { get; set; }
        public DateTime CreatedDate { get; set; }  = DateTime.Now;
    }
}
