using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClipMoney.BusinessLogic;
using ClipMoney.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ClipMoney.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepositController : ControllerBase
    {
        private readonly DepositBusinessLogic _depositBusinessLogic;

        public DepositController(DepositBusinessLogic depositBusinessLogic)
        {
            _depositBusinessLogic = depositBusinessLogic;
        }

        [HttpPost]
        public IActionResult DepositMoney(DepositModel deposit)
        {
            var result = _depositBusinessLogic.DepositMoney(deposit);
            return Ok(result);
        }
    }
}
