using Microsoft.AspNetCore.Mvc;
using UserManagement.Bussiness.Repository;
using UserManagement.Bussiness.RepositoryInterface;
using UserManagement.Model.User;

namespace UserManagementAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserInfoController : ControllerBase
    {
        private readonly IUserInfoRepository _repository;
        public UserInfoController(IUserInfoRepository repository)
        {
            _repository = repository;
        }


        [HttpGet("Select")]
        public IEnumerable<UserInfo> GetSelect([FromQuery] int userid = 0, [FromQuery] string status=null)
        {
            return _repository.Select(new UserInfo() { userID = userid, status = status });
        }

        
        [HttpPost("Insert")]

        public bool PostInsert(
            [FromQuery] string userName,
            [FromQuery] string email,
            [FromQuery] string fatherName,
            [FromQuery] string motherName,
            [FromQuery] long aadhaarNumber,
            [FromQuery] string panCardNo,
            [FromQuery] string PassportNo,
            [FromQuery] string status,
            [FromQuery] int createdby)
        {

            return _repository.Insert(new UserInfo()
            {
                userName = userName,
                email = email,
                fatherName = fatherName,
                motherName = motherName,
                aadhaarNumber = aadhaarNumber,
                panCardNo = panCardNo,
                passportNo = PassportNo,
                status = status,
                createdBy = createdby
            });

        }


        
        [HttpPost("Update")]
        public bool PostUpdate([FromQuery] int userid,
            [FromQuery] string userName,
            [FromQuery] string email,
            [FromQuery] string fatherName,
            [FromQuery] string motherName,
            [FromQuery] long aadhaarNumber,
            [FromQuery] string panCardNo,
            [FromQuery] string PassportNo,
            [FromQuery] string status,
            [FromQuery] int updatedBy)
        {


            return _repository.Update(new UserInfo()
            {
                userID = userid,
                userName = userName,
                email = email,
                fatherName = fatherName,
                motherName = motherName,
                aadhaarNumber = aadhaarNumber,
                panCardNo = panCardNo,
                passportNo = PassportNo,
                status = status,
                updatedBy = updatedBy
            });

        }

        
        [HttpPost("ChangeStatus")]
        public bool PostChangeStatus([FromQuery] int userid,
        [FromQuery] string status,
        [FromQuery] int updatedBy)
        {
            return _repository.ChangeStatus(new UserInfo()
            {
                userID = userid,
                status = status,
                updatedBy = updatedBy
            });
        }


    }
}
