namespace ClickMeApi.Models
{
    public interface IClickAction
    {
        string Id { get; set; }
        DateTime UtcDateTime { get; set; }
        string Username { get; set; }
        string ActionName { get; set; }
    }
}
