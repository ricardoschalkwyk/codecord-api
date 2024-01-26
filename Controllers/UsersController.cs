using System.Text.RegularExpressions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Any;
using ServiceStack.Text;

namespace codecord_api
{
  [ApiController]
  [Route("[controller]")]
  public class UsersController : ControllerBase
  {

    private readonly IUsersService _usersService;

    public UsersController(IUsersService usersService)
    {
      this._usersService = usersService;
    }

    [HttpGet()]
    [ProducesResponseType(200, Type = typeof(IEnumerable<User>))]
    public IActionResult FindAll()
    {
      var users = _usersService.GetUsers();

      return Ok(users);
    }

    [HttpGet("{userId}")]
    public IActionResult FindOne(int? userId)
    {
      if (!userId.HasValue)
      {
        return BadRequest();
      }

      var user = _usersService.GetUser(userId);

      return Ok(user);
    }

    [HttpPost()]
    public async Task<ActionResult<User>> AddUser([FromBody] User user)
    {
      try
      {
        if (user == null)
          return BadRequest();


        user.CreatedAt = DateTime.UtcNow;
        user.UpdatedAt = DateTime.UtcNow;

        user.PhoneNumber = Regex.Replace(user.PhoneNumber ?? "", "[^0-9]", "");


        var addedUser = await _usersService.AddUser(user);

        return Ok(addedUser);
      }
      catch (Exception)
      {
        return StatusCode(StatusCodes.Status500InternalServerError,
        "Error Creating new user record");
      }
    }

    [HttpPut("{userId}")]
    public async Task<ActionResult<User>> UpdateUser(int? userId, [FromBody] User user)
    {
      try
      {
        if (!userId.HasValue)
        {
          return BadRequest();
        }

        var userToUpdate = await _usersService.UpdateUser(userId, user);

        if (userToUpdate == null)
        {
          return BadRequest();
        }

        return Ok(userToUpdate);
      }
      catch (Exception)
      {
        return StatusCode(StatusCodes.Status500InternalServerError,
        "Error Creating new user record");
      }
    }

    [HttpDelete("{userId}")]
    public async Task<ActionResult<User>> DeleteUser(int? userId)
    {
      if (!userId.HasValue)
      {
        return BadRequest();
      }

      var user = await _usersService.DeleteUser(userId);

      if (user == null)
      {
        return BadRequest();
      }

      return Ok(user);
    }

  }

}
