using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalesReporting.ViewResource
{
    public class SearchResponseViewResouce
    {
        public SearchResponseViewResouce()
        {
        }
        public long Total { get; set; }
        public int Page { get; set; }
        public int Limit { get; set; }
        public IQueryable<SalesReporting.Model.SalesReporting> Data { get; set; }
    }
}
