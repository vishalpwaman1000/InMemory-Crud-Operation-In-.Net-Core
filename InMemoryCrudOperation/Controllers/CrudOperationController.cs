using InMemoryCrudOperation.DataAccessLayer;
using InMemoryCrudOperation.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InMemoryCrudOperation.Controllers
{
    [Route("api/[controller]/[Action]")]
    [ApiController]
    public class CrudOperationController : ControllerBase
    {

        private readonly ICrudOperationDL _crudOperationDL;

        public CrudOperationController(ICrudOperationDL crudOperationDL)
        {
            _crudOperationDL = crudOperationDL;
        }

        [HttpPost]
        public async Task<IActionResult> InsertUserDetails(UserDetails request)
        {
            UserDetailsResponse response = new UserDetailsResponse();
            try
            {

                response = await _crudOperationDL.InsertUserDetails(request);

            }
            catch(Exception ex)
            {
                response.IsSuccess = false;
                response.Message = "Exception Message : " + ex.Message;
            }

            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> GetUserDetails(GetUserDetailsRequest request)
        {
            GetUserDetailsResponse response = new GetUserDetailsResponse();
            try
            {

                response = await _crudOperationDL.GetUserDetails(request);

            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = "Exception Message : " + ex.Message;
            }

            return Ok(response);
        }
    }
}
