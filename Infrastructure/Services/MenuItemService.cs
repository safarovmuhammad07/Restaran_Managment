using System.Net;
using Dapper;
using Domein.Entities;
using Infrastructure.ApiResponses;
using Infrastructure.DataContext;
using Infrastructure.Interfaces;

namespace Infrastructure.Services;

public class MenuItemService(Context context) : IItemService
{
    public async Task<Response<List<MenuItem>>> GetAll()
    {
        const string sql = @"select * from MenuItems";
        var res = await context.Connection().QueryAsync<MenuItem>(sql);
        return new Response<List<MenuItem>>(res.ToList());
    }

    public async Task<Response<bool>> Creat(MenuItem item)
    {
        const string sql = @"insert into MenuItems(Name, Price, Category) values (@Name, @Price, @Category)";
        var res = await context.Connection().ExecuteAsync(sql, item);
        return res == 0   ? new Response<bool>(HttpStatusCode.InternalServerError, "Internal Server Error")   : new Response<bool>(HttpStatusCode.Created, "Created"); 
    }
}