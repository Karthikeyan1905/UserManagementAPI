using Microsoft.AspNetCore.Mvc;
using UserManagement.Bussiness.RepositoryInterface;
using UserManagement.Model.Department;

namespace UserManagementAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DesignationController : ControllerBase
    {
        private readonly IDesignationRepository _repository;

        public DesignationController(IDesignationRepository repository)
        {
            _repository = repository;
        }

        [HttpGet("Select")]
        public IEnumerable<Designation> GetSelect([FromQuery] int designationID = 0, [FromQuery] string status = null)
        {
            return _repository.Select(new Designation() { designationID = designationID, status = status });
        }

        [HttpPost("Insert")]
        public bool PostDesignationInsert(
            [FromQuery] string designationName,
            [FromQuery] string designationShortName,
            [FromQuery] string status,
            [FromQuery] int createdBy)
        {
            return _repository.Insert(new Designation()
            {
                designationName = designationName,
                designationShortName = designationShortName,
                status = status,
                createdBy = createdBy
            });
        }

        [HttpPost("Update")]
        public bool PostDesignationUpdate(
            [FromQuery] int designationID,
            [FromQuery] string designationName,
            [FromQuery] string designationShortName,
            [FromQuery] string status,
            [FromQuery] int updatedBy)
        {
            return _repository.Update(new Designation()
            {
                designationID = designationID,
                designationName = designationName,
                designationShortName = designationShortName,
                status = status,
                updatedBy = updatedBy
            });
        }

        [HttpPost("ChangeStatus")]
        public bool PostDesignationChangeStatus(
            [FromQuery] int designationID,
            [FromQuery] string status,
            [FromQuery] int updatedBy)
        {
            return _repository.ChangeStatus(new Designation()
            {
                designationID = designationID,
                status = status,
                updatedBy = updatedBy
            });
        }
    }
}
