namespace Models;

public record ErrorResponseModel
{
    public string ErrorMessage { get; set; }
    public int ErrorCode { get; set; }

    public ErrorResponseModel(string ErrorMessage, int ErrorCode)
    {
        this.ErrorMessage = ErrorMessage;
        this.ErrorCode = ErrorCode;
    }
}
