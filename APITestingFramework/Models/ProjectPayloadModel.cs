namespace Models;

using System;
using System.Collections.Generic;

public record ProjectPayloadModel
{
    public int? Id { get; set; } = null;
    public string? Content { get; set; }
    public int? ItemsCount { get; set; } = null;
    public int? Icon { get; set; } = null;
    public int? ItemType { get; set; } = null;
    public int? ParentId { get; set; } = null;
    public bool? Collapsed { get; set; } = null;
    public int? ItemOrder { get; set; } = null;
    public List<ProjectPayloadModel>? Children { get; set; } = null;
    public bool? IsProjectShared { get; set; } = null;
    public string? ProjectShareOwnerName { get; set; } = null;
    public string? ProjectShareOwnerEmail { get; set; } = null;
    public bool? IsShareApproved { get; set; } = null;
    public bool? IsOwnProject { get; set; } = null;
    public DateTime? LastSyncedDateTime { get; set; } = null;
    public DateTime? LastUpdatedDate { get; set; } = null;
    public bool? Deleted { get; set; } = null;
    public int? SyncClientCreationId { get; set; } = null;

    public ProjectPayloadModel(
        int? id,
        string? content,
        int? itemsCount,
        int? icon,
        int? itemType,
        int? parentId,
        bool? collapsed,
        int? itemOrder,
        List<ProjectPayloadModel>? children,
        bool? isProjectShared,
        string? projectShareOwnerName,
        string? projectShareOwnerEmail,
        bool? isShareApproved,
        bool? isOwnProject,
        DateTime? lastSyncedDateTime,
        DateTime? lastUpdatedDate,
        bool? deleted,
        int? syncClientCreationId
    )
    {
        Content = content;
        ItemsCount = itemsCount;
        Icon = icon;
        ItemType = itemType;
        Id = id;
        ParentId = parentId;
        Collapsed = collapsed;
        ItemOrder = itemOrder;
        Children = children;
        IsProjectShared = isProjectShared;
        ProjectShareOwnerName = projectShareOwnerName;
        ProjectShareOwnerEmail = projectShareOwnerEmail;
        IsShareApproved = isShareApproved;
        IsOwnProject = isOwnProject;
        LastSyncedDateTime = lastSyncedDateTime;
        LastUpdatedDate = lastUpdatedDate;
        Deleted = deleted;
        SyncClientCreationId = syncClientCreationId;
    }
}
