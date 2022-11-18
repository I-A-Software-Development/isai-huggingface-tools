using System.ComponentModel.DataAnnotations;

namespace Entities.Models
{
    public class TextDescription
    { 
        [Required(ErrorMessage = "Text is required")] 
        [StringLength(100, ErrorMessage = "Text cannot be loner then 100 characters")] 
        public string Text { get; set; } = string.Empty;
    }
}