using System.ComponentModel.DataAnnotations;

namespace SPU911.Models
{
    public enum ProductTypes
    {
        Laptops = 0,
        
        [Display(Name = "Smart phones")]
        SmartPhones,
        Cameras,
        Accesories,
        
        [Display(Name = "Other")]
        Random
    }
}
