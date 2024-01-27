namespace codecord_api;
public interface IUsersRepository
{
  ICollection<User> GetUsers();
  User? GetUser(int userId);
  Task<User?> AddUser(User user);
  Task<User?> UpdateUser(User user, User newUser);
  Task<User?> DeleteUser(User user);
}

