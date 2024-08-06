namespace ClickMe.Application.DatabaseSettings
{
    public interface IClickActionDatabaseSettings
    {
        string ClickActionsCollectionName { get; set; }
        string DatabaseName { get; set; }
        string ConnectionString { get; set; }
    }
}
