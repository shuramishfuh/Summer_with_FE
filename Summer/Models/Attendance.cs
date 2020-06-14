namespace Summer.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Attendance")]
    public class Attendance
    {
        public int Id { get; set; }

        public int WeekNumber { get; set; }

        public int StudentId { get; set; }

     
        [Column(TypeName = "date")]
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }

        [DataType(DataType.Time)]
        public DateTime Time { get; set; }

        public virtual Student Student { get; set; }

        public virtual WeekNumber WeekNumbers { get; set; }
    }
}