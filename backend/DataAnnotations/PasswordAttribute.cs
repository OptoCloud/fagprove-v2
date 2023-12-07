using System.ComponentModel.DataAnnotations;

namespace backend.DataAnnotations;

/// <summary>
/// Validates that a string is a valid password (cannot start/end with white space, must be between 5 and 64 characters long).
/// </summary>
[AttributeUsage(AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Parameter, AllowMultiple = false)]
public class PasswordAttribute : DataTypeAttribute
{
    public bool Required { get; set; } = true;

    public PasswordAttribute()
        : base(DataType.Text)
    {
    }

    public override bool IsValid(object? value)
    {
        if (value == null)
        {
            return !Required;
        }

        if (value is not string valueAsString)
        {
            return false;
        }

        // Check if password starts/ends with white space
        if (Char.IsWhiteSpace(valueAsString[0]) || Char.IsWhiteSpace(valueAsString[^1]))
        {
            return false;
        }

        // Check length
        if (valueAsString.Length is < 5 or > 64)
        {
            return false;
        }

        return true;
    }
}
