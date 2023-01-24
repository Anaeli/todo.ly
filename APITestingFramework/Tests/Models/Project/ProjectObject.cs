namespace Models;
using System.Collections.Generic;
using System.Text.Json.Serialization;
public record ProjectObject
{
    public long? Id { get; set; } = null;
    public string Content { get; set; }
    public int ItemsCount { get; set; } 
    public int? Icon { get; set; } = null;
    public int ItemType { get; set; } 
    public long? ParentId { get; set; } = null;
    public bool? Collapsed { get; set; } = null;
    public int? ItemOrder { get; set; } = null;
    public List<ProjectObject>? Children { get; set; } = new List<ProjectObject>();
    public bool? IsProjectShared { get; set; } = null;
    public string? ProjectShareOwnerName { get; set; } = null;
    public string? ProjectShareOwnerEmail { get; set; } = null;
    public bool? IsShareApproved { get; set; } = null;
    public bool? IsOwnProject { get; set; } = null;
    public string? LastSyncedDateTime { get; set; } = null;
    public string? LastUpdatedDate { get; set; } = null;
    public bool? Deleted { get; set; } = null;
    public long? SyncClientCreationId { get; set; } = null;

public ProjectObject(
    long Id,
    string Content,
    int ItemsCount,
    int? Icon,
    int ItemType,
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
)
    {
        this.Id = Id;
        this.Content = Content;
        this.ItemsCount = ItemsCount;
        this.Icon = Icon;
        this.ItemType = ItemType;
        this.ParentId = ParentId;
        this.Collapsed = Collapsed;
        this.ItemOrder = ItemOrder;
        this.Children = Children;
        this.IsProjectShared = IsProjectShare;
        this.ProjectShareOwnerName = ProjectShareOwnerName;
        this.ProjectShareOwnerEmail = ProjectShareOwnerEmail;
        this.IsShareApproved = IsShareApproved;
        this.IsOwnProject = IsOwnProject;
        this.LastSyncedDateTime = LastSyncedDateTime;
        this.LastUpdatedDate = LastUpdatedDate;
        this.Deleted = Deleted;
        this.SyncClientCreationId = SyncClientCreationId;
    }
}
