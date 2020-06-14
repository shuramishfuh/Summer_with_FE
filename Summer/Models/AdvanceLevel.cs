namespace Summer.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("AdvanceLevel")]
    public class AdvanceLevel
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        [Column(TypeName = "ntext")]
        [Required]
        public string Subject_1 { get; set; }

        [Column(TypeName = "ntext")]
        [Required]
        public string Subject_2 { get; set; }

        [Column(TypeName = "ntext")]

        public string Subject_3 { get; set; }

        [Column(TypeName = "ntext")]

        public string Subject_4 { get; set; }

        [Column(TypeName = "ntext")]

        public string Subject_5 { get; set; }



        public virtual Student Student { get; set; }
    }
}
