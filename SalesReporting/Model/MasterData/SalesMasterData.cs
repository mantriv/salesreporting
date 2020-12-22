using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalesReporting.Model.MasterData
{
    public class SalesMasterData
    {
        public virtual DbSet<SalesReporting> SalesReportings { get; set; }
        public int Count { get; set; }
    }
}
