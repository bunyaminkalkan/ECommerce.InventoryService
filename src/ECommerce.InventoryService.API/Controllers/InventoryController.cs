using ECommerce.InventoryService.API.UseCases.Commands;
using ECommerce.InventoryService.API.UseCases.Queries;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Space.Abstraction;

namespace ECommerce.InventoryService.API.Controllers;

[ApiController]
[Route("/[controller]")]
public class InventoryController(ISpace space) : ControllerBase
{
    [HttpGet("{productId:guid}")]
    public async Task<IActionResult> GetProductStockAsync([FromRoute] Guid productId)
    {
        var request = new GetProductStockQuery(productId);
        var response = await space.Send(request);
        return Ok(response);
    }

    [HttpPost("adjust-stock")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> AdjustStockAsync([FromBody] AdjustStockCommand request)
    {
        var response = await space.Send(request);
        return Ok(response);
    }
}
