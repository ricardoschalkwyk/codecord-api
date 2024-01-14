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

    public ICollection<User> GetUsers()
    {
      return _context.User.OrderBy(u => u.Id).ToList();
    }

    public User GetUser(int? userId)
    {
      return _context.User.First(u => u.Id == userId);
    }
  }
}