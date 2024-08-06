namespace ClickMeApi.Settings
{
    public class ClickActionDatabaseSettings : IClickActionDatabaseSettings
    {
        public string ClickActionsCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }

}
