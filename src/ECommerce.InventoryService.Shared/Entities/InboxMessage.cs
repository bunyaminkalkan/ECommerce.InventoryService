namespace ECommerce.InventoryService.API.Domain.Entities;

public class InboxMessage
{
    public Guid Id { get; private set; }
    public string EventType { get; private set; } = default!;
    public string Payload { get; private set; } = default!;
    public DateTime ReceivedAt { get; private set; }
    public bool Processed { get; private set; }

    public InboxMessage(string eventType, string payload)
    {
        Id = Guid.CreateVersion7();
        EventType = eventType;
        Payload = payload;
        ReceivedAt = DateTime.UtcNow;
        Processed = false;
    }

    public void MarkAsProcessed() => Processed = true;
}
