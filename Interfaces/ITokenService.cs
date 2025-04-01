using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication6.Models;

namespace WebApplication6.Interfaces
{
    public interface ITokenService
    {
        string CreateToken(AppUser user);
    }
}
