using Domein.Entities;
using Infrastructure.ApiResponses;

namespace Infrastructure.Interfaces;

public interface ITableService
{
    public Task<Response<List<Table>>> GetAllTablesAsync();
    public Task<Response<List<Table>>> GetFreeTables();
    public Task<Response<bool>> UpdateStatusTableToBookings(int tableId);
    public Task<Response<bool>> UpdateStatusTableToFree(int tableId);
    public Task<Response<bool>> ChangeStatusAndTableNumber(int id, string tableNumber, string isOccupied);
}