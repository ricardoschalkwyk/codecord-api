using Microsoft.AspNetCore.Mvc;

namespace codecord_api;

public class UsersService
{
  private readonly IUsersRepository _usersRepository;

  public UsersService(IUsersRepository usersRepository) {
    this._usersRepository = usersRepository;
  }

  public ICollection<User> GetUsers() {
    var users = _usersRepository.GetUsers();

    return users;
  }

  public User GetUser(int userId) {
    var user = _usersRepository.GetUser(userId);

    return user;
  }
}
