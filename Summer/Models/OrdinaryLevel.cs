namespace Summer.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("OrdinaryLevel")]
    public class OrdinaryLevel
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
        [Required]
        public string Subject_3 { get; set; }

        [Column(TypeName = "ntext")]
        [Required]
        public string Subject_4 { get; set; }

        [Column(TypeName = "ntext")]

        public string Subject_5 { get; set; }

        [Column(TypeName = "ntext")]

        public string Subject_6 { get; set; }

        [Column(TypeName = "ntext")]

        public string Subject_7 { get; set; }

        [Column(TypeName = "ntext")]

        public string Subject_8 { get; set; }

        [Column(TypeName = "ntext")]

        public string Subject_9 { get; set; }

        [Column(TypeName = "ntext")]

        public string Subject_10 { get; set; }

        [Column(TypeName = "ntext")]

        public string Subject_11 { get; set; }

        public virtual Student Student { get; set; }
    }
}
