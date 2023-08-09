using System.ComponentModel.DataAnnotations;

namespace AppModel
{
    public class Category
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
        public int Price { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
    }
}