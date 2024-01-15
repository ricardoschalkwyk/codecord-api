using codecord_api.Data;

namespace codecord_api
{
  public class UsersRepository : IUsersRepository
  {
    private readonly DataContext _context;

    public UsersRepository(DataContext context)
    {
      _context = context;
    }

    // Get all users
    public ICollection<User> GetUsers()
    {
      return _context.User.OrderBy(u => u.Id).ToList();
    }

    // Get 1 user
    public User GetUser(int? userId)
    {
      return _context.User.First(u => u.Id == userId);
    }

    // Create 1 user
    public async Task<User> AddUser(User user)
    {
      var result = await _context.User.AddAsync(user);

      await _context.SaveChangesAsync();

      return result.Entity;
    }
  }
}