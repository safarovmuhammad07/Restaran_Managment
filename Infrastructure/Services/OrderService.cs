using System.Net;
using Dapper;
using Domein.Entities;
using Infrastructure.ApiResponses;
using Infrastructure.DataContext;
using Infrastructure.Interfaces;

namespace Infrastructure.Services;

public class OrderService(Context context) : IOrderService
{
    public async Task<Response<List<Order>>> GetAll()
    {
        const string sql = @"select * from Orders";
        var orders = await context.Connection().QueryAsync<Order>(sql);
        return new Response<List<Order>>(orders.ToList());
    }


    public async Task<Response<List<Order>>> GetOrdersByCustomer(int id)
    {
        const string sql = @"select * from Orders where CustomerId = @id";
        var orders = await context.Connection().QueryAsync<Order>(sql, new { id });
        return new Response<List<Order>>(orders.ToList());
    }
    
    public async Task<Response<bool>> Create(Order order)
    {
        const string sql = @"insert into Order(CustomerId, TableId, Status) values (@CustomerId, @TableId, @Status) returns OrderId";
        var res = await context.Connection().ExecuteAsync(sql , order);
        return res==0 ? new Response<bool>(HttpStatusCode.InternalServerError, "Internal Server Error") : new Response<bool>(HttpStatusCode.Created, "Order successfully created");
        
    }

    public async Task<Response<bool>> UpdateStatusOrder(int orderId, string status)
    {
        const string sqlOrder = @"update Orders set Status = @status where OrderId = @orderId";
        var resOrder = await context.Connection().ExecuteScalarAsync<int>(sqlOrder, new{orderId, status});
        return resOrder==0 ? new Response<bool>(HttpStatusCode.InternalServerError, "Internal Server Error") : new Response<bool>(HttpStatusCode.OK, "Status updated");
    }
}