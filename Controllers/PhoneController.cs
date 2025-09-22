using Microsoft.AspNetCore.Mvc;
using UserManagement.Bussiness.RepositoryInterface;
using UserManagement.Model.User;

namespace UserManagementAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PhoneController : ControllerBase
    {
        private readonly IPhoneRepository _repository;

        public PhoneController(IPhoneRepository repository)
        {
            _repository = repository;
        }

        [HttpGet("Select")]
        public IEnumerable<Phone> GetPhone([FromQuery] int phoneID=0,[FromQuery] int userid=0, [FromQuery] string status=null)
        {
            return _repository.Select(new Phone()
            {
                phoneID = phoneID,
                userID = userid,
                status = status
            });
        }

        [HttpPost("Insert")]
        public bool PostPhoneInsert(
            [FromQuery] long userID,
            [FromQuery] long phoneNumber,
            [FromQuery] string phoneType,
            [FromQuery] string status,
            [FromQuery] int createdBy)
        {
            return _repository.Insert(new Phone()
            {
                userID = userID,
                phoneNumber = phoneNumber,
                phoneType = phoneType,
                status = status,
                createdBy = createdBy
            });
        }

        [HttpPost("Update")]
        public bool PostPhoneUpdate(
            [FromQuery] int phoneID,
            [FromQuery] long userID,
            [FromQuery] long phoneNumber,
            [FromQuery] string phoneType,
            [FromQuery] string status,
            [FromQuery] int updatedBy)
        {
            return _repository.Update(new Phone()
            {
                phoneID = phoneID,
                userID = userID,
                phoneNumber = phoneNumber,
                phoneType = phoneType,
                status = status,
                updatedBy = updatedBy
            });
        }

        [HttpPost("changeStatus")]
        public bool PostPhoneChangeStatus(
            [FromQuery] int phoneID,
            [FromQuery] string status,
            [FromQuery] int updatedBy)
        {
            return _repository.ChangeStatus(new Phone()
            {
                phoneID = phoneID,
                status = status,
                updatedBy = updatedBy
            });
        }
    }
}
