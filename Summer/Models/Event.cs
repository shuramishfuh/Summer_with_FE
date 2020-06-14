using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Summer.Models
{
    public class Event
    {
        public short EventId { get; set; }
        public string EventName { get; set; }
        public string Description { get; set; }
        [Column(TypeName = "date")]
        [DataType(DataType.Date)]
        public DateTime EventDate { get; set; }
    }
}