using System.Threading.Tasks;
using DatingAppAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace DatingAppAPI.Data
{
    public class AuthRepository : IAuthRepository
    {
        private readonly DataContext _dataContext;   
        public AuthRepository(DataContext dataContext)     //Inject data context
        {
            _dataContext = dataContext;
        }

        public async Task<User> Login(string userName, string password)
        {
            var user = await _dataContext.Users.FirstOrDefaultAsync(x => x.UserName == userName);
            if(user == null)
                return null;
            if(!verifyPasswordHash(password,user.PasswordHash,user.PasswordSalt))
                return null;

            return user;
        }

        public async Task<User> Register(User user, string password)
        {
            byte[] passwordHash, passwordSalt;
            createPasswordHash(password, out passwordHash, out passwordSalt);   //pass as a reference when is updated it also updated inside here as well

            user.PasswordHash = passwordHash;
            user.PasswordSalt = passwordSalt;

            await _dataContext.Users.AddAsync(user);
            await _dataContext.SaveChangesAsync();

            return user;
        }

          public async Task<bool> userExists(string userName)
        {
           if(await _dataContext.Users.AnyAsync(x=>x.UserName == userName))
                return true;
            return false;

        }

        private void createPasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {

            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));

            }
        }

        private bool verifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512(passwordSalt))
            {
                
                var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                for(int i =0;i<computedHash.Length; i++){
                    if(computedHash[i] != passwordHash[i]) return false;

                }
                
            }   
            return true; 
        }

      
    }
}