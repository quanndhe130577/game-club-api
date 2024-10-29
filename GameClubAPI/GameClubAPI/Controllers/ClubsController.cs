using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GameClubAPI.DbContexts;
using GameClubAPI.Models;
using GameClubAPI.Services.Interfaces;
using GameClubAPI.Services.Dtos;
using GameClubAPI.Services.Implements;

namespace GameClubAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ClubsController : ControllerBase
    {
        private readonly IClubsService _clubService;
        public readonly IEventsService _eventService;

        public ClubsController(IClubsService clubsService, IEventsService eventsService)
        {
            _clubService = clubsService;
            _eventService = eventsService;
        }

        #region Clubs
        /// <summary>
        /// Get all clubs
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ClubDto>>> GetClubs()
        {
            var result = await _clubService.GetClubs();
            if (!result.Any())
            {
                return NotFound();
            }

            return new ActionResult<IEnumerable<ClubDto>>(result);
        }

        /// <summary>
        /// Get club by the club Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<ClubDto>> GetClubById(Guid id)
        {
            var result = await _clubService.GetClubById(id);
            if (result == null)
            {
                return NotFound();
            }

            return new ActionResult<ClubDto>(result);
        }

        /// <summary>
        /// Add new club
        /// </summary>
        /// <param name="clubDto"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<Clubs>> CreateClub(AddClubDto clubDto)
        {
            try
            {
                var clubId = await _clubService.AddClub(clubDto);
                return CreatedAtAction("CreateClub", new { id = clubId });
            }
            catch (Exception ex)
            {
                if (ex.Message == "Duplicated Club Name.")
                    return StatusCode(409, new { message = "Duplicate club name" });
                else return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Filter clubs by club name
        /// </summary>
        /// <param name="search"></param>
        /// <returns></returns>
        [HttpGet("search={search}")]
        public async Task<ActionResult<IEnumerable<ClubDto>>> FilterClubsByName(string search)
        {
            var result = await _clubService.SearchClubsByName(search);
            if (!result.Any())
            {
                return NotFound();
            }

            return new ActionResult<IEnumerable<ClubDto>>(result);
        }

        #endregion

        #region Events
        /// <summary>
        /// Get all events for specific Club by club Id
        /// </summary>
        /// <param name="clubId"></param>
        /// <returns></returns>
        [HttpGet("{clubId}/events")]
        public async Task<ActionResult<IEnumerable<EventDto>>> GetEventsByClubId(Guid clubId)
        {
            var events = await _eventService.GetEventByClubId(clubId);
            if (!events.Any())
            {
                return NotFound();
            }
            return new ActionResult<IEnumerable<EventDto>>(events);
        }

        /// <summary>
        /// Add an event into a club
        /// </summary>
        /// <param name="clubId"></param>
        /// <param name="addEventDto"></param>
        /// <returns></returns>
        [HttpPost("{clubId}/events")]
        public async Task<ActionResult<IEnumerable<EventDto>>> AddEvent(Guid clubId, AddEventDto addEventDto)
        {
            try
            {
                var eventId = await _eventService.AddEvent(clubId, addEventDto);
                return CreatedAtAction("AddEvent", new { id = eventId });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        #endregion
    }
}
