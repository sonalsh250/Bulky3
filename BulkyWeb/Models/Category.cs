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
        [DisplayName("Category Name")]
        public string Name { get; set; }
        [DisplayName("Display Order")]
        public int DisplayOrder { get; set; }

    }
}
