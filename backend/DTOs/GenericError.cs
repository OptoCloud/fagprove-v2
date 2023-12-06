namespace backend.DTOs;

public struct GenericError
{
    public GenericError(string error)
    {
        Error = error;
    }

    public string Error { get; set; }
}
