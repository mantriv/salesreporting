using SalesReporting.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalesReporting.Security
{
    public interface IJwtTokenGenerator
    {
        string CreateToken(User User);
    }
}
