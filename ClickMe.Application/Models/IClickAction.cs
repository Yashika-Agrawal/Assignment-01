namespace ClickMe.Application.Models // Ensure this matches the namespace in your project structure
{
    public interface IClickAction
    {
        string Id { get; set; }
        DateTime UtcDateTime { get; set; }
        string Username { get; set; }
        string ActionName { get; set; }
    }
}
