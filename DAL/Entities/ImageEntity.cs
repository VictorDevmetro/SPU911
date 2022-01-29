using System.ComponentModel.DataAnnotations;

namespace SPU911.DAL.Entities
{
    public class ImageEntity
    {
        [Key]
        public int Id { get; set; }
        public string ImageUrl { get; set; }
    }
}
