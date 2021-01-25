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
    public class AccountController : ControllerBase
    {
        private readonly AccountBusinessLogic _accountBusinessLogic;

        public AccountController(AccountBusinessLogic accountBusinessLogic)
        {
            _accountBusinessLogic = accountBusinessLogic;
        }

        [HttpPost]
        public IActionResult PostMoney(PostUserMoneyModel user)
        {
            var result = _accountBusinessLogic.PostMoney(user);
            return Ok(result);
        }

        [HttpGet("{userId}")]
        public IActionResult GetAccountByUserId(int userId)
        {
            var result = _accountBusinessLogic.GetAccountByUserId(userId);
            return Ok(result);
        }

        [HttpPost("overdraft/{accountId}")]
        public IActionResult PostOverdraft(int accountId)
        {
            var result = _accountBusinessLogic.PostOverdraft(accountId);

            return Ok(result);
        }

    }
}
