﻿namespace codecord_api;
public interface IUsersService
{
  ICollection<User> GetUsers();
  User? GetUser(int? userId);
  Task<User>? AddUser(User user);
  Task<User>? UpdateUser(int? userId, User user);
  Task<User>? DeleteUser(int? userId);
}
