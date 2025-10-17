namespace ECommerce.InventoryService.API.Domain.Entities;

public class ProductStock
{
    public Guid Id { get; private set; }
    public Guid ProductId { get; private set; }
    public int Quantity { get; private set; }

    public ProductStock(Guid productId, int quantity)
    {
        Id = Guid.CreateVersion7();
        ProductId = productId;
        Quantity = quantity;
    }

    public void Decrease(int amount)
    {
        if (Quantity < amount)
            throw new InvalidOperationException("Not enough stock available.");

        Quantity -= amount;
    }

    public void Increase(int amount)
    {
        Quantity += amount;
    }
}
