using ClipMoney.BusinessLogic;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClipMoney.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovementController: ControllerBase
    {
        private readonly MovementBusinessLogic _movementBusinessLogic;

        public MovementController(MovementBusinessLogic movementBusinessLogic)
        {
            _movementBusinessLogic = movementBusinessLogic;
        }

        [HttpGet("{accountId}")]
        public IActionResult GetMovementsByAccountId(int accountId)
        {
            var result = _movementBusinessLogic.GetMovementsByAccountId(accountId);
            return Ok(result);
        }
    }
}
