using ECommerce.InventoryService.API.Constants.Tables;
using ECommerce.InventoryService.API.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ECommerce.InventoryService.API.Data.Configurations;

public class ProductStockConfiguration : IEntityTypeConfiguration<ProductStock>
{
    public void Configure(EntityTypeBuilder<ProductStock> builder)
    {
        builder.ToTable(Tables.ProductStocks);

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .ValueGeneratedNever();

        builder.Property(x => x.ProductId)
            .IsRequired();

        builder.Property(x => x.Quantity)
            .IsRequired();

        builder.HasIndex(x => x.ProductId)
            .IsUnique();
    }
}
