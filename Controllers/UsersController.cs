using Microsoft.AspNetCore.Mvc;
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

        var addedUser = await _usersService.AddUser(user);

        return Ok(addedUser);
      }
      catch (Exception)
      {
        return StatusCode(StatusCodes.Status500InternalServerError,
        "Error Creating new user record");
      }
    }
  }
}
