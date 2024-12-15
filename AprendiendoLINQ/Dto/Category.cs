using System.ComponentModel.DataAnnotations.Schema;

namespace AprendiendoLINQ.Dto
{
    public class Category
    {
        [Column("categoryid")]
        public Guid Id { get; set; }

        [Column("categoryname")]
        public string Name { get; set; }

        [Column("description")]
        public string Description { get; set; }
    }
}
