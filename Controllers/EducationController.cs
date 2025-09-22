using Microsoft.AspNetCore.Mvc;
using UserManagement.Bussiness.RepositoryInterface;
using UserManagement.Model.User;

namespace UserManagementAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EducationController : ControllerBase
    {
        private readonly IEducationRepository _repository;

        public EducationController(IEducationRepository repository)
        {
            _repository = repository;
        }

        [HttpGet("Select")]
        public IEnumerable<Education> GetEducation([FromQuery] int educationID =0,[FromQuery] long userid = 0, [FromQuery] string status = null)
        {
            return _repository.Select(new Education()
            {
                educationID = educationID,
                userID = userid,
                status = status
            });
        }

        [HttpPost("Insert")]
        public bool PostEducationInsert(
            [FromQuery] long userID,
            [FromQuery] string instituteName,
            [FromQuery] string instituteAddress,
            [FromQuery] string board,
            [FromQuery] string courseName,
            [FromQuery] float percentage,
            [FromQuery] int startYear,
            [FromQuery] string status,
            [FromQuery] int createdBy)
        {
            return _repository.Insert(new Education()
            {
                userID = userID,
                instituteName = instituteName,
                instituteAddress = instituteAddress,
                board = board,
                courseName = courseName,
                percentage = percentage,
                startYear = startYear,
                status = status,
                createdBy = createdBy
            });
        }

        [HttpPost("Update")]
        public bool PostEducationUpdate(
            [FromQuery] int educationID,
            [FromQuery] long userID,
            [FromQuery] string instituteName,
            [FromQuery] string instituteAddress,
            [FromQuery] string board,
            [FromQuery] string courseName,
            [FromQuery] float percentage,
            [FromQuery] int startYear,
            [FromQuery] string status,
            [FromQuery] int updatedBy)
        {
            return _repository.Update(new Education()
            {
                educationID = educationID,
                userID = userID,
                instituteName = instituteName,
                instituteAddress = instituteAddress,
                board = board,
                courseName = courseName,
                percentage = percentage,
                startYear = startYear,
                status = status,
                updatedBy = updatedBy
            });
        }
        [HttpPost("ChangeStatus")]
        public bool PostEducationChangeStatus(
            [FromQuery] int educationID,
            [FromQuery] string status,
            [FromQuery] int updatedBy)
        {
            return _repository.ChangeStatus(new Education()
            {
                educationID = educationID,
                status = status,
                updatedBy = updatedBy
            });
        }
    }
}
