using Microsoft.AspNetCore.Mvc;
using UserManagement.Bussiness.RepositoryInterface;
using UserManagement.Model.History;

namespace UserManagementAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LoginHistoryController : ControllerBase
    {
        private readonly ILoginHistoryRepository _repository;

        public LoginHistoryController(ILoginHistoryRepository repository)
        {
            _repository = repository;
        }

        [HttpGet("Select")]
        public IEnumerable<LoginHistory> GetLoginHistory([FromQuery] long loginID=0,[FromQuery] long userid=0, [FromQuery] string status=null)
        {
            return _repository.Select(new LoginHistory()
            {
                loginID = loginID,
                userID = userid,
                status = status
            });
        }
        [HttpPost("Insert")]
        public bool PostLoginHistoryInsert(
            [FromQuery] long userID,
            [FromQuery] string status,
            [FromQuery] DateTime loginTime,
            [FromQuery] DateTime? loginOut,
            [FromQuery] int createdBy)
        {
            return _repository.Insert(new LoginHistory()
            {
                userID = userID,
                status = status,
                loginTime = loginTime,
                loginOut = loginOut,
                createdBy = createdBy
            });
        }

        [HttpPost("Update")]
        public bool PostLoginHistoryUpdate(
            [FromQuery] long loginID,
            [FromQuery] long userID,
            [FromQuery] string status,
            [FromQuery] DateTime loginTime,
            [FromQuery] DateTime? loginOut,
            [FromQuery] int updatedBy)
        {
            return _repository.Update(new LoginHistory()
            {
                loginID = loginID,
                userID = userID,
                status = status,
                loginTime = loginTime,
                loginOut = loginOut,
                updatedBy = updatedBy
            });
        }

        [HttpPost("ChangeStatus")]
        public bool PostLoginHistoryChangeStatus(
            [FromQuery] long loginID,
            [FromQuery] string status,
            [FromQuery] int updatedBy)
        {
            return _repository.ChangeStatus(new LoginHistory()
            {
                loginID = loginID,
                status = status,
                updatedBy = updatedBy
            });
        }
    }
}
