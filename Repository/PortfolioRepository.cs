using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication6.data;
using WebApplication6.Interfaces;
using WebApplication6.Models;
using Microsoft.EntityFrameworkCore;

namespace WebApplication6.Repository
{
    public class PortfolioRepository : IPortfolioRepository
    {
        private readonly ApplicationDBContext  _context; 
        public PortfolioRepository(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task<Portfolio> CreateAsync(Portfolio portfolio)
        {
            await _context.Portfolios.AddAsync(portfolio);
            await _context.SaveChangesAsync();
            return portfolio;
        }

        public async Task<Portfolio> deletePortfolio(AppUser appuser, string symbol)
        {
            var portfolioModel = await _context.Portfolios.FirstOrDefaultAsync(x => x.AppUserId == appuser.Id && x.Stock.Symbol.ToLower() == symbol.ToLower());

            if (portfolioModel == null)
            {
                return null;
            }

            _context.Portfolios.Remove(portfolioModel);
            await _context.SaveChangesAsync();
            return portfolioModel;
        }

        public async Task<List<Stock>> GetUserPortfolio(AppUser user)
        {
            return await _context.Portfolios.Where(u => u.AppUserId == user.Id)
               .Select(stock => new Stock
               {
                   Id = stock.StockId,
                   Symbol = stock.Stock.Symbol,
                   CompanyName = stock.Stock.CompanyName,
                   Purchase = stock.Stock.Purchase,
                   LastDiv = stock.Stock.LastDiv,
                   Industry = stock.Stock.Industry,
                   MarketCap = stock.Stock.MarketCap
               }).ToListAsync();
        }
    }
}
