using System.ComponentModel.DataAnnotations;

namespace GameClubAPI.Services.Dtos
{
    public class AddClubDto
    {
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
