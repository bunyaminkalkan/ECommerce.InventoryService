using ECommerce.BuildingBlocks.Shared.Kernel.Exceptions;
using ECommerce.InventoryService.API.Data.Context;
using ECommerce.InventoryService.API.Domain.Entities;
using ECommerce.InventoryService.API.UseCases.Commands;
using ECommerce.InventoryService.API.UseCases.Queries;
using Microsoft.EntityFrameworkCore;
using Space.Abstraction.Attributes;
using Space.Abstraction.Context;

namespace ECommerce.InventoryService.API.UseCases.Handlers;

public class InventoryHandler(AppDbContext appDbContext)
{
    [Handle]
    public async Task<ProductStock> AdjustStockAsync(HandlerContext<AdjustStockCommand> ctx)
    {
        ctx.CancellationToken.ThrowIfCancellationRequested();
        var request = ctx.Request;

        var stock = await appDbContext.ProductStocks.FirstOrDefaultAsync(ps => ps.ProductId == request.ProductId)
            ?? throw new BadRequestException("Product stock not found");

        if (request.QuantityChange < 0)
            stock.Decrease(Math.Abs(request.QuantityChange));
        else
            stock.Increase(request.QuantityChange);

        await appDbContext.SaveChangesAsync();

        return stock;
    }

    [Handle]
    public async Task<ProductStock> GetProductStockAsync(HandlerContext<GetProductStockQuery> ctx)
    {
        ctx.CancellationToken.ThrowIfCancellationRequested();
        var request = ctx.Request;

        var stock = await appDbContext.ProductStocks.FirstOrDefaultAsync(ps => ps.ProductId == request.ProductId)
            ?? throw new BadRequestException("Product stock not found");

        return stock;
    }
}
