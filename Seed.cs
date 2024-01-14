// using codecord_api.Data;
// using codecord_api.Models;

// namespace codecord_api
// {
//     public class Seed
//     {
//         private readonly DataContext dataContext;
//         public Seed(DataContext context)
//         {
//             this.dataContext = context;
//         }
//         public void SeedDataContext()
//         {
//             if (!dataContext.User.Any())
//             {
//                 var User = new List<User>()
//                 {
//                     new User()
//                     {
//                         User = new User()
//                         {
//                             UserName = "Jaco Vermel",
//                         },
//                     },

//                 };
//                 dataContext.User.AddRange();
//                 dataContext.SaveChanges();
//             }
//         }
//     }
// }