using Microsoft.AspNetCore.Mvc;
using UserManagement.Bussiness.RepositoryInterface;
using UserManagement.Model.Team;

namespace UserManagementAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TeamUserController : ControllerBase
    {
        private readonly ITeamUserRepository _repository;

        public TeamUserController(ITeamUserRepository repository)
        {
            _repository = repository;
        }

        [HttpGet("Select")]
        public IEnumerable<TeamUser> GetTeamUser([FromQuery] int teamuserID=0,[FromQuery] int userid=0, [FromQuery] string status=null)
        {
            return _repository.Select(new TeamUser()
            {
                teamuserID = teamuserID,
                userid = userid,
                status = status
            });
        }

        [HttpPost("Insert")]
        public bool PostTeamUserInsert(
            [FromQuery] int userid,
            [FromQuery] int teamID,
            [FromQuery] int employeeID,
            [FromQuery] string status,
            [FromQuery] int createdBy)
        {
            return _repository.Insert(new TeamUser()
            {
                userid = userid,
                teamID = teamID,
                employeeID = employeeID,
                status = status,
                createdBy = createdBy
            });
        }

        [HttpPost("Update")]
        public bool PostTeamUserUpdate(
            [FromQuery] int teamuserID,
            [FromQuery] int userid,
            [FromQuery] int teamID,
            [FromQuery] int employeeID,
            [FromQuery] string status,
            [FromQuery] int updatedBy)
        {
            return _repository.Update(new TeamUser()
            {
                teamuserID = teamuserID,
                userid = userid,
                teamID = teamID,
                employeeID = employeeID,
                status = status,
                updatedBy = updatedBy
            });
        }

        [HttpPost("ChangeStatus")]
        public bool PostTeamUserChangeStatus(
            [FromQuery] int teamuserID,
            [FromQuery] string status,
            [FromQuery] int updatedBy)
        {
            return _repository.ChangeStatus(new TeamUser()
            {
                teamuserID = teamuserID,
                status = status,
                updatedBy = updatedBy
            });
        }
    }
}
