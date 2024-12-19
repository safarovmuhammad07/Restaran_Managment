using Domein.Entities;
using Infrastructure.ApiResponses;

namespace Infrastructure.Interfaces;

public interface IOrderService
{
    public Task<Response<List<Order>>> GetAll();
    public Task<Response<List<Order>>> GetOrdersByCustomer(int customerId);
    public Task<Response<bool>> Create(Order order);
    public Task<Response<bool>> UpdateStatusOrder(int orderId, string status);
    
}