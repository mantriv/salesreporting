using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SalesReporting.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.AspNetCore.Authorization;
using SalesReporting.ViewResource;

namespace Ryde.Api.Controllers
{
    [Authorize]
    [Route("api/v1/[controller]")]
    [ApiController]
    public class SalesController : ControllerBase
    {
        private readonly SalesDBContext _salesDBContext;
        public SalesController(SalesDBContext salesDBContext)
        {
            _salesDBContext = salesDBContext;
    }
        [HttpGet]
        [Route("{region}/{country}")]
        public IActionResult Get(string region, string country, int page, int limit, string itemType)
        {
            if (page <= 0)
            {
                page = 1;
            }

            if (limit <= 0)
            {
                limit = 10;
            }   

            var displayPage = page;

            page = (page - 1) * limit;
            var TotalRecs = _salesDBContext.SalesReportings.Where(x => x.Region == region && x.Country == country && x.ItemType == itemType);
            var result = _salesDBContext.SalesReportings.Where(x => x.Region == region && x.Country == country && x.ItemType == itemType).Skip(page).Take(limit);

            var searchResponse = new SearchResponseViewResouce()
            {
                Total = TotalRecs.Count(),
                Page = displayPage,
                Limit = limit,
                Data = result
            };

            return Ok(searchResponse);
        }
    }
}
