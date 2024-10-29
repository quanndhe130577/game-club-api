using GameClubAPI.DbContexts;
using GameClubAPI.Models;
using GameClubAPI.Services.Dtos;
using GameClubAPI.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace GameClubAPI.Services.Implements
{
    public class ClubsService : IClubsService
    {
        private readonly AppDbContext _context;
        public ClubsService(AppDbContext context)
        {
            _context = context;
        }


        /// <summary>
        /// Get all clubs
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<ClubDto>> GetClubs()
        {
            return await _context.Clubs.Select(x => new ClubDto()
            {
                Id = x.Id,
                Name = x.Name,
                Description = x.Description
            }).ToListAsync();
        }

        /// <summary>
        /// Get club by club id
        /// </summary>
        /// <param name="clubId"></param>
        /// <returns></returns>
        public async Task<ClubDto> GetClubById(Guid clubId)
        {
            var club = await _context.Clubs.FirstOrDefaultAsync(x => x.Id == clubId);
            if (club != null)
            {
                return new ClubDto()
                {
                    Id = club.Id,
                    Description = club.Description,
                    Name = club.Name
                };
            }

            return null;
        }

        /// <summary>
        /// Add new club with uique Name
        /// </summary>
        /// <param name="clubDto"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public async Task<Guid> AddClub(AddClubDto clubDto)
        {
            var club = _context.Clubs.Where(x => x.Name.ToLower() == clubDto.Name.ToLower());
            if (club.Any())
            {
                throw new Exception("Duplicated Club Name.");
            }

            var newClub = new Clubs()
            {
                Id = Guid.NewGuid(),
                Name = clubDto.Name,
                Description = clubDto.Description
            };

            _context.Clubs.Add(newClub);

            await _context.SaveChangesAsync();

            return newClub.Id;
        }

        /// <summary>
        /// Search club by club name
        /// </summary>
        /// <param name="searchText"></param>
        /// <returns></returns>
        public async Task<IEnumerable<ClubDto>> SearchClubsByName(string searchText)
        {
            var clubs = _context.Clubs.AsEnumerable().Where(x => x.Name.Contains(searchText, StringComparison.OrdinalIgnoreCase));
            return clubs.Select(x => new ClubDto()
            {
                Id = x.Id,
                Name = x.Name,
                Description = x.Description
            });
        }
    }
}
