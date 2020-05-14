using System.ComponentModel.DataAnnotations;

namespace DatingAppAPI.DTO
{
    public class UserForRegisterDTO
    {
        [Required]
        public string UserName { get; set; }
        [Required]
        [StringLength(10,MinimumLength=4,ErrorMessage="You mush specify value between 4 to 10 charaters")]
        public string Password { get; set; }
    }
}