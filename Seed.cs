using Bogus;
using codecord_api.Data;

namespace codecord_api
{
  public class Seed
  {
    private readonly DataContext dataContext;
    public Seed(DataContext context)
    {
      this.dataContext = context;
    }
    public void SeedDataContext()
    {
      var userFaker = new Faker<User>()
      .RuleFor(u => u.DisplayName, f => f.Internet.UserName())
      .RuleFor(u => u.UserName, f => f.Internet.UserName())
      .RuleFor(u => u.Email, f => f.Internet.Email())
      .RuleFor(u => u.Name, f => f.Name.FirstName())
      .RuleFor(u => u.PhoneNumber, f => f.Random.Number(1000000000, 1999999999).ToString())
      .RuleFor(u => u.UserTag, f => f.Random.Number(1000, 9999))
      .RuleFor(u => u.CreatedAt, f => DateTime.UtcNow)
      .RuleFor(u => u.UpdatedAt, f => DateTime.UtcNow);


      var users = userFaker.UseSeed(1024).Generate(1500);

      dataContext.User.AddRange(users);
      dataContext.SaveChanges();

      // *************************************************

      var serverFaker = new Faker<Server>()
      .RuleFor(u => u.Name, f => f.Name.FirstName())
      .RuleFor(u => u.CreatedAt, f => DateTime.UtcNow)
      .RuleFor(u => u.UpdatedAt, f => DateTime.UtcNow);


      var servers = serverFaker.UseSeed(1024).Generate(50);

      dataContext.Server.AddRange(servers);
      dataContext.SaveChanges();
    }
  }
}