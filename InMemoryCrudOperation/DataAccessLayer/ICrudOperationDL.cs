using InMemoryCrudOperation.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InMemoryCrudOperation.DataAccessLayer
{
    public interface ICrudOperationDL
    {
        public Task<UserDetailsResponse> InsertUserDetails(UserDetails request);
        public Task<GetUserDetailsResponse> GetUserDetails(GetUserDetailsRequest request);
    }
}
