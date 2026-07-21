using api.DTOs.Stock;
using api.Models;

namespace api.Interfaces;

public interface IStockRepository
{
    Task<List<Stock>> GetAllAsync();
    Task<Stock?> GetOneAsync(string id);
    Task<Stock> CreateAsync(Stock stockModel);
    Task<Stock?> UpdateAsync(string id, UpdateStockRequestDto updateDto);
    Task<Stock?> DeleteAsync(string id);
    Task<bool> StockExists(string id);
}
