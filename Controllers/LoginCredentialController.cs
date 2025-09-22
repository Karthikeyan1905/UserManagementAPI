using Microsoft.AspNetCore.Mvc;
using UserManagement.Bussiness.RepositoryInterface;
using UserManagement.Model.User;

namespace UserManagementAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LoginCredentialController : ControllerBase
    {
        private readonly ILoginCredentialRepository _repository;

        public LoginCredentialController(ILoginCredentialRepository repository)
        {
            _repository = repository;
        }

        [HttpGet("Select")]
        public IEnumerable<LoginCredential> GetLoginCredential([FromQuery] int loginCredentialID = 0,[FromQuery] long userid=0, [FromQuery] string status=null)
        {
            return _repository.Select(new LoginCredential()
            {
                loginCredentialid = loginCredentialID,
                userID = userid,
                status = status
            });
        }

        [HttpPost("Insert")]
        public bool PostLoginCredentialInsert(
            [FromQuery] long userID,
            [FromQuery] string loginUsername,
            [FromQuery] string loginPassword,
            [FromQuery] string status,
            [FromQuery] int createdBy)
        {
            return _repository.Insert(new LoginCredential()
            {
                userID = userID,
                loginUsername = loginUsername,
                login_Password = loginPassword,
                status = status,
                createdBy = createdBy
            });
        }

        [HttpPost("Update")]
        public bool PostLoginCredentialUpdate(
            [FromQuery] int loginCredentialID,
            [FromQuery] long userID,
            [FromQuery] string loginUsername,
            [FromQuery] string loginPassword,
            [FromQuery] string status,
            [FromQuery] int updatedBy)
        {
            return _repository.Update(new LoginCredential()
            {
                loginCredentialid = loginCredentialID,
                userID = userID,
                loginUsername = loginUsername,
                login_Password = loginPassword,
                status = status,
                updatedBy = updatedBy
            });
        }

        [HttpPost("ChangeStatus")]
        public bool PostLoginCredentialChangeStatus(
            [FromQuery] int loginCredentialID,
            [FromQuery] string status,
            [FromQuery] int updatedBy)
        {
            return _repository.ChangeStatus(new LoginCredential()
            {
                loginCredentialid = loginCredentialID,
                status = status,
                updatedBy = updatedBy
            });
        }
    }
}
