using Microsoft.AspNetCore.Authorization;

namespace UserManagement.Models
{
    public class User
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Address { get; set; }
    }
}
