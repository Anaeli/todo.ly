namespace Models;

public class UserPayloadModel
{
    public int? Id { get; }
    string? Email;
    string? Password;

    string? FullName;
    int? TimeZone;

    bool? IsProUser;

    int? DefaultProjectId;

    bool? AddItemMoreExpanded;

    bool? EditDueDateMoreExpanded;

    int? ListSortType;
    int? FirstDayOfWeek;

    int? NewTaskDueDate;

    string? TimeZoneId;
}
