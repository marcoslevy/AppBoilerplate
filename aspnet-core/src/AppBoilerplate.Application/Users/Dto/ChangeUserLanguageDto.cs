using System.ComponentModel.DataAnnotations;

namespace AppBoilerplate.Users.Dto
{
    public class ChangeUserLanguageDto
    {
        [Required]
        public string LanguageName { get; set; }
    }
}