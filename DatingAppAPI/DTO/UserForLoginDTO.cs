using System.ComponentModel.DataAnnotations;

namespace DatingAppAPI.DTO
{
    public class UserForLoginDTO
    {
        [Required]
        public string UserName { get; set; }
        
        [StringLength(10,MinimumLength=4,ErrorMessage="You mush specify value between 4 to 10 charaters")]
        public string Password { get; set; }
    }
}