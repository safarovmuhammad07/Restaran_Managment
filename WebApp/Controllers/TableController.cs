using Domein.Entities;
using Infrastructure.ApiResponses;
using Infrastructure.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers;

[ApiController]
[Route("[controller]")]
public class TableController(ITableService service):ControllerBase
{
    [HttpGet]
    public async Task<Response<List<Table>>> GetTables()
    {
        return await service.GetAllTablesAsync();
    }

    [HttpPut]
    public async Task<Response<bool>> TableToBookings(int tableId)
    {
        return await service.UpdateStatusTableToBookings(tableId);
    }

    [HttpPut("UpdateTableToFree")]
    public async Task<Response<bool>> TableToFree(int tableId)
    {
        return await service.UpdateStatusTableToFree(tableId);
    }

    [HttpGet("GetFreeTables")]
    public async Task<Response<List<Table>>> GetFreeTables()
    {
        return await service.GetFreeTables();
    }

    [HttpPut("ChangeStatusAndTableNumber")]
    public async Task<Response<bool>> ChangeStatusAndTableNumber(int id, string tableNumber, string isOccupied)
    {
        return await service.ChangeStatusAndTableNumber(id, tableNumber, isOccupied);
    }
}