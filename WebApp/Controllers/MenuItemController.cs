using Domein.Entities;
using Infrastructure.ApiResponses;
using Infrastructure.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers;
[ApiController]
[Route("[controller]")]
public class MenuItemController(IItemService service): ControllerBase
{
    [HttpGet]
    public async Task<Response<List<MenuItem>>> GetMenuItems()
    {
        return await service.GetAll();
    }

    [HttpPost]
    public async Task<Response<bool>> AddMenuItem(MenuItem menuItem)
    {
        return await service.Creat(menuItem);
    }
}