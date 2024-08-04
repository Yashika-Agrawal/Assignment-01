using ClickMeApi.Models;
using ClickMeApi.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace ClickMeApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClickActionController : ControllerBase
    {
        private readonly IClickActionService _clickActionService;

        public ClickActionController(IClickActionService clickActionService)
        {
            _clickActionService = clickActionService;
        }

        [HttpPost]
        public ActionResult<ClickAction> PostClickAction([FromBody] ClickAction clickAction)
        {
            if (clickAction == null)
            {
                return BadRequest("ClickAction object is null");
            }

            clickAction.Id = null;
            clickAction.UtcDateTime = DateTime.UtcNow;

            _clickActionService.Create(clickAction);
            return CreatedAtAction(nameof(GetClickAction), new { id = clickAction.Id }, clickAction);
        }

        [HttpGet]
        public ActionResult<List<ClickAction>> GetClickActions()
        {
            return _clickActionService.Get();
        }

        [HttpGet("{id:length(24)}", Name = "GetClickAction")]
        public ActionResult<ClickAction> GetClickAction(string id)
        {
            var clickAction = _clickActionService.Get(id);

            if (clickAction == null)
            {
                return NotFound();
            }

            return clickAction;
        }
    }
}
