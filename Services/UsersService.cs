using Microsoft.AspNetCore.Mvc;

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

  public User? GetUser(int? userId)
  {

    var user = _usersRepository.GetUser(userId);

    return user;
  }
  public Task<User>? AddUser(User user)
  {
    var newUser = _usersRepository.AddUser(user);

    return newUser;
  }

  public Task<User>? UpdateUser(int? userId, User user)
  {
    var findUser = _usersRepository.GetUser(userId);

    if (findUser == null)
    {
      return default;
    }

    var updatedUser = _usersRepository.UpdateUser(userId, user);

    return updatedUser;
  }

  public Task<User>? DeleteUser(int? userId)
  {
    var findUser = _usersRepository.GetUser(userId);

    if (findUser == null)
    {
      return default;
    }

    var user = _usersRepository.DeleteUser(userId);

    return user;
  }
}
