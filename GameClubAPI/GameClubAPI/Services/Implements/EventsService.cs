using GameClubAPI.DbContexts;
using GameClubAPI.Models;
using GameClubAPI.Services.Dtos;
using GameClubAPI.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace GameClubAPI.Services.Implements
{
    public class EventsService : IEventsService
    {
        private readonly AppDbContext _context;
        public EventsService(AppDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Get all event for specific club by club Id
        /// </summary>
        /// <param name="clubId"></param>
        /// <returns></returns>
        public async Task<IEnumerable<EventDto>> GetEventByClubId(Guid clubId)
        {
            return await _context.Events.Where(x => x.ClubId == clubId).Select(x => new EventDto()
            {
                Id = x.Id,
                Title = x.Title,
                Description = x.Description,
                ClubId = x.ClubId,
                StartDate = x.StartDate,
                EndDate = x.EndDate
            }).ToListAsync();
        }

        /// <summary>
        /// Add new event for a specific club by club Id
        /// </summary>
        /// <param name="clubId"></param>
        /// <param name="eventDto"></param>
        /// <returns></returns>
        public async Task<Guid> AddEvent(Guid clubId, AddEventDto eventDto)
        {
            var newEvent = new Events()
            {
                Id = Guid.NewGuid(),
                Title = eventDto.Title,
                Description = eventDto.Description,
                ClubId = clubId,
                StartDate = eventDto.StartDate,
                EndDate = eventDto.EndDate,
            };

            _context.Events.Add(newEvent);

            await _context.SaveChangesAsync();

            return newEvent.Id;
        }
    }
}
