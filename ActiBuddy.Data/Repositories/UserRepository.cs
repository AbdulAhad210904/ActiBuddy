using ActiBuddy.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ActiBuddy.Data.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly DatabaseContext _context;

        public UserRepository(DatabaseContext context)
        {
            //context is a parameter that is passed to the constructor
            _context = context;
        }

        public User GetUserById(int id)
        {
            //Find the user by id
            return _context.Users.Find(id);
        }

        public IEnumerable<User> GetAllUsers()
        {
            //Return all users
            return _context.Users.ToList();
        }

        public void AddUser(User user)
        {
            //Add the user to the database
            user.PasswordHash = HashPassword(user.PasswordHash); // Hashing the password before saving
            _context.Users.Add(user);
            _context.SaveChanges();
        }

        public void UpdateUser(User user)
        {
            //Update the user in the database
            _context.Entry(user).State = System.Data.Entity.EntityState.Modified;
            _context.SaveChanges();
        }

        public void DeleteUser(int id)
        {
            //Find the user by id and remove it from the database
            var user = _context.Users.Find(id);
            if (user != null)
            {
                _context.Users.Remove(user);
                _context.SaveChanges();
            }
        }
        // method for validating the user credentials
        public User ValidateUser(string username, string password)
        {
            string hashedPassword = HashPassword(password);
            return _context.Users.FirstOrDefault(u => u.Username == username && u.PasswordHash == hashedPassword);
        }

        // method for hashing the password using SHA256
        public string HashPassword(string password)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }
    }
}
