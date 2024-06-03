using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BulkyWeb.Models
{
    public class Category
    {
        //Id or ModelNameId (CategoryId) makes this value a primary key by default
        //[Key] //makes Id the primary key
        [Key]
        public int Id { get; set; } //primary key of the table

        [Required]  //makes Name not nullable
        [MaxLength(30)]
        [DisplayName("Category Name")]
        public string Name { get; set; }
        [DisplayName("Display Order")]
        [Range(1,100,ErrorMessage = "Display Order must be between 1-100.")]
        public int DisplayOrder { get; set; }

    }
}
