using System.ComponentModel.DataAnnotations;

namespace WebApplication2.Models
{
    public class Category
    {
        [Key]   // means that Id is a primary key .
        public int Id { get; set; }
        [Required] // means that the name field is required .
        public string Name { get; set; }
        public string DisplayOrder { get; set; }
        public DateTime CreatedDateTime { get; set; } = DateTime.Now;
    }
}
