using Microsoft.AspNetCore.Mvc;


namespace codecord_api
{
  [ApiController]
  [Route("[controller]")]
  public class ServersController : ControllerBase
  {

    private readonly IServersService _serversService;

    public ServersController(IServersService serversService)
    {
      this._serversService = serversService;
    }

    [HttpGet()]
    [ProducesResponseType(200, Type = typeof(IEnumerable<Server>))]
    public IActionResult FindAll()
    {
      var servers = _serversService.GetServers();

      return Ok(servers);
    }

    [HttpGet("{serverId}")]
    public IActionResult FindOne([FromRoute] int serverId)
    {
      var server = _serversService.GetServer(serverId);

      return Ok(server);
    }

    [HttpPost()]
    public async Task<ActionResult<Server>> AddServer([FromBody] Server server)
    {
      try
      {
        if (server == null)
          return BadRequest();

        server.Name = Faker.Name.First();
        server.CreatedAt = DateTime.UtcNow;
        server.UpdatedAt = DateTime.UtcNow;

        var addedServer = await _serversService.AddServer(server);

        return Ok(addedServer);
      }
      catch (Exception)
      {
        return StatusCode(StatusCodes.Status500InternalServerError,
        "Error Creating new server record");
      }
    }

    [HttpPut("join/{serverId}/{userId}")]
    public async Task<ActionResult<Server>> JoinServer([FromRoute] int serverId, [FromRoute] int userId)
    {
      try
      {
        var findServer = _serversService.GetServer(serverId);

        if (findServer == null)
        {
          return NotFound("Can't find server");
        }

        var addUserToServer = await _serversService.JoinServer(findServer, userId);

        if (addUserToServer == null)
        {
          return BadRequest();
        }

        return Ok(addUserToServer);
      }
      catch (Exception)
      {
        return StatusCode(StatusCodes.Status500InternalServerError,
        "Error Creating new user record");
      }
    }

    [HttpPut("{serverId}")]
    public async Task<ActionResult<Server>> UpdateServer([FromRoute] int serverId, [FromBody] Server server)
    {
      try
      {
        var findServer = _serversService.GetServer(serverId);

        if (findServer == null)
        {
          return NotFound();
        }

        var serverToUpdate = await _serversService.UpdateServer(findServer, server);


        if (serverToUpdate == null)
        {
          return BadRequest();
        }

        return Ok(serverToUpdate);
      }
      catch (Exception)
      {
        return StatusCode(StatusCodes.Status500InternalServerError,
        "Error Creating new user record");
      }
    }

    [HttpDelete("{serverId}")]
    public async Task<ActionResult<Server>> DeleteUser([FromRoute] int serverId)
    {
      var server = _serversService.GetServer(serverId);

      if (server == null)
      {
        return NotFound();
      }

      var deletedServer = await _serversService.DeleteServer(server);

      if (deletedServer == null)
      {
        return BadRequest();
      }

      return Ok(deletedServer);
    }
  }
}
