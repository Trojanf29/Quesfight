namespace QuesFight.Models.UserDTOs
{
    public class UserDTO
    {
        public string Id { get; set; } = null!;
        public string UserName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string? Avatar { get; set; }
        public string? Bio { get; set; }
        public int Point { get; set; }
    }
}
