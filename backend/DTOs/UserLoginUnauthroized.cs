namespace backend.DTOs;

public struct UserLoginUnauthroized
{
    public enum ReasonEnum
    {
        UserNotFound,
        HashMismatch
    }

    public UserLoginUnauthroized(ReasonEnum reason)
    {
        Reason = reason;
    }

    public ReasonEnum Reason { get; set; }
}
