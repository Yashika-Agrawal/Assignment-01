using MongoDB.Driver;
using ClickMe.Application.Models; 
using ClickMe.Application.DatabaseSettings; 
using System.Collections.Generic;
using System.Linq;

namespace ClickMe.Application.Services 
{
    public class ClickActionService : IClickActionService
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
            _clickActions.Find(action => action.Id == id).FirstOrDefault();

        public ClickAction Create(ClickAction action)
        {
            _clickActions.InsertOne(action);
            return action;
        }
    }
}
