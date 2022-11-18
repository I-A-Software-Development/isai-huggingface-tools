using SixLabors.ImageSharp;

namespace Entities.DTOs
{
    public class GeneratedImageDto
    {
        public Image? Img { get; set; }   
        public string? ErrorMessage { get; set; }
        public bool IsFailed { get; set; }
    }
}