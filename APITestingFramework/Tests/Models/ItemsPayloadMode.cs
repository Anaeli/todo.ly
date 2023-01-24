namespace Models;

using System;
using System.Collections.Generic;

public record ItemsPayloadModel
{
    public long? Id { get; set; }
    public string? Content { get; set; }
    public long? ItemType { get; set; }
    public bool? Checked { get; set; }
    public long? ProjectId { get; set; }
    public object? ParentId { get; set; }
    public string? Path { get; set; }
    public bool? Collapsed { get; set; }
    public object? DateString { get; set; }
    public long? DateStringPriority { get; set; }
    public string? DueDate { get; set; }
    public object? Recurrence { get; set; }
    public long? ItemOrder { get; set; }
    public long? Priority { get; set; }
    public DateTime? LastSyncedDateTime { get; set; }
    public List<ItemsPayloadModel>? Children { get; set; }
    public DateTime? DueDateTime { get; set; }
    public DateTime? CreatedDate { get; set; }
    public DateTime? LastCheckedDate { get; set; }
    public DateTime? LastUpdatedDate { get; set; }
    public bool? Deleted { get; set; }
    public string? Notes { get; set; }
    public bool? InHistory { get; set; }
    public object? SyncClientCreationId { get; set; }
    public DateTime? DueTimeSpecified { get; set; }
    public long? OwnerId { get; set; }

    public ItemsPayloadModel(
        long? id,
        string? content,
        long? itemType,
        bool? checkeds,
        long? projectId,
        object? parentId,
        string? path,
        bool? collapsed,
        object? dateString,
        long? dateStringPriority,
        string? dueDate,
        object? recurrence,
        long? itemOrder,
        long? priority,
        DateTime? lastSyncedDateTime,
        List<ItemsPayloadModel>? children,
        DateTime? dueDateTime,
        DateTime? createdDate,
        DateTime? lastCheckedDate,
        DateTime? lastUpdatedDate,
        bool? deleted,
        string? notes,
        bool? inHistory,
        object? syncClientCreationId,
        DateTime? dueTimeSpecified,
        long? ownerId
    )
    {
        Id = id;
        Content = content;
        ItemType = itemType;
        Checked = checkeds;
        ProjectId = projectId;
        ParentId = parentId;
        Path = path;
        Collapsed = collapsed;
        DateString = dateString;
        DateStringPriority = dateStringPriority;
        DueDate = dueDate;
        Recurrence = recurrence;
        ItemOrder = itemOrder;
        Priority = priority;
        LastSyncedDateTime = lastSyncedDateTime;
        Children = children;
        DueDateTime = dueDateTime;
        CreatedDate = createdDate;
        LastCheckedDate = lastCheckedDate;
        LastUpdatedDate = lastUpdatedDate;
        Deleted = deleted;
        Notes = notes;
        InHistory = inHistory;
        SyncClientCreationId = syncClientCreationId;
        DueTimeSpecified = dueTimeSpecified;
        OwnerId = ownerId;
    }
}
