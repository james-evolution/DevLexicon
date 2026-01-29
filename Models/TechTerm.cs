using System.ComponentModel.DataAnnotations;

namespace DevLexicon.Models
{
    // Represents a single technical term in the DevLexicon domain.
    // Persisted via EF Core in a local SQL database.
    public class TechTerm
    {
        // Primary key for the term.
        public int Id { get; set; }

        // Canonical name of the term. Required. Max length 100.
        [Required]
        [StringLength(100)]
        public string Name { get; set; } = null!;
        
        // Formal definition or explanation of the term. Required.
        [Required]
        public string Definition { get; set; } = null!;

        // Optional external URL to documentation or authoritative references.
        // Displayed as "Documentation Link" in views.
        [Display(Name = "Documentation Link")]
        public string? DocumentationLink { get; set; }

        // Optional category (e.g., Framework, Language, Tooling). Max length 50.
        // Used for display and search filtering.
        [StringLength(50)]
        public string? Category { get; set; }
    }
}
