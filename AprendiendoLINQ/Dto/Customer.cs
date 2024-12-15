using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AprendiendoLINQ.Dto
{
    [Table("Customers")]
    public class Customer
    {
        [Column("customerid"), Key]
        public string CustomerID { get; set; }
        [Column("companyname")]
        public string CompanyName { get; set; }
        [Column("contactname")]
        public string ContactName { get; set; }
        [Column("contacttitle")]
        public string? ContactTitle { get; set; }
        [Column("address")]
        public string? Address { get; set; }
        [Column("city")]
        public string? City { get; set; }
        [Column("country")]
        public string? Country { get; set; }
        [Column("phone")]
        public string? Phone { get; set; }
    }
}
