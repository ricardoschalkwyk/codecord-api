namespace codecord_api;

public class ServersService : IServersService
{
  private readonly IServersRepository _serversRepository;

  public ServersService(IServersRepository serversRepository)
  {
    this._serversRepository = serversRepository;
  }

  public ICollection<Server> GetServers()
  {
    var servers = _serversRepository.GetServers();

    return servers;
  }

  public Server? GetServer(int serverId)
  {
    return _serversRepository.GetServer(serverId);
  }

  public Task<Server?> AddServer(Server server)
  {
    var newServer = _serversRepository.AddServer(server);

    return newServer;
  }

  public Task<Server?> JoinServer(Server server, int userId)
  {
    return _serversRepository.JoinServer(server, userId);
  }
  public Task<Server?> UpdateServer(Server server, Server newServer)
  {
    return _serversRepository.UpdateServer(server, newServer);
  }

  public Task<Server?> DeleteServer(Server server)
  {
    return _serversRepository.DeleteServer(server);
  }
}
