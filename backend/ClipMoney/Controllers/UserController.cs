using ClipMoney.BusinessLogic;
using ClipMoney.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClipMoney.Controllers
{
    [Route("api/users")]
    [ApiController]
    public class UserController: ControllerBase
    {
        private readonly UserBusinessLogic _userBusinessLogic;

        public UserController(UserBusinessLogic userBusinessLogic)
        {
            _userBusinessLogic = userBusinessLogic;
        }

        /// <summary>
        /// Get user by id in database and return the user model.
        /// </summary>
        [HttpGet("{id}")]
        public IActionResult GetUserById(int id)
        {
            var user = _userBusinessLogic.GetUserById(id);
            
            return Ok(user);
        }

        /// <summary>
        /// Edit user profile.
        /// </summary>
        [HttpPut]
        public IActionResult EditProfile(UserModel user)
        {
            var newProfile = _userBusinessLogic.EditProfile(user);

            return Ok(newProfile);
        }

    }
}
