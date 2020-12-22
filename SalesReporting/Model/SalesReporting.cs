using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace SalesReporting.Model
{
    [Table("SalesReporting")]
    [Index(nameof(Country), Name = "IX_SalesReporting_Country")]
    [Index(nameof(Region), Name = "IX_SalesReporting_Region")]
    [Index(nameof(Region), nameof(Country), Name = "IX_SalesReporting_Region_Country")]
    public partial class SalesReporting
    {
        [Key]
        public int Id { get; set; }
        [StringLength(50)]
        public string Region { get; set; }
        [StringLength(50)]
        public string Country { get; set; }
        [StringLength(100)]
        public string ItemType { get; set; }
        [StringLength(50)]
        public string SalesChannel { get; set; }
        [StringLength(50)]
        public string OrderPriority { get; set; }
        [StringLength(50)]
        public string OrderDate { get; set; }
        [Column("OrderID")]
        [StringLength(20)]
        public string OrderId { get; set; }
        [StringLength(50)]
        public string ShipDate { get; set; }
        public int? UnitsSold { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal? UnitPrice { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal? UnitCost { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal? TotalRevenue { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal? TotalCost { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal? TotalProfit { get; set; }
    }
}
