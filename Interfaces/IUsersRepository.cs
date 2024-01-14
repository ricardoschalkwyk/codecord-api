namespace codecord_api;
public interface IUsersRepository
{
  ICollection<User> GetUsers();
  User GetUser(int userId);
}

