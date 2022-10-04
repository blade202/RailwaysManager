using TrainBackendApi.Models;
using TrainBackendApi.Repository;

namespace TrainBackendApi.Services
{
    public class UserManager
    {
        private Random random = new Random();
        private TrainDbConntext dbContext;

        public UserManager(TrainDbConntext dbContext)
        {
            this.dbContext = dbContext;
        }

        public User CreateUser(User user)
        {
            user.Role = "basic";
            user.Id = RandomString(12);
            user.Password = BCrypt.Net.BCrypt.HashPassword(user.Password, BCrypt.Net.BCrypt.GenerateSalt());
            dbContext.Users.Add(user);
            dbContext.SaveChanges();
            return user;
        }

        public bool IsUsernameExist(User user)
        {
            if (dbContext.Users.FirstOrDefault(x => x.UserName == user.UserName) != null)
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

        public bool ValaidateUser(User user, out User outuser)
        {

            var tempuser = dbContext.Users.FirstOrDefault(x => x.UserName == user.UserName);
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
