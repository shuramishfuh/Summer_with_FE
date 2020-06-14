

namespace Summer.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations.Schema;


    [Table("WeekNumber")]
    public class WeekNumber
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public WeekNumber()
        {
            Attendances = new HashSet<Attendance>();
        }

        public int Id { get; set; }

        public int Number { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Attendance> Attendances { get; set; }
    }
}