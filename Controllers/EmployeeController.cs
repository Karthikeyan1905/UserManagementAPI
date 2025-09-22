using Microsoft.AspNetCore.Mvc;
using UserManagement.Bussiness.RepositoryInterface;
using UserManagement.Model.Department;

namespace UserManagementAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeRepository _repository;

        public EmployeeController(IEmployeeRepository repository)
        {
            _repository = repository;
        }

        [HttpGet("Select")]
        public IEnumerable<Employee> GetEmployee([FromQuery] long employeeID=0,[FromQuery] long userid =0, [FromQuery] string status=null)
        {
            return _repository.Select(new Employee()
            {
                employeeID = employeeID,
                userID =userid,
                status = status
            });
        }

        [HttpPost("Insert")]
        public bool PostEmployeeInsert(
            [FromQuery] long userID,
            [FromQuery] long deptID,
            [FromQuery] long designationID,
            [FromQuery] string status,
            [FromQuery] long createdBy)
        {
            return _repository.Insert(new Employee()
            {
                userID = userID,
                deptID = deptID,
                designationID = designationID,
                status = status,
                createdBy = createdBy
            });
        }

        [HttpPost("Update")]
        public bool PostEmployeeUpdate(
            [FromQuery] long employeeID,
            [FromQuery] long userID,
            [FromQuery] long deptID,
            [FromQuery] long designationID,
            [FromQuery] string status,
            [FromQuery] long updatedBy)
        {
            return _repository.Update(new Employee()
            {
                employeeID = employeeID,
                userID = userID,
                deptID = deptID,
                designationID = designationID,
                status = status,
                updatedBy = updatedBy
            });
        }

        [HttpPost("ChangeStatus")]
        public bool PostEmployeeChangeStatus(
            [FromQuery] long employeeID,
            [FromQuery] string status,
            [FromQuery] long updatedBy)
        {
            return _repository.ChangeStatus(new Employee()
            {
                employeeID = employeeID,
                status = status,
                updatedBy = updatedBy
            });
        }
    }
}
