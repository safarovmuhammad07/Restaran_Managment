using Domein.Entities;
using Infrastructure.ApiResponses;
using Infrastructure.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers;

[ApiController]
[Route("[controller]")]
public class OrederController(IOrderService service):ControllerBase
{
    [HttpPost]
    public async Task<Response<bool>> Create(Order order)
    {
        return await service.Create(order);
    }

    [HttpGet]
    public async Task<Response<List<Order>>> GetOreders()
    {
        return await service.GetAll();
    }

    [HttpGet("Changing")]
    public async Task<Response<bool>> ChengeStatus(int id,string status)
    {
        return await service.UpdateStatusOrder(id,status);
    }

    [HttpGet("Customers")]
    public async Task<Response<List<Order>>> GetCustomerOrders(int id)
    {
        return await service.GetOrdersByCustomer(id);
    }
}