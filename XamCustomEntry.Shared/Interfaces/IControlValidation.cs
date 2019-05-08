namespace XamCustomEntry.Shared
{
    public interface IControlValidation
    {
        bool HasError { get; }
        string ErrorMessage { get; }
        bool ShowErrorMessage { get; set; }
    }
}
