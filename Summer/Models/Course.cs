namespace Summer.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Course")]
    public class Course
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Course()
        {
            TestScores = new HashSet<TestScore>();
        }

        public int Id { get; set; }

        [Required]
        [StringLength(200)]
        public string CourseName { get; set; }

        [Column(TypeName = "ntext")]
        [Required]
        public string CourseDescription { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TestScore> TestScores { get; set; }
    }
}
