using Domein.Entities;
using Infrastructure.ApiResponses;

namespace Infrastructure.Interfaces;

public interface IItemService
{
    public Task<Response<List<MenuItem>>> GetAll();
    public Task<Response<bool>> Creat(MenuItem item);
    
}