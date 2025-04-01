using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication6.Models;

namespace WebApplication6.Interfaces
{
    public interface IPortfolioRepository
    {
        Task <List<Stock>> GetUserPortfolio(AppUser user);
        Task<Portfolio> CreateAsync(Portfolio portfolio);
        Task<Portfolio> deletePortfolio(AppUser appuser, string symbol);
    }
}
