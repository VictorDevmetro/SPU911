namespace SPU911.Models
{
    public class HomeIndexImageModel
    {
        public string ImageUrl { get; set; }
        public string ImageAltText { get; set; }
        public int H { get; set; }
        public int W { get; set; }
        public decimal KByte { get; set; }

        public override string ToString()
        {
            return ImageAltText;
        }
    }
}
