using codecord_api.Data;
using Microsoft.AspNetCore.Http.HttpResults;

namespace codecord_api
{
  public class ServersRepository : IServersRepository
  {
    private readonly DataContext _context;

    public ServersRepository(DataContext context)
    {
      _context = context;
    }

    // Get all servers
    public ICollection<Server> GetServers()
    {
      return _context.Server.Where(s => s.IsDeleted == false).OrderBy(s => s.Id).ToList();
    }

    // Get 1 server
    public Server? GetServer(int serverId)
    {
      return _context.Server.FirstOrDefault(s => s.Id == serverId);
    }

    // Create 1 server
    public async Task<Server?> AddServer(Server server)
    {
      var result = await _context.Server.AddAsync(server);

      await _context.SaveChangesAsync();

      return result.Entity;
    }

    // Join a server based on the user thats logged in
    public async Task<Server?> JoinServer(Server server, int userId)
    {
      var user = _context.User.FirstOrDefault(u => u.Id == userId);

      var serverCheck = _context.User.FirstOrDefault(s => s.Id == server.Id);

      server.Users.Add(user);

      await _context.SaveChangesAsync();

      return server;
    }

    public async Task<Server?> UpdateServer(Server server, Server newServer)
    {
      server.Name = newServer.Name;
      server.UpdatedAt = DateTime.UtcNow;

      await _context.SaveChangesAsync();

      return server;
    }

    public async Task<Server?> DeleteServer(Server server)
    {
      server.IsDeleted = true;

      await _context.SaveChangesAsync();

      return server;
    }
  }
}
