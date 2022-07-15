using InMemoryCrudOperation.Context;
using InMemoryCrudOperation.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InMemoryCrudOperation.DataAccessLayer
{
    public class CrudOperationDL : ICrudOperationDL
    {
        private readonly UserDbContext _userDbContext;

        public CrudOperationDL(UserDbContext userDbContext)
        {
            _userDbContext = userDbContext;
        }

        public async Task<GetUserDetailsResponse> GetUserDetails(GetUserDetailsRequest request)
        {
            GetUserDetailsResponse response = new GetUserDetailsResponse();
            response.Message = "Fetch Data Successfully";
            response.IsSuccess = true;

            try
            {
                response.data = new List<UserDetails>();
                int Offset = (request.PageNumber - 1)*request.NumberOfRecordPerPage;
                //response.data = _userDbContext.UserDetails.ToList();
                response.data = _userDbContext.UserDetails.Skip(Offset).Take(request.NumberOfRecordPerPage).ToList();
                if (response.data.Count == 0)
                {
                    response.Message = "No Data Found";
                }
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = "Exception Occurs : " + ex.Message;
            }

            return response;
        }

        public async Task<UserDetailsResponse> InsertUserDetails(UserDetails request)
        {
            UserDetailsResponse response = new UserDetailsResponse();
            response.Message = "Data Inserted Successfully";
            response.IsSuccess = true;

            try
            {
                request.InsertionDate = DateTime.Now;
                await _userDbContext.UserDetails.AddAsync(request);
                var Result = _userDbContext.SaveChangesAsync();
                if(Result.Result != 1)
                {
                    response.IsSuccess = false;
                    response.Message = "Something Went Wrong";
                }

            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = "Exception Occurs : " + ex.Message;
            }

            return response;
        }

        public async Task<UserDetailsResponse> UpdateUserDetails(UserDetails request)
        {
            UserDetailsResponse response = new UserDetailsResponse();
            response.Message = "Data Inserted Successfully";
            response.IsSuccess = true;

            try
            {

                var Result = await _userDbContext.UserDetails.FindAsync(request.UserID);
                if (Result == null)
                {
                    response.IsSuccess = false;
                    response.Message = "Something Went Wrong";
                }

                Result.UserName = request.UserName;
                Result.InsertionDate = DateTime.Now;
                Result.Age = request.Age;

                var UpdateResult = await _userDbContext.SaveChangesAsync();
                if (UpdateResult > 0)
                {
                    response.IsSuccess = false;
                    response.Message = "Something Went Wrong";
                }
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = "Exception Occurs : " + ex.Message;
            }

            return response;
        }
    }
}
