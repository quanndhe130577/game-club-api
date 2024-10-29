using System.ComponentModel.DataAnnotations;

namespace GameClubAPI.Models
{
    public class Clubs
    {
        public Guid Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
