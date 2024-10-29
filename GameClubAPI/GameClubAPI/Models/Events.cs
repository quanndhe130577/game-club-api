using System.ComponentModel.DataAnnotations;

namespace GameClubAPI.Models
{
    public class Events
    {
        public Guid Id { get; set; }
        [Required]
        public string Title { get; set; }
        public string Description { get; set; }

        public Guid ClubId { get; set; }

        [Required]
        public DateTime StartDate { get; set; } = DateTime.Now;
        public DateTime? EndDate { get; set; }
        public virtual Clubs Club { get; set; }
    }
}
