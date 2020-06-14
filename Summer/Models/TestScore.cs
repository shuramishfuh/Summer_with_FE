using System.ComponentModel.DataAnnotations;

namespace Summer.Models
{
    using System;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("TestScore")]
    public class TestScore
    {
        public int Id { get; set; }

        public int CourseId { get; set; }

        public int StudentId { get; set; }

        public double StudentScore { get; set; }

        [Column(TypeName = "ntext")]
        public string Comment { get; set; }

        [Column(TypeName = "date")]
        [DataType(DataType.Date)]
        public DateTime DateTime { get; set; }

        public virtual Course Course { get; set; }

        public virtual Student Student { get; set; }
    }
}
