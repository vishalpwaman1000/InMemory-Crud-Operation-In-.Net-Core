using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InMemoryCrudOperation.Model
{
    public class GetUserDetailsRequest
    {
        public int PageNumber { get; set; }
        public int NumberOfRecordPerPage { get; set; }
    }

    public class GetUserDetailsResponse
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
        public List<UserDetails> data { get; set;}
    }
}
