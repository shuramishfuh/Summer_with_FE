namespace Summer.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Student")]
    public class Student
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Student()
        {
            Attendances = new HashSet<Attendance>();
            TestScores = new HashSet<TestScore>();
        }

        public int StudentId { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [Required]
        [StringLength(6)]
        public string Sex { get; set; }

        public byte Age { get; set; }

        [Required]
        [StringLength(300)]
        public string School { get; set; }


        [StringLength(150)]
        public string FutureCareerChoice { get; set; }

        [Required]
        [StringLength(10)]
        public string Tel { get; set; }

        [Column(TypeName = "date")]
        [DataType(dataType: DataType.Date)]
        public DateTime YearOfAttendance { get; set; }

        public virtual AdvanceLevel AdvanceLevel { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Attendance> Attendances { get; set; }

        public virtual OrdinaryLevel OrdinaryLevel { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TestScore> TestScores { get; set; }
    }
}
