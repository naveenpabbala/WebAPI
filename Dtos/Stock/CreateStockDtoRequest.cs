using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations.Schema;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace WebApplication6.Dtos.Stock
{
    public class CreateStockDtoRequest
    {
        [Required]
        [MinLength(10, ErrorMessage = "Symbol connot be over 10 characters")]
        public string Symbol { get; set; } = string.Empty;
        [Required]
        [MinLength(10, ErrorMessage = "CompanyName connot be over 10 characters")]
        public string CompanyName { get; set; } = string.Empty;
        [Required]
        [Range(1,1000000000)]
        public decimal Purchase { get; set; }
        [Required]
        [Range(0.001,100)]
        public decimal LastDiv { get; set; }
        [Required]
        [MaxLength(10,ErrorMessage ="Industry cannot be over 10 characters")]
        public string Industry { get; set; } = string.Empty;
        [Range(1,5000000000)]
        public long MarketCap { get; set; }
    }
}

