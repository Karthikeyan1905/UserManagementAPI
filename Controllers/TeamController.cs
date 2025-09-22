using Microsoft.AspNetCore.Mvc;
using UserManagement.Bussiness.RepositoryInterface;
using UserManagement.Model.Team;

namespace UserManagementAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TeamController : ControllerBase
    {
        private readonly ITeamRepository _repository;

        public TeamController(ITeamRepository repository)
        {
            _repository = repository;
        }

        [HttpGet("Select")]
        public IEnumerable<Team> GetTeam([FromQuery] int teamID=0, [FromQuery] string status=null)
        {
            return _repository.Select(new Team()
            {
                teamID = teamID,
                status = status
            });
        }

        [HttpPost("Insert")]
        public bool PostTeamInsert(
            [FromQuery] string teamName,
            [FromQuery] string teamCode,
            [FromQuery] string status,
            [FromQuery] int createdBy)
        {
            return _repository.Insert(new Team()
            {
                teamName = teamName,
                teamCode = teamCode,
                status = status,
                createdBy = createdBy
            });
        }

        [HttpPost("Update")]
        public bool PostTeamUpdate(
            [FromQuery] int teamID,
            [FromQuery] string teamName,
            [FromQuery] string teamCode,
            [FromQuery] string status,
            [FromQuery] int updatedBy)
        {
            return _repository.Update(new Team()
            {
                teamID = teamID,
                teamName = teamName,
                teamCode = teamCode,
                status = status,
                updatedBy = updatedBy
            });
        }

        [HttpPost("ChangeStatus")]
        public bool PostTeamChangeStatus(
            [FromQuery] int teamID,
            [FromQuery] string status,
            [FromQuery] int updatedBy)
        {
            return _repository.ChangeStatus(new Team()
            {
                teamID = teamID,
                status = status,
                updatedBy = updatedBy
            });
        }
    }
}
