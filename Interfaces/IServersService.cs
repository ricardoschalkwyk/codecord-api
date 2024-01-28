﻿namespace codecord_api;

public interface IServersService
{
  ICollection<Server> GetServers();
  Server? GetServer(int serverId);
  Task<Server?> AddServer(Server server);
  Task<Server?> UpdateServer(Server server, Server newServer);
  Task<Server?> DeleteServer(Server server);
}
