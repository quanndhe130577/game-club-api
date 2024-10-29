using GameClubAPI.Services.Dtos;

namespace GameClubAPI.Services.Interfaces
{
    public interface IEventsService
    {
        /// <summary>
        /// Get all events for a specific club by club id
        /// </summary>
        /// <param name="clubId"></param>
        /// <returns></returns>
        Task<IEnumerable<EventDto>> GetEventByClubId(Guid clubId);

        /// <summary>
        /// Add new Event into a specific club by club Id
        /// </summary>
        /// <param name="clubId"></param>
        /// <param name="eventDto"></param>
        /// <returns></returns>
        Task<Guid> AddEvent(Guid clubId, AddEventDto eventDto);
    }
}
