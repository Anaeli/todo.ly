namespace Models;
using System.Collections.Generic;
using System.Text.Json.Serialization;
public record ProjectPayloadFail
{
    public string ErrorMessage { get; set; }
    public int ErrorCode { get; set; }

    public ProjectPayloadFail(string errorMessage, int errorCode)
    {
        ErrorMessage = errorMessage;
        ErrorCode = errorCode;
    }
}
