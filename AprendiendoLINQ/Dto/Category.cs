using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AprendiendoLINQ.Dto
{
    [Table("categories")]
    public class Category
    {
        [Column("categoryid")]
        public int Id { get; set; }

        [Column("categoryname"), MaxLength(50)]
        public string? Name { get; set; }

        [Column("description")]
        public string? Description { get; set; }
    }
}
