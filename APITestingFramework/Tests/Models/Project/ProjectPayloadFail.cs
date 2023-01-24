namespace Models;
using System.Collections.Generic;
using System.Text.Json.Serialization;

    public record ProjectRecord(
    long? Id,
    string Content,
    int? ItemsCount,
    int? Icon,
    int? ItemType,
    long? ParentId,
    bool? Collapsed,
    int? ItemOrder,
    List<ProjectObject>? Children,
    bool? IsProjectShare,
    string? ProjectShareOwnerName,
    string? ProjectShareOwnerEmail,
    bool? IsShareApproved,
    bool? IsOwnProject,
    string? LastSyncedDateTime,
    string? LastUpdatedDate,
    bool? Deleted,
    long? SyncClientCreationId
);

