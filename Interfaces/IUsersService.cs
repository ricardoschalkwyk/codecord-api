namespace codecord_api;
public interface IUsersService
{
  ICollection<User> GetUsers();
  User GetUser(int? userId);
  Task<User> AddUser(User user);
}
