using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AprendiendoLINQ.Dto
{
    [Table("orderdetails")]
    public class OrderDetails
    {
        [Column("orderdetailid"), Key]
        public int OrderDetailId { get; set; }

        [Column("orderid"), ForeignKey("orderid")]
        public int OrderId { get; set; }

        [Column("productid"), ForeignKey("productid")]
        public int ProductId { get; set; }
        
        [Column("unitprice")]
        public double UnitPrice { get; set; }

        [Column("quantity")]
        public int Quantity { get; set; }

        [Column("discount")]
        public double?  Discount { get; set; }
    }
}
