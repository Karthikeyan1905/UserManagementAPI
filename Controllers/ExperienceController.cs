using Microsoft.AspNetCore.Mvc;
using UserManagement.Bussiness.RepositoryInterface;
using UserManagement.Model.User;

namespace UserManagementAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ExperienceController : ControllerBase
    {
        private readonly IExperienceRepository _repository;

        public ExperienceController(IExperienceRepository repository)
        {
            _repository = repository;
        }


        [HttpGet("Select")]
        public IEnumerable<Experience> GetExperience([FromQuery] int experienceID=0,[FromQuery] long userid=0, [FromQuery] string status=null)
        {
            return _repository.Select(new Experience()
            {
                experienceID = experienceID,
                userID = userid,
                status = status
            });
        }

        [HttpPost("Insert")]
        public bool PostExperienceInsert(
            [FromQuery] long userID,
            [FromQuery] string companyName,
            [FromQuery] string companyAddress,
            [FromQuery] int workingExperienceInMonths,
            [FromQuery] string contactPersonName,
            [FromQuery] string contactPersonDesignation,
            [FromQuery] long contactPersonPhone,
            [FromQuery] string contactPersonEmail,
            [FromQuery] string status,
            [FromQuery] int createdBy)
        {
            return _repository.Insert(new Experience()
            {
                userID = userID,
                companyName = companyName,
                companyAddress = companyAddress,
                workingExperienceInMonths = workingExperienceInMonths,
                contactPersonName = contactPersonName,
                contactPersonDesignation = contactPersonDesignation,
                contactPersonPhone = contactPersonPhone,
                contactPersonEmail = contactPersonEmail,
                status = status,
                createdBy = createdBy
            });
        }

        [HttpPost("Update")]    
        public bool PostExperienceUpdate(
            [FromQuery] int experienceID,
            [FromQuery] long userID,
            [FromQuery] string companyName,
            [FromQuery] string companyAddress,
            [FromQuery] int workingExperienceInMonths,
            [FromQuery] string contactPersonName,
            [FromQuery] string contactPersonDesignation,
            [FromQuery] long contactPersonPhone,
            [FromQuery] string contactPersonEmail,
            [FromQuery] string status,
            [FromQuery] int updatedBy)
        {
            return _repository.Update(new Experience()
            {
                experienceID = experienceID,
                userID = userID,
                companyName = companyName,
                companyAddress = companyAddress,
                workingExperienceInMonths = workingExperienceInMonths,
                contactPersonName = contactPersonName,
                contactPersonDesignation = contactPersonDesignation,
                contactPersonPhone = contactPersonPhone,
                contactPersonEmail = contactPersonEmail,
                status = status,
                updatedBy = updatedBy
            });
        }

        [HttpPost("ChangeStatus")]
        public bool PostExperienceChangeStatus(
            [FromQuery] int experienceID,
            [FromQuery] string status,
            [FromQuery] int updatedBy)
        {
            return _repository.ChangeStatus(new Experience()
            {
                experienceID = experienceID,
                status = status,
                updatedBy = updatedBy
            });
        }
    }
}
