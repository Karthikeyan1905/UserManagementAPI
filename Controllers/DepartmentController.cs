using Microsoft.AspNetCore.Mvc;
using UserManagement.Bussiness.RepositoryInterface;
using UserManagement.Model.Department;

namespace UserManagementAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DepartmentController : ControllerBase
    {
        private readonly IDepartmentRepository _repository;

        public DepartmentController(IDepartmentRepository repository)
        {
            _repository = repository;
        }

        [HttpGet("Select")]
        public IEnumerable<Department> GetSelect([FromQuery] int deptID=0, [FromQuery] string status = null)
        {
            return _repository.Select(new Department() { deptID = deptID, status = status });
        }

        [HttpPost("Insert")]
        public bool PostDepartmentInsert(
            [FromQuery] string deptName,
            [FromQuery] string deptShortName,
            [FromQuery] string status,
            [FromQuery] int createdBy)
        {
            return _repository.Insert(new Department()
            {
                deptName = deptName,
                deptShortName = deptShortName,
                status = status,
                createdBy = createdBy
            });
        }

        [HttpPost("Update")]
        public bool PostDepartmentUpdate(
            [FromQuery] int deptID,
            [FromQuery] string deptName,
            [FromQuery] string deptShortName,
            [FromQuery] string status,
            [FromQuery] int updatedBy)
        {
            return _repository.Update(new Department()
            {
                deptID = deptID,
                deptName = deptName,
                deptShortName = deptShortName,
                status = status,
                updatedBy = updatedBy
            });
        }

        [HttpPost("ChangeStatus")]
        public bool PostDepartmentChangeStatus(
            [FromQuery] int deptID,
            [FromQuery] string status,
            [FromQuery] int updatedBy)
        {
            return _repository.ChangeStatus(new Department()
            {
                deptID = deptID,
                status = status,
                updatedBy = updatedBy
            });
        }
    }
}
