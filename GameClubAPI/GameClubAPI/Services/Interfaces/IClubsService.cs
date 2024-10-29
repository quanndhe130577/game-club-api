using GameClubAPI.Services.Dtos;

namespace GameClubAPI.Services.Interfaces
{
    public interface IClubsService
    {
        /// <summary>
        /// Get all clubss
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<ClubDto>> GetClubs();

        /// <summary>
        /// Get club by club id
        /// </summary>
        /// <param name="clubId"></param>
        /// <returns></returns>
        Task<ClubDto> GetClubById(Guid clubId);

        /// <summary>
        /// Add new club
        /// </summary>
        /// <param name="clubDto"></param>
        /// <returns></returns>
        Task<Guid> AddClub(AddClubDto clubDto);

        /// <summary>
        /// Search club by name
        /// </summary>
        /// <param name="searchText"></param>
        /// <returns></returns>
        Task<IEnumerable<ClubDto>> SearchClubsByName(string searchText);
    }
}
