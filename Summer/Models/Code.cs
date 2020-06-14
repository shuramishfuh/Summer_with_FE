using System.ComponentModel.DataAnnotations;

namespace Summer.Models
{
    public class Code
    {
        public int Id { get; set; }
        [Required]
        public string type { get; set; }
        [Required]
        public string code { get; set; }
    }
}