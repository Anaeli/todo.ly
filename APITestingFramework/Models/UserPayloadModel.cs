namespace Models;

public record UserPayloadModel
{
    public long? Id { get; set; } = null;
    public string? Email { get; set; }
    public string? Password { get; set; }
    public string? FullName { get; set; }
    public double? TimeZone { get; set; } = null;
    public bool? IsProUser { get; set; } = null;
    public long? DefaultProjectId { get; set; } = null;
    public bool? AddItemMoreExpanded { get; set; } = null;
    public bool? EditDueDateMoreExpanded { get; set; } = null;
    public int? ListSortType { get; set; } = null;
    public int? FirstDayOfWeek { get; set; } = null;
    public int? NewTaskDueDate { get; set; } = null;
    public string? TimeZoneId { get; set; } = null;

    public UserPayloadModel(
        string? Email,
        string? Password,
        string? FullName,
        long? Id,
        double? TimeZone,
        bool? IsProUser,
        long? DefaultProjectId,
        bool? AddItemMoreExpanded,
        bool? EditDueDateMoreExpanded,
        int? ListSortType,
        int? FirstDayOfWeek,
        int? NewTaskDueDate,
        string? TimeZoneId
    )
    {
        this.Id = Id;
        this.Email = Email;
        this.Password = Password;
        this.FullName = FullName;
        this.TimeZone = TimeZone;
        this.IsProUser = IsProUser;
        this.DefaultProjectId = DefaultProjectId;
        this.AddItemMoreExpanded = AddItemMoreExpanded;
        this.EditDueDateMoreExpanded = EditDueDateMoreExpanded;
        this.ListSortType = ListSortType;
        this.FirstDayOfWeek = FirstDayOfWeek;
        this.NewTaskDueDate = NewTaskDueDate;
        this.TimeZoneId = TimeZoneId;
    }
}
