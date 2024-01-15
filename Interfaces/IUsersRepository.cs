namespace codecord_api;
public interface IUsersRepository
{
  ICollection<User> GetUsers();
  User GetUser(int? userId);
  Task<User> AddUser(User user);
}

