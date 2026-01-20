namespace WarehouseManagementSystem.Task4_BusinessAndSecurity.Validation;

public class ValidationResult
{
    public bool IsValid => Errors.Count == 0;
    public List<string> Errors { get; }

    public ValidationResult()
    {
        Errors = new List<string>();
    }
    public static ValidationResult Success() => new();

    public static ValidationResult Failure(string[] error)
    {
        var result = new ValidationResult();
        result.Errors.AddRange(error);
        return result;
    }
}