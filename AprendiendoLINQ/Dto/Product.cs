using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AprendiendoLINQ.Dto
{
    [Table("products")]
    public class Product
    {
        [Key, Column("productid"), Required]
        public int ProductID { get; set; }

        [Column("productname"), MaxLength(50), Required]
        public string ProductName { get; set; }

        [Column("supplierid")]
        public int? SupplierID { get; set; }

        [Column("categoryid")]
        public int? CategoryID { get; set; }

        [Column("quantityperunit"), MaxLength(20)]
        public string? QuantityPerUnit { get; set; }
        
        [Column("unitprice"), MaxLength(10)]
        public decimal? UnitPrice { get; set; }

        [Column("unitsinstock")]
        public int? UnitsInStock { get; set; }

        [Column("unitsonorder")]
        public int? UnitsOnOrder { get; set; }

        [Column("reorderlevel")]
        public int? ReorderLevel { get; set; }

        [Column("discontinued")]
        public bool? Discontinued { get; set; } = false;
    }
}
