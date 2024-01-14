using Microsoft.AspNetCore.Mvc;

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
    public IActionResult FindOne(int userId)
    {
      var user = _usersService.GetUser(userId);

      return Ok(user);
    }
  }
}
