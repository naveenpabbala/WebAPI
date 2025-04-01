using WebApplication6.Interfaces;
using WebApplication6.Models;
using Microsoft.EntityFrameworkCore;
using WebApplication6.Dtos.Stock;
using WebApplication6.data;
using WebApplication6.Helpers;

namespace WebApplication6.Repository
{
    public class StockRepository : IStockRepository
    {
        private readonly ApplicationDBContext _context;
        public StockRepository(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task<Stock> CreateAsync(Stock stockModel)
        {
            await _context.Stocks.AddAsync(stockModel);
            await _context.SaveChangesAsync();
            return stockModel;
        }

        public async Task<Stock?> DeleteAsync(int id)
        {
            var stockmodel = await _context.Stocks.FirstOrDefaultAsync(x => x.Id == id);

            if(stockmodel == null)
            {
                return null;
            }

            _context.Stocks.Remove(stockmodel);
            await _context.SaveChangesAsync();
            return stockmodel;
        }

        public async Task<List<Stock>> GetAllAsync(QueryObject query)
        {
            var stocks = _context.Stocks.Include(c => c.Comments).ThenInclude(a => a.AppUser).AsQueryable(); 

            if(!string.IsNullOrWhiteSpace(query.CompanyName))
            {
                stocks = stocks.Where(s => s.CompanyName.Contains(query.CompanyName));
            }

            if(!string.IsNullOrWhiteSpace(query.Symbol))
            {
                stocks = stocks.Where(s => s.Symbol.Contains(query.Symbol));
            }


            if(!string.IsNullOrWhiteSpace(query.SortBy))
            {
                if(query.SortBy.Equals("Symbol",StringComparison.OrdinalIgnoreCase))
                {
                    stocks = query.IsDecsending ? stocks.OrderByDescending(s => s.Symbol) : stocks.OrderBy(s => s.Symbol);
                }

            }

            var skipNumber = (query.PageNumber - 1) * query.PageSize;

            return await stocks.Skip(skipNumber).Take(query.PageSize).ToListAsync();
        }

        
        public async Task<Stock?> GetByIdAsync(int id)
        {
            return await _context.Stocks.Include(c => c.Comments).FirstOrDefaultAsync(i => i.Id ==id); 
        }

        public async Task<Stock?> GetBySymbolAsync(string symbol)
        {
            return await _context.Stocks.FirstOrDefaultAsync(s => s.Symbol == symbol);
        }

        public Task<bool> StockExists(int id)
        {
            return _context.Stocks.AnyAsync(s => s.Id == id);
        }

        public async Task<Stock?> UpdateAsync(int id, UpdateStockDtoRequest StockDto)
        {
            var existingStock = await _context.Stocks.FirstOrDefaultAsync(x => x.Id == id);
            if (existingStock ==null)
            {
                return null;
            }

            existingStock.Symbol = StockDto.Symbol;
            existingStock.CompanyName = StockDto.CompanyName;
            existingStock.Purchase = StockDto.Purchase;
            existingStock.LastDiv = StockDto.LastDiv;
            existingStock.Industry = StockDto.Industry;
            existingStock.MarketCap = StockDto.MarketCap;
                
            await _context.SaveChangesAsync();
            return existingStock;
        }
    }
}
