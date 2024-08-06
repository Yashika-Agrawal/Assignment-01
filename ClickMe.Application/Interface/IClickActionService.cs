using ClickMe.Application.Models; 
using System.Collections.Generic;

namespace ClickMe.Application.Services 
{
    public interface IClickActionService
    {
        List<ClickAction> Get();
        ClickAction Get(string id);
        ClickAction Create(ClickAction action);
    }
}
