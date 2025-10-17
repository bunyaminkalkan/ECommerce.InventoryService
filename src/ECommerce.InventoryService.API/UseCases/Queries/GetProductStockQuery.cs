using ECommerce.InventoryService.API.Domain.Entities;
using Space.Abstraction.Contracts;

namespace ECommerce.InventoryService.API.UseCases.Queries;

public record GetProductStockQuery(Guid ProductId) : IRequest<ProductStock>;
