using TrainBackendApi.Models;
using TrainBackendApi.Repository;

namespace TrainBackendApi.Services
{
    public class UserManager
    {
        private Random random = new Random();
        private TrainDbConntext dbContext;
        public static bool Updated { get; set; }

        public UserManager(TrainDbConntext dbContext)
        {
            this.dbContext = dbContext;
        }

        public User CreateUser(RegistryUser user)
        {
            User newuser = new User
            {
                Id = RandomString(12),
                Role = "basic",
                Password = BCrypt.Net.BCrypt.HashPassword(user.Password, BCrypt.Net.BCrypt.GenerateSalt()),
                UserName = user.Username
            };
            dbContext.Users.Add(newuser);
            dbContext.SaveChanges();
            return newuser;
        }
        public bool isUpdated()
        {
            return Updated;
        }

        public bool IsUsernameExist(RegistryUser user)
        {
            if (dbContext.Users.FirstOrDefault(x => x.UserName == user.Username) != null)
            {
                return true;
            }
            return false;
        }
        public User GetById(string id)
        {
            var user = dbContext.Users.FirstOrDefault(x => x.Id == id);
            if (user != null)
            {
                return user;
            }
            return null;
        }

        public bool ValaidateUser(LoginUser user, out User outuser)
        {

            var tempuser = dbContext.Users.FirstOrDefault(x => x.UserName == user.Username);
            if (tempuser != null)
            {
                outuser = tempuser;
                return BCrypt.Net.BCrypt.Verify(user.Password, tempuser.Password);
            }
            outuser = null;
            return false;

        }

        private string RandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
                .Select(s => s[random.Next(s.Length)]).ToArray());
        }
    }
}
