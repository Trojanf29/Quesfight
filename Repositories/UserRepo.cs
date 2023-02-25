using System.Security.Cryptography;
using System.Text;

using QuesFight.Data;
using QuesFight.Models.UserDTOs;

namespace QuesFight.Repositories
{
    public class UserRepo : IRepository
    {
        //using mail as identifier

        private readonly Context _context;

        public UserRepo(Context context)
        {
            _context = context;
        }

        public void Save() => _context.SaveChanges();






        public UserDTO? Find(string id)
        {
            User? user = _context.Users.Find(id);
            return user == null ? null : Map(user);
        }

        public IEnumerable<UserDTO> GetAll() => _context.Users.Select(user => new UserDTO
        {
            Id = user.Id,
            UserName = user.UserName,
            Email = user.Email,
            Avatar = user.Avatar,
            Bio = user.Bio,
            Point = user.Point
        });

        public User? GetByEmail(string email) => _context.Users.FirstOrDefault(u => u.Email == email);

        public User? CheckLogin(LoginDTO dto)
        {
            if (dto.Email == null || dto.Password == null)
                return null;
            User? user = _context.Users.FirstOrDefault(ele => ele.Email == dto.Email);

            string pw = HashPassword(dto.Password);
            if (user == null || pw != user.Password)
                return null;
            return user;
        }

        public void UpdateRefreshToken(User user, string token)
        {
            user.Token = token;
            user.UpdateAt = DateTime.Now;
        }

        public bool CheckRefreshToken(User user, string token) => user.Token == token;

        public bool ChangePassword(ChangePasswordDTO dto, string? mail) {
            if (mail == null || String.IsNullOrEmpty(dto.CurrentPassword) || String.IsNullOrEmpty(dto.NewPassword))
                return false;
            User? user = GetByEmail(mail);
            if (user == null || HashPassword(dto.CurrentPassword) != user.Password)
                return false;
            user.Password = HashPassword(dto.NewPassword);
            return true;
        }






        /*
         * CreateAdmin necessary?
         */
        public bool Create(RegisterDTO dto) {
            if (_context.Users.Any(u => u.Email == dto.Email))
                return false;

            User user = new()
            {
                Id = Guid.NewGuid().ToString(),
                UserName = dto.UserName,
                Email = dto.Email,
                Password = HashPassword(dto.Password),
                Role = "USER",
                CreatedAt = DateTime.Now,
                UpdateAt = DateTime.Now
            };
            _context.Users.Add(user);
            return true;
        }

        public bool UpdateBio(string bio, string? mail)
        {
            if (mail == null)
                return false;
            User? user = GetByEmail(mail);
            if (user == null)
                return false;
            user.Bio = bio;
            return true;
        }






        private static UserDTO Map(User user) {
            return new UserDTO
            {
                Id = user.Id,
                UserName = user.UserName,
                Email = user.Email,
                Avatar = user.Avatar,
                Bio = user.Bio,
                Point = user.Point
            };
        }

        private static string HashPassword(string password) {
            using SHA256 sha256Hash = SHA256.Create();
            byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(password));
            StringBuilder builder = new();
            for (int i = 0; i < bytes.Length; i++)
                builder.Append(bytes[i].ToString("x2"));
            return builder.ToString();
        }
    }
}
