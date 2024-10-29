using System.ComponentModel.DataAnnotations;

namespace GameClubAPI.Services.Dtos
{
    public class AddEventDto
    {
        [Required]
        public string Title { get; set; }
        public string Description { get; set; }
        [Required]
        public Guid ClubId { get; set; }
        public DateTime StartDate { get; set; } = DateTime.Now;
        public DateTime? EndDate { get; set; }
    }
}
