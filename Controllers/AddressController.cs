using Microsoft.AspNetCore.Mvc;
using UserManagement.Bussiness.RepositoryInterface;
using UserManagement.Model.User;

namespace UserManagementAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AddressController : ControllerBase
    {
        private readonly IAddressRepository _repository;

        public AddressController(IAddressRepository repository)
        {
            _repository = repository;
        }


        [HttpGet("Select")]
        public IEnumerable<Address> GetAddress([FromQuery] long userid = 0,[FromQuery] long addressid = 0, [FromQuery] string status=null)
        {
            return _repository.Select(new Address()
            {
                userid = userid ,
                addressid = addressid,
                status = status
            });
        }

        [HttpPost("Insert")]
        public bool PostAddressInsert(
            [FromQuery] long userid,
            [FromQuery] string addressType,
            [FromQuery] string permDoorNo,
            [FromQuery] string street,
            [FromQuery] string town,
            [FromQuery] string district,
            [FromQuery] string state,
            [FromQuery] string country,
            [FromQuery] long pincode,
            [FromQuery] string status,
            [FromQuery] int createdBy)
        {
            return _repository.Insert(new Address()
            {
                userid = userid,
                addressType = addressType,
                permDoorNo = permDoorNo,
                street = street,
                town = town,
                district = district,
                state = state,
                country = country,
                pincode = pincode,
                status = status,
                createdBy = createdBy
            });
        }

        
        [HttpPost("Update")]
        public bool PostAddressUpdate(
            [FromQuery] long userid,
            [FromQuery] long addressid,
            [FromQuery] string addressType,
            [FromQuery] string permDoorNo,
            [FromQuery] string street,
            [FromQuery] string town,
            [FromQuery] string district,
            [FromQuery] string state,
            [FromQuery] string country,
            [FromQuery] long pincode,
            [FromQuery] string status,
            [FromQuery] int createdBy)
        {
            return _repository.Update(new Address()
            {
                userid = userid,
                addressid = addressid,
                addressType = addressType,
                permDoorNo = permDoorNo,
                street = street,
                town = town,
                district = district,
                state = state,
                country = country,
                pincode = pincode,
                status = status,
                createdBy = createdBy
            });
        }

        [HttpPost("ChangeStatus")]
        public bool PostAddressChangeStatus(
            [FromQuery] long addressid,
            [FromQuery] string status,
            [FromQuery] int updatedBy)
        {
            return _repository.ChangeStatus(new Address()
            {
                addressid = addressid,
                status = status,
                updatedBy = updatedBy
            });
        }
    }
}
