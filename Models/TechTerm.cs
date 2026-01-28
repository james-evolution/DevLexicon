using System.ComponentModel.DataAnnotations;

namespace DevLexicon.Models
{
    public class TechTerm
    {
        public int Id { get; set; }
        [Required]
        [StringLength(100)]
        public string Name { get; set; } = null!;
        [Required]
        public string Definition { get; set; } = null!;

        [Display(Name = "Documentation Link")]
        public string? DocumentationLink { get; set; }

        [StringLength(50)]
        public string? Category { get; set; }
    }
}
