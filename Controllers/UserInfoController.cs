using Microsoft.AspNetCore.Mvc;
using UserManagement.Bussiness.Repository;
using UserManagement.Bussiness.RepositoryInterface;
using UserManagement.Model.User;

namespace UserManagementAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserInfoController : Controller
    {
        
        [HttpGet(Name = "GetSelect")]
        public IEnumerable<UserInfo> GetSelect([FromQuery] int userid, [FromQuery] string status )
        {
           
            IUserInfoRepository _repository = new UserInfoRepository();
           return _repository.Select(new UserInfo() { userID = userid, Status = status});

        }
    }
}
