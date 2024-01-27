namespace codecord_api;

public class UsersService : IUsersService
{
  private readonly IUsersRepository _usersRepository;

  public UsersService(IUsersRepository usersRepository)
  {
    this._usersRepository = usersRepository;
  }

  public ICollection<User> GetUsers()
  {
    var users = _usersRepository.GetUsers();

    return users;
  }

  public User? GetUser(int userId)
  {
    return _usersRepository.GetUser(userId);
  }
  public Task<User?> AddUser(User user)
  {
    var newUser = _usersRepository.AddUser(user);

    return newUser;
  }

  public Task<User?> UpdateUser(User user, User newUser)
  {
    return _usersRepository.UpdateUser(user, newUser);
  }

  public Task<User?> DeleteUser(User user)
  {
    // var findUser = _usersRepository.GetUser(userId);

    // if (findUser == null)
    // {
    //   return default;
    // }

    return _usersRepository.DeleteUser(user);
  }
}
