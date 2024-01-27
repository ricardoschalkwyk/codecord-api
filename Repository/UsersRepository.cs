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
    public User? GetUser(int userId)
    {
      return _context.User.FirstOrDefault(u => u.Id == userId);
    }

    // Create 1 user
    public async Task<User?> AddUser(User user)
    {
      var result = await _context.User.AddAsync(user);

      await _context.SaveChangesAsync();

      return result.Entity;
    }

    public async Task<User?> UpdateUser(User user, User newUser)
    {
      user.PhoneNumber = newUser.PhoneNumber;
      user.DisplayName = newUser.DisplayName;
      user.UpdatedAt = DateTime.UtcNow;
      user.UserName = newUser.UserName;
      user.Email = newUser.Email;
      user.Name = newUser.Name;

      await _context.SaveChangesAsync();

      return user;
    }

    public async Task<User?> DeleteUser(User user)
    {
      user.IsDeleted = true;

      await _context.SaveChangesAsync();

      return user;
    }
  }
}