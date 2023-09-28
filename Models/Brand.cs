using System.ComponentModel.DataAnnotations;

namespace SafeSkull.Models
{
    public class Brand
    {
        [Key]
        public int Id { get; set; }
        public string BrandName { get; set; }
        public int CategoryId { get; set; } // Foreign key to Category
        public int IsAvailable { get; set; }

        
    }
}
