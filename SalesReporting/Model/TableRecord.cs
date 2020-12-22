using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace SalesReporting.Model
{
    public partial class TableRecord
    {
        [Key]
        public int Id { get; set; }
        public long RecCount { get; set; }
    }
}
