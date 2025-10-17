using ECommerce.InventoryService.API.Constants.Tables;
using ECommerce.InventoryService.API.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ECommerce.InventoryService.API.Data.Configurations;

public class InboxMessageConfiguration : IEntityTypeConfiguration<InboxMessage>
{
    public void Configure(EntityTypeBuilder<InboxMessage> builder)
    {
        builder.ToTable(Tables.InboxMessages);

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .ValueGeneratedNever();

        builder.Property(x => x.EventType)
            .IsRequired()
            .HasMaxLength(200);

        builder.Property(x => x.Payload)
            .IsRequired();

        builder.Property(x => x.ReceivedAt)
            .IsRequired();

        builder.Property(x => x.Processed)
            .HasDefaultValue(false)
            .IsRequired();

        builder.HasIndex(x => new { x.Processed, x.ReceivedAt });
    }
}
