using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AprendiendoLINQ.Dto
{
    [Table("orders")]
    public class Order
    {
        [Column("orderid"), Key]
        public int OrderID { get; set; }
        
        [Column("customerid"), ForeignKey("customerid")]

        public string CustomerID { get; set; }
        [Column("orderdate")]

        public DateTime? OrderDate { get; set; }
        [Column("shipname")]

        public string? ShipName { get; set; }
        [Column("shipaddress")]

        public string? ShipAddress { get; set; }
        [Column("shipcity")]

        public string? ShipCity { get; set; }
        [Column("shipcountry")]

        public string? ShipCountry { get; set; }

    }
}
