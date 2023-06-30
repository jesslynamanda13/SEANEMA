using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SEANEMAAPI.Helper;
using SEANEMAAPI.Model;
using System;
namespace SEANEMAAPI.Controllers
{
    [EnableCors]
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private UserHelper userHelper;
        public UserController(UserHelper userHelper)
        {
            this.userHelper = userHelper;
        }
        [HttpPost]
        [Produces("application/json")]
        [ProducesResponseType(typeof(object), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        public IActionResult Post([FromBody] User user)
        {
            try
            {
                var objJSON = userHelper.Register(user);
                return new OkObjectResult(objJSON);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
