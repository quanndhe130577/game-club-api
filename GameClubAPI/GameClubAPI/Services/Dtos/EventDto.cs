using System.ComponentModel.DataAnnotations;

namespace GameClubAPI.Services.Dtos
{
    public class EventDto
    {
        public Guid Id { get; set; }
        [Required]
        public string Title { get; set; }
        public string Description { get; set; }

        public Guid ClubId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
    }
}
