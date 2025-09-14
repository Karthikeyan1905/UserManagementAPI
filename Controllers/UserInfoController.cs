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
        private readonly IUserInfoRepository _repository;

        public UserInfoController(IUserInfoRepository repository)
        {
            _repository = repository;
        }



        [HttpGet(Name = "GetSelect")]
        public IEnumerable<UserInfo> GetSelect([FromQuery] int userid, [FromQuery] string status )
        {           
           
           return _repository.Select(new UserInfo() { userID = userid, Status = status});

        }
    }
}
