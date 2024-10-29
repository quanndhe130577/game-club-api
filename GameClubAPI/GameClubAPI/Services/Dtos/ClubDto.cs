using System.ComponentModel.DataAnnotations;

namespace GameClubAPI.Services.Dtos
{
    public class ClubDto
    {
        public Guid Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
