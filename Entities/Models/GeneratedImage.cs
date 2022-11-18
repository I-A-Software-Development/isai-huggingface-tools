using SixLabors.ImageSharp;

namespace Entities.Models
{
    public class GeneratedImage
    {
        public Image? Img { get; set; }   

        public void test()
        {
            Img.Save("test.png");
        }
    }
}