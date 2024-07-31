using MongoDB.Driver;
using ClickMeApi.Models;
using ClickMeApi.Settings;
using MongoDB.Bson;

namespace ClickMeApi.Services
{
    public class ClickActionService
    {
        private readonly IMongoCollection<ClickAction> _clickActions;

        public ClickActionService(IClickActionDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);
            _clickActions = database.GetCollection<ClickAction>(settings.ClickActionsCollectionName);
        }

        public List<ClickAction> Get() =>
            _clickActions.Find(action => true).ToList();

        public ClickAction Get(string id) =>
            _clickActions.Find<ClickAction>(action => action.Id == id).FirstOrDefault();

        public ClickAction Create(ClickAction action)
        {
            _clickActions.InsertOne(action);
            return action;
        }
    }
}
