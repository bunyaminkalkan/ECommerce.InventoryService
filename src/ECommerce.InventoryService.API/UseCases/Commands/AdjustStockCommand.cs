using ECommerce.InventoryService.API.Domain.Entities;
using Space.Abstraction.Contracts;

namespace ECommerce.InventoryService.API.UseCases.Commands;

public record AdjustStockCommand(Guid ProductId, int QuantityChange) : IRequest<ProductStock>;