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
      return _context.User.Where(u => u.IsDeleted == false).OrderBy(u => u.Id).ToList();
    }

    // Get 1 user
    public User? GetUser(int? userId)
    {
      var user = _context.User.FirstOrDefault(u => u.Id == userId);

      return user;
    }

    // Create 1 user
    public async Task<User>? AddUser(User user)
    {
      var result = await _context.User.AddAsync(user);

      await _context.SaveChangesAsync();

      return result.Entity;
    }

    public async Task<User>? UpdateUser(int? userId, User user)
    {
      var result = GetUser(userId);

      if (result == null)
      {
        return default;
      }

      result.PhoneNumber = user.PhoneNumber;
      result.DisplayName = user.DisplayName;
      result.UpdatedAt = DateTime.UtcNow;
      result.UserName = user.UserName;
      result.Email = user.Email;
      result.Name = user.Name;

      await _context.SaveChangesAsync();

      return result;
    }

    public async Task<User>? DeleteUser(int? userId)
    {
      var result = GetUser(userId);

      result.IsDeleted = true;

      await _context.SaveChangesAsync();

      return result;
    }
  }
}