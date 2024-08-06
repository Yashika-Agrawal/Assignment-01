using ClickMeApi.Models;
using System.Collections.Generic;

namespace ClickMeApi.Services
{
    public interface IClickActionService
    {
        List<ClickAction> Get();
        ClickAction Get(string id);
        ClickAction Create(ClickAction action);
    }
}
